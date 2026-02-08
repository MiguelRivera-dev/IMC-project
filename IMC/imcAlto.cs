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
    public partial class imcAlto : Form
    {
        public imcAlto()
        {
            InitializeComponent();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            // Boton para regresar a la pantalla de registro/informacion
            CapturaDatosForm FCapDatos1 = new CapturaDatosForm();
            FCapDatos1.Show();
            // Cierra la ventana anterior osea la de este codigo
            this.Close();
        }
    }
}
