using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

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