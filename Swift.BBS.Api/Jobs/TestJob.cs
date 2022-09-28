using Quartz;
using System;
using System.Threading.Tasks;

namespace Swift.BBS.Api.Jobs
{
    public class TestJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine("Testjob打印");
            Console.ReadLine();
            return Task.CompletedTask;
        }
    }
}
