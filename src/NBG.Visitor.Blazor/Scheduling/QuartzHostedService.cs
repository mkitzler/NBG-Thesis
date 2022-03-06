using System;
using System.Collections.Generic;
using Microsoft.Extensions.Hosting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NBG.Visitor.Blazor.Scheduling;
using Quartz;
using Quartz.Spi;
using System.Threading;

namespace NBG.Visitor.Blazor.Scheduling
{
    public class QuartzHostedService : IHostedService
    {
        private readonly ISchedulerFactory _schedulerFactory;
        private readonly IJobFactory _jobFactory;
        private readonly IEnumerable<Job> _jobs;
        
        public QuartzHostedService(ISchedulerFactory schedulerFactory,
                                   IJobFactory jobFactory,
                                   IEnumerable<Job> jobs)
        {
            _schedulerFactory = schedulerFactory;
            _jobFactory = jobFactory;
            _jobs = jobs;
        }

        public IScheduler Scheduler { get; set; }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("StartAsync at " + DateTime.Now.ToString());

            Scheduler = await _schedulerFactory.GetScheduler(cancellationToken);
            Scheduler.JobFactory = _jobFactory;
            foreach (var _job in _jobs)
            {
                var job = CreateJob(_job);
                var trigger = CreateTrigger(_job);
                await Scheduler.ScheduleJob(job, trigger, cancellationToken);
            }
            await Scheduler.Start(cancellationToken);
        }

        private IJobDetail CreateJob(Job job)
        {
            var type = job.Type;
            return JobBuilder.Create(type).WithIdentity(type.FullName).WithDescription(type.Name).Build();
        }

        private ITrigger CreateTrigger(Job job)
        {
            return TriggerBuilder.Create().WithIdentity($"{job.Type.FullName}.trigger").WithCronSchedule(job.Expression).WithDescription(job.Expression).Build();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("StopAsync at " + DateTime.Now.ToString());
            return Scheduler?.Shutdown(cancellationToken);
        }
    }
}
