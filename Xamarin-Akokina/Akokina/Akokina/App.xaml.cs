using Akokina.Services;
using Akokina.ViewModel;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Akokina
{
    public partial class App : Application
    {
        public App()
        {
            if (!ServiceLocator.IsLocationProviderSet)
            {
                ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            }

            InitializeComponent();

            // Configure Services 
            var dataService = new DataService();
            SimpleIoc.Default.Register<IDataService>(() => dataService);

            // Configure Navigation Service
            Services.NavigationService navigationService = ConfigureNavigationService();
            SimpleIoc.Default.Register<INavigationService>(() => navigationService);

            MainPage mainPage = new MainPage();
            var initPage = new View.BaseNavigationPage(mainPage);
            navigationService.Initialize(initPage);

            MainPage = initPage;

            // Check Empty Settings
            if (Helpers.Settings.IsNullOrEmpty())
            {
                navigationService.NavigateTo(Constants.SettingsPageKey);
            }
        }

        private Services.NavigationService ConfigureNavigationService()
        {
            var service = new Services.NavigationService();

            service.Configure(Constants.MainPageKey, typeof(MainPage));
            service.Configure(Constants.SettingsPageKey, typeof(View.SettingsPage));
            service.Configure(Constants.LastMovementsPageKey, typeof(View.LastMovementsPage));

            return service;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
