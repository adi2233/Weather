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
    class Program
    {
        static void Main(string[] args)
        {
            string city = "";
            ///<summary>
            ///main function to choose a city
            ///</summary>
            while (city!=null)
            {
                //factory service
                WeatherDataServiceFactory fact = new WeatherDataServiceFactory();
                IWeatherDataService data = fact.GetWeatherDataService(WeatherDataServiceFactory.service.OpenWeatherMap);

                Console.WriteLine("please choose city:");
                city = Console.ReadLine();
                if(city== null)
                {
                    throw new WeatherDataServiceException("didn't choose a city");
                }
                
                try
                {
                    Location loc = new Location(city);//create location
                    WeatherData s = data.GetWeatherData(loc);//get the weather
                    Console.WriteLine(s.ToString());//print the weather
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("can't find city");
                }


            }

        }
    }
}
