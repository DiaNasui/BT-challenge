using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleJobsProcessing.Handlers
{
    public class TaskHttpClient
    {
        static HttpClient client = new HttpClient();
        static EmailManager emailManager = new EmailManager();

        static async Task<List<ConsoleJobsProcessing.Models.Task>> GetTasks()
        {
            List<ConsoleJobsProcessing.Models.Task> tasks = new List<ConsoleJobsProcessing.Models.Task>();
            var action = $"GetJobs";
            var request = client.GetAsync(action);
            var response = request.Result.Content.ReadAsAsync<List<ConsoleJobsProcessing.Models.Task>>();
            tasks.AddRange(response.Result);
            return tasks;
        }

        static async Task<bool> ConfirmIsProccessedTask(int id)
        {
            var action = $"Confirm?id={id}";
            var request = client.GetAsync(action);
            var response = request.Result.Content.ReadAsAsync<bool>();
            return response.Result;
        }

        public async Task RunAsync()
        {
            client.BaseAddress = new Uri("https://localhost:44304/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                List<ConsoleJobsProcessing.Models.Task> tasks = await GetTasks();
                foreach (var task in tasks)
                {
                    if (!task.TaskIsProcessed)
                    {
                        emailManager.SendEmail(task.TaskName, task.TaskDescription);
                        bool confirmIsSent = await ConfirmIsProccessedTask(task.TaskID);
                        if (confirmIsSent)
                        {
                            Console.WriteLine("Notification sent : " + DateTime.Now);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Notification already sent : " + task.TaskProcessedDate);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
