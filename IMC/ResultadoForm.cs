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
    public partial class ResultadoForm : Form
    {
        // Constructor modificado para recibir el IMC
        public ResultadoForm(double imc)
        {
            InitializeComponent();
            MostrarResultado(imc);
        }

        private void MostrarResultado(double imc)
        {
            // Configuración base de fuentes
            lblResultado.Font = new Font("Segoe UI", 40, FontStyle.Bold); // Número gigante
            lblMensaje.Font = new Font("Segoe UI", 18, FontStyle.Italic);
            lblResultado.Text = imc.ToString("0.0");

            // Texto blanco para contraste
            lblResultado.ForeColor = Color.White;
            lblMensaje.ForeColor = Color.White;

            // LÓGICA DE COLORES (Semáforo)
            if (imc < 18.5)
            {
                this.BackColor = Color.FromArgb(255, 193, 7); // Amarillo Ámbar
                lblMensaje.Text = "BAJO PESO";
                // Aquí podrías cargar una imagen: pbImagen.Image = Properties.Resources.flaco;
            }
            else if (imc >= 18.5 && imc <= 24.9)
            {
                this.BackColor = Color.FromArgb(76, 175, 80); // Verde Material
                lblMensaje.Text = "PESO NORMAL";
                // pbImagen.Image = Properties.Resources.normal;
            }
            else if (imc >= 25 && imc <= 29.9)
            {
                this.BackColor = Color.FromArgb(255, 152, 0); // Naranja
                lblMensaje.Text = "SOBREPESO";
            }
            else
            {
                this.BackColor = Color.FromArgb(244, 67, 54); // Rojo Alerta
                lblMensaje.Text = "OBESIDAD";
            }

            this.CenterToScreen();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            // Regresa al menú principal o a capturar datos
            this.Close();
            // Nota: Asegúrate de que el form anterior reaparezca si usaste Hide()
            // O simplemente abre uno nuevo: new InicioForm().Show();
        }
    }
}
