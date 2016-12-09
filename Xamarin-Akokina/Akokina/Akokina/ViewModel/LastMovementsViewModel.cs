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
    public class LastMovementsViewModel : ViewModelBase
    {
        readonly IDataService _dataService = null;
        readonly INavigationService _navigationService = null;
        const int maxMovementsToDownload = 20;

        public LastMovementsViewModel(INavigationService navigationService, IDataService dataService)
        {
            _navigationService = navigationService;
            _dataService = dataService;
            Initialize();
        }

        void Initialize()
        {
            this.LoadLocalDataCommand.Execute(null);
        }

        public string Title
        {
            get { return "Últimas Entradas"; }
        }

        #region Property IsBusy

        /// <summary>
        /// The <see cref="IsBusy" /> property's name.
        /// </summary>
        public const string IsBusyPropertyName = "IsBusy";

        private bool _isBusy = false;

        /// <summary>
        /// Sets and gets the IsBusy property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }
            set
            {
                if (_isBusy == value)
                {
                    return;
                }
                _isBusy = value;
                RaisePropertyChanged(IsBusyPropertyName);
            }
        }

        #endregion

        #region Property DataSource

        /// <summary>
        /// The <see cref="DataSource" /> property's name.
        /// </summary>
        public const string DataSourcePropertyName = "DataSource";

        private IList<MovementListItemViewModel> _dataSource = null;

        /// <summary>
        /// Sets and gets the DataSource property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public IList<MovementListItemViewModel> DataSource
        {
            get
            {
                return _dataSource;
            }
            set
            {
                if (_dataSource == value)
                {
                    return;
                }
                _dataSource = value;
                RaisePropertyChanged(DataSourcePropertyName);
            }
        }

        #endregion

        #region Command LoadLocalData

        private RelayCommand _loadLocalDataCommand;

        /// <summary>
        /// Gets the LoadLocalData command.
        /// </summary>
        public RelayCommand LoadLocalDataCommand
        {
            get
            {
                return _loadLocalDataCommand
                    ?? (_loadLocalDataCommand = new RelayCommand(
                    () =>
                    {
                        this.ExecuteLoadLocalDataCommand();
                    },
                    () => true));
            }
        }

        private void ExecuteLoadLocalDataCommand()
        {
            if (!this.LoadLocalDataCommand.CanExecute(null))
            {
                return;
            }

            this.DataSource = _dataService.GetMovementsFromLocal()
                .Select(model => MovementListItemViewModel.Create(model))
                .ToList();
        }

        #endregion

        #region Command Synchronize

        private RelayCommand _synchronizeCommand;

        /// <summary>
        /// Gets the Synchronize command.
        /// </summary>
        public RelayCommand SynchronizeCommand
        {
            get
            {
                return _synchronizeCommand
                    ?? (_synchronizeCommand = new RelayCommand(
                    () =>
                    {
                        this.ExecuteSynchronizeCommand();
                    },
                    () => true));
            }
        }

        private void ExecuteSynchronizeCommand()
        {
            if (!this.SynchronizeCommand.CanExecute(null))
            {
                return;
            }

            if (_dataService.SynchronizeMovements(maxMovementsToDownload))
            {
                this.LoadLocalDataCommand.Execute(null);
            }
        }

        #endregion

    }
}
