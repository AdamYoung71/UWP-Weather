using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.IO;
using Windows.UI.Xaml.Controls;

namespace FiveDays
{
    class FiveDays
    {
        public async static Task<Root> getFiveDays(string city)
        {
            var location_cd = city;
            var http = new HttpClient();
            //var response = await http.GetAsync("https://api.seniverse.com/v3/weather/daily.json?key=your_api_key&location=beijing&language=zh-Hans&unit=c&start=0&days=5");
            var response = await http.GetAsync("https://api.seniverse.com/v3/weather/daily.json?key=SrcvbANXIm08Wx519&location=" + location_cd + "&language=zh-Hans&unit=c&start=0&days=5");
            var result = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(Root));

            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (Root)serializer.ReadObject(ms);

            return data;
        }
    }


    public class Location
    {
        /// <summary>
        /// WX4FBXXFKE4F
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 北京
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// CN
        /// </summary>
        public string country { get; set; }
        /// <summary>
        /// 北京,北京,中国
        /// </summary>
        public string path { get; set; }
        /// <summary>
        /// Asia/Shanghai
        /// </summary>
        public string timezone { get; set; }
        /// <summary>
        /// +08:00
        /// </summary>
        public string timezone_offset { get; set; }
    }

    public class Daily
    {
        /// <summary>
        /// 2019-04-15
        /// </summary>
        public DateTime date { get; set; }
        /// <summary>
        /// 多云
        /// </summary>
        public string text_day { get; set; }
        /// <summary>
        /// 4
        /// </summary>
        public string code_day { get; set; }
        /// <summary>
        /// 多云
        /// </summary>
        public string text_night { get; set; }
        /// <summary>
        /// 4
        /// </summary>
        public string code_night { get; set; }
        /// <summary>
        /// 26
        /// </summary>
        public string high { get; set; }
        /// <summary>
        /// 12
        /// </summary>
        public string low { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string precip { get; set; }
        /// <summary>
        /// 南
        /// </summary>
        public string wind_direction { get; set; }
        /// <summary>
        /// 180
        /// </summary>
        public string wind_direction_degree { get; set; }
        /// <summary>
        /// 15
        /// </summary>
        public string wind_speed { get; set; }
        /// <summary>
        /// 3
        /// </summary>
        public string wind_scale { get; set; }
    }

    public class Results
    {
        /// <summary>
        /// Location
        /// </summary>
        public Location location { get; set; }
        /// <summary>
        /// Daily
        /// </summary>
        public List<Daily> daily { get; set; }
        /// <summary>
        /// 2019-04-15T11:00:00+08:00
        /// </summary>
        public string last_update { get; set; }
    }

    public class Root
    {
        /// <summary>
        /// Results
        /// </summary>
        public List<Results> results { get; set; }
    }

}
