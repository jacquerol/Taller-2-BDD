using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace taller2base
{
    public partial class DataTableDisplay : Form
    {
        string titulo; DataTable tabla;
        public DataTableDisplay(DataTable tabla, string titulo)
        {
            this.titulo = titulo;
            this.tabla = tabla;
        }

        private void DataTableDisplay_Load(object sender, EventArgs e)
        {
            dataGridView.ColumnCount = this.tabla.Columns.Count;
            for (int i = 0; i < tabla.Columns.Count; i++)
            {
                this.dataGridView.Columns[i].Name = tabla.Columns[i].ColumnName.ToString();

            }
        }
    }
}

