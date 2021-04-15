using JobsDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobsService.Repositories
{
    public class JobsRepository
    {
        public IEnumerable<Tasks> GetJobs()
        {
            using (JobsDBEntities entities = new JobsDBEntities())
            {
                return entities.tasks.ToList();
            }
        }

        public Tasks GetJobById(int id)
        {
            using (JobsDBEntities entities = new JobsDBEntities())
            {
                return entities.tasks.Where(t => t.TaskID == id).FirstOrDefault();
            }
        }

        public bool Init(Tasks task)
        {
            bool result = false;

            using (JobsDBEntities entities = new JobsDBEntities())
            {
                if (task != null)
                {
                    entities.tasks.Add(task);
                    entities.SaveChanges();

                    result = true;
                }
            }
            return result;
        }

        public bool Confirm(int id)
        {
            bool result = false;

            using (JobsDBEntities entities = new JobsDBEntities())
            {
                var task = this.GetJobById(id);
                if(task != null && task.TaskIsProcessed == false)
                {
                    entities.Entry(task).State = System.Data.Entity.EntityState.Modified;
                    task.TaskIsProcessed = true;
                    task.TaskProcessedDate = DateTime.Now;

                    entities.SaveChanges();
                    result = true;
                }
            }
            return result;
        }

        public bool Reject(int id)
        {
            bool result = false;

            using (JobsDBEntities entities = new JobsDBEntities())
            {
                var task = this.GetJobById(id);
                if (task != null && task.TaskIsProcessed == true)
                {
                    entities.Entry(task).State = System.Data.Entity.EntityState.Modified;
                    task.TaskIsProcessed = false;
                    task.TaskProcessedDate = DateTime.Now;

                    entities.SaveChanges();
                    result = true;
                }              
            }
            return result;
        }


    }
}