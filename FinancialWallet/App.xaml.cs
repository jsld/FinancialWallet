using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using DataBase;

namespace FinancialWallet
{
    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            SQLitePCL.Batteries.Init();
            //SQLitePCL.raw.SetProvider();
            //{ "You need to call .  If you are using a bundle package, this is done by calling ."}
            //using (MyDatabaseContext dbContext = new MyDatabaseContext())
            //{
            //    dbContext.Database.Migrate();
            //}
        }
    }
}
