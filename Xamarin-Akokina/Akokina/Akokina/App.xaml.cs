using Akokina.Infrastructure;
using Akokina.Services;
using Akokina.ViewModel;
using GalaSoft.MvvmLight.Ioc;
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
            MainPage mainPage = new MainPage();
            var initPage = new View.BaseNavigationPage(mainPage);
            NavigationService navigationService = ConfigureNavigationService(initPage);
            SimpleIoc.Default.Register<INavigationService>(() => navigationService);

            MainPage = initPage;

            // Check Empty Settings
            if (Helpers.Settings.IsNullOrEmpty())
            {
                navigationService.NavigateTo(Constants.SettingsPageKey);
            }
        }

        private NavigationService ConfigureNavigationService(NavigationPage navigationPage)
        {
            var service = new NavigationService(navigationPage);

            service.Map(Constants.MainPageKey, typeof(MainPage));
            service.Map(Constants.SettingsPageKey, typeof(View.SettingsPage));
            service.Map(Constants.LastMovementsPageKey, typeof(View.LastMovementsPage));

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
