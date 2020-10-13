using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using LiveStreamer.Models;
using Microsoft.IdentityModel.Tokens;

namespace LiveStreamer
{
    public class AuthenticateService : IAuthenticateService
    {
        public User Authenticate(User user)
        {
            if (user.name == "test1" && user.password == "test1")
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes("somekeysomekeysomekeysomekeysomekeysomekeysomekeysomekeysomekeysomekeysomekeysomekey");
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.Name, user.name),
				//For claim-based authorisation
				new Claim(ClaimTypes.Role, "group1")
                }),
                    Expires = DateTime.UtcNow.AddSeconds(10),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                user.token = tokenHandler.WriteToken(token);



                return new User
                {
                    name = "test1",
                    groups = new string[] { "group1" },
                    token = user.token
                };
            }

            else if (user.name == "test2" && user.password == "test2")
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes("somekeysomekeysomekeysomekeysomekeysomekeysomekeysomekeysomekeysomekeysomekeysomekey");
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.Name, user.name),
				//For claim-based authorisation
				new Claim(ClaimTypes.Role, "group2")
                }),
                    Expires = DateTime.UtcNow.AddSeconds(10),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                user.token = tokenHandler.WriteToken(token);
                return new User
                {
                    name = "test1",
                    groups = new string[] { "group2" },
                    token = user.token
                };
            }
            else if (user.name == "test3" && user.password == "test3")
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes("somekeysomekeysomekeysomekeysomekeysomekeysomekeysomekeysomekeysomekeysomekeysomekey");
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.Name, user.name),
				//For claim-based authorisation
                new Claim(ClaimTypes.Role, "group3")
                }),
                    Expires = DateTime.UtcNow.AddSeconds(10),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                user.token = tokenHandler.WriteToken(token);
                return new User
                {
                    name = "test1",
                    groups = new string[] { "group3" },
                    token = user.token
                };
            }
            else if (user.name == "test4" && user.password == "test4")
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes("somekeysomekeysomekeysomekeysomekeysomekeysomekeysomekeysomekeysomekeysomekeysomekey");
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.Name, user.name),
				//For claim-based authorisation
				new Claim(ClaimTypes.Role, "group2"),
                new Claim(ClaimTypes.Role, "group3")
                }),
                    Expires = DateTime.UtcNow.AddSeconds(10),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                user.token = tokenHandler.WriteToken(token);
                return new User
                {
                    name = "test1",
                    groups = new string[] { "group2", "group3" },
                    token = user.token
                };
            }

            else
                return null;
        }
    }
}