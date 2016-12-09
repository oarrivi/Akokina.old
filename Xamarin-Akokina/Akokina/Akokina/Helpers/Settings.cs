// Helpers/Settings.cs
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace Akokina.Helpers
{
    /// <summary>
    /// This is the Settings static class that can be used in your Core solution or in any
    /// of your client applications. All settings are laid out the same exact way with getters
    /// and setters. 
    /// </summary>
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        #region UserId

        private const string UserIdKey = "user_id_key";

        private static readonly int UserIdDefault = 0;

        public static int UserId
        {
            get
            {
                return AppSettings.GetValueOrDefault<int>(UserIdKey, UserIdDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue<int>(UserIdKey, value);
            }
        }

        #endregion

        #region UserName

        private const string UserNameKey = "user_name_key";

        private static readonly string UserNameDefault = string.Empty;

        public static string UserName
        {
            get
            {
                return AppSettings.GetValueOrDefault<string>(UserNameKey, UserNameDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue<string>(UserNameKey, value);
            }
        }

        #endregion

        #region UserFullName 

        private const string UserFullNameKey = "user_full_name_key";

        private static readonly string UserFullNameDefault = string.Empty;

        public static string UserFullName
        {
            get
            {
                return AppSettings.GetValueOrDefault<string>(UserFullNameKey, UserFullNameDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue<string>(UserFullNameKey, value);
            }
        }

        #endregion

        #region UserInitials

        private const string UserInitialsKey = "user_initials_key";

        private static string UserInitialsDefault = string.Empty;

        public static string UserInitials
        {
            get
            {
                return AppSettings.GetValueOrDefault<string>(UserInitialsKey, UserInitialsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue<string>(UserInitialsKey, value);
            }
        }

        #endregion

        #region WebServerUri

        private const string WebServerUriKey = "web_server_uri_key";

        private static readonly string WebServerUriDefault = string.Empty;

        public static string WebServerUri
        {
            get
            {
                return AppSettings.GetValueOrDefault<string>(WebServerUriKey, WebServerUriDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue<string>(WebServerUriKey, value);
            }
        }

        #endregion

        public static bool IsNullOrEmpty()
        {
            return (string.IsNullOrEmpty(UserName) || string.Equals(UserName, UserIdDefault)) &&
                   (string.IsNullOrEmpty(WebServerUri) || string.Equals(WebServerUri, WebServerUriDefault));
        }
    }
}