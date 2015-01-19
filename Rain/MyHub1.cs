using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace Rain
{
    [HubName("RainHub")]
    public class MyHub1 : Hub
    {
        public void SendRainInfo(string msg)
        {
            Clients.All.GetRainInfo(msg);
        }
    }
}