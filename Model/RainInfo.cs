using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class RainInfo
    {
        /// <summary>
        /// TWD67經度
        /// </summary>
        /// <value>The lon.</value>
        public string Lon{ get; set; }
        /// <summary>
        /// TWD67緯度
        /// </summary>
        /// <value>The lat.</value>
        public string Lat { get; set; }
        /// <summary>
        /// 圖示
        /// </summary>
        /// <value>The rainfall10min.</value>
        public string Icon { get; set; }
    }
}
 //{latLng: [25.0961583, 121.4840275], data:"Perpignan ! GO USAP !", options:{icon: "http://maps.google.com/mapfiles/marker_green.png"}}
//測站代碼(SiteId)、測站名稱(SiteName)、縣市(County)、鄉鎮(Township)、TWD67經度(TWD67Lon)、TWD67緯度(TWD67Lat)、10分鐘累積雨量(Rainfall10min)、1小時累積雨量(Rainfall1hr)、3小時累積雨量(Rainfall3hr)、6小時累積雨量(Rainfall6hr)、12小時累積雨量(Rainfall12hr)、24小時累積雨量(Rainfall24hr)、日累積雨量(Now)、設置單位(Unit)、發布時間(PublishTime)
//X97=X67+807.8+0.00001549*X67+0.000006521*Y67
//Y97=Y67-248.6+A*Y67+B*X67
//A=0.00001549, B=0.000006521 