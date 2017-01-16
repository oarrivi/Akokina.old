using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Akokina.Services;
using System.IO;

[assembly: Dependency (typeof(LocalStorage))]

namespace Akokina.Droid.Services
{
    public class LocalStorage : ILocalStorage
    {
        public StreamWriter OpenStreamForWriteUsers(string filename)
        {
            string path = Environment.Spe
        }
    }
}