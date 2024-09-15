using Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class ClienteDetalle : Form
    {
        private Cliente cliente;

        public Cliente Cliente
        {
            get { return cliente; }
            set 
            { 
                cliente = value;
                this.SetCliente();
            }
        }

        //Probablemente un Enum seria mas apropiado        
        public bool EditMode { get; set; } = false;

        public ClienteDetalle()
        {
            InitializeComponent();
        }

        private async void aceptarButton_Click(object sender, EventArgs e)
        {
            ClienteApiClient client = new ClienteApiClient();

            if (this.ValidateCliente())
            {
                this.Cliente.Nombre = nombreTextBox.Text;

                //El Detalle se esta llevando la responsabilidad de llamar al servicio
                //pero tal vez deberia ser solo una vista y que esta responsabilidad quede
                //en la Lista o tal vez en un Presenter o Controler

                if (this.EditMode)
                {
                    await ClienteApiClient.UpdateAsync(this.Cliente);
                }
                else
                {
                    await ClienteApiClient.AddAsync(this.Cliente);
                }

                this.Close();
            }
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SetCliente()
        {
            this.nombreTextBox.Text = this.Cliente.Nombre;
        }

        private bool ValidateCliente()
        {
            bool isValid = true;

            errorProvider.SetError(nombreTextBox, string.Empty);

            if (this.nombreTextBox.Text == string.Empty)
            {
                isValid = false;
                errorProvider.SetError(nombreTextBox, "El Nombre es Requerido");
            }

            return isValid;
        }

 
    }
}
