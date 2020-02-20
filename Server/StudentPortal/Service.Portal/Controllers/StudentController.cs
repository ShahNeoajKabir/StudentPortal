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
        public int AddStudent([FromBody]object objstudent)
        {
            try
            {
                Student student = JsonConvert.DeserializeObject<Student>(objstudent.ToString());
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
        [HttpGet]
        [Route("Gets")]

        public string Gets()
        {

            return "hello";
        }
    }
}