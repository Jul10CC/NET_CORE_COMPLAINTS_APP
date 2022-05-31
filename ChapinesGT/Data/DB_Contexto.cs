using M04_SLN_APP_04_NET_CORE_LOGIN.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M04_SLN_APP_04_NET_CORE_LOGIN.Data
{
    public class DB_Contexto : DbContext
    {
        public DB_Contexto(DbContextOptions<DB_Contexto> options) : base(options)
        {

        }

        public DbSet<Usuario> Usuario { get; set; }
    }
}
