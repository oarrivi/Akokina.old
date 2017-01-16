using Akokina.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Akokina.Infrastructure
{
    public interface INavigationService
    {
        void NavigateTo(string pageKey);

        void NavigateTo(string pageKey, object parameters);

        void GoBack();

        void Map(string pageKey, Type pageType);
    }

}
