using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;

namespace RaysHotDogs.Andriod
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        int counter = 1;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            Button button = FindViewById<Button>(Resource.Id.button1);

            button.Click += delegate { button.Text = string.Format($"Hello World, {counter++} clicks!"); };
        }
    }
}

