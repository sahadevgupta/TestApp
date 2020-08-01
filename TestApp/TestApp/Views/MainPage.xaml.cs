using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace TestApp.Views
{
    public partial class MainPage : ContentPage
    {
        MainPageViewModel _viewModel;
        public MainPage()
        {
            InitializeComponent();
            _viewModel = BindingContext as MainPageViewModel;
        }

        public Location CurrentLocation { get; private set; }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            GetCurrentLocation();
        }
        private async void GetCurrentLocation()
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
                    CurrentLocation = await Geolocation.GetLastKnownLocationAsync();
                    if (CurrentLocation == null)
                    {
                        return;
                    }
                    MapSpan mapSpan = MapSpan.FromCenterAndRadius(new Position(CurrentLocation.Latitude, CurrentLocation.Longitude), Distance.FromKilometers(0.444));
                    map.MoveToRegion(mapSpan);
                }
                catch (Exception)
                {

                    CurrentLocation = await Geolocation.GetLocationAsync();
                    MapSpan mapSpan = MapSpan.FromCenterAndRadius(new Position(CurrentLocation.Latitude, CurrentLocation.Longitude), Distance.FromKilometers(0.444));
                    map.MoveToRegion(mapSpan);
                }
                finally
                {

                }


            }
            else
                await DisplayAlert("Error!!", "Kindly Enable Location from your settings to use this feature", "OK");


        }
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

        }
    }
}