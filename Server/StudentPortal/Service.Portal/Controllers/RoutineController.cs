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
    [Route("api/Routine")]
    [ApiController]
    public class RoutineController : ControllerBase
    {
        private readonly IRoutineBLLManager routineBLLManager;
        public RoutineController(IRoutineBLLManager routineBLLManager)
        {
            this.routineBLLManager = routineBLLManager;

        }
        [HttpPost]
        [Route("AddRoutine")]
        public int AddRoutine([FromBody]TempMessage message)
        {
            try
            {
                Routine routine = JsonConvert.DeserializeObject<Routine>(message.Content.ToString());
                this.routineBLLManager.AddRoutine(routine);
                return 1;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        [HttpGet]
        [Route("GetAll")]
        public List<Routine> GetAll()
        {
            try
            {
                return this.routineBLLManager.GetAll();
            }
            catch (Exception ex)
            {

                throw;
            }


        }
        [HttpPost]
        [Route("UpdateRoutine")]
        public int UpdateRoutine([FromBody]TempMessage message)
        {
            try
            {
                Routine routine = JsonConvert.DeserializeObject<Routine>(message.Content.ToString());
                this.routineBLLManager.UpdateRoutine(routine);
                return 1;

            }
            catch(Exception ex)
            {
                throw;
            }
        }
        [HttpPost]
        [Route("GetById")]
        public Routine GetById([FromBody]TempMessage message)
        {
            try
            {
                Routine routine = JsonConvert.DeserializeObject<Routine>(message.Content.ToString());
                return this.routineBLLManager.GetRoutineById(routine);
                

            }
            catch(Exception ex)
            {
                throw;
            }
        }

    }
}