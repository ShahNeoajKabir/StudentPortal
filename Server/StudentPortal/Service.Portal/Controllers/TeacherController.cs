using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SecurityBLLManager;
using StudentPortal.DTO.DTO;
using StudentPortal.DTO.ViewModel;

namespace Service.Portal.Controllers
{
    [Route("api/Teacher")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherBLLManager teacherBLLManager;
        public TeacherController(ITeacherBLLManager teacherBLLManager)
        {
            this.teacherBLLManager = teacherBLLManager;

        }

        [HttpPost]
        [Route("AddTeacher")]
        public int AddTeacher([FromBody]TempMessage message)
        {
            try
            {
                Teacher teacher= JsonConvert.DeserializeObject<Teacher>(message.Content.ToString());
                teacher.CreatedBy = message.UserId;
                this.teacherBLLManager.AddTeacher(teacher);
                return 1;

            }
            catch(Exception ex)
            {
                throw;
            }
        }
        [HttpPost]
        [Route("UpdateTeacher")]
        public int UpdateTeacher([FromBody]TempMessage message)
        {
            try
            {
                Teacher teacher = JsonConvert.DeserializeObject<Teacher>(message.Content.ToString());
                this.teacherBLLManager.UpdateTeacher(teacher);
                return 1;

            }
            catch(Exception ex)
            {
                throw;
            }
        }
        [HttpPost]
        [Route("GetById")]
        public Teacher GetById([FromBody]TempMessage message)
        {
            try
            {
                Teacher teacher = JsonConvert.DeserializeObject<Teacher>(message.Content.ToString());
                return this.teacherBLLManager.GetTeacherById(teacher);
               

            }
            catch(Exception ex)
            {
                throw;
            }
        }
        [HttpGet]
        [Route("GetAll")]
        public List<Teacher> GetAll()
        {
            try
            {
                return this.teacherBLLManager.GetAll();
            }
            catch (Exception ex)
            {

                throw;
            }


        }
    }
}