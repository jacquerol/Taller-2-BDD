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
        private BindingSource bindingSource = new BindingSource();
        public DataTableDisplay(DataTable tabla, string titulo)
        {
            InitializeComponent();
            label.Text = titulo;
            bindingSource = new BindingSource();
            bindingSource.DataSource = tabla;
            this.Controls.Add(dataGridView);
        }

        private void DataTableDisplay_Load(object sender, EventArgs e)
        {
            dataGridView.Dock = DockStyle.Bottom;
            dataGridView.AutoGenerateColumns = true;
            dataGridView.DataSource = bindingSource;
            dataGridView.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dataGridView.BorderStyle = BorderStyle.Fixed3D;
        }
        ~DataTableDisplay()
        {

        }
        private void exit(object sender, EventArgs e){this.Close();}

        private void label_Click(object sender, EventArgs e)
        {

        }
    }
}

