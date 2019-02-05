using DataBase;
using FinancialWallet.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FinancialWallet.Controller
{
    public class ViewController
    {
        #region TAB AGREGAR ENTIDAD
        public static void FillComboboxEntity(ComboBox CBAddEmpresaType)
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    var resultCombo = context.MasterDataRepositorio
                    .Select(x => new { x.MasterDataId, x.Texto, x.MasterType })
                    .Where(x => x.MasterType.Codigo == GlobalValues.ENTIDAD);
                    foreach (var item in resultCombo)
                    {
                        CBAddEmpresaType.Items.Add(new ComboBoxItem
                        {
                            Tag = item.MasterDataId,
                            Content = item.Texto
                        });
                    }
                    CBAddEmpresaType.Items.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion


    }
}
