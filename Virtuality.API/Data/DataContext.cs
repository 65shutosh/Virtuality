

using Microsoft.EntityFrameworkCore;
using Virtuality.API.Models;

namespace Virtuality.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}

        public DbSet<Value> Values {get ; set ;}
    }
}