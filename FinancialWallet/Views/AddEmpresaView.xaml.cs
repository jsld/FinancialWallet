using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using FinancialWallet.Resources;
using DataBase;
using FinancialWallet.Controller;
using FinancialWallet.Messages;
using FinancialWallet.Views.Modals;

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

            FillTablaEmpresa();
            FillTablaProveedores();
            FillTablaPersonas();
            ViewController.FillComboboxEntity(CBAddEmpresaType);
        }
        
        #region Metodos Privados Vista
        //BOTÓN CANCEL LÓGICA
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

        //PINTAR TABLA EMPRESA
        private void FillTablaEmpresa()
        {
            var response = SaveController.GetAllEntidadesByType(GlobalValues.CODE_EMPRESA);
            if (response.IsValid && response.ListaEntidades != null && response.ListaEntidades.Any())
            {
                foreach (var item in response.ListaEntidades)
                {
                    AddNewEntidadRow(item.EntidadId, item.Nombre, item.Codigo);
                }
            }
        }

        //PINTAR TABLA PROVEEDORES
        private void FillTablaProveedores()
        {
            var response = SaveController.GetAllEntidadesByType(GlobalValues.CODE_PROVEEDOR);
            if (response.IsValid && response.ListaEntidades != null && response.ListaEntidades.Any())
            {
                foreach (var item in response.ListaEntidades)
                {
                    AddNewEntidadRow(item.EntidadId, item.Nombre, item.Codigo);
                }
            }
        }

        //PINTAR TABLA PERSONAS
        private void FillTablaPersonas()
        {
            var response = SaveController.GetAllEntidadesByType(GlobalValues.CODE_PERSONA);
            if (response.IsValid && response.ListaEntidades != null && response.ListaEntidades.Any())
            {
                foreach (var item in response.ListaEntidades)
                {
                    AddNewEntidadRow(item.EntidadId, item.Nombre, item.Codigo);
                }
            }
        }

        //AGREGAR NUEVAS FILAS PARA TABLAS ENTIDADES
        private void AddNewEntidadRow(
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
                Width = new GridLength(95)
            });
            grid.ColumnDefinitions.Add(new ColumnDefinition
            {
                Width = new GridLength(80)
            });

            TextBox idEntidad = new TextBox
            {
                Text = id.ToString(),
                Name = "TBEmpresaId",
                IsEnabled = false,
                Margin = new Thickness(10)
            };
            Grid.SetColumn(idEntidad, 0);
            Grid.SetRow(idEntidad, 0);

            TextBox nameEntidad = new TextBox
            {
                Text = name,
                Name = "TBEmpresaName",
                IsEnabled = false,
                Margin = new Thickness(10)
            };
            Grid.SetColumn(nameEntidad, 1);
            Grid.SetRow(nameEntidad, 0);

            TextBox codeEntidad = new TextBox
            {
                Text = code,
                Name = "TBEmpresaCode",
                IsEnabled = false,
                Margin = new Thickness(10)
            };
            Grid.SetColumn(codeEntidad, 2);
            Grid.SetRow(codeEntidad, 0);
            
            Button btnInfoContacto = new Button
            {
                Style = (Style)FindResource("InfoButton"),
                Content = "Contacto",
                Name = "TBEntidadContacto",
                Margin = new Thickness(10)
            };
            btnInfoContacto.Click += new RoutedEventHandler(ContactoEntidad_Click);

            Grid.SetColumn(btnInfoContacto, 3);
            Grid.SetRow(btnInfoContacto, 0);

            Button btnDelete = new Button
            {
                Style = (Style)FindResource("DangerButton"),
                Content = "Borrar",
                Name = "TBEntidadDelete",
                Margin = new Thickness(10)
            };
            btnDelete.Click += new RoutedEventHandler(BorrarEntidad_Click);

            Grid.SetColumn(btnDelete, 4);
            Grid.SetRow(btnDelete, 0);

            grid.Children.Add(idEntidad);
            grid.Children.Add(nameEntidad);
            grid.Children.Add(codeEntidad);
            grid.Children.Add(btnInfoContacto);
            grid.Children.Add(btnDelete);

            border.Child = grid;

            if (code.Contains(GlobalValues.CODE_EMPRESA))
            {
                empresasPanel.Children.Add(border);
            }
            else if (code.Contains(GlobalValues.CODE_PROVEEDOR))
            {
                proveedoresPanel.Children.Add(border);
            }
            else
            {
                personasPanel.Children.Add(border);
            }
        }
        #endregion

        #region Eventos
        //CREAR EMPRESA
        private void CrearEntidad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int typeId = (int)((ComboBoxItem)CBAddEmpresaType.SelectedItem).Tag;
                var name = TBAddEmpresaName.Text;
                var code = TBAddEmpresaCode.Text;
                if (typeId != 0 && name != string.Empty && code != string.Empty)
                {
                    AddNewEntidadRow(typeId, name, code);
                    var request = new EntidadRequest
                    {
                        EntidadTipoId = typeId,
                        EntidadNombre = name,
                        EntidadCode = code
                    };

                    var response = SaveController.CreateEntidad(request);

                    if (response.IsValid)
                    {
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
                        MessageBox.Show(response.ErrorMessage);
                    }
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
                    if (result.IsValid)
                    {
                        int id = result.Entidad != null ?
                            result.Entidad.EntidadId + 1:
                            1;
                        var codigoEmpresa = SetCodeForEntidad(type, name, id);
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
        
        //BORRAR ENTIDAD
        private void BorrarEntidad_Click(object sender, RoutedEventArgs e)
        {
            var code = ((TextBox)((Grid)((Button)sender).Parent).Children[2]).Text;
            var name = ((TextBox)((Grid)((Button)sender).Parent).Children[1]).Text;
            MessageBoxResult messageBoxResult = System.Windows.MessageBox
                .Show("¿Desea borrar a " + name + "de la base de datos?",
                "Borrar entidad", System.Windows.MessageBoxButton.YesNo);

            if (messageBoxResult == MessageBoxResult.Yes)
            {
                var response = SaveController.DeleteEntidad(code);

                if (response.IsValid)
                {
                    MessageBox.Show("Se ha borrado exitosamente a:" + name);
                }
                else
                {
                    MessageBox.Show(response.ErrorMessage);
                }
            }
        }

        //VER INFO CONTACTO
        private void ContactoEntidad_Click(object sender, RoutedEventArgs e)
        {
            var code = ((TextBox)((Grid)((Button)sender).Parent).Children[2]).Text;
            var name = ((TextBox)((Grid)((Button)sender).Parent).Children[1]).Text;
            var dialogContacto = new ModalCrearContacto(name,code);
            if (dialogContacto.ShowDialog() == true)
            {
                if (!dialogContacto.Response.IsValid)
                {
                    MessageBox.Show(dialogContacto.Response.ErrorMessage);
                }
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

        #region Negocio
        private string SetCodeForEntidad(string type, string name, int id)
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
        #endregion

    }
}