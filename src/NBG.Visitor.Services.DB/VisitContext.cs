using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NBG.Visitor.Services.DB.Models;

namespace NBG.Visitor.Services.DB
{
    class VisitContext : DbContext
    {
        public DbSet<Company> Companies {  get; set; }
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
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=nbg.ftp.sh;Database=nbg;Username=nbg;Password=nbg1234");
    }
}
