using Akokina.ViewModel;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Akokina
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            this.BindingContext = new MainViewModel(SimpleIoc.Default.GetInstance<INavigationService>());
            InitializeComponent();
        }
    }
}
