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
    [Route("api/Parents")]
    [ApiController]
    public class ParentsController : ControllerBase
    {
        private readonly IParentsBLLManager parentsBLLManager;
        public ParentsController(IParentsBLLManager parentsBLLManager)
        {
            this.parentsBLLManager = parentsBLLManager;
        }
        [HttpPost]
        [Route("AddParents")]
        public int AddParent([FromBody]TempMessage message)
        {
            try
            {
                Parents parents = JsonConvert.DeserializeObject<Parents>(message.Content.ToString());
                this.parentsBLLManager.AddParents(parents);
                return 1;
            }
            catch (Exception ex)
            {

                throw;
            }


        }
        [HttpGet]
        [Route("GetAll")]
        public List<Parents> GetAll()
        {
            try
            {
                return this.parentsBLLManager.GetAll();
            }
            catch (Exception ex)
            {

                throw;
            }


        }
        [HttpPost]
        [Route("UpdateParents")]
        public int UpdateParents([FromBody]TempMessage message)
        {
            try
            {
                Parents parents = JsonConvert.DeserializeObject<Parents>(message.Content.ToString());
                this.parentsBLLManager.UpdateParents(parents);
                return 1;

            }
            catch(Exception ex)
            {
                throw;
            }
            
        }
        [HttpPost]
        [Route("GetById")]
        public Parents GetById([FromBody]TempMessage message)
        {
            try
            {
                Parents parents = JsonConvert.DeserializeObject<Parents>(message.Content.ToString());
                return this.parentsBLLManager.GetParentsById(parents);
                
            }
            catch(Exception ex)
            {
                throw;
            }
        }

    }
}