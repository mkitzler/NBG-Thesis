using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using NBG.Visitor.Services.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBG.Visitor.Storage
{
    public class VisitContextDesignTimeFactory : IDesignTimeDbContextFactory<VisitContext>
    {
        public VisitContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<VisitContext>();
            optionsBuilder.UseNpgsql("Host=nbg.ftp.sh;Database=nbg;Username=nbg;Password=nbg1234");

            return new VisitContext(optionsBuilder.Options);
        }
    }
}
