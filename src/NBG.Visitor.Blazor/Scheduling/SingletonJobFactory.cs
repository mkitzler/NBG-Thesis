using Quartz;
using Quartz.Spi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBG.Visitor.Blazor.Scheduling
{
    public class SingletonJobFactory : IJobFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public SingletonJobFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            Console.WriteLine("NewJob at " + DateTime.Now.ToString());
            return _serviceProvider.GetService(bundle.JobDetail.JobType) as IJob;

        }

        public void ReturnJob(IJob job)
        {
            throw new NotImplementedException();
        }
    }
}
