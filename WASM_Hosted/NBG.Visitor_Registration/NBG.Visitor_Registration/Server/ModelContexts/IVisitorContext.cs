using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NBG.Visitor_Registration.Shared.Models;

namespace NBG.Visitor_Registration.Server.ModelContexts
{
    public interface IVisitorContext
    {
        DbSet<Visitor> Visitors { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
