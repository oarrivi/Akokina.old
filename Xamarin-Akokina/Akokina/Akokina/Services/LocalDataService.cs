using Akokina.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akokina.Services
{
    public class LocalDataService
    {
        readonly ILocalStorage _localStorage = null;

        public LocalDataService(ILocalStorage localStorage)
        {
            _localStorage = localStorage;
        }

        public IEnumerable<User> GetUsers()
        {
        }

        public void SaveUsers(IEnumerable<User> users)
        {
        }
    }
}
