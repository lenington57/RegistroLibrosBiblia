using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RegistrarLibrosBiblicos.Entidades;
using RegistrarLibrosBiblicos.BLL;

namespace RegistrarLibrosBiblicos.UI.Registros
{
    public partial class RegistrarLibrosBiblia : Form
    {
        public RegistrarLibrosBiblia()
        {
            InitializeComponent();
        }

        //Métodos
        private LibrosBiblia LLenaClase()
        {
            LibrosBiblia librosBiblia = new LibrosBiblia();

            librosBiblia.LibrosId = Convert.ToInt32(LibrosIdNumericUpDown.Value);
            librosBiblia.Fecha = FechaDateTimePicker.Value;
            librosBiblia.Descripcion = DescripcionTextBox.Text;
            librosBiblia.Siglas = SiglasTextBox.Text;
            librosBiblia.Tipo = Convert.ToBoolean(TipoComboBox.SelectedValue);
            return librosBiblia;
        }

        private void Nuevo()
        {
            LibrosIdNumericUpDown.Value = 0;
            FechaDateTimePicker.Value = DateTime.Now;
            DescripcionTextBox.Clear();
            SiglasTextBox.Clear();
            TipoComboBox.SelectedIndex = 0;
        }

        //Progrmación de los Botones
        private void BuscarButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(LibrosIdNumericUpDown.Value);
            LibrosBiblia librosBiblia =LibrosBibliaBLL.Buscar(id);

            if (librosBiblia != null)
            {
                FechaDateTimePicker.Value = librosBiblia.Fecha;
                DescripcionTextBox.Text = librosBiblia.Descripcion;
                SiglasTextBox.Text = librosBiblia.Siglas;
                TipoComboBox.SelectedValue = Convert.ToDecimal(librosBiblia.Tipo);
            }
            else
                MessageBox.Show("No se encontró!!", "Falló",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            Nuevo();
        }
    }
}
