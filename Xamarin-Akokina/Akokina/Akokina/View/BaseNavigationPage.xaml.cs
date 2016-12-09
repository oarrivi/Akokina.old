﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Akokina.View
{
    public partial class BaseNavigationPage : NavigationPage
    {
        public BaseNavigationPage()
        {
            InitializeComponent();
        }

        public BaseNavigationPage(Page root) : base(root)
        {
            InitializeComponent();
        }
    }
}
