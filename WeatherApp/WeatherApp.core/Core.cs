using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.core
{
    public class Core
    {
        public static async Task<Weather> GetWeather(string zipCode)
        {
            string key = "e75b73caed0d728414c37cd7037d4291";
            string queryString = "http://api.openweathermap.org/data/2.5/weather?q=Tallinn&appid=" + key;

            dynamic results = await DataService.GetDataFromService(queryString).ConfigureAwait(false);
            var weather = new Weather();
            weather.Temperature = (string)results["main"]["temp"] + " C";
            return weather;
        }
    }
}
