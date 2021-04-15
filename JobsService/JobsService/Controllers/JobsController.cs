using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using JobsDataAccess;
using JobsService.Handlers;

namespace JobsService.Controllers
{
    public class JobsController : ApiController
    {
        private JobsHandler jobsHandler = new JobsHandler();

        [HttpGet]
        [Route("GetJobs")]
        public IEnumerable<Tasks> GetJobs()
        {
            return jobsHandler.GetJobs();
        }


        [HttpGet]
        [Route("GetJobById")]
        public Tasks GetJobById(int id)
        {
            return jobsHandler.GetJobById(id);
        }

        [HttpPost]
        [Route("Init")]
        public bool Init([FromBody] Tasks task)
        {
            return jobsHandler.Init(task);
        }

        [HttpGet]
        [Route("Confirm")]
        public bool Confirm(int id)
        {
            return jobsHandler.Confirm(id);
        }

        [HttpGet]
        [Route("Reject")]
        public bool Reject(int id)
        {
            return jobsHandler.Reject(id);
        }
    }
}
