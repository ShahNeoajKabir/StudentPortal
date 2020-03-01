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
    [Route("api/Student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentBLLManager studentBLLManager;

        public StudentController(IStudentBLLManager studentBLLManager)
        {
            this.studentBLLManager = studentBLLManager;

        }
        [HttpPost]
        [Route("AddStudent")]
        public int AddStudent([FromBody]TempMessage message)
        {
            try
            {
                Student student = JsonConvert.DeserializeObject<Student>(message.Content.ToString());
                student.CreatedBy = message.UserId;
                this.studentBLLManager.AddStudent(student);
                return 1;
            }
            catch (Exception ex)
            {

                throw;
            }


        }
        [HttpGet]
        [Route("GetAll")]
        public List<Student> GetAll()
        {
            try
            {
                return this.studentBLLManager.GetAll();
            }
            catch (Exception ex)
            {

                throw;
            }


        }
        [HttpPost]
        [Route("UpdateStudent")]
        public int UpdateStudent([FromBody]TempMessage message)
        {
            try
            {
                Student student = JsonConvert.DeserializeObject<Student>(message.ToString());
                this.studentBLLManager.UpdateStudent(student);
                return 1;

            }
            catch(Exception ex)
            {
                throw;
            }
        }
        [HttpPost]
        [Route("GetById")]
        public Student GetById([FromBody]TempMessage message)
        {
            try
            {
                Student student = JsonConvert.DeserializeObject<Student>(message.Content.ToString());
                return this.studentBLLManager.GetStudentId(student);
                

            }
            catch(Exception ex)
            {
                throw;
            }

        }
    }
}