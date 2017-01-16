using Akokina.Helpers;
using Akokina.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Akokina.Model
{
    public interface ISettingsController
    {
        /// <summary>
        /// Tries to load current user. If not configured, returns a default new user with Id equals to 0.
        /// </summary>
        /// <returns>A user entity.</returns>
        User CreateOrLoadCurrentUser();
    }

    /// <summary>
    /// Business logic of Settings page
    /// </summary>
    public class SettingsController
    {
        readonly IDataService _dataService = null;
        readonly Dictionary<string, Color> nameToColor = null;

        public SettingsController(IDataService dataService)
        {
            _dataService = dataService;
            this.NameToColors = new Dictionary<string, Color>
            {
                { "Aqua", Color.Aqua }, 
                { "Blue", Color.Blue }, { "Fucshia", Color.Fuchsia },
                { "Green", Color.Green },
                { "Lime", Color.Lime }, { "Maroon", Color.Maroon },
                { "Navy", Color.Navy }, { "Olive", Color.Olive },
                { "Purple", Color.Purple }, { "Red", Color.Red },
                { "Teal", Color.Teal },
                { "Yellow", Color.Yellow }
            };
        }

        public Dictionary<string, Color> NameToColors { get; private set; }

        public User CreateOrLoadCurrentUser()
        {
            int userId = Settings.UserId;
            User user = null;

            if (userId == 0)
            {
                user = new User();
                user.Id = 0;
                user.Avatar = 0;
                user.Color = GetRandomColorName();
                user.Email = string.Empty;
                user.Initials = string.Empty;
                user.Username = string.Empty;
            }
            else
            {
                user = _dataService.FindUser(userId);
            }

            return user;
        }

        string GetRandomColorName()
        {
            var rand = new Random();
            int index = rand.Next(this.NameToColors.Count - 1);

            return this.NameToColors.Keys.ElementAt(index);
        }
    }
}
