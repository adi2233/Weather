using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace weather
{
    public class Location
    {
        private string cityName;

        /// <summary>
        /// location constructor
        /// </summary>
        /// <param name="_city"></param>
        public Location(string _city)
        {
            city = _city;
        }
        public string city
        {
            get
            {
                return cityName;
            }
            set
            {
                if(value==null)
                {
                    throw new WeatherDataServiceException("didnt find city name");
                }
                else
                {
                    cityName = value;
                }
            }
        }

        /// <summary>
        /// location input
        /// </summary>
        public override string ToString()
        {
            return city;
        }
    }
}
