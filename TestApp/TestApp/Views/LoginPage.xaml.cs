using TestApp.ViewModels;
using Xamarin.Forms;

namespace TestApp.Views
{
    public partial class LoginPage : ContentPage
    {
        LoginPageViewModel _viewModel;
        public LoginPage()
        {
            InitializeComponent();
            _viewModel = BindingContext as LoginPageViewModel;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }
        private async void Login_Tapped(object sender, System.EventArgs e)
        {
            var view = (Grid)sender;
            view.Opacity = 0;
            await view.FadeTo(1, 250);

            await _viewModel.Login();
            view.Opacity = 1;
        }
    }
}
