using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace UserAPI.Models.Context
{
    public class UserContext:DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {

        }
        public DbSet<UserDetail>? UserDetails { get; set; }
        public DbSet<Traveller>? Travellers { get; set; }
        public DbSet<TravelAgent>? TravelAgents { get; set; }
        public DbSet<User>? Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserDetail>().Property(ud => ud.UserId).ValueGeneratedNever();
            modelBuilder.Entity<TravelAgent>().Property(ta => ta.TravelAgentId).ValueGeneratedNever();
            modelBuilder.Entity<Traveller>().Property(t => t.TravellerId).ValueGeneratedNever();
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique(true);
        }
    }
}
