using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMC
{
    public partial class imcNormal : Form
    {
        public imcNormal()
        {
            InitializeComponent();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            // Boton para regresar a la pantalla de registro/informacion
            CapturaDatosForm FCapDatos3 = new CapturaDatosForm();
            FCapDatos3.Show();
            // Cierra la ventana anterior osea la de este codigo
            this.Close();
        }
    }
}
