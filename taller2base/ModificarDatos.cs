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
        public string[] entidades, modificaciones;
        public string selectedEntity;
        public ModificarDatos()
        {
            InitializeComponent();
            this.entidades = new string[] { "Cliente", "Categoria", "Vendedor", "Orden", "Proveedor", "Producto" };
            this.modificaciones = new string[] { "Cambiar precio", "Cambiar salario", "Agregar saldo", "Eliminar cliente"};
            this.selectedEntity = "";
        }

        /**
         * Atender la orden de compra de un cliente (se debe tener saldo suficiente para aprobar la orden) (1)
         **/
        private void atenderCompra(object sender, EventArgs e)
        {
            new DataTableDisplay(getCamposEntidad("ORDENPRODUCTO"), "ordenproducto", true);
            new DataTableDisplay(getCamposEntidad("ORDEN"), "orden", true);
        }
        /**
         * Insertar un dato a la base de datos. Puede ser una de las siguientes opciones: (2)
         * Insertar un nuevo cliente, Insertar un nuevo proveedor, Insertar un nuevo producto, 
         * Insertar un nuevo vendedor, Insertar una nueva categoría 
         **/
        private void insertar(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender; if (!componenteLleno(box)) return; string entidad = box.SelectedItem.ToString();
            for (int i = 0; i < entidades.Length; i++)
            {
                if (entidad == entidades[i])
                {
                    DataTableDisplay display = new DataTableDisplay(getCamposEntidad(entidades[i]), entidad, true);

                }
            }
        }
        /**
         * Modificar un dato de la base de datos. Puede ser uno de los siguientes: (3)
         * Cambiar el precio de venta de un producto al cliente, Cambiar el salario a un vendedor, 
         * Agregar dinero a la cuenta de un cliente, Eliminar un cliente (solamente se pone una marca de cliente inactivo) 
         **/
        private void enviarModificacion(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender; if (!componenteLleno(modifyComboBox) || !componenteLleno(registroComboBox)) return;
            string operacion = modifyComboBox.SelectedItem.ToString(); string pk = registroComboBox.SelectedItem.ToString();
            if(operacion != "Eliminar cliente") new DataTableDisplay(selectedEntity, pk);

        }
        private void seleccionarEntidad(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender; if (!componenteLleno(box)) return; string operacion = box.SelectedItem.ToString();
            string[] entidadOperacion = new string[] { "Producto", "Vendedor", "Cliente", "Cliente" };
            for(int i = 0; i < entidadOperacion.Length; i++)
            {
                if(operacion == modificaciones[i])
                {
                    this.selectedEntity = entidadOperacion[i];
                    RellenarConRegistros(registroComboBox, entidadOperacion[i]);
                }
            }
        }

        
        private void rellenarModificaciones(object sender, EventArgs e){RellenarComboBox((ComboBox)sender, modificaciones);}
        private void rellenarEntidades(object sender, EventArgs e){RellenarComboBox((ComboBox)sender, entidades);}
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
