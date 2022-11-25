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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ConexMySQL conex = new ConexMySQL();
            conex.open();
            conex.close();
        }


        private void modifyButton_Click(object sender, EventArgs e)
        {
            ModificarDatos modificarDatos = new ModificarDatos();
            modificarDatos.Show();
        }

        private void statisticsButton_Click(object sender, EventArgs e)
        {
            ConsultaDatos consultaDatos = new ConsultaDatos();
            consultaDatos.Show();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

    }
}

