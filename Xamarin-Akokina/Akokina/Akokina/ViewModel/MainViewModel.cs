using Akokina.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akokina.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        readonly INavigationService _navigationService;

        public MainViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        #region Command OpenSettings

        private RelayCommand _openSettingsCommand;

        /// <summary>
        /// Gets the OpenSettingsCommand.
        /// </summary>
        public RelayCommand OpenSettingsCommand
        {
            get
            {
                return _openSettingsCommand
                    ?? (_openSettingsCommand = new RelayCommand(
                    () =>
                    {
                        _navigationService.NavigateTo(Constants.SettingsPageKey);
                    }));
            }
        }

        #endregion


        #region Command OpenLastMovements

        private RelayCommand _openLastMovementsCommand;

        /// <summary>
        /// Gets the OpenLastMovements command.
        /// </summary>
        public RelayCommand OpenLastMovementsCommand
        {
            get
            {
                return _openLastMovementsCommand
                    ?? (_openLastMovementsCommand = new RelayCommand(
                    () =>
                    {
                        this.ExecuteOpenLastMovementsCommand();
                    },
                    () => true));
            }
        }

        private void ExecuteOpenLastMovementsCommand()
        {
            if (!this.OpenLastMovementsCommand.CanExecute(null))
            {
                return;
            }

            _navigationService.NavigateTo(Constants.LastMovementsPageKey);
        }

        #endregion

        public override void Cleanup()
        {
            base.Cleanup();
        }
    }
}
