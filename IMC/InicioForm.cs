using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing; // Necesario para colores
using System.Drawing.Drawing2D; // IMPORTANTE: Necesario para el degradado
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Aquí llamamos a nuestra función de diseño al iniciar
            PersonalizarDiseño();
        }

        private void PersonalizarDiseño()
        {
            // 1. Configuración básica de la ventana
            this.Text = "Calculadora IMC - Menú";
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;

            // 2. Estilizar Botones 
            // NOTA: Si te marca error aquí es porque no has creado los botones 
            // o no les has puesto este nombre en "Properties > Name"
            EstilizarBoton(btnIngresar, Color.FromArgb(0, 150, 136)); // Verde Azulado
            EstilizarBoton(btnInfo, Color.FromArgb(63, 81, 181));     // Índigo
                                                                      // Dentro de PersonalizarDiseño()

            lblTitulo.Text = "CALCULADORA IMC"; // O el texto que quieras
            lblTitulo.Font = new Font("Segoe UI", 24, FontStyle.Bold); // Fuente, Tamaño, Estilo
            lblTitulo.ForeColor = Color.White; // Color del texto
            lblTitulo.BackColor = Color.Transparent; // ¡IMPORTANTE! Para que se vea el degradado de fondo
        }

        // Método para pintar el fondo degradado automáticamente
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle,
                                               Color.FromArgb(30, 30, 30), // Gris Oscuro
                                               Color.FromArgb(50, 50, 70), // Azul Grisáceo
                                               90F)) // Ángulo vertical
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        // Método para poner bonitos los botones
        private void EstilizarBoton(Button btn, Color colorFondo)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = colorFondo;
            btn.ForeColor = Color.White;
            btn.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;

            // Esto hace que los bordes sean redondos
            btn.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn.Width, btn.Height, 20, 20));
        }

        // Código técnico de Windows para redondear bordes
        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        // --- AQUÍ ABAJO IRÁN LOS CLICS DE TUS BOTONES ---
        // Por ejemplo, da doble clic en el botón en el diseñador para que se cree esto:

        /* private void btnIngresar_Click(object sender, EventArgs e)
        {
             // Código para ir al siguiente form
        }
        */
    }
}