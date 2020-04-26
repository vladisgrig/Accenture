using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accenture.Data
{
    public class AccentureDbContext : DbContext
    {

        public AccentureDbContext(DbContextOptions<AccentureDbContext> options)
    : base(options)
        {
        }

        public DbSet<Operation> Operations { get; set; }

        public DbSet<SubOrder> SubOrders { get; set; } 
    }
}
