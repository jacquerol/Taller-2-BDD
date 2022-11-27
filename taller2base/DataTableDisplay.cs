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
        private Boolean insertData = false;
        public DataTableDisplay(DataTable tabla, string titulo)
        {
            InitializeComponent();
            label.Text = titulo;
            bindingSource = new BindingSource();
            bindingSource.DataSource = tabla;
            this.Controls.Add(dataGridView);
        }
        /**
         * Sobrecarga del constructor para realizar querys de envio
         **/
        public DataTableDisplay(string[] columns, string titulo, Boolean insertData=true)
        {
            InitializeComponent();
            label.Text = titulo;
            bindingSource = new BindingSource();
            DataTable tabla = new DataTable();
            for (int i = 0; i < columns.Length; i++)
            {
                tabla.Columns.Add(columns[i]);
            }
            bindingSource.DataSource = tabla;
            this.Controls.Add(dataGridView);
            this.insertData = insertData;
        }

        private void DataTableDisplay_Load(object sender, EventArgs e)
        {
            dataGridView.Dock = DockStyle.Bottom;
            dataGridView.AutoGenerateColumns = true;
            dataGridView.DataSource = bindingSource;
            dataGridView.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dataGridView.BorderStyle = BorderStyle.Fixed3D;
            if (this.insertData)
            {
                dataGridView.EditMode = DataGridViewEditMode.EditOnEnter;
                sendButton.Show();
            }
            else sendButton.Hide();
        }
        ~DataTableDisplay(){}

        private void exit(object sender, EventArgs e){this.Close();}

        private void label_Click(object sender, EventArgs e)
        {

        }
    }
}

