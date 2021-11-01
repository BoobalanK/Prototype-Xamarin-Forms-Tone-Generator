using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Android.Content;
using ServicesDemo3;
using Xamarin.Forms;

namespace App1.Droid
{
    [Activity(Label = "ToneGenerator Prototype", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public static Intent startServiceIntent;
        public static Intent stopServiceIntent;
        public static Context? AppContext { get; set; }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            AppContext = this.ApplicationContext;

            startServiceIntent = new Intent(this, typeof(TimestampService));
            startServiceIntent.SetAction(Constants.ACTION_START_SERVICE);

            stopServiceIntent = new Intent(this, typeof(TimestampService));
            stopServiceIntent.SetAction(Constants.ACTION_STOP_SERVICE);

            MessagingCenter.Subscribe<string>(this, "StartService", (sender) =>
            {
                StartService(startServiceIntent);
            });

            MessagingCenter.Subscribe<string>(this, "StopService", (sender) =>
            {
                StopService(startServiceIntent);
            });

            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }


    }
}