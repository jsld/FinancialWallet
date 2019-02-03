using DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using FinancialWallet.Messages;

namespace FinancialWallet.Controller
{
    public class SaveController
    {
        public static ResponseEntity GetLastEntidad()
        {
            var response = new ResponseEntity
            {
                IsValid = false
            };

            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    response.Entidad = context.EntidadRepositorio.Last();
                    response.IsValid = true;
                }
            }
            catch(Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public static ResponseEntity GetEntidadByCode(string code)
        {
            var response = new ResponseEntity
            {
                IsValid = false
            };

            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    response.Entidad = context.EntidadRepositorio.Single(x => x.Codigo == code);
                    response.IsValid = true;
                }
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }


    }
}
