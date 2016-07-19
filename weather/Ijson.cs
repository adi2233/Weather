using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weather
{
    public interface Ijson
    {
        WeatherData parse();
        ///<summary>
        ///return object of WeatherData
        ///</summary>
    }
}
