using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SecurityBLLManager;
using StudentPortal.DTO.DTO;

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
        public int AddTeacher([FromBody]object objteacher)
        {
            try
            {
                Teacher teacher= JsonConvert.DeserializeObject<Teacher>(objteacher.ToString());
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
        public int UpdateTeacher([FromBody]object objteacher)
        {
            try
            {
                Teacher teacher = JsonConvert.DeserializeObject<Teacher>(objteacher.ToString());
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
        public int GetById([FromBody]object objteacher)
        {
            try
            {
                Teacher teacher = JsonConvert.DeserializeObject<Teacher>(objteacher.ToString());
                this.teacherBLLManager.GetTeacherById(teacher);
                return 1;

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