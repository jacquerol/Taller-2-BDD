
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
         **/
        public void datosVendedor(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender; if (!componenteLleno(box)) return;
                new DataTableDisplay(getTabla(
                    "SELECT *, ROUND(( DATEDIFF(CURDATE(), VENDEDOR.FECHACONTRATACION))/365,0) AS Antiguedad FROM VENDEDOR WHERE VENDEDOR.NUMEMPLEADO = " + box.SelectedItem.ToString() + ""), 
                    "Datos del vendedor " + box.SelectedItem.ToString());
        }
        /**
         * Los vendedores de mayor antigüedad y los vendedores de menor antigüedad en la empresa (indicar los años de antigüedad) (3) 
         **/
        public void VendedoresAntiguedad(object sender, EventArgs e)
        {
            string query = "SELECT *, ROUND(( DATEDIFF(CURDATE(), V.FECHACONTRATACION))/365,0) AS Antiguedad FROM VENDEDOR V WHERE V.FECHACONTRATACION = (SELECT MIN(V.FECHACONTRATACION) FROM VENDEDOR V) OR V.FECHACONTRATACION = (SELECT MAX(V.FECHACONTRATACION) FROM VENDEDOR V)";
            new DataTableDisplay(getTabla(query), "Vendedores de mayor y menor antiguedad");
        }
        /**
         * Datos de una orden de compra, incluyendo el cliente, el vendedor y los productos de la orden (4)
         **/
        public void datosCompra(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender; if (!componenteLleno(box)) return;
            new DataTableDisplay(getTabla("SELECT * FROM ORDEN INNER JOIN ORDENPRODUCTO ON ORDENPRODUCTO.IDORDEN = ORDEN.IDORDEN WHERE ORDEN.IDORDEN = '" + box.SelectedItem.ToString() + "'"), "Datos de la compra " + box.SelectedItem.ToString());
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
         **/
        public void proveedoresDeProducto(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender; if (!componenteLleno(box)) return;
            string idProducto = box.SelectedItem.ToString();
            new DataTableDisplay(
                getTabla("SELECT prov.rut FROM proveedor prov INNER JOIN suministra s ON s.rutProveedor = prov.rut INNER JOIN PRODUCTO ON PRODUCTO.ID = s.idProducto AND PRODUCTO.ID = " + box.SelectedItem.ToString()), "Proveedores de producto "+box.SelectedItem.ToString());
        }
        /**
         * Los productos que suministra un proveedor, indicando el precio y la cantidad (8)
         **/
        public void productosDeProveedor(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender; if (!componenteLleno(box)) return;
            string query =
                "select producto.precioVenta from proveedor inner join suministra on proveedor.rut = suministra.rutProveedor and proveedor.rut = '" + box.SelectedItem.ToString() + "' inner join producto on suministra.idProducto = producto.id";
            new DataTableDisplay(getTabla(query),
                "Productos del proveedor " + box.SelectedItem.ToString());
        }
        /**
         * Cantidad de órdenes de compra asociadas a un cliente, en los últimos 30 días (9) #Incompleta
         **/
        public void ordenesCliente(object sender, EventArgs e)
        {
            TextBox box = (TextBox)sender; if (!componenteLleno(box)) return;
            new DataTableDisplay(getTabla("SELECT * FROM CLIENTE WHERE RUT = '" + box.Text + "'"), "Datos del vendedor " + box.Text);
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
            new DataTableDisplay(getTabla("SELECT * FROM CLIENTE WHERE RUT = '" + box.Text + "'"), "Datos del vendedor " + box.Text);
        }
        /**
         * Los 5 productos más vendidos de la semana anterior, indicar la cantidad de cada producto (12)
         **/
        public void Top5Semana(object sender, EventArgs e)
        {
            string query = "select prod.id, prod.nombre, op.cantidad from producto prod inner join ordenproducto op on op.idProducto = prod.id inner join orden o on o.idOrden = op.idOrden where WEEK(o.fecha) = WEEK(CURDATE()) group by prod.nombre order by op.cantidad DESC limit 5 ;";
            new DataTableDisplay(getTabla(query), "Top 5 ultima semana");
        }
        /**
         * Los productos que ha comprado un cierto cliente durante el año, indicar la cantidad de cada producto (13)
         **/
        public void ProductosCompradosAnual(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender; if (!componenteLleno(box)) return;
            string query = "select distinct prod.nombre, op.cantidad from producto prod inner join ordenproducto op on op.idProducto = prod.id inner join orden o on o.idOrden = op.idOrden where YEAR(o.fecha) = YEAR(CURDATE()) and o.rutCliente = '"+box.SelectedItem.ToString()+"'";
            new DataTableDisplay(getTabla(query), "Datos de " + box.SelectedItem.ToString());
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
                new DataTableDisplay(getTabla(query), "Resultado");
            }
        }
        /**
        * Los productos que no han participado en órdenes de compra en el último mes (15)
        **/
        public void ProductosSinDemanda(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender; if (!componenteLleno(box)) return;
            string query = "SELECT * FROM((orden inner join ordenProducto on orden.idOrden = ordenProducto.idOrden) inner join producto on ordenProducto.idProducto = producto.id) WHERE NOT EXISTS(SELECT ORDEN.fecha BETWEEN DATE_ADD(NOW(), INTERVAL - 1 MONTH) AND NOW()); ";
            new DataTableDisplay(getTabla(query), "Datos de " + box.SelectedItem.ToString());
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
