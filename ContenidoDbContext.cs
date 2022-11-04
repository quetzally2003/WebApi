using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Wuetzally.Models;

namespace Wuetzally
{
    public class ContenidoDbContext : DbContext
    {
        public ContenidoDbContext(DbContextOptions options) : base (options)
    {


    }
        public DbSet<Alumnos> Alumnos { get; set;}
        
    }    
    
}
