using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NBG.Visitor.Storage.Models;

namespace NBG.Visitor.Storage
{
    public class VisitContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<ContactPerson> ContactPeople { get; set; }
        public DbSet<Models.Visitor> Visitors {  get; set; }
        public DbSet<Visit> Visits { get; set; }

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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=nbg.ftp.sh;Database=nbg;Username=nbg;Password=nbg1234");
    }
}
