using LocationFInderApp.Services;
using LocationFInderApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LocationFInderApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
            //MainPage = new Location();
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
