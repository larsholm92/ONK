using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Backend.Model;

namespace Backend.Models
{
    public class BackendContext : DbContext
    {
        public BackendContext (DbContextOptions<BackendContext> options)
            : base(options)
        {
        }

        public DbSet<Backend.Model.Owner> Owner { get; set; }

        public DbSet<Backend.Model.Portfolio> Portfolio { get; set; }

        public DbSet<Backend.Model.StockBundle> StockBundle { get; set; }

        public DbSet<Backend.Model.Stock> Stock { get; set; }
    }
}
