using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NBG.Visitor.Storage.Models;

namespace NBG.Visitor.Services.DB
{
    public class VisitContext : DbContext
    {
        public DbSet<Storage.Models.Visitor> Visitors {  get; set; }
        public DbSet<Visit> Visits { get; set; }

        public VisitContext(DbContextOptions<VisitContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasPostgresExtension("uuid-ossp");

            builder.Entity<Visit>()
                .Property(e => e.Status)
                .HasConversion(
                    v => v.ToString(),
                    v => Enum.Parse<VisitStatus>(v)
                );
            builder.Entity<Visit>()
                .Property(e => e.Guid)
                .HasDefaultValueSql("uuid_generate_v4()");
        }
    }
}
