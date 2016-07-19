using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Web.Script.Serialization;
using System.IO;


namespace weather
{
    public class jsonParse : Ijson
    {
        private string urlAdd;

        /// <summary>
        /// check if url if empty if not return url
        /// </summary>
        /// <param name="_url"></param>
        public jsonParse(string _url)
        {
            if (_url == null)
            {
                throw new WeatherDataServiceException("can't find url");
            }
            else
                urlAdd = _url;
        }

        /// <summary>
        /// parse by url
        /// </summary>
        /// <returns></returns>
        public WeatherData parse()
        {
            try
            {
                string json = new WebClient().DownloadString(urlAdd);
                dynamic obj = JObject.Parse(json);

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
            catch(JsonException e)
            {
                Console.WriteLine(e.Message);
                throw new WeatherDataServiceException("can't parse Json");
            }
            catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException)
            {
 
                throw new WeatherDataServiceException("can't find city-wrong input");
            }
        }

   
    }
}
