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

        private void btnCalcular_Click_1(object sender, EventArgs e)
        {

            // Sacamos el valor de las cajas de texto para el calculo
            float weight;
            float height;

            // Con este if verificamos que los valores del peso sean validos
            if (float.TryParse(txtPeso.Text, out weight))
            {
                // Con este if verificamos que los valores de la altura sean validos
                if (float.TryParse(txtAltura.Text, out height))
                {
                    // Formula para calcular el imc
                    double imc = weight / (height * height);
                    // Verificacion de los resultados para ver el camino a seguir
                    
                    // if para el imc bajo
                    if (imc < 18.49)
                    {
                        ImcBajo imcBajo = new ImcBajo();
                        imcBajo.Show();

                    }   // if para el imc normal
                    else if (imc > 18.49 && imc < 24.99)
                    {
                        imcNormal Normal = new imcNormal();
                        Normal.Show();
                    }
                    else   // else para el imc alto
                    {
                        imcAlto Alto = new imcAlto();
                        Alto.Show();
                    }

                    // Cierra la ventana anterior osea la de este codigo
                    this.Close();
                }
                else // El else verifica que la altura sea un valor valido
                {
                    MessageBox.Show("Ingresa un valor valido");
                }
            }
            else // El else verifica que el peso sea un valor valido
            {
                MessageBox.Show("Ingresa un valor valido");
            }

            
            
            
        }

        private void txtPeso_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
