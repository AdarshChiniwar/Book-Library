using App1.Services;
using App1.Views;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            Application.Current.UserAppTheme = OSAppTheme.Light;
            DependencyService.Register<MockDataStore>();
            MainPage = new NavigationPage(new HomePage()); ;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
