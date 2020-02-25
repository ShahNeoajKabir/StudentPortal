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
    [Route("api/Course")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseBLLManager courseBLLManager;
        public CourseController(ICourseBLLManager courseBLLManager)
        {
            this.courseBLLManager = courseBLLManager;
        }
        [HttpPost]
        [Route("AddCourse")]
        public int AddCourse([FromBody]object objCourse)
        {
            try
            {
                Course course= JsonConvert.DeserializeObject<Course>(objCourse.ToString());
                this.courseBLLManager.AddCourse(course);
                return 1;

            }
            catch(Exception ex)
            {
                throw;
            }
        }
        [HttpGet]
        [Route("GetAll")]
        public List<Course> GetAll()
        {
            try
            {
                return this.courseBLLManager.GetAll();
            }
            catch (Exception ex)
            {

                throw;
            }


        }
        [HttpPost]
        [Route("UpdateCourse")]
        public int UpdateCourse([FromBody]object objcourse)
        {
            try
            {
                Course course = JsonConvert.DeserializeObject<Course>(objcourse.ToString());
                this.courseBLLManager.GetCourseById(course);
                return 1;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        [HttpPost]
        [Route("GetById")]
        public int GetById([FromBody]object objcourse)
        {
            try
            {
                Course course = JsonConvert.DeserializeObject<Course>(objcourse.ToString());
                this.courseBLLManager.GetCourseById(course);
                return 1;

            }
            catch(Exception ex)
            {
                throw;
            }
        }

    }
}