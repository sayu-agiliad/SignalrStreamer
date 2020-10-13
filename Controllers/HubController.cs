using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using LiveStreamer.DataGen;
using LiveStreamer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace LiveStreamer.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class HubController : ControllerBase
    {
        private IHubContext<DemoHub> _hub;

        public HubController(IHubContext<DemoHub> hub )
        {
            _hub = hub;
        }

        public IActionResult Get()
        {
            Console.WriteLine("Accssing the hub");
            Random rnd = new Random(DateTime.Now.Millisecond);
            //var tm = new DataGenerator(() => _hub.Clients.All.SendAsync("ParamUpdate", new ParameterData() { ParamName = "test" + rnd.Next(0,10), Value = rnd.NextDouble()}));
            var tm = new DataGenerator(mymethod);
            return Ok(new { Message = "Done!!" });
        }

        private void mymethod()
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            
            int number = rnd.Next(0, 1000);

            _hub.Clients.Group($"group1").SendAsync("Randumnumber", number);
            
            if (number % 2 == 0)
            {
                _hub.Clients.Group($"group2").SendAsync("Randumnumber", number);
            }
            if (number % 3 == 0)
            {
                _hub.Clients.Group($"group3").SendAsync("Randumnumber", number);
            }


        }
    }
}
