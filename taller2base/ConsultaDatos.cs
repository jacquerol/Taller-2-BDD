
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
using static DatabaseUtil.Util;

namespace taller2base
{
    public partial class ConsultaDatos : Form
    {
        
        public string receivedData;
        public string[] entidades;
        public ConsultaDatos()
        {
            InitializeComponent();
            entidades = new string[] { "Cliente", "Categoria", "Vendedor", "Orden", "Proveedor", "Producto" };
        }
        public void DatosPorRut(object sender, KeyPressEventArgs e)
        {
            TextBox box = (TextBox)sender; if (!ComponenteLleno(box) || e.KeyChar != ((char)Keys.Enter)) return;
            DataTableDisplay display = new DataTableDisplay(GetTabla("SELECT * FROM CLIENTE WHERE RUT = '" + box.Text + "'"), "Datos del vendedor " + box.Text);
            display.Show();
        }
        
        public void DatosCompra(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender; if (!ComponenteLleno(box)) return;
            DataTableDisplay display = new DataTableDisplay(GetTabla("SELECT * FROM ORDEN INNER JOIN ORDENPRODUCTO ON ORDENPRODUCTO.IDORDEN = ORDEN.IDORDEN WHERE ORDEN.IDORDEN = '" + box.SelectedItem.ToString() + "'"), "Datos de la compra "+box.SelectedItem.ToString());
            display.Show();
        } 
        public void ProductosCompradosAnual(object sender, EventArgs e)
        {

        }
        public void CantProductosProveedor(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender; if (!ComponenteLleno(box)) return;
            MessageBox.Show("Cantidad: "+GetDato("select DISTINCT count(suministra.idProducto) " +
                "from((suministra inner join producto on suministra.idProducto = producto.id) " +
                "inner join proveedor on suministra.rutProveedor = proveedor.rut and " +
                "proveedor.rut = '" + box.SelectedItem.ToString() + "')"), "Resultado del proveedor "+box.SelectedItem.ToString()); 
        }
        public void DatosVendedor(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender; if (!ComponenteLleno(box)) return;
            DataTableDisplay display = new DataTableDisplay(GetTabla("SELECT * FROM VENDEDOR WHERE NUMEMPLEADO = '" + box.SelectedItem.ToString() + "'"), "Datos del vendedor " + box.SelectedItem.ToString());
            display.Show();
        }
        public void ProductosDeProveedor(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender; string query = 
                "select producto.precioVenta from proveedor inner join suministra on proveedor.rut = suministra.rutProveedor and proveedor.rut = "+box.SelectedItem.ToString()+" inner join producto on suministra.idProducto = producto.id";
            MostrarTabla(box, query, "Productos del proveedor");
        }
        public void ProveedoresDeProducto(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender; if (!ComponenteLleno(box)) return;
            DataTableDisplay display = new DataTableDisplay(
                GetTabla("select distinct p.nombre, p.rut from producto inner join suministra on suministra.idproducto = producto.id and producto.id = '" + box.SelectedItem.ToString() +
                "' inner join proveedor p on p.rut = suministra.rutproveedor"), 
                "Proveedores del producto " + box.SelectedItem.ToString());
            display.Show();
        }
        public void ProductosCompradosPorCategoria(object sender, EventArgs e)
        {
            if(ComponenteLleno(productCategoryButton_category) & ComponenteLleno(productCategoryButton_client))
            {
                ComboBox categoriaComboBox = (ComboBox)sender; ComboBox clienteComboBox = (ComboBox)sender;
                string idcategoria = categoriaComboBox.SelectedItem.ToString(); string rutCliente = clienteComboBox.SelectedItem.ToString();
                string query = "select distinct producto.nombre from((((cliente inner join orden on cliente.rut = orden.rutCliente) inner join ordenProducto on orden.idOrden = ordenProducto.idOrden) inner join producto on ordenProducto.idProducto = producto.id) inner join categoria on producto.idCategoria = categoria.id)";
                MostrarTabla(clienteComboBox, query, "Resultado de la categoria ");
            }
        }
        public void ProductosCompradosPorDia(object sender, EventArgs e)
        {

        }
        public void ProductosCategoria(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender; if (!ComponenteLleno(box)) return;
            MessageBox.Show(GetDato("select distinct count(p.nombre) from categoria c inner join producto p where p.idcategoria = c.id and c.id = '" + box.SelectedItem.ToString() + "'"), "Cantidad");
        }
        public void CategoriaProducto(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender; if (!ComponenteLleno(box)) return;
            DesplegarDatos(GetTabla("select c.nombre from categoria c inner join producto p where p.idcategoria = c.id and p.id = '" + box.SelectedItem.ToString() +  "'"));
        }
        public void VendedoresAntiguedad(object sender, EventArgs e)
        {

        }
        public void Top5Semana(object sender, EventArgs e)
        {

        }
        public void ProductosSinDemanda(object sender, EventArgs e)
        {

        }
        private void label3_Click(object sender, EventArgs e)
        {

        }
        public void DesplegarListadoUniversal(object sender, EventArgs e) {
            object input = ListadoUniversalComboBox.SelectedItem;
            if (input== null) return;
            string text = input.ToString();
            for(int i = 0; i < this.entidades.Length; i++)
            {
                if(text == this.entidades[i]) DesplegarListado((ComboBox)sender, this.entidades[i]);
            }
        }
        public void RellenarCliente(object sender, EventArgs e) { RellenarConRegistros((ComboBox)sender, "cliente"); }
        public void RellenarCategoria(object sender, EventArgs e) { RellenarConRegistros((ComboBox)sender, "categoria"); }
        public void RellenarVendedor(object sender, EventArgs e) { RellenarConRegistros((ComboBox)sender, "vendedor"); }
        public void RellenarCompra(object sender, EventArgs e) { RellenarConRegistros((ComboBox)sender, "orden"); }
        public void RellenarProveedor(object sender, EventArgs e) { RellenarConRegistros((ComboBox)sender, "proveedor"); }
        public void RellenarProducto(object sender, EventArgs e) { RellenarConRegistros((ComboBox)sender, "producto"); }
        public void RellenarListadoUniversal(object sender, EventArgs e) { RellenarComboBox(ListadoUniversalComboBox, this.entidades); }

    }
}
