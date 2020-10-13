using System;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
//using Microsoft.AspNet.SignalR;//using Microsoft.AspNet.SignalR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Connections.Features;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Microsoft.IdentityModel.Tokens;

namespace LiveStreamer
{
    [Authorize]
    public class DemoHub : Hub
    {
        public override Task OnConnectedAsync()
        {

            var feature = Context.Features.Get<IConnectionHeartbeatFeature>();
            var result = Context.GetHttpContext().AuthenticateAsync(JwtBearerDefaults.AuthenticationScheme).Result;
            var ctx = Context.GetHttpContext();
            Int64 exp = 0;
            foreach (var cl in ctx.User.Claims)
            {
                Console.WriteLine($" {cl.Type}  {cl.Value}  {cl.Issuer}");
                if (cl.Type == "exp")
                    exp = Int64.Parse(cl.Value );
            }

            if (feature == null)
            {
                Console.WriteLine("No heartbeat :( ");
            }
            else
            {
                feature.OnHeartbeat((state) =>
                {
                    var (exp, connection) = ((Int64, HubCallerContext))state;

                    Console.WriteLine($"Lub Dub ... {exp.ToString()}");
                    DateTime dt = DateTimeOffset.FromUnixTimeSeconds((Int64)exp).UtcDateTime;
                        Console.WriteLine($"{dt}");

                    if (dt < DateTime.UtcNow )
                    {
                        connection.Abort();


                    }
                 

                }, (exp,Context));
            }
            Console.WriteLine("-----------------------------------");

            foreach (var cl in Context.GetHttpContext().User.Claims)
            {
                Console.WriteLine($" {cl.Type}  {cl.Value}  {cl.Issuer}");
                if (cl.Type == ClaimTypes.Role)
                    Groups.AddToGroupAsync(Context.ConnectionId, cl.Value);
            }
            return base.OnConnectedAsync();
        }

    }
}