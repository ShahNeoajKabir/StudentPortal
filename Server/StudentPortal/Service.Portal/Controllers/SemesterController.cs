﻿using System;
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
    [Route("api/Semester")]
    [ApiController]
    public class SemesterController : ControllerBase
    {
        private readonly ISemesterBLLManager semesterBLLManager;
        public SemesterController(ISemesterBLLManager semesterBLLManager)
        {
            this.semesterBLLManager = semesterBLLManager;

        }
        [HttpPost]
        [Route("AddSemester")]
        public int AddSemester([FromBody]TempMessage message)
        {
            try
            {
                Semester semester = JsonConvert.DeserializeObject<Semester>(message.Content.ToString());
                this.semesterBLLManager.AddSemester(semester);
                return 1;

            }
            catch(Exception ex)
            {
                throw;
            }
        }
        [HttpGet]
        [Route("GetAll")]
        public List<Semester> GetAll()
        {
            try
            {
                return this.semesterBLLManager.GetAll();
            }
            catch (Exception ex)
            {

                throw;
            }


        }
        [HttpPost]
        [Route("UpdateSemester")]
        public int UpdateSemester([FromBody]TempMessage message)
        {
            try
            {
                Semester semester = JsonConvert.DeserializeObject<Semester>(message.Content.ToString());
                this.semesterBLLManager.UpdateSemester(semester);
                return 1;

            }
            catch(Exception ex)
            {
                throw;
            }
        }
        [HttpPost]
        [Route("GetById")]
        public Semester GetById([FromBody]TempMessage message)
        {
            try
            {
                Semester semester = JsonConvert.DeserializeObject<Semester>(message.Content.ToString());
                return this.semesterBLLManager.GetSemesterById(semester);
                 

            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}