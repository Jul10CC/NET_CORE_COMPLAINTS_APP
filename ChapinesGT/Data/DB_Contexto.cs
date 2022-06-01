using ChapinesGT.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChapinesGT.Data
{
    public class DB_Contexto : DbContext
    {
        public DB_Contexto(DbContextOptions<DB_Contexto> options) : base(options)
        {

        }

        public DbSet<Comercio> Comercio { get; set; }
        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<Municipio> Municipio { get; set; }
        public DbSet<Queja> Queja { get; set; }
        public DbSet<Region> Region { get; set; }
        public DbSet<Sucursal> Sucursal { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

    }
}
