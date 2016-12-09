using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akokina.Model;
using Plugin.Connectivity;
using System.Net.Http;

namespace Akokina.Services
{

    public interface IDataService
    {
        IEnumerable<Movement> GetMovementsFromLocal();

        Task<bool> SynchronizeMovementsAsync(int maxItems);

        IEnumerable<User> GetUsersFromLocal();

        Task<bool> SynchronizeUsersAsync();
    }

    public class DataService : IDataService
    {
        public DataService()
        {
            //_urlRoot
        }

        private string UrlRoot
        {
            get
            {
                return Helpers.Settings.WebServerUri;
            }
        }

        public async Task<bool> SynchronizeUsersAsync()
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> SynchronizeMovementsAsync(int maxItems)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                return false;
            }

            return true;
        }

        private async Task<HttpClient> GetClient()
        {
            var httpClient = new HttpClient();

            //if (string.IsNullOrEmpty(authorizationKey))
            //{
            //    string response = await httpClient.GetStringAsync(Url + "login");
            //    authorizationKey = JsonConvert.DeserializeObject<string>(response);
            //}

            //httpClient.DefaultRequestHeaders.Add("Authorization", authorizationKey);
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

            return httpClient;
        }

        #region Local Data

        public IEnumerable<Movement> GetMovementsFromLocal()
        {
            var users = this.GetUsersFromLocal();

            return new Movement[]
            {
                new Movement
                {
                    Id = 1,
                    UserId = 1,
                    ValueDate = new DateTime(2016, 1, 1),
                    Title = "Desayuno",
                    Amount = 7.30m,
                    User = users.FirstOrDefault(user => user.Id == 1)
                },
                new Movement
                {
                    Id = 2,
                    UserId = 1,
                    ValueDate = new DateTime(2016, 1, 1),
                    Title = "Almuerzo",
                    Amount = 12m,
                    User = users.FirstOrDefault(user => user.Id == 1)
                },
                new Movement
                {
                    Id = 3,
                    UserId = 2,
                    ValueDate = new DateTime(2016, 1, 1),
                    Title = "Merienda",
                    Amount = 4.2m,
                    User = users.FirstOrDefault(user => user.Id == 2)
                },
                new Movement
                {
                    Id = 4,
                    UserId = 1,
                    ValueDate = new DateTime(2016, 1, 1),
                    Title = "Cena",
                    Amount = 21m,
                    User = users.FirstOrDefault(user => user.Id == 1)
                },
            };
        }

        public IEnumerable<User> GetUsersFromLocal()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                SynchronizeUsersAsync();
            }

            return new User[]
            {
                new Model.User { Id = 1, Username = "user1", Initials = "U1", FullName = "User 1" },
                new Model.User { Id = 2, Username = "user2", Initials = "U2", FullName = "User 2" },
            };
        }

        public User FindUserFromLocal(int id)
        {
            return this.GetUsersFromLocal()
                .FirstOrDefault(user => user.Id == id);
        }

        #endregion
    }

}
