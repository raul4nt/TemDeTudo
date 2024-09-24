using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TemDeTudo.Models;

namespace TemDeTudo.Data
{
    public class TemDeTudoContext : DbContext
    {
        public TemDeTudoContext (DbContextOptions<TemDeTudoContext> options)
            : base(options)
        {
        }

        public DbSet<TemDeTudo.Models.Product> Product { get; set; } = default!;
    }
}
