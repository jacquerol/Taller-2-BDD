
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
        /**
         * Emitir un listado. Puede ser uno de los siguientes listados: (1)
         * Listado de proveedores, Listado de clientes, Listado de productos, 
         * Listado de categorías, Listado de vendedores 
         **/
        public void DesplegarListadoUniversal(object sender, EventArgs e)
        {
            object input = ListadoUniversalComboBox.SelectedItem;
            if (input == null) return;
            string text = input.ToString();
            for (int i = 0; i < this.entidades.Length; i++)
            {
                if (text == this.entidades[i]) DesplegarListado((ComboBox)sender, this.entidades[i]);
            }
        }
        /**
         * Datos de un vendedor por rut (2) 
         * #Falta antiguedad
         **/
        public void datosVendedor(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender; if (!componenteLleno(box)) return;
            DataTableDisplay display = 
                new DataTableDisplay(getTabla(
                    "SELECT * FROM VENDEDOR WHERE NUMEMPLEADO = '" + box.SelectedItem.ToString() + "'"), 
                    "Datos del vendedor " + box.SelectedItem.ToString());
        }
        /**
         * Los vendedores de mayor antigüedad y los vendedores de menor antigüedad en la empresa (indicar los años de antigüedad) (3) 
         * #Incompleta
         **/
        public void VendedoresAntiguedad(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender; if (!componenteLleno(box)) return;
            string query = "Rellenar con query";
            DataTableDisplay display = new DataTableDisplay(getTabla(query), "Datos de " + box.SelectedItem.ToString());
        }
        /**
         * Datos de una orden de compra, incluyendo el cliente, el vendedor y los productos de la orden (4)
         **/
        public void datosCompra(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender; if (!componenteLleno(box)) return;
            DataTableDisplay display = new DataTableDisplay(getTabla("SELECT * FROM ORDEN INNER JOIN ORDENPRODUCTO ON ORDENPRODUCTO.IDORDEN = ORDEN.IDORDEN WHERE ORDEN.IDORDEN = '" + box.SelectedItem.ToString() + "'"), "Datos de la compra " + box.SelectedItem.ToString());
        }
        /**
         * La categoría de un producto (5)
         **/
        public void CategoriaProducto(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender; if (!componenteLleno(box)) return;
            DesplegarDatos(getTabla("select c.nombre from categoria c inner join producto p where p.idcategoria = c.id and p.id = '" + box.SelectedItem.ToString() + "'"));
        }
        /**
         * Cantidad de productos asociados a una categoría (6)
         **/
        public void ProductosCategoria(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender; if (!componenteLleno(box)) return;
            MessageBox.Show(GetDato("select distinct count(p.nombre) from categoria c inner join producto p where p.idcategoria = c.id and c.id = '" + box.SelectedItem.ToString() + "'"), "Cantidad");
        }
        /**
         * Los proveedores que suministran un producto (7)
         * #No funciona
         **/
        public void proveedoresDeProducto(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender; if (!componenteLleno(box)) return;
            DataTableDisplay display = new DataTableDisplay(
                getTabla("select distinct p.nombre, p.rut from producto inner join suministra on suministra.idproducto = producto.id and producto.id = '" + box.SelectedItem.ToString() +
                "' inner join proveedor p on p.rut = suministra.rutproveedor"),
                "Proveedores del producto " + box.SelectedItem.ToString());
        }
        /**
         * Los productos que suministra un proveedor, indicando el precio y la cantidad (8)
         **/
        public void productosDeProveedor(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender; if (!componenteLleno(box)) return;
            string query =
                "select producto.precioVenta from proveedor inner join suministra on proveedor.rut = suministra.rutProveedor and proveedor.rut = " + box.SelectedItem.ToString() + " inner join producto on suministra.idProducto = producto.id";
            DataTableDisplay display = new DataTableDisplay(getTabla(query),
                "Productos del proveedor " + box.SelectedItem.ToString());
        }
        /**
         * Cantidad de órdenes de compra asociadas a un cliente, en los últimos 30 días (9) #Incompleta
         **/
        public void ordenesCliente(object sender, EventArgs e)
        {
            TextBox box = (TextBox)sender; if (!componenteLleno(box)) return;
            DataTableDisplay display = new DataTableDisplay(getTabla("SELECT * FROM CLIENTE WHERE RUT = '" + box.Text + "'"), "Datos del vendedor " + box.Text);
        }
        /**
         * Cantidad total de productos que suministra un vendedor (10)
         **/
        public void cantProductosProveedor(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender; if (!componenteLleno(box)) return;
            MessageBox.Show("Cantidad: " + GetDato("select DISTINCT count(suministra.idProducto) " +
                "from((suministra inner join producto on suministra.idProducto = producto.id) " +
                "inner join proveedor on suministra.rutProveedor = proveedor.rut and " +
                "proveedor.rut = '" + box.SelectedItem.ToString() + "')"), "Resultado del proveedor " + box.SelectedItem.ToString());
        }
        /**
         * Dado un rut de cliente desplegar: rut, nombre, saldo en su cuenta, monto total por órdenes de compras emitidas en los últimos 3 meses (11) 
         * #Falta monto
         **/
        public void datosPorRut(object sender, KeyPressEventArgs e)
        {
            TextBox box = (TextBox)sender; if (!componenteLleno(box) || e.KeyChar != ((char)Keys.Enter)) return;
            DataTableDisplay display = new DataTableDisplay(getTabla("SELECT * FROM CLIENTE WHERE RUT = '" + box.Text + "'"), "Datos del vendedor " + box.Text);
        }
        /**
         * Los 5 productos más vendidos de la semana anterior, indicar la cantidad de cada producto (12)
         **/
        public void Top5Semana(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender; if (!componenteLleno(box)) return;
            string query = "Rellenar con query";
            DataTableDisplay display = new DataTableDisplay(getTabla(query), "Datos de  " + box.SelectedItem.ToString());
        }
        /**
         * Los productos que ha comprado un cierto cliente durante el año, indicar la cantidad de cada producto (13)
         **/
        public void ProductosCompradosAnual(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender; if (!componenteLleno(box)) return;
            string query = "Rellenar con query";
            DataTableDisplay display = new DataTableDisplay(getTabla(query), "Datos de " + box.SelectedItem.ToString());
        }
        /**
         * Los productos de una cierta categoría que ha comprado un cliente (14)
         **/
        public void ProductosCompradosPorCategoria(object sender, EventArgs e)
        {
            if (componenteLleno(productCategoryButton_category) & componenteLleno(productCategoryButton_client))
            {
                ComboBox categoriaComboBox = (ComboBox)sender; ComboBox clienteComboBox = (ComboBox)sender;
                string idcategoria = categoriaComboBox.SelectedItem.ToString(); string rutCliente = clienteComboBox.SelectedItem.ToString();
                string query = "select distinct producto.nombre from((((cliente inner join orden on cliente.rut = orden.rutCliente) inner join ordenProducto on orden.idOrden = ordenProducto.idOrden) inner join producto on ordenProducto.idProducto = producto.id) inner join categoria on producto.idCategoria = categoria.id)";
                DataTableDisplay display = new DataTableDisplay(getTabla(query), "Resultado"); display.Show();
            }
        }
        /**
        * Los productos que no han participado en órdenes de compra en el último mes (15)
        * #Incompleta
        **/
        public void ProductosSinDemanda(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender; if (!componenteLleno(box)) return;
            string query = "Rellenar con query";
            DataTableDisplay display = new DataTableDisplay(getTabla(query), "Datos de " + box.SelectedItem.ToString());
        }
        /**
         * Los productos que fueron comprados por los clientes en un cierto día (16)
         * #Incompleta
         **/
        public void ProductosCompradosPorDia(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender; if (!componenteLleno(box)) return;
            string query = "Rellenar con query";
            DataTableDisplay(getTabla(query), "Datos de " + box.SelectedItem.ToString());
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
