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
        public DbSet<HistorialTarjetaCredito> HistorialTarjetasCredito { get; set; }
        public DbSet<Tarjetas> Tarjetas { get; set; }
        public DbSet<MasterData> MasterData { get; set; }
        public DbSet<MasterType> MasterType { get; set; }
        public DbSet<Pagos> Pagos { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<Transaccion> Transacciones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=MyDatabase.sqlite");
        }
        
    }
}
