using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Models
{
    public class WebApplication1Context : DbContext
    {
        public WebApplication1Context (DbContextOptions<WebApplication1Context> options)
            : base(options)
        {
        }

        public DbSet<Departments> Departments { get; set; } = default!;

        public DbSet <Seller> Seller { get; set; }
        public DbSet <SalesRecord> SalesRecord { get; set; }
    }
}
