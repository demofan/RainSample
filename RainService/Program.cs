using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Caching;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;
using Model;
using Newtonsoft.Json;

namespace RainService
{
    class Program
    {
        private static string _cacheJsonData = "";
        static void Main(string[] args)
        {
            var connection = new HubConnection("http://localhost:11856/");
            var rainHub = connection.CreateHubProxy("RainHub");
            connection.Start().ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    Console.WriteLine("There was an error opening the connection:{0}",
                                      task.Exception.GetBaseException());
                }
                else
                {
                    Console.WriteLine("Connected");
                }

            }).Wait();
            string[] loop = null;
            while (true)
            {
                if (string.IsNullOrWhiteSpace(_cacheJsonData))
                {
                    Console.WriteLine("Start");

                    //真的遠端讀取
                    var webClient = new WebClient();
                    var baseUri = "http://opendata.epa.gov.tw/ws/Data/RainTenMin/?format=json";
                    webClient.Encoding = Encoding.UTF8;
                    var jsonData = webClient.DownloadString(baseUri);
                    _cacheJsonData = jsonData;

                    //網路差的時候直接用本機範例檔
                    //using (StreamReader sr = new StreamReader("../../json.json"))
                    //{
                    //    _cacheJsonData = sr.ReadToEnd();
                    //}

                    //loop =
                    //    JsonConvert.DeserializeObject<List<JsonData>>(_cacheJsonData)
                    //        .GroupBy(d => d.County)
                    //        .Select(d => d.Key)
                    //        .ToArray();

                }

                //展示每五秒換一個行政區的效果
                //for (int i = 0; i < loop.Length; i++)
                //{
                //    var filterData = JsonConvert.DeserializeObject<List<JsonData>>(_cacheJsonData).Where(d => d.County == loop[i]);
                //    Console.WriteLine("Invoke Hub");
                //    rainHub.Invoke<string>("SendRainInfo", ConvertToJsonRainInfo(filterData));
                //    Console.WriteLine("Invoke Hub Success!" + DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss"));
                //    Thread.Sleep(5000);
                //}

                //展示每10秒更新資料的效果
                var filterData = JsonConvert.DeserializeObject<List<JsonData>>(_cacheJsonData).Where(d => d.County == "臺北市");
                Console.WriteLine("Invoke Hub");
                rainHub.Invoke<string>("SendRainInfo", ConvertToJsonRainInfo(filterData));
                Console.WriteLine("Invoke Hub Success!" + DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss"));
                Thread.Sleep(1000 * 60 * 10);
            }

            Console.Read();
            connection.Stop();
        }

        private static string ConvertToJsonRainInfo(IEnumerable<JsonData> data)
        {
            var source = data.Select(item => new RainInfo { Lat = item.TWD67Lat, Lon = item.TWD67Lon, Icon = MarkerIcon(item.Rainfall10min) });
            return JsonConvert.SerializeObject(source);
        }

        private static string MarkerIcon(string rainfall)
        {
            var rainVal = Convert.ToDouble(rainfall);
            if (rainVal < 0.5)
            {
                return "/Content/sunny.png";
            }
            if (rainVal == 0.5)
            {
                return "/Content/rainy.png";
            }

            return "/Content/umbrella.png";
        }
    }
}
