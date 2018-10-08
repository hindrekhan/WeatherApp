using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using WeatherApp.Core;

namespace WeatherApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Button search;
        EditText input;
        TextView temperature;
        TextView pressure;
        TextView windSpeed;
        ImageView weatherIcon;

        protected  override  void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            search = FindViewById<Button>(Resource.Id.search);
            input = FindViewById<EditText>(Resource.Id.input);
            temperature = FindViewById<TextView>(Resource.Id.temperature);
            pressure = FindViewById<TextView>(Resource.Id.pressure);
            windSpeed = FindViewById<TextView>(Resource.Id.windSpeed);
            weatherIcon = FindViewById<ImageView>(Resource.Id.weatherIcon);

            search.Click += Button_Click;
        }

        private async void Button_Click(object sender, System.EventArgs e)
        {
            var weather = await Core.Core.GetWeather(input.Text);
            temperature.Text = weather.Temperature;
            pressure.Text = weather.Pressure;
            windSpeed.Text = weather.WindSpeed;

            weatherIcon.SetImageResource(Resources.GetIdentifier(weather.ImageName, "drawable", PackageName));
        }
    }
}