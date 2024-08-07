using GenVibeServer.Asset.BUS.Auth;
using GenVibeServer.Asset.DTO.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace GenVibeServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public string? Error { get; set; }

        [HttpPost("login")]
        public IActionResult Login(string username, string password)
        {
            AuthBUS bus = AuthBUS.Instance;            
            bool status = bus.Login(username, password);
            this.Error = bus.Error;
            if (status)
            {
                return Ok(bus.User);
            }

            return NotFound(Error);
        }

        [HttpPost("register")]
        public IActionResult Regitser(string username, string password, string email, string phone, string fullname)
        {
            UserDTO user = new()
            {
                Username = username,
                Password = password,
                Phone = phone,
                FullName = fullname,
                Email = email
            };
            AuthBUS authBUS = AuthBUS.Instance;
            bool status = authBUS.Register(user);
            this.Error = authBUS.Error;

            if (status)
            {
                return Ok(authBUS.User);
            }
            return NotFound(Error);
        }
    }
}
