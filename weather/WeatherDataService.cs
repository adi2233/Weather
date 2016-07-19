using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace weather
{
    public class WeatherDataService : IWeatherDataService
    {
      
        private static WeatherDataService _varaible;
        public static WeatherDataService Varaible
        {
            get
            {
                if (_varaible == null)
                {
                    _varaible = new WeatherDataService();
                }
                return _varaible;
            }
        }


         ///<summary>
        /// get data by location 
        ///</summary>

        public WeatherData GetWeatherData(Location location)
        {
            if (location == null)
            {
                throw new WeatherDataServiceException("location dosent exist");
                    
            }
            Console.WriteLine("weather in " + location.city);
            try
            {
                string url = "http://api.openweathermap.org/data/2.5/weather?q=" + location.city + "&APPID=ca618d97e8b322c883af330b7f103f2d";
                Ijson json = new jsonParse(url);
                return json.parse();
            }
            catch(WeatherDataServiceException e)
            {
                Console.WriteLine(e.Message);
                throw new WeatherDataServiceException("can't connect");
            }  
        }


    }
}