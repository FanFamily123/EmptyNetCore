using Quartz;
using System;
using System.Threading.Tasks;

namespace Swift.BBS.Api.Jobs
{
    [DisallowConcurrentExecution]
    public class TexJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine("job打印");
            return Task.CompletedTask;
        }



    }
}
