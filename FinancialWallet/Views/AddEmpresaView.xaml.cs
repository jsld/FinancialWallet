using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
                Name = "IdEmpresa",
                IsEnabled = false,
                Margin = new Thickness(10)
            };
            Grid.SetColumn(idEmpresa, 0);
            Grid.SetRow(idEmpresa, 0);

            TextBox nameEmpresa = new TextBox
            {
                Text = "Delight Eventos",
                Name = "NameEmpresa",
                IsEnabled = false,
                Margin = new Thickness(10)
            };
            Grid.SetColumn(nameEmpresa, 1);
            Grid.SetRow(nameEmpresa, 0);

            TextBox codeEmpresa = new TextBox
            {
                Text = "Code",
                Name = "CodeEmpresa",
                IsEnabled = false,
                Margin = new Thickness(10)
            };
            Grid.SetColumn(codeEmpresa, 2);
            Grid.SetRow(codeEmpresa, 0);
            
            Button btnDelete = new Button
            {
                Style = (Style)FindResource("DangerButton"),
                Content = "Borrar",
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
    }
}
