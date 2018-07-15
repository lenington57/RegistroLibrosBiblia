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
        private LibrosBiblia LlenaClase()
        {
            LibrosBiblia librosBiblia = new LibrosBiblia();

            librosBiblia.LibrosId = Convert.ToInt32(LibrosIdNumericUpDown.Value);
            librosBiblia.Fecha = FechaDateTimePicker.Value;
            librosBiblia.Descripcion = DescripcionTextBox.Text;
            librosBiblia.Siglas = SiglasTextBox.Text;
            librosBiblia.Tipo = TipoComboBox.Text;
            return librosBiblia;
        }

        private void Nuevo()
        {
            LibrosIdNumericUpDown.Value = 0;
            FechaDateTimePicker.Value = DateTime.Now;
            DescripcionTextBox.Clear();
            SiglasTextBox.Clear();
            TipoComboBox.SelectedIndex = 0;
            MyErrorProvider.Clear();
        }

        private bool HayErrores()
        {
            bool HayErrores = false;

            if (String.IsNullOrWhiteSpace(DescripcionTextBox.Text))
            {
                MyErrorProvider.SetError(DescripcionTextBox,
                    "Debes escribir una Decripción para el Libro");
                HayErrores = true;
            }

            if (String.IsNullOrWhiteSpace(SiglasTextBox.Text))
            {
                MyErrorProvider.SetError(SiglasTextBox,
                    "Debes escribir una Sigla para el Libro");
                HayErrores = true;
            }

            return HayErrores;
        }


        //Progrmación de los Botones
        private void BuscarButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(LibrosIdNumericUpDown.Value);
            LibrosBiblia librosBiblia = LibrosBibliaBLL.Buscar(id);

            if (librosBiblia != null)
            {
                FechaDateTimePicker.Value = librosBiblia.Fecha;
                DescripcionTextBox.Text = librosBiblia.Descripcion;
                SiglasTextBox.Text = librosBiblia.Siglas;
                TipoComboBox.Text = librosBiblia.Tipo;
            }
            else
                MessageBox.Show("No se encontró!!", "Falló",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            LibrosBiblia librosBiblia;
            bool Paso = false;

            if (HayErrores())
            {
                MessageBox.Show("Debe llenar todos los campos que se indican!!!", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            librosBiblia = LlenaClase();

            if (LibrosIdNumericUpDown.Value == 0)
                Paso = LibrosBibliaBLL.Guardar(librosBiblia);
            else
            {
                int id = Convert.ToInt32(LibrosIdNumericUpDown.Value);
                LibrosBiblia librosBiblias = LibrosBibliaBLL.Buscar(id);

                if (librosBiblia != null)
                {
                    Paso = LibrosBibliaBLL.Modificar(LlenaClase());
                }
                else
                    MessageBox.Show("El Id que desea Modificar no existe!!", "Falló",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (Paso)
            {
                Nuevo();
                MessageBox.Show("Guardado!!", "Exito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }                
            else
                MessageBox.Show("No se pudo guardar!!", "Falló",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(LibrosIdNumericUpDown.Value);
            LibrosBiblia librosBiblia = LibrosBibliaBLL.Buscar(id);

            if (librosBiblia != null)
            {
                if (LibrosBibliaBLL.Eliminar(id))
                {
                    MessageBox.Show("Eliminado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Nuevo();
                }
                else
                    MessageBox.Show("No se pudo eliminar!!", "Falló", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("El Id que desea Eliminar no existe", "Falló", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Eventos de los Objetos
        private void DescripcionTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Solo se puede escribir Lettras", "Falló",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
        }

        private void SiglasTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Solo se puede escribir Lettras", "Falló",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
        }
    }
}
