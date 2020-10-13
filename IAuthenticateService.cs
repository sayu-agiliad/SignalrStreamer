using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiveStreamer.Models;
using Microsoft.AspNetCore.Identity;

namespace LiveStreamer
{
    public interface IAuthenticateService
    {
        User Authenticate(User user);
    }
}
