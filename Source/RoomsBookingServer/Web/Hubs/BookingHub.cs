using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.SignalR;

namespace Web.Hubs
{
    public class BookingHub : Hub
    {
        public static ConcurrentBag<Connection> Connections =new ConcurrentBag<Connection>();
        public override Task OnConnected()
        {
            if (!Context.User.Identity.IsAuthenticated)
                return base.OnConnected();
            
            Connections.Add(new Connection {UserId = Context.User.Identity.GetUserId(), ConnectionId = Context.ConnectionId});
            return base.OnConnected();
        }



        public class Connection 
        {
            public string UserId { get; set; }

            public string ConnectionId { get; set; }
        }
    }
}