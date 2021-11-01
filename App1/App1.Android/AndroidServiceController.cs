using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using App1.Droid;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

[assembly: Dependency(typeof(AndroidServiceController))]
namespace App1.Droid
{
    public class AndroidServiceController : IAndroidServiceController
    {
        public void StartService()
        {
            MainActivity.AppContext.StartService(MainActivity.startServiceIntent);
        }

        public void StopService()
        {
            MainActivity.AppContext.StopService(MainActivity.stopServiceIntent);
        }
    }
}