using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LojaInterativa.Models;

namespace LojaInterativa.Data
{
    public class LojaInterativaContext : DbContext
    {
        public LojaInterativaContext (DbContextOptions<LojaInterativaContext> options)
            : base(options)
        {
        }

        public DbSet<Fabricante> Fabricante { get; set; } = default!;
        public DbSet<Produto> Produto { get; set; } = default!;
    }
}
