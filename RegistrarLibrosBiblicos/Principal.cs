using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RegistrarLibrosBiblicos.UI.Registros;
using RegistrarLibrosBiblicos.UI.Consultas;

namespace RegistrarLibrosBiblicos
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void librosBibliaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistrarLibrosBiblia registrarLibrosBiblia = new RegistrarLibrosBiblia();
            registrarLibrosBiblia.MdiParent = this;
            registrarLibrosBiblia.Show();
        }

        private void consultarLibrosBibliaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultarLibrosBiblia consultarLibrosBiblia = new ConsultarLibrosBiblia();
            consultarLibrosBiblia.MdiParent = this;
            consultarLibrosBiblia.Show();
        }

        private void LibrosBibliaToolStripButton_Click(object sender, EventArgs e)
        {
            RegistrarLibrosBiblia registrarLibrosBiblia = new RegistrarLibrosBiblia();
            registrarLibrosBiblia.MdiParent = this;
            registrarLibrosBiblia.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ConsultarLibrosBiblia consultarLibrosBiblia = new ConsultarLibrosBiblia();
            consultarLibrosBiblia.MdiParent = this;
            consultarLibrosBiblia.Show();
        }
    }
}
