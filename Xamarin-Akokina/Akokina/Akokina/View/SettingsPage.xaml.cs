using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Akokina.View
{
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            this.BindingContext = new ViewModel.SettingsViewModel(
                ServiceLocator.Current.GetInstance<INavigationService>());
            InitializeComponent();
        }
    }
}
