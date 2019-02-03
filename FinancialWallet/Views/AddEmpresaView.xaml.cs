using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using FinancialWallet.Resources;
using DataBase;
using FinancialWallet.Controller;

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
            btnDelete.Click += new RoutedEventHandler(BorrarEntidad_Click);

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

        #region Eventos
        //CREAR EMPRESA
        private void CrearEmpresa_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int typeId = (int)((ComboBoxItem)CBAddEmpresaType.SelectedItem).Tag;
                var name = TBAddEmpresaName.Text;
                var code = TBAddEmpresaCode.Text;
                if (typeId != 0 && name != string.Empty && code != string.Empty)
                {
                    AddNewEmpresaRow(typeId, name, code);

                    var tabControl = ((TabControl)((TabItem)AddEmpresaPartial.Parent).Parent);
                    foreach (TabItem item in tabControl.Items)
                    {
                        item.IsEnabled = true;
                    }
                    BtnCancel.IsEnabled = false;
                    BtnCancel.Visibility = Visibility.Hidden;
                    InfoEditEmpresa.Visibility = Visibility.Hidden;
                    TBAddEmpresaName.Text = string.Empty;
                    TBAddEmpresaCode.Text = string.Empty;
                    CBAddEmpresaType.SelectedIndex = 0;
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

        //GENERAR CODIGO
        private void GenerarCodigo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int typeId = (int)((ComboBoxItem)CBAddEmpresaType.SelectedItem).Tag;
                string name = TBAddEmpresaName.Text;
                if (typeId != 0 && name != string.Empty)
                {
                    string type = (string)((ComboBoxItem)CBAddEmpresaType.SelectedItem).Content;
                    var result = SaveController.GetLastEntidad();
                    if (result.IsValid && result.Entidad != null)
                    {
                        int id = result.Entidad.EntidadId;
                        var codigoEmpresa = SetCodeForEmpresa(type, name, id);
                        TBAddEmpresaCode.Text = codigoEmpresa;
                    }
                    
                }
                else
                {
                    MessageBox.Show("Error: Verifique nombre y tipo de la entidad.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Verifique nombre y tipo de la entidad.\n\n" + ex.Message);
            }
        }

        //CAMBIO DE TAB ITEM
        private void AddEmpresaPartial_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CBAddEmpresaType.Items.Count == 1)
            {
                ViewController.FillComboboxEntity(CBAddEmpresaType);
            }
        }

        //BORRAR ENTIDAD
        private void BorrarEntidad_Click(object sender, RoutedEventArgs e)
        {
            var name = ((TextBox)((Grid)((Button)sender).Parent).Children[1]).Text;
            MessageBoxResult messageBoxResult = System.Windows.MessageBox
                .Show("¿Desea borrar a " + name + "de la base de datos?",
                "Borrar entidad", System.Windows.MessageBoxButton.YesNo);

            if (messageBoxResult == MessageBoxResult.Yes)
            {
                MessageBox.Show("Se ha borrado exitosamente a:" + name);
            }
        }

        //CANCELAR CREACIÓN DE ENTIDAD
        private void CancelarEntidad_Click(object sender, RoutedEventArgs e)
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
            TBAddEmpresaCode.Text = string.Empty;
            CBAddEmpresaType.SelectedIndex = 0;
        }
        #endregion

        private string SetCodeForEmpresa(string type, string name, int id)
        {
            string code = string.Empty;
            switch (type)
            {
                case GlobalValues.EMPRESA:
                    code = GlobalValues.CODE_EMPRESA + id.ToString() + name.First().ToString();
                    break;
                case GlobalValues.PROVEEDOR:
                    code = GlobalValues.CODE_PROVEEDOR + id.ToString() + name.First().ToString();
                    break;
                default:
                    code = GlobalValues.CODE_PERSONA + id.ToString() + name.First().ToString();
                    break;
            }
            
            return code;
        }

        
    }
}