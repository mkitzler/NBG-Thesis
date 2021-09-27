using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VisitorService.Models;

namespace VisitorService.ModelContexts
{
    public interface IAppDbContext
    {
        DbSet<Visitor> Visitors { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
