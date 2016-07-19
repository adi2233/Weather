using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weather
{
    public interface IWeatherDataService
    {
        WeatherData GetWeatherData(Location location);
        ///<summary>
        ///return weather info for location
        ///<param name="location">
        ///</summary>
    }
}
