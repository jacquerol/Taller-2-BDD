using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;


namespace taller2base
{
    public partial class ModularForm : Form
    {
        public string ReturnValue { get; set; }
        string title, instruction, SQLDataColumnType;
        public ModularForm(string SQLDataColumnType, string title, string instruction)
        {
            InitializeComponent();
            this.title = title;
            this.instruction = instruction;
            this.SQLDataColumnType = SQLDataColumnType;
        }
        private void click(object sender, EventArgs e)
        {
            if(this.textBox1.Text == "" && this.SQLDataColumnType == "ingresarManual")
            {
                MessageBox.Show("Rellene todos los campos", "Error");
                return;
            }
            if(this.comboBox1.SelectedItem  == null && this.SQLDataColumnType != "ingresarManual")
            {
                MessageBox.Show("Rellene todos los campos", "Error");
                return;
            }
            if(this.SQLDataColumnType == "ingresarManual") this.ReturnValue = textBox1.Text;
            else this.ReturnValue = comboBox1.SelectedItem.ToString();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void cancelButtonk(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        /*
        private void on_load(object sender, EventArgs e)
        {
            if (this.SQLDataColumnType == "ingresarManual")
            {
                comboBox1.Hide();
                textBox1.Show();
            }
            else
            {
                comboBox1.Show();
                textBox1.Hide();
            }
            label1.Text = this.title;
            boxLabel.Text = this.instruction;

            if(this.SQLDataColumnType == "cliente")
            {
                DatabaseUtils.cargarClientes(comboBox1);
            }
            if(this.SQLDataColumnType == "libro")
            {
                DatabaseUtils.cargarLibros(comboBox1, "titulo", 1);
            }
            if(this.SQLDataColumnType == "empleado")
            {
                DatabaseUtils.cargarEmpleados(comboBox1);
            }
            if(this.SQLDataColumnType == "categoria")
            {
                DatabaseUtils.cargarCategorias(comboBox1);
            }
            if(this.SQLDataColumnType == "autor")
            {
                try
                {
                    ConexMySQL conex = new ConexMySQL(); conex.open();
                    DataTable autores = conex.selectQuery("SELECT autor FROM LIBRO GROUP BY autor");
                    for(int i = 0; i < autores.Rows.Count; i++)
                    {
                        comboBox1.Items.Add(autores.Rows[i]["autor"]);
                    }
                    conex.close();

                    
                }catch(Exception ex)
                {
                    MessageBox.Show("Ha ocurrido un error de tipo " + ex.Message, "Error");
                }
            }
            
            

        }
        */
    }
}
