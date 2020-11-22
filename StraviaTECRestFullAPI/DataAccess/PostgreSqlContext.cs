using Microsoft.EntityFrameworkCore;
using StraviaTECRestFullAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StraviaTECRestFullAPI.DataAccess
{
    /*
     * Description:This class is where all the DB config is placed.
    */
      
    public class PostgreSqlContext : DbContext
    {
        public PostgreSqlContext(DbContextOptions<PostgreSqlContext> options) : base(options)
        {
        }
        public DbSet<Organizer> organizers { get; set; }
        public DbSet<Athlete> athletes { get; set; }
        public DbSet<OnlineUser> onlineusers { get; set; }
        public DbSet<Race> race { get; set; }

        public DbSet<Follows> follows { get; set; }

        public DbSet<AthleteEnrollsChallenge> athleteenrollschallenges { get; set; }

        public DbSet<AthleteEnrollsRace> athleteenrollsraces { get; set; }

        public DbSet<Activity> activity {get; set;}
        public DbSet<ActivityType> activity_type{get; set;}
        public DbSet<Group> groups { set; get; }
        public DbSet<RaceSponsorship> racehassponsor { get; set; }

        public DbSet<ChallengeSponsorship> challengehassponsor { get; set; }
        public DbSet<Challenge> challenge { get; set; }
        public DbSet<AthleteBelongsGroup> athletebelongsgroup { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Athlete>().HasKey(a => new { a.id, a.username });
            builder.Entity<Organizer>().HasKey(o => new { o.id, o.username });
            builder.Entity<Race>().Property(r => r.id_race).ValueGeneratedOnAdd();
            base.OnModelCreating(builder);

        }
        

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }
    }
}
