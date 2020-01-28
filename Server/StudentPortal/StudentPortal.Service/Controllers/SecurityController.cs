using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SecurityBLLManager;
using StudentPortal.DTO.DTO;
using StudentPortal.DTO.ViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentPortal.Service.Controllers
{
    [Route("api/Security")]
    public class SecurityController : Controller
    {
        private readonly ISecurityBLLManager _securityBLLManager;
        private readonly IUserBLLManager _userBLLManager;
        public SecurityController(IUserBLLManager userBLLManager)
        {
            _userBLLManager = userBLLManager;

        }
        public SecurityController(ISecurityBLLManager securityBLLManager)
        {
            _securityBLLManager = securityBLLManager;
        }

        [HttpPost("Login")]
        public void Login([FromBody]VMLogin vMLogin)
        {
            _securityBLLManager.Login(vMLogin);
        }
        [HttpPost("AddUser")]
        public void AddUser([FromBody]User user)
        {
            _userBLLManager.AddUser(user);
        }
        [HttpPost("UpdateUser")]
        public void UpdateUser([FromBody]User user)
        {
            _userBLLManager.UpdateUser(user);
        }
        [HttpPost("GetAll")]
        public async Task<List<User>> GetAll([FromBody]int a)
        {
           return await _userBLLManager.GetAll();
        }
        [HttpPost("DeleteUser")]
        public void DeleteUser([FromBody]User user)
        {
            _userBLLManager.DeleteUser(user);
        }
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        [HttpPost("Login")]
        public void Login([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
