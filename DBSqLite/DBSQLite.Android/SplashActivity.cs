using Android.App;
using Android.Content;
using Android.OS;
using Android.Content.PM;

namespace DBSQLite.Droid
{
    [Activity(Label = "Dalliat", Icon = "@mipmap/icon", Theme = "@style/SplashTheme", MainLauncher = true, NoHistory = true, ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
            Finish();
        }
    }
}
