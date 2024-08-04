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

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            AuthBUS bus = AuthBUS.Instance;
            this.Error = bus.Error;
            bool status = bus.Login(username, password);
            if (status)
            {
                return Ok();
            }

            return NotFound(Error);
        }
    }
}
