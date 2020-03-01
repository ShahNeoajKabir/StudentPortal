using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecurityBLLManager;
using StudentPortal.DTO.DTO;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using StudentPortal.DTO.ViewModel;

namespace Service.Portal.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBLLManager userBLLManager;
        public UserController(IUserBLLManager userBLLManager)
        {
            this.userBLLManager = userBLLManager;
        }

        [HttpPost]
        [Route("AddUser")]
        public int AddUser([FromBody]TempMessage message)
        {
            try
            {

                User user = JsonConvert.DeserializeObject<User>(message.Content.ToString());
                this.userBLLManager.AddUser(user);
                return 1;
            }
            catch (Exception ex)
            {

                throw;
            }


        }
        [HttpPost]
        [Route("UpdateUser")]
        public int UpdateUser([FromBody]TempMessage message)
        {
            try
            {
                User user = JsonConvert.DeserializeObject<User>(message.Content.ToString());
                this.userBLLManager.UpdateUser(user);
                return 1;
            }
            catch (Exception ex)
            {

                throw;
            }


        }
        [HttpPost]
        [Route("GetbyID")]
        public User GetbyID([FromBody]TempMessage message)
        {
            try
            {
                User user = JsonConvert.DeserializeObject<User>(message.Content.ToString());
                return this.userBLLManager.GetUserByID(user);
                
            }
            catch (Exception ex)
            {

                throw;
            }


        }
        [HttpGet]
        [Route("GetAll")]
        public List<User> GetAll()
        {
            try
            {
                return this.userBLLManager.GetAll();
            }
            catch (Exception ex)
            {

                throw;
            }


        }

        [HttpGet]
        [Route("Gets")]

        public string Gets()
        {

            return "hello";
        }
        //[HttpPost]
        //[Route("AddUser")]
        //public void AddUser([FromBody]User user)
        //{
        //    _userBLLManager.AddUser(user);
        //}

    }
}