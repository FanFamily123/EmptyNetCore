using Quartz;
using Swift.BBS.Common.Helper;
using System;
using System.Threading.Tasks;

namespace Swift.BBS.Api.Jobs
{
    [DisallowConcurrentExecution]
    public class TexJob : IJob
    {
     //   private LoggerHelper _logHelper;

        //public TexJob(LoggerHelper logHelper)
        //{
        //    _logHelper = logHelper;
        //    Console.WriteLine("初始化类");
        //}


        public TexJob()
        {
            
            Console.WriteLine("初始化类");
        }

        public Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine("job打印");
          //  _logHelper.Debug("12345643");
            return Task.CompletedTask;
        }



    }
}
