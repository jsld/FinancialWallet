using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() :
            base(new SQLiteConnection()
            {
                ConnectionString = new SQLiteConnectionStringBuilder()
                {
                    DataSource = "D:\\Desarrollo\\FW\\FinancialWallet\\BBDD\\bbdd.db",
                    ForeignKeys = true
                }.ConnectionString
            }, true)
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<MasterData> MasterDataRepositorio { get; set; }
        public DbSet<MasterType> MasterTypeRepositorio { get; set; }
        public DbSet<Entidad> EntidadRepositorio { get; set; }
        public DbSet<Contacto> ContactoRepositorio { get; set; }
    }
}
