using Microsoft.EntityFrameworkCore;
using PaymentSystem.Data.Entities;

namespace PaymentSystem.Data.DBContext
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
            

        }

        public DbSet<Users> Users { get; set; }
    }
}
