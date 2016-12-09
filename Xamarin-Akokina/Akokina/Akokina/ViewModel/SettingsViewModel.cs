using Akokina.Helpers;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akokina.ViewModel
{
    public class SettingsViewModel : ViewModelBase
    {
        readonly INavigationService _navigationService = null;
        public SettingsViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            Initialize();
        }

        void Initialize()
        {
            IsBusy = false;

            this.UserId = Settings.UserId;
            this.UserName = Settings.UserName;
            this.UserFullName = Settings.UserFullName;
            this.UserInitials = Settings.UserInitials;
            this.WebServerUri = Settings.WebServerUri;
        }

        public string Title
        {
            get { return "Configuración"; }
        }

        #region Property UserId

        /// <summary>
        /// The <see cref="UserId" /> property's name.
        /// </summary>
        public const string UserIdPropertyName = "UserId";

        private int _userId = 0;

        /// <summary>
        /// Sets and gets the UserId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int UserId
        {
            get
            {
                return _userId;
            }
            set
            {
                if (_userId == value)
                {
                    return;
                }
                _userId = value;
                RaisePropertyChanged(UserIdPropertyName);
                OnSettingsPropertyChanged();
            }
        }

        #endregion

        #region Property UserName

        /// <summary>
        /// The <see cref="UserName" /> property's name.
        /// </summary>
        public const string UserNamePropertyName = "UserName";

        private string _userName = null;

        /// <summary>
        /// Sets and gets the UserName property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                if (_userName == value)
                {
                    return;
                }
                _userName = value;
                RaisePropertyChanged(UserNamePropertyName);
            }
        }

        #endregion

        #region Property UserFullName

        /// <summary>
        /// The <see cref="UserFullName" /> property's name.
        /// </summary>
        public const string UserFullNamePropertyName = "UserFullName";

        private string _userFullName = null;

        /// <summary>
        /// Sets and gets the UserFullName property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string UserFullName
        {
            get
            {
                return _userFullName;
            }
            set
            {
                if (_userFullName == value)
                {
                    return;
                }
                _userFullName = value;
                RaisePropertyChanged(UserFullNamePropertyName);
                OnSettingsPropertyChanged();
            }
        }

        #endregion

        #region Property UserInitials

        /// <summary>
        /// The <see cref="UserInitials" /> property's name.
        /// </summary>
        public const string UserInitialsPropertyName = "UserInitials";

        private string _userInitials = null;

        /// <summary>
        /// Sets and gets the UserInitials property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string UserInitials
        {
            get
            {
                return _userInitials;
            }
            set
            {
                if (_userInitials == value)
                {
                    return;
                }
                _userInitials = value;
                RaisePropertyChanged(UserInitialsPropertyName);
                OnSettingsPropertyChanged();
            }
        }

        #endregion

        #region Property IsUserInitialsValid

        /// <summary>
        /// The <see cref="IsUserInitialsValid" /> property's name.
        /// </summary>
        public const string IsUserInitialsValidPropertyName = "IsUserInitialsValid";

        private bool _isUserInitialsValid = false;

        /// <summary>
        /// Sets and gets the IsUserInitialsValid property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool IsUserInitialsValid
        {
            get
            {
                return _isUserInitialsValid;
            }
            set
            {
                if (_isUserInitialsValid == value)
                {
                    return;
                }
                _isUserInitialsValid = value;
                RaisePropertyChanged(IsUserInitialsValidPropertyName);
            }
        }

        #endregion

        #region Property WebServerUri

        /// <summary>
        /// The <see cref="WebServerUri" /> property's name.
        /// </summary>
        public const string WebServerUriPropertyName = "WebServerUri";

        private string _webServerUri = null;

        /// <summary>
        /// Sets and gets the WebServerUri property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string WebServerUri
        {
            get
            {
                return _webServerUri;
            }
            set
            {
                if (_webServerUri == value)
                {
                    return;
                }
                _webServerUri = value;
                RaisePropertyChanged(WebServerUriPropertyName);
                OnSettingsPropertyChanged();
            }
        }

        #endregion

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
                this.CommitChangesCommand.RaiseCanExecuteChanged();
            }
        }

        #endregion

        #region Property ValidationMessage

        /// <summary>
        /// The <see cref="ValidationMessage" /> property's name.
        /// </summary>
        public const string ValidationMessagePropertyName = "ValidationMessage";

        private string _validationMessage = null;

        /// <summary>
        /// Sets and gets the ValidationMessage property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string ValidationMessage
        {
            get
            {
                return _validationMessage;
            }
            set
            {
                if (_validationMessage == value)
                {
                    return;
                }
                _validationMessage = value;
                RaisePropertyChanged(ValidationMessagePropertyName);
            }
        }

        #endregion

        #region Command CommitChanges

        private RelayCommand _commitChangesCommand;

        /// <summary>
        /// Gets the CommitChanges command.
        /// </summary>
        public RelayCommand CommitChangesCommand
        {
            get
            {
                return _commitChangesCommand
                    ?? (_commitChangesCommand = new RelayCommand(
                    () =>
                    {
                        this.ExecuteCommitChangesCommand();
                    },
                    () => CanExecuteCommitChangesCommand()));
            }
        }

        private bool CanExecuteCommitChangesCommand()
        {
            return !string.IsNullOrEmpty(this.UserName) &&
                !string.IsNullOrEmpty(this.WebServerUri) &&
                !this.IsBusy;
        }

        private void ExecuteCommitChangesCommand()
        {
            if (!this.CommitChangesCommand.CanExecute(null))
            {
                return;
            }

            if (ValidateConnection())
            {
                Settings.UserId = this.UserId;
                Settings.UserName = this.UserName;
                Settings.UserFullName = this.UserFullName;
                Settings.UserInitials = this.UserInitials;
                Settings.WebServerUri = this.WebServerUri;

                _navigationService.GoBack();
            }
        }

        private bool ValidateConnection()
        {
            this.ValidationMessage = "No se ha podido conectar con el servicio. Intentelo más tarde.";
            return true;
        }

        #endregion

        void OnSettingsPropertyChanged()
        {
            this.ValidationMessage = null;
            this.CommitChangesCommand.RaiseCanExecuteChanged();
        }
    }
}
