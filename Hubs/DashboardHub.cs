using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace dashboard.Hubs
{
    public class DashboardHub : Hub
    {
        public Task Send(string message)
        {
            return Clients.All.InvokeAsync("TestSend", message);
        }
    }
}
