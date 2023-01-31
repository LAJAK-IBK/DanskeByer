using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DanskeByer.Models;

namespace DanskeByer.Data
{
    public class CityContext : DbContext
    {
        public CityContext (DbContextOptions<CityContext> options)
            : base(options)
        {
        }

        public DbSet<DanskeByer.Models.City> City { get; set; }
    }
}
