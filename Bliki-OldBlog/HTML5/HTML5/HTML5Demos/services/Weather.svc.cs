using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;
using System.Net;
using System.Xml.Linq;
using System.IO;
using System.ServiceModel.Channels;

[ServiceContract]
public class Weather
{
    [OperationContract]
    [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "{zip}")]
    public WeatherData GetCurrentWeather(string zip)
    {
        WeatherData weather = new WeatherData();
            
        if (!String.IsNullOrEmpty(zip) && zip.Length == 5)
        {
            // Add CORS header to outgoing response
            WebOperationContext.Current.OutgoingResponse.Headers.Add("Access-Control-Allow-Origin", "*");

            // Get current weather data from Weather Underground
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri("http://api.wunderground.com/auto/wui/geo/WXCurrentObXML/index.xml?query=" + zip));
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                string result = reader.ReadToEnd();

                // Use LINQ to XML to extract data
                XDocument doc = XDocument.Parse(result);

                string location = (from x in doc.Element("current_observation").Elements("display_location")
                                    select x).Single().Element("full").Value;

                string temperature = (from x in doc.Descendants("current_observation")
                                        select x).Single().Element("temp_f").Value;

                weather.location = location;
                weather.temperature = temperature;
            }
        }

        // Return current weather data to client
        return weather;
    }
}

[DataContract]
public class WeatherData
{
    [DataMember]
    public string location { get; set; }

    [DataMember]
    public string temperature { get; set; }
}