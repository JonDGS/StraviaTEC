using Microsoft.EntityFrameworkCore;
using StraviaTECRestFullAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StraviaTECRestFullAPI.DataAccess
{
    public class PostgreSqlContext : DbContext
    {
        public PostgreSqlContext(DbContextOptions<PostgreSqlContext> options) : base(options)
        {
        }
        public DbSet<Organizer> organizers { get; set; }
        public DbSet<Athlete> athletes { get; set; }
        public DbSet<OnlineUser> onlineusers { get; set; }
        public DbSet<Race> race { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Athlete>().HasKey(a => new { a.id, a.username });
            builder.Entity<Organizer>().HasKey(o => new { o.id, o.username });
            base.OnModelCreating(builder);
        }
        

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }
    }
}
