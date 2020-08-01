using Prism;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace TestApp.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            Xamarin.FormsMaps.Init("zzuUbJ3IbJ2QJKeKEdKF~PFhXSl6RPy-Om8S1MXA1LA~AtkN9bxKsQn8Z6siyKqoPPDc089MG_Oa1jRaQ_8az3nle2C3rlzIkuYU0v3J6MeW");
            Windows.Services.Maps.MapService.ServiceToken = "zzuUbJ3IbJ2QJKeKEdKF~PFhXSl6RPy-Om8S1MXA1LA~AtkN9bxKsQn8Z6siyKqoPPDc089MG_Oa1jRaQ_8az3nle2C3rlzIkuYU0v3J6MeW";
            LoadApplication(new TestApp.App(new UwpInitializer()));
        }
    }

    public class UwpInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Register any platform specific implementations
        }
    }
}
