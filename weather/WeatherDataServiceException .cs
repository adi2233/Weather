using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weather
{
    public class WeatherDataServiceException :Exception
    {
        /// <summary>
        /// exception write message
        /// </summary>
        /// <param name="message"></param>
        public WeatherDataServiceException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// empty exception
        /// </summary>
        /// <param name=""></param>
        public WeatherDataServiceException() { }
    }


}



   