using Microsoft.VisualStudio.TestTools.UnitTesting;
using weather;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Web;

namespace weather.Tests
{
    /// <summary>
    /// test for city='paris'
    /// </summary>
    [TestClass()]
    public class WeatherDataServiceTests
    {
        [TestMethod()]
        public void GetWeatherDataTest()
        {
            WeatherDataServiceFactory fact = new WeatherDataServiceFactory();

            IWeatherDataService service = fact.GetWeatherDataService(WeatherDataServiceFactory.service.OpenWeatherMap);
            Location myTest = new Location("paris");

            WeatherData test = service.GetWeatherData(myTest);

            string url = "http://api.openweathermap.org/data/2.5/weather?q=" + myTest + "&APPID=ca618d97e8b322c883af330b7f103f2d";

            WeatherData myWeather = checkWeather(url);

            Assert.AreEqual(test.temp, myWeather.temp);
            Assert.AreEqual(test.minTemp, myWeather.minTemp);
            Assert.AreEqual(test.humidity, myWeather.humidity);
            Assert.AreEqual(test.maxTemp, myWeather.maxTemp);
        }


        /// <summary>
        ///test for city=null
        /// </summary>
        [TestMethod()]
        public void GetWeatherDataCityNullTest()
        {
            WeatherDataServiceFactory fact = new WeatherDataServiceFactory();
            IWeatherDataService service = fact.GetWeatherDataService(WeatherDataServiceFactory.service.OpenWeatherMap);
            try
            {
                WeatherData test = service.GetWeatherData(new Location(null));
                Assert.Fail("exception");
            }
            catch (WeatherDataServiceException e)
            {
                Console.WriteLine(e.Message);
            }
        }



        private WeatherData checkWeather(string url)
        {
            try
            {
                string json = new WebClient().DownloadString(url);
                var obj = JObject.Parse(json);

                var jsontemp = (string)obj["main"]["temp"];
                var json_min_temp = (string)obj["main"]["temp_min"];
                var json_max_temp = (string)obj["main"]["temp_max"];
                var json_humidity = (string)obj["main"]["humidity"];


                Double result = Convert.ToDouble(jsontemp);
                result -= 273.15;
                result = System.Math.Round(result, 2);

                Double tempMin = Convert.ToDouble(json_min_temp);
                tempMin -= 273.15;
                tempMin = System.Math.Round(tempMin, 2);
                Double tempMax = Convert.ToDouble(json_max_temp);
                tempMax -= 273.15;
                tempMax = System.Math.Round(tempMax, 2);
                Double humidity = Convert.ToDouble(json_humidity);
                humidity = System.Math.Round(humidity, 2);


                WeatherData data = new WeatherData(result, tempMin, tempMax, humidity);

                return data;

            }
            catch (WeatherDataServiceException e)
            {
                Console.WriteLine(e.Message);
                throw new WeatherDataServiceException("can't parse Json");
            }
        }


    }
}
    

