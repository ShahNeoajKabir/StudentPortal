using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Security.BLLManager;
using StudentPortal.DTO.ViewModel;

namespace Service.Portal.Controllers
{
    [Route("api/Security")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly ISecurityBLLManager securityBLLManager;
        public SecurityController(ISecurityBLLManager securityBLLManager)
        {
            this.securityBLLManager = securityBLLManager;
        }

        [HttpPost]
        [Route("Login")]
        public int Login([FromBody]VMLogin login)
        {
            this.securityBLLManager.Login(login);

            return 1;


        }
        [HttpPost("Gets")]
        public string Gets()
        {
            return "Hello";
        }

    }
}