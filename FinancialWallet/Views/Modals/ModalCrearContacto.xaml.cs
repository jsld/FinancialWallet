using FinancialWallet.Controller;
using FinancialWallet.Messages;
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
using System.Windows.Shapes;

namespace FinancialWallet.Views.Modals
{
    /// <summary>
    /// Lógica de interacción para ModalCrearContacto.xaml
    /// </summary>
    public partial class ModalCrearContacto : Window
    {
        private ResponseBase response = new ResponseBase
        {
            IsValid = false
        };
        private string name = string.Empty;
        private string code = string.Empty;

        private bool isNewContact = false;

        public ModalCrearContacto(string name, string code)
        {
            InitializeComponent();
            this.name = name;
            this.code = code;
            this.Title += name;
            var result = SaveController.GetContactoByEntityCode(code);
            FillContacto(result);
        }

        public ResponseBase Response
        {
            get { return response; }
        }

        private void FillContacto(ResponseContacto result)
        {
            if (result.IsValid)
            {
                if (result.Contacto != null)
                {
                    this.TBNumeroTelefono.Text = result.Contacto.Telefono.ToString();
                    this.TBEMail.Text = result.Contacto.Correo;
                    this.TBComentario.Text = result.Contacto.Detalle;
                }
                else
                {
                    MessageBox.Show("No existe información de contacto asociada a:\n" +
                        this.name +
                        "\n\nPor favor ingrese nueva información de contacto.");
                    this.isNewContact = true;
                }
            }
        }

        private void Guardar_Click(object sender, RoutedEventArgs e)
        {
            var resultEntidad = SaveController.GetEntidadByCode(this.code);

            if (this.isNewContact)
            {
                response = SaveController.CreateContacto(
                    TBNumeroTelefono.Text,
                    TBEMail.Text,
                    TBComentario.Text,
                    resultEntidad.Entidad.EntidadId);
            }
            else
            {
                response = SaveController.UpdateContacto(
                    TBNumeroTelefono.Text,
                    TBEMail.Text,
                    TBComentario.Text,
                    resultEntidad.Entidad.EntidadId);
            }

            this.DialogResult = true;
        }
    }
}
