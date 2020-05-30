

using Microsoft.EntityFrameworkCore;
using Virtuality.API.Models;

namespace Virtuality.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }


        public DbSet<User> Users { get; set; }
    
        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Purchase> Purchases { get; set; }

        public DbSet<Feedback> feedbacks { get; set; }

        public DbSet<Video> Videos { get; set; }
    }

}