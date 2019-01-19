using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using FinancialWallet.Resources;
using Database;

namespace FinancialWallet.Views
{
    /// <summary>
    /// Lógica de interacción para AddEmpresaView.xaml
    /// </summary>
    public partial class AddEmpresaView : UserControl
    {
        public AddEmpresaView()
        {
            InitializeComponent();
        }

        private void CrearEmpresa_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int typeId = Convert.ToInt32((string)((ComboBoxItem)CBAddEmpresaType.SelectedItem).Tag);
                var name = TBAddEmpresaName.Text;
                var code = TBAddEmpresaCode.Text;
                if (typeId != 0 && name != string.Empty && code != string.Empty)
                {
                    AddNewEmpresaRow(typeId,name,code);
                }
                else
                {
                    MessageBox.Show("Error: Verifique nombre, tipo y código de la entidad.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: No se pudo realizar guardado de nueva entridad.\n\n" + ex.Message);
            }
        }

        private void GenerarCodigo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int typeId = Convert.ToInt32((string)((ComboBoxItem)CBAddEmpresaType.SelectedItem).Tag);
                string name = TBAddEmpresaName.Text;
                if (typeId != 0 && name != string.Empty)
                {
                    string type = (string)((ComboBoxItem)CBAddEmpresaType.SelectedItem).Content;
                    Empresa empresa = GetLastEmpresa();
                    int id = empresa is null ? 0 : empresa.Id;
                    var codigoEmpresa = SetCodeForEmpresa(type, name, id + 1);
                    TBAddEmpresaCode.Text = codigoEmpresa;
                }
                else
                {
                    MessageBox.Show("Error: Verifique nombre y tipo de la entidad.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Verifique nombre y tipo de la entidad.\n\n"+ex.Message);
            }
        }

        private void CancelarEmpresa_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Se cancelará la creación de nueva Entidad.");
            var tabControl = ((TabControl)((TabItem)AddEmpresaPartial.Parent).Parent);
            foreach (TabItem item in tabControl.Items)
            {
                item.IsEnabled = true;
            }
            BtnCancel.IsEnabled = false;
            BtnCancel.Visibility = Visibility.Hidden;
            InfoEditEmpresa.Visibility = Visibility.Hidden;
            TBAddEmpresaName.Text = string.Empty;
            CBAddEmpresaType.SelectedIndex = 0;
        }

        private void BorrarEmpresa_Click(object sender, RoutedEventArgs e)
        {
            var name = ((TextBox)((Grid)((Button)sender).Parent).Children[1]).Text;
            MessageBox.Show("Se Borrará la empresa " + name);
        }

        private void BtnCancelAppear(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (!BtnCancel.IsEnabled)
            {
                var tabControl = ((TabControl)((TabItem)AddEmpresaPartial.Parent).Parent);
                foreach (TabItem item in tabControl.Items)
                {
                    item.IsEnabled = false;
                }
                BtnCancel.IsEnabled = true;
                BtnCancel.Visibility = Visibility.Visible;
                InfoEditEmpresa.Visibility = Visibility.Visible;
            }
        }

        #region Metodos Privados Vista
        private void AddNewEmpresaRow(
            int id,
            string name,
            string code)
        {
            Border border = new Border
            {
                BorderBrush = (SolidColorBrush)new BrushConverter()
                    .ConvertFrom("#FF252A30"),
                BorderThickness = new Thickness(1, 1, 1, 1)
            };
            Grid grid = new Grid();
            grid.RowDefinitions.Add(new RowDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition
            {
                Width = new GridLength(100)
            });
            grid.ColumnDefinitions.Add(new ColumnDefinition
            {
                Width = new GridLength(40, GridUnitType.Star)
            });
            grid.ColumnDefinitions.Add(new ColumnDefinition
            {
                Width = new GridLength(100)
            });
            grid.ColumnDefinitions.Add(new ColumnDefinition
            {
                Width = new GridLength(80)
            });

            TextBox idEmpresa = new TextBox
            {
                Text = id.ToString(),
                Name = "TBEmpresaId",
                IsEnabled = false,
                Margin = new Thickness(10)
            };
            Grid.SetColumn(idEmpresa, 0);
            Grid.SetRow(idEmpresa, 0);

            TextBox nameEmpresa = new TextBox
            {
                Text = name,
                Name = "TBEmpresaName",
                IsEnabled = false,
                Margin = new Thickness(10)
            };
            Grid.SetColumn(nameEmpresa, 1);
            Grid.SetRow(nameEmpresa, 0);

            TextBox codeEmpresa = new TextBox
            {
                Text = code,
                Name = "TBEmpresaCode",
                IsEnabled = false,
                Margin = new Thickness(10)
            };
            Grid.SetColumn(codeEmpresa, 2);
            Grid.SetRow(codeEmpresa, 0);

            Button btnDelete = new Button
            {
                Style = (Style)FindResource("DangerButton"),
                Content = "Borrar",
                Name = "TBEmpresaDelete",
                Margin = new Thickness(10)
            };
            btnDelete.Click += new RoutedEventHandler(BorrarEmpresa_Click);

            Grid.SetColumn(btnDelete, 3);
            Grid.SetRow(btnDelete, 0);

            grid.Children.Add(idEmpresa);
            grid.Children.Add(nameEmpresa);
            grid.Children.Add(codeEmpresa);
            grid.Children.Add(btnDelete);

            border.Child = grid;

            empresasPanel.Children.Add(border);
        }
        #endregion

        #region Metodos Privados Base Datos
        private Empresa GetLastEmpresa()
        {
            var response = new Empresa();
            using (MyDatabaseContext dbContext = new MyDatabaseContext())
            {
                response = dbContext.Empresas.LastOrDefault();
            }
            return response;
        }
        #endregion

        #region Metodos Privados Business
        private string SetCodeForEmpresa(string type, string name, int id)
        {
            string code = string.Empty;
            if (type == GlobalValues.CODE_EMPRESA)
            {
                code = "E" + id.ToString() + name.First().ToString();
            }
            else
            {
                code = "P" + id.ToString() + name.First().ToString();
            }
            return code;
        }
        #endregion
    }
}