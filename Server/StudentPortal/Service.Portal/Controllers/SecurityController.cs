using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Security.BLLManager;
using Service.Portal.Handler;
using StudentPortal.Common.Utility;
using StudentPortal.DTO.DTO;
using StudentPortal.DTO.ViewModel;

namespace Service.Portal.Controllers
{
    [Produces("application/json")]
    [Route("api/Security")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly ISecurityBLLManager securityBLLManager;
        private readonly IAuthenticationManager authenticationManager;
        public SecurityController(ISecurityBLLManager securityBLLManager, IAuthenticationManager authenticationManager)
        {
            this.securityBLLManager = securityBLLManager;
            this.authenticationManager = authenticationManager;
        }

        [HttpPost]
        [Route("Login")]
        public JsonResult Login([FromBody]TempMessage message)
        {
            VMLogin userLogin = JsonConvert.DeserializeObject<VMLogin>(message.Content);
           var result= this.securityBLLManager.Login(userLogin).Result;
            if (result != null)
            {
                return new JsonResult(new { Token = this.authenticationManager.BuildToken(Converter.ObjectConvert<User>(result)) });
            }
            else
            {
                return new JsonResult("User not Authenticate") { StatusCode = 400 };
            }


        }
        [HttpGet("Gets")]
        public string Gets()
        {
            return "Hello";
        }

    }
}