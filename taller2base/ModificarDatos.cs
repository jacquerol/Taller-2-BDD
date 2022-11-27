using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DatabaseUtil.Util;

namespace taller2base
{
    public partial class ModificarDatos : Form
    {
        public string[] entidades;
        public ModificarDatos()
        {
            InitializeComponent();
            this.entidades = new string[] { "Cliente", "Categoria", "Vendedor", "Orden", "Proveedor", "Producto" };
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
        private void modificar(object sender, EventArgs e)
        {

        }
        /**
         * Insertar un dato a la base de datos. Puede ser una de las siguientes opciones: (2)
         * Insertar un nuevo cliente, Insertar un nuevo proveedor, Insertar un nuevo producto, 
         * Insertar un nuevo vendedor, Insertar una nueva categoría 
         **/
        private void insertar(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender; if (!componenteLleno(box)) return; string entidad = box.SelectedItem.ToString();
            for(int i = 0; i < entidades.Length; i++)
            {
                if(entidad == entidades[i])
                {
                    DataTableDisplay display = new DataTableDisplay(getCamposEntidad(entidades[i]), entidad, true);
                }
            }
        }
        private void cargarEntidades(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender;
            for(int i = 0; i < entidades.Length; i++)
            {
                box.Items.Add(entidades[i]);
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ModificarDatos_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
