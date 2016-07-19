using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weather
{
    public class WeatherDataServiceFactory
    {
        /// <summary>
        /// the service 
        /// </summary>
        public enum service { OpenWeatherMap };

        /// <summary>
        /// get weather service by the type
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public IWeatherDataService GetWeatherDataService(service s)
        {
            IWeatherDataService _service;
            if(s == service.OpenWeatherMap)
            {
                _service = WeatherDataService.Varaible;
            }
            else
                _service = null;

            return _service;
        }
    }
}
