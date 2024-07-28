using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using AndroidX.Core.App;
using AndroidX.Core.Content;
using Android;
using Android.Widget;

namespace App1.Droid
{
    [Activity(Label = "App1", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public const int RequestWriteExternalStorageId = 0;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
          
            LoadApplication(new App());
            RequestPermissions();
        }
        void RequestPermissions()
        {
            if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.WriteExternalStorage) != Permission.Granted)
            {
                ActivityCompat.RequestPermissions(this, new string[] { Manifest.Permission.WriteExternalStorage }, RequestWriteExternalStorageId);
            }
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            if (requestCode == RequestWriteExternalStorageId)
            {
                if (grantResults.Length > 0 && grantResults[0] == Permission.Granted)
                {
                    // Permission granted, proceed with your operation
                    //CopyFileToDownloads();
                }
                else
                {
                    // Permission denied, show a message to the user
                    Toast.MakeText(this, "Write permission is required to save the file.", ToastLength.Long).Show();
                }
            }
        }
    }
}