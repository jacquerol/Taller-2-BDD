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
        public Boolean insertData = false; public Boolean updateData = false; string[] columnas; string entidad;
        public DataTableDisplay(DataTable tabla, string titulo)
        {
            InitializeComponent();
            label.Text = titulo;
            bindingSource = new BindingSource();
            bindingSource.DataSource = tabla;
            this.Controls.Add(dataGridView);
            this.Show();
            updateData = false; insertData = false;
        }
        /**
         * Sobrecarga del constructor para realizar queries INSERT
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
        /**
         * Sobrecarga del constructor para realizar queries UPDATE
         **/
        public DataTableDisplay(string entidad, string pk, Boolean updateData = true)
        {
            InitializeComponent();
            label.Text = "Actualizar " + entidad;
            bindingSource = new BindingSource();
            DataTable tabla = new DataTable();
            string pkCampo = getTabla("SELECT * FROM " + entidad).Columns[0].ColumnName;
            if (!int.TryParse(pk, out int parseInt)) pk = "'" + pk + "'";
            tabla = getTabla("SELECT * FROM " + entidad + " WHERE " + pkCampo + " = " + pk);
            bindingSource.DataSource = tabla;
            this.Controls.Add(dataGridView);
            this.updateData = updateData;
            this.entidad = entidad;
            this.Show();
        }
        private void DataTableDisplay_Load(object sender, EventArgs e)
        {
            dataGridView.Dock = DockStyle.Bottom;
            dataGridView.AutoGenerateColumns = true;
            dataGridView.DataSource = bindingSource;
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dataGridView.BorderStyle = BorderStyle.Fixed3D;
            dataGridView.AllowUserToAddRows = false;
            if (this.insertData & !this.updateData)
            {
                dataGridView.EditMode = DataGridViewEditMode.EditOnEnter;
                sendButton.Show();
            }
            else if (this.updateData & !this.insertData)
            {
                dataGridView.EditMode = DataGridViewEditMode.EditOnEnter;
                sendButton.Show();
            }
        }
        ~DataTableDisplay(){}
        /**
         * Genera una query de insercion utilizando los valores guardados en la tabla de la form
         * Si el modo update está activado envia una query update
         **/
        private void enviar(object sender, EventArgs e)
        {
            DataTable tabla = convertirEnDataTable(this.dataGridView);
            if (!datosLlenados(tabla))
            {
                MessageBox.Show("Complete todos los campos.", "Error");
                return;
            }
            string query = "";
            if (this.insertData)
            {
                query = "INSERT INTO " + this.entidad + " (";
                for (int i = 0; i < tabla.Columns.Count; i++)
                {
                    query += tabla.Columns[i].ColumnName.ToString();
                    if (i < tabla.Columns.Count - 1) query += ", ";
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
            }
            else if (this.updateData)
            {
                query = "UPDATE " + this.entidad + " SET ";
                for (int i = 1; i < tabla.Columns.Count; i++)
                {
                    query += tabla.Columns[i].ColumnName.ToString() + "=";
                    string cell = tabla.Rows[0][i].ToString();
                    if (!int.TryParse(tabla.Rows[0][i].ToString(), out int parseInt)) cell = "'" + cell + "'";
                    query += cell;
                    if (i < tabla.Columns.Count - 1) query += ", ";
                }
                string pkValue = tabla.Rows[0][0].ToString();
                if (!int.TryParse(pkValue, out int parseInt2)) pkValue = "'" + pkValue + "'";
                query += " WHERE " + tabla.Columns[0].ColumnName.ToString() + " = " + pkValue;
            }
            MessageBox.Show(query);
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

