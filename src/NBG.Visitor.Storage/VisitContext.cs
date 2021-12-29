using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NBG.Visitor.Storage.Models;

namespace NBG.Visitor.Services.DB
{
    public class VisitContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<ContactPerson> ContactPeople { get; set; }
        public DbSet<Storage.Models.Visitor> Visitors {  get; set; }
        public DbSet<Visit> Visits { get; set; }

        public VisitContext(DbContextOptions<VisitContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Company>(entity => {
                entity.HasIndex(e => e.CompanyLabel).IsUnique();
            });

            builder.Entity<ContactPerson>(entity => {
                entity.HasIndex(e => e.Name).IsUnique();
            });

            builder.Entity<Visit>()
                .Property(e => e.Status)
                .HasConversion(
                    v => v.ToString(),
                    v => Enum.Parse<VisitStatus>(v)
                );
        }
    }
}
