using Akokina.Services;
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
    public partial class LastMovementsPage : ContentPage
    {
        public LastMovementsPage()
        {
            this.BindingContext = new ViewModel.LastMovementsViewModel(
                ServiceLocator.Current.GetInstance<INavigationService>(),
                ServiceLocator.Current.GetInstance<IDataService>());

            InitializeComponent();
        }
    }
}
