using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NBG.Visitor.Domain;
using Microsoft.AspNetCore.Components;

namespace NBG.Visitor.Blazor.Scheduling
{
    public class DeleteOldVisitorsJob : IJob
    {
        IVisitService DataRepository { get; set; }
        public DeleteOldVisitorsJob() { }

        public DeleteOldVisitorsJob(IVisitService vs)
        {
            DataRepository = vs;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            await DataRepository.RemoveOldVisits();
            Console.WriteLine("RemoveOldVisits executed at " + DateTime.Now.ToString());
        }
    }
}
