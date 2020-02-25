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
        public int AddRoutine([FromBody]object objuser)
        {
            try
            {
                Routine routine = JsonConvert.DeserializeObject<Routine>(objuser.ToString());
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
        public int UpdateRoutine([FromBody]object objroutine)
        {
            try
            {
                Routine routine = JsonConvert.DeserializeObject<Routine>(objroutine.ToString());
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
        public int GetById([FromBody]object objroutine)
        {
            try
            {
                Routine routine = JsonConvert.DeserializeObject<Routine>(objroutine.ToString());
                this.routineBLLManager.GetRoutineById(routine);
                return 1;

            }
            catch(Exception ex)
            {
                throw;
            }
        }

    }
}