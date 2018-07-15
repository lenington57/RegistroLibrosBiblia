using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Linq.Expressions;
using RegistrarLibrosBiblicos.BLL;
using RegistrarLibrosBiblicos.Entidades;

namespace RegistrarLibrosBiblicos.UI.Consultas
{
    public partial class ConsultarLibrosBiblia : Form
    {
        public ConsultarLibrosBiblia()
        {
            InitializeComponent();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            Expression<Func<LibrosBiblia, bool>> filtro = l => true;
            int id;
            switch (FiltroComboBox.SelectedIndex)
            {
                case 0://Filtrando por ID del Libro.
                    id = Convert.ToInt32(CriterioTextBox.Text);
                    filtro = l => l.LibrosId == id;
                    break;
                case 1://Filtrando por la Fecha del Libro.
                    filtro = l => l.Fecha >= DesdeDateTimePicker.Value && l.Fecha <= HastaDateTimePicker.Value;
                    break;
                case 2://Filtrando por Descripción del Libro y Fecha.
                    filtro = l => l.Descripcion.Contains(CriterioTextBox.Text) && l.Fecha >= DesdeDateTimePicker.Value && l.Fecha <= HastaDateTimePicker.Value;
                    break;
                case 3://Filtrando por Siglas del Libro y Fecha.
                    filtro = l => l.Siglas.Contains(CriterioTextBox.Text) && l.Fecha >= DesdeDateTimePicker.Value && l.Fecha <= HastaDateTimePicker.Value;
                    break;
                case 4://Filtrando por Tipo del Libro y Fecha.
                    filtro = l => l.Tipo.Contains(CriterioTextBox.Text) && l.Fecha >= DesdeDateTimePicker.Value && l.Fecha <= HastaDateTimePicker.Value;
                    break;
            }

            LibrosBibliaConsultaDataGridView.DataSource = LibrosBibliaBLL.GetList(filtro);
        }

        private void FiltroComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FiltroComboBox.SelectedIndex == 0)
            {
                DesdeLabel.Visible = true;
                DesdeDateTimePicker.Visible = true;
                HastaLabel.Visible = true;
                HastaDateTimePicker.Visible = true;
            }

            if (FiltroComboBox.SelectedIndex == 1)
            {
                CriterioTextBox.Visible = false;
                CriterioLabel.Visible = false;
            }
            else
            {
                CriterioTextBox.Visible = true;
                CriterioLabel.Visible = true;
            }

        }
    }
}
