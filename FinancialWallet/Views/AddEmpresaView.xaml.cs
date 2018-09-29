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
            AddNewEmpresaRow();
        }

        #region Metodos Privados Vista
        private void AddNewEmpresaRow()
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
                Text = "ID",
                Name = "TBEmpresaId",
                IsEnabled = false,
                Margin = new Thickness(10)
            };
            Grid.SetColumn(idEmpresa, 0);
            Grid.SetRow(idEmpresa, 0);

            TextBox nameEmpresa = new TextBox
            {
                Text = TBAddEmpresaName.Text,
                Name = "TBEmpresaName",
                IsEnabled = false,
                Margin = new Thickness(10)
            };
            Grid.SetColumn(nameEmpresa, 1);
            Grid.SetRow(nameEmpresa, 0);

            TextBox codeEmpresa = new TextBox
            {
                Text = "Code",
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
