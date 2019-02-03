using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialWallet.Resources
{
    public class GlobalValues
    {
        public const string EMPRESA = "EMPRESA";

        public const string PROVEEDOR = "PROVEEDOR";
        
        public const string PERSONA = "PERSONA";

        public static string ENTIDAD
        {
            get { return "ENTIDAD"; }
        }

        public static string CODE_EMPRESA
        {
            get { return "EE"; }
        }

        public static string CODE_PROVEEDOR
        {
            get { return "PVD"; }
        }

        public static string CODE_PERSONA
        {
            get { return "PP"; }
        }
    }
}