using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Webkit;
using Android.Widget;

using App1.DependencyServices;
using App1.Droid;
using App1.Droid.DependencyServices;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

[assembly: Dependency(typeof(CookieManagerService))]
namespace App1.Droid.DependencyServices
{
    public class CookieManagerService : ICookieManagerService
    {
        public string GetCookies(string url)
        {
            var cookieHeader = CookieManager.Instance.GetCookie(url);
            return cookieHeader;
        }
    }
}