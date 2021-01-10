using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proiect_Muresan_Andrei_Cristian.Models;

namespace Proiect_Muresan_Andrei_Cristian.Data
{
    public class Proiect_Muresan_Andrei_CristianContext : DbContext
    {
        public Proiect_Muresan_Andrei_CristianContext (DbContextOptions<Proiect_Muresan_Andrei_CristianContext> options)
            : base(options)
        {
        }

        public DbSet<Proiect_Muresan_Andrei_Cristian.Models.Game> Game { get; set; }

        public DbSet<Proiect_Muresan_Andrei_Cristian.Models.Publisher> Publisher { get; set; }

        public DbSet<Proiect_Muresan_Andrei_Cristian.Models.Genre> Genre { get; set; }
    }
}
