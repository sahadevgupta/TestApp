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
           
                CurrentLocation = await Geolocation.GetLastKnownLocationAsync();

                MapSpan mapSpan = MapSpan.FromCenterAndRadius(new Position(CurrentLocation.Latitude, CurrentLocation.Longitude), Distance.FromKilometers(0.444));
                map.MoveToRegion(mapSpan);

           


        }
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

        }
    }
}