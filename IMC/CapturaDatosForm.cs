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
    public partial class CapturaDatosForm : Form
    {
        public CapturaDatosForm()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(30, 30, 30); // Fondo oscuro
            ConfigurarInputs();
        }

        private void ConfigurarInputs()
        {
            // Estilo para las etiquetas
            EstilizarLabel(lblPeso, "Peso (kg):");
            EstilizarLabel(lblAltura, "Altura (m):");

            // Estilo para el botón calcular
            btnCalcular.FlatStyle = FlatStyle.Flat;
            btnCalcular.BackColor = Color.FromArgb(255, 87, 34); // Naranja llamativo
            btnCalcular.ForeColor = Color.White;
            btnCalcular.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            btnCalcular.Cursor = Cursors.Hand;
        }

        private void EstilizarLabel(Label lbl, string texto)
        {
            lbl.Text = texto;
            lbl.ForeColor = Color.LightGray;
            lbl.Font = new Font("Segoe UI", 12, FontStyle.Regular);
        }

        // Lógica del botón Calcular
        private void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                double peso = double.Parse(txtPeso.Text);
                double altura = double.Parse(txtAltura.Text);

                // Validamos que no metan ceros
                if (altura == 0) { MessageBox.Show("La altura no puede ser 0"); return; }

                double imc = peso / (altura * altura);

                // LLAMAMOS AL FORM DINÁMICO
                ResultadoForm formRes = new ResultadoForm(imc);
                formRes.Show();
                this.Hide();
            }
            catch
            {
                MessageBox.Show("Por favor ingresa números válidos.");
            }
        }
    }
}
