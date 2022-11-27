using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static DatabaseUtil.Util;

namespace taller2base
{
    public partial class DataTableDisplay : Form
    {
        private BindingSource bindingSource = new BindingSource();
        private Boolean insertData = false; string[] columnas; string entidad;
        public DataTableDisplay(DataTable tabla, string titulo)
        {
            InitializeComponent();
            label.Text = titulo;
            bindingSource = new BindingSource();
            bindingSource.DataSource = tabla;
            this.Controls.Add(dataGridView);
            this.Show();
        }
        /**
         * Sobrecarga del constructor para realizar querys de envio
         **/
        public DataTableDisplay(string[] columnas, string entidad, Boolean insertData=true)
        {
            InitializeComponent();
            label.Text = "Insertar "+entidad;
            bindingSource = new BindingSource();
            DataTable tabla = new DataTable();
            this.columnas = columnas;
            for (int i = 0; i < columnas.Length; i++){tabla.Columns.Add(columnas[i]);}
            tabla.Rows.Add();
            bindingSource.DataSource = tabla;
            this.Controls.Add(dataGridView);
            this.insertData = insertData;
            this.entidad = entidad;
            this.Show();
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
                dataGridView.AllowUserToAddRows = false;
            }
            else sendButton.Hide();
        }
        ~DataTableDisplay(){}
        /**
         * Genera una query de insercion utilizando los valores guardados en la tabla de la form
         **/
        private void insertar(object sender, EventArgs e)
        {
            DataTable tabla = convertirEnDataTable(this.dataGridView);
            if (!datosLlenados(tabla))
            {
                MessageBox.Show("Complete todos los campos.", "Error");
                return;
            }
            string query = "INSERT INTO "+this.entidad+" (";
            for(int i = 0; i < tabla.Columns.Count; i++)
            {
                query += tabla.Columns[i].ColumnName.ToString();
                if (i < tabla.Columns.Count-1) query += ", ";
            }
            query += ") VALUES (";
            for (int i = 0; i < tabla.Columns.Count; i++)
            {
                string cell = tabla.Rows[0][i].ToString();
                if (!int.TryParse(tabla.Rows[0][i].ToString(), out int parseInt)) cell = "'" + cell + "'";
                query += cell;
                if (i < tabla.Columns.Count - 1) query += ", ";
            }
            query += ")";
            añadirDato(query);
        }
        private Boolean datosLlenados(DataTable tabla)
        {
            for(int i = 0; i < tabla.Columns.Count; i++)
            {
                if (tabla.Rows[0][i].ToString() == "") return false;
            }
            return true;
        }
        /**
         * Convierte un componente DataGridView en un objeto DataTable
         **/
        private DataTable convertirEnDataTable(DataGridView gridView)
        {
            DataTable tabla = new DataTable();
            foreach (DataGridViewColumn column in gridView.Columns)
            {
                tabla.Columns.Add(column.HeaderText, column.ValueType);
            }
            foreach (DataGridViewRow row in gridView.Rows)
            {
                tabla.Rows.Add();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    tabla.Rows[tabla.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();
                }
            }
            return tabla;
        }

        private void exit(object sender, EventArgs e){this.Close();}

        private void label_Click(object sender, EventArgs e)
        {

        }
    }
}

