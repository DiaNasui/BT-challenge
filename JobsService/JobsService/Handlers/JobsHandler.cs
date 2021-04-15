using JobsDataAccess;
using JobsService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobsService.Handlers
{
    public class JobsHandler
    {
        private JobsRepository jobsRepository = new JobsRepository();

        public IEnumerable<Tasks> GetJobs()
        {
            return jobsRepository.GetJobs();
        }

        public Tasks GetJobById(int id)
        {
            return jobsRepository.GetJobById(id);
        }

        public bool Init(Tasks task)
        {
            return jobsRepository.Init(task);
        }

        public bool Confirm(int id)
        {
            return jobsRepository.Confirm(id);
        }

        public bool Reject(int id)
        {
            return jobsRepository.Reject(id);
        }
    }
}