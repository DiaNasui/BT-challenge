using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using ConsoleJobsProcessing.Handlers;

namespace ConsoleJobsProcessing
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskHttpClient client = new TaskHttpClient();

            client.RunAsync().GetAwaiter().GetResult();
        }
  
    }
}
