using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Core
{
    public class Core
    {
        public static async Task<Weather> GetWeather(string location)
        {
            string key = "e75b73caed0d728414c37cd7037d4291";
            string queryString = "http://api.openweathermap.org/data/2.5/weather?q=" + location + "&APPID=" + key + "&units=metric";

            dynamic results = await DataService.GetDataFromService(queryString).ConfigureAwait(false);
            if (results["weather"] == null)
                return null;

            var weather = new Weather();
            weather.Temperature = (string)results["main"]["temp"] + " C";
            weather.Pressure = (string)results["main"]["pressure"] + " hPa";
            weather.WindSpeed = (string)results["wind"]["speed"] + " M/S";
            
            weather.ImageName = "_" + (string)results["weather"][0]["icon"];
            return weather;
        }
    }
}
