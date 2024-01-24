using Microsoft.EntityFrameworkCore;
using order_api.Entities;

namespace order_api.Contexts
{
    public class DBContext: DbContext
    {
        public DBContext(DbContextOptions options) : base(options)
        {
            
        }
        
        public DbSet<Order> Orders { get; set; }
    }
}

