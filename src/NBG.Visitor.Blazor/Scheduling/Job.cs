using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBG.Visitor.Blazor.Scheduling
{
    public class Job : IJob
    {
        public Type Type { get; }
        public string Expression { get; }
        public Job(Type type, string expression)
        {
            Type = type;
            Expression = expression;
        }

        public Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine("Execute at " + DateTime.Now.ToString());
            return Task.CompletedTask;
        }
    }
}
