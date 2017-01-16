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
            return (UserId == UserIdDefault) ||
                   (string.IsNullOrEmpty(WebServerUri) || string.Equals(WebServerUri, WebServerUriDefault));
        }
    }
}