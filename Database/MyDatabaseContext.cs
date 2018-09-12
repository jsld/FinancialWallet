using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class MyDatabaseContext : DbContext
    {
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<HistorialTarjetaCredito> HistorialTarjetaCreditos { get; set; }
        public DbSet<MasterData> MasterDatas { get; set; }
        public DbSet<MasterState> MasterStates { get; set; }
        public DbSet<MasterType> MasterTypes { get; set; }
        public DbSet<Pagos> Pagos { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<Transaccion> Transacciones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=MyDatabase.sqlite");
        }
        
    }
}
