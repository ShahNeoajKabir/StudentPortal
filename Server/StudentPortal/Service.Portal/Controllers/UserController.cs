using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecurityBLLManager;
using StudentPortal.DTO.DTO;

namespace Service.Portal.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBLLManager _userBLLManager;
        public UserController(IUserBLLManager userBLLManager)
        {
            _userBLLManager = userBLLManager;
        }
        [HttpPost]
        [Route("AddUser")]
        public void AddUser([FromBody]User user)
        {
            _userBLLManager.AddUser(user);
        }
      
    }
}