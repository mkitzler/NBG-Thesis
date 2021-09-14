using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NBG.Visitor_Registration.Shared.Models;

namespace NBG.Visitor_Registration.Server.ModelContexts
{
    public class VisitorContext : DbContext, IDataContext
    {
        public VisitorContext(DbContextOptions<VisitorContext> options) : base(options)
        {

        }

        public DbSet<Visitor> Visitors { get; set; }
    }
}
