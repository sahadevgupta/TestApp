using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Models;
using Xamarin.Essentials;
using Xamarin.Forms.Maps;

namespace TestApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public UserInfo User { get; private set; }


        private Location _currentLocation;
        public Location CurrentLocation
        {
            get { return _currentLocation; }
            set { SetProperty(ref _currentLocation, value); }
        }
        private ObservableCollection<LocationModel> _locations = new ObservableCollection<LocationModel>();
        public ObservableCollection<LocationModel> locations
        {
            get { return _locations; }
            set { SetProperty(ref _locations, value); }
        }
        public DelegateCommand AddPinCommand { get; set; }

      
        public MainPageViewModel(INavigationService navigationService,IDialogService dialogService)
            : base(navigationService)
        {
            Title = "Map Page";

            AddPinCommand = new DelegateCommand(() =>
            {
                dialogService.ShowDialog("AddLocationDialog", CloseDialogCallback);
            });

        }

        private async void CloseDialogCallback(IDialogResult obj)
        {
            var address = obj.Parameters.GetValue<string>("pin");
            try
            {
                var locations = await Geocoding.GetLocationsAsync(address);
                var pinlocation = locations?.FirstOrDefault();
                if (pinlocation !=null)
                {
                    LocationModel location = new LocationModel
                    {
                        position = new Position(double.Parse(pinlocation.Latitude.ToString(CultureInfo.InvariantCulture)), double.Parse(pinlocation.Longitude.ToString(CultureInfo.InvariantCulture))),
                        Title = "New Pin",
                        Description = address,
                       
                    };
                    this.locations.Add(location);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private async Task LoadData()
        {
            var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
            if (status != PermissionStatus.Granted)
            {
                status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
            }

            if (status == PermissionStatus.Granted)
            {
                try
                {
                    if (string.IsNullOrEmpty(User.Address))
                    {
                        CurrentLocation = await Geolocation.GetLocationAsync();
                    }
                    else
                    {
                        var locations = await Geocoding.GetLocationsAsync(User.Address);
                        CurrentLocation = locations?.FirstOrDefault();
                        if (CurrentLocation == null)
                        {
                            CurrentLocation = await Geolocation.GetLocationAsync();
                        }
                    }
                }
                catch (Exception)
                {

                    CurrentLocation = await Geolocation.GetLocationAsync();
                }
               

                
            }

        }
        public  override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);
            User = parameters.GetValue<UserInfo>("user");
            Xamarin.Forms.Device.BeginInvokeOnMainThread(async() =>
            {
                await LoadData();
            });
          
        }

        
    }

    public class LocationModel : BindableBase
    {
        private Position _position;
        public Position position
        {
            get { return _position; }
            set { SetProperty(ref _position, value); }
        }

        public string Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
    }
}
