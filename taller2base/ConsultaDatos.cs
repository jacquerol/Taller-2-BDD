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
    public partial class ConsultaDatos : Form
    {

        
        public string receivedData;
        public ConsultaDatos()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// función que trabaja con los datos del cliente para poder consultar los datos correspondientes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void clientData(object sender, EventArgs e)
        {
            string rut = ""; string nombre; string email; string saldo; string precioNeto;
            using (var form = new ModularForm("cliente", "Datos de un cliente", "Ingrese el rut del cliente"))
            {
                var result = form.ShowDialog();
                if(result == DialogResult.OK)
                {
                    rut = form.ReturnValue;
                }
                if (result == DialogResult.Cancel) return;
            }
            try
            {
                ConexMySQL conex = new ConexMySQL(); conex.open();
                string query = "SELECT nombre, email, saldo FROM CLIENTE c INNER JOIN VENTA v on c.rut = v.rutCliente WHERE v.fecha > CURDATE()-90 and c.rut = '" + rut + "'";
                DataTable data = conex.selectQuery(query);
                nombre = data.Rows[0]["nombre"].ToString();
                email = data.Rows[0]["email"].ToString();
                saldo = data.Rows[0]["saldo"].ToString();
                MessageBox.Show("Nombre: " + nombre + "\nCorreo: " + email + "\nSaldo: " + saldo, "Estadísticas del cliente");
                conex.close();

            }
            catch(Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error de tipo " + ex.Message,"Error");
            }
        }
        /// <summary>
        /// función para determinar el top de las 5 ventas la última semana
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void top5salesLastWeek(object sender, EventArgs e)
        {
            try
            {
                ConexMySQL conex = new ConexMySQL(); conex.open();
                string query = "SELECT isbnLibro, cantidad FROM VENTA v INNER JOIN VENTA_LIBRO vl WHERE v.ID = idVenta AND YEAR(v.fecha) = YEAR(CURDATE()) AND WEEKOFYEAR(v.fecha) = (WEEKOFYEAR(CURDATE()) - 1) LIMIT 5";
                DataTable libros = conex.selectQuery(query);
                string message = "";
                for (int i = 0; i < libros.Rows.Count; i++)
                {
                    message = "Titulo: " + libros.Rows[i]["isbnLibro"] + " cantidad: " + libros.Rows[i]["cantidad"] + "\n";
                }
                if (libros.Rows.Count == 0) message = "No se encontraron ventas";
                MessageBox.Show(message, "Top 10 libros");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error de tipo " + ex.Message, "Error");
            }
        }
        /// <summary>
        /// función para determinar el top de las 10 ventas el último año
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void top10salesLastYear(object sender, EventArgs e)
        {
            try
            {
                ConexMySQL conex = new ConexMySQL(); conex.open();
                string query = "SELECT isbnLibro, cantidad FROM VENTA v INNER JOIN VENTA_LIBRO vl WHERE v.ID = idVenta AND YEAR(v.fecha) = YEAR(CURDATE()) LIMIT 10";
                DataTable libros = conex.selectQuery(query);
                string message = "";
                for (int i = 0; i < libros.Rows.Count; i++)
                {
                    message = "Titulo: " + libros.Rows[i]["isbnLibro"] + " cantidad: " + libros.Rows[i]["cantidad"] + "\n";
                }
                if (libros.Rows.Count == 0) message = "No se encontraron ventas";
                MessageBox.Show(message, "Top 10 libros");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error de tipo " + ex.Message, "Error");
            }
        }
        
        /// <summary>
        /// función para poder mostrar que libros corresponden a que categoría
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void categoryBooks(object sender, EventArgs e)
        {
            string categoria = "";
            using (var form = new ModularForm("categoria", "Libros de una categoría", "Seleccione la categoría"))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    categoria = form.ReturnValue;
                }
                if(result == DialogResult.Cancel) return;
            }
            try
            {
                ConexMySQL conex = new ConexMySQL(); conex.open();
                string query = "SELECT titulo FROM LIBRO l INNER JOIN CATEGORIA c WHERE c.nombre ='"+categoria+"' AND idCategoria = ID";
                DataTable libros = conex.selectQuery(query);
                string message = "";
                for(int i = 0; i < libros.Rows.Count; i++)
                {
                    message += "Titulo: " + libros.Rows[i]["titulo"] + "\n";
                }
                MessageBox.Show(message, "Libros de la categoría " + categoria);
            } catch(Exception ex)
            {
                MessageBox.Show("Hubo un error de tipo " + ex.Message, "Error");
            }

        }
        /// <summary>
        /// función para consultar los autores de cada libro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void authorBooks(object sender, EventArgs e)
        {
            string autor = "";
            using (var form = new ModularForm("autor", "Libros por autor", "Seleccione el autor"))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    autor = form.ReturnValue;
                }
                if (result == DialogResult.Cancel) return;
            }
            try
            {
                ConexMySQL conex = new ConexMySQL(); conex.open();
                string query = "SELECT titulo FROM LIBRO WHERE AUTOR = '" + autor + "'";
                DataTable libros = conex.selectQuery(query);
                string message = "";
                for(int i = 0; i < libros.Rows.Count; i++)
                {
                    message += "Titulo: " + libros.Rows[i]["titulo"] + "\n";
                }
                MessageBox.Show(message, "Libros del autor " + autor);
                conex.close();
            }catch(Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error de tipo " + ex.Message, "Error");
            }
        }
        /// <summary>
        /// función para consultar títulos de un libro de acuerdo a una palabra clave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void searchByTitle(object sender, EventArgs e)
        {
            string word = "";
            using (var form = new ModularForm("ingresarManual", "Buscar un libro", "Ingrese la palabra"))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    word = form.ReturnValue;
                }
                if (result == DialogResult.Cancel) return;
            }
            try
            {
                ConexMySQL conex = new ConexMySQL(); conex.open();
                string query = "SELECT titulo, ISBN FROM LIBRO WHERE titulo LIKE '%" + word + "%'";
                DataTable libros = conex.selectQuery(query);
                string message = "";
                for (int i = 0; i < libros.Rows.Count; i++)
                {
                    message += "Titulo: " + libros.Rows[i]["titulo"];
                    message += " ISBN: " + libros.Rows[i]["ISBN"]+"\n";
                }
                MessageBox.Show(message, "Libros encontrados");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error de tipo " + ex.Message, "Error");
            }
        }
        /// <summary>
        /// función para poder consultar las compras que ha hecho cada cliente este año
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void clientSalesThisYear(object sender, EventArgs e)
        {
            string rut = "";
            using (var form = new ModularForm("cliente", "Compras cliente", "Seleccione el rut del cliente"))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    rut = form.ReturnValue;
                }
                if (result == DialogResult.Cancel) return;

            }
            try
            {
                ConexMySQL conex = new ConexMySQL(); conex.open();
                string query = "SELECT isbnLibro, cantidad FROM VENTA v INNER JOIN VENTA_LIBRO vl WHERE rutCliente = '" + rut + "' AND YEAR(v.fecha) = YEAR(CURDATE())";
                DataTable libros = conex.selectQuery(query);
                string message = "";
                for(int i = 0; i < libros.Rows.Count; i++)
                {
                    message += "ISBN: " + libros.Rows[i]["isbnLibro"] + "\nCantidad: " + libros.Rows[i]["cantidad"]+"\n";
                }
                MessageBox.Show(message, "Compras del cliente en el año");
                conex.close();

            }catch(Exception ex)
            {
                MessageBox.Show("Hubo un error de tipo " + ex.Message, "Error");
            }


        }
        /// <summary>
        /// función que permite buscar los libros que un cliente dado compró, que son de una categoría dada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void categoryBooksClient(object sender, EventArgs e) 
        {
            string cliente = ""; string categoria = "";
            using (var form = new ModularForm("cliente", "Libros por categoria", "Seleccione el RUT del cliente"))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    cliente = form.ReturnValue;
                }
                if (result == DialogResult.Cancel) return;
            }
            using (var form = new ModularForm("categoria", "Libros por categoria", "Seleccione el libro"))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    categoria = form.ReturnValue;
                }
                if (result == DialogResult.Cancel) return;
            }
            try
            {
                ConexMySQL conex = new ConexMySQL(); conex.open();

                string query = "SELECT vl.isbnLibro FROM VENTA_LIBRO vl INNER JOIN LIBRO l WHERE idCategoria IN (SELECT c.ID FROM CATEGORIA c where c.nombre = '" + categoria + "' GROUP BY ID) AND vl.idVenta IN (SELECT v.ID FROM VENTA v WHERE v.rutCliente = '" + cliente+"' GROUP BY v.ID) GROUP BY isbnLibro";
                DataTable libros = conex.selectQuery(query);
                string message = "";
                for (int i = 0; i < libros.Rows.Count; i++)
                {
                    message += "ISBN: " + libros.Rows[i]["isbnLibro"] + "\n";
                }
                MessageBox.Show(message, "Libros de la categoría comprados por el cliente");
                conex.close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error de tipo " + ex.Message, "Error");
            }

        }
        /// <summary>
        /// función para consultar qué libros no se han vendido este mes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void noSalesLastMonth(object sender, EventArgs e)
        {
            try
            {
                ConexMySQL conex = new ConexMySQL(); conex.open();
                string query = "SELECT titulo FROM LIBRO l WHERE NOT EXISTS (SELECT * FROM VENTA_LIBRO vl WHERE vl.isbnLibro = l.ISBN AND idVenta IN (SELECT ID FROM VENTA v WHERE MONTH(v.fecha) = MONTH(CURDATE())))";
                DataTable libros = conex.selectQuery(query);
                string message = "";
                for(int i = 0; i < libros.Rows.Count; i++)
                {
                    message += "Titulo: " + libros.Rows[i]["titulo"] + "\n";
                }
                MessageBox.Show(message, "Libros sin ventas en el mes");
                conex.close();
            }catch(Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error de tipo " + ex.Message); 
            }
        }
        /// <summary>
        /// función que permite consultar los datos de un libro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void bookData(object sender, EventArgs e)
        {
            string book = "";
            using (var form = new ModularForm("libro", "Datos libro", "Seleccione el libro"))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    book = form.ReturnValue;
                    MessageBox.Show(book);
                }
                if (result == DialogResult.Cancel) return;
            }
            try
            {
                ConexMySQL conex = new ConexMySQL(); conex.open();
                string query = "SELECT precioNeto, stock FROM LIBRO WHERE titulo = '" + book + "'";
                DataTable data = conex.selectQuery(query);
                int precioNeto = int.Parse(data.Rows[0]["precioNeto"].ToString());
                int precioTotal = (int)(precioNeto + precioNeto * 0.19);
                MessageBox.Show("Precio con IVA incluido: "+precioTotal.ToString()+"\nStock: "+ data.Rows[0]["stock"].ToString(),"Datos del libro "+book);
                conex.close();
            }catch(Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error de tipo " + ex.Message,"Error");
            }


        }
        /// <summary>
        /// funcion para consultar las ventas diarias que tiene un libro en específico
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void dailyBookSales(object sender, EventArgs e)
        {
            string book = "";
            using (var form = new ModularForm("libro", "Datos libro", "Seleccione el libro"))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    book = form.ReturnValue;
                }
                if (result == DialogResult.Cancel) return;
            }
            try
            {
                ConexMySQL conex = new ConexMySQL(); conex.open();
                string query = "SELECT cantidad FROM VENTA_LIBRO WHERE idVenta = (SELECT ID FROM VENTA WHERE fecha = CURDATE()) AND isbnLibro = (SELECT ISBN FROM LIBRO WHERE titulo = '" + book + "')";
                DataTable libros = conex.selectQuery(query);
                string message = "";
                MessageBox.Show("Ventas: " + libros.Rows[0]["cantidad"], "Ventas del libro en el día");
                conex.close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error de tipo " + ex.Message);
            }
        }

        /// <summary>
        /// función que permite buscar los libros que estén en descuento
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void discountCategoryBooks(object sender, EventArgs e)
        {
            string categoria = "";
            using (var form = new ModularForm("categoria", "Libros de una categoría en descuento", "Seleccione la categoría"))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK) categoria = form.ReturnValue;
                if (result == DialogResult.Cancel) return;
            }
            try
            {
                ConexMySQL conex = new ConexMySQL(); conex.open();
                string query = "SELECT titulo FROM LIBRO WHERE porcentajeDescuento > 0 AND idCategoria = (SELECT ID FROM CATEGORIA WHERE nombre = '"+categoria+"')";
                DataTable libros = conex.selectQuery(query);
                string message = "";
                for(int i = 0; i < libros.Rows.Count; i++)
                {
                    message += "Titulo: " + libros.Rows[i]["titulo"] + "\n";
                }
                MessageBox.Show(message, "Libros de la categoría en descuento");
                conex.close();
            }catch(Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error de tipo " + ex.Message);
            }


        }
        /// <summary>
        /// función que permite consultar qué tan antiguo o que tan nuevo es un empleado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void oldestLatestEmployees(object sender, EventArgs e)
        {
            try
            {
                ConexMySQL conex = new ConexMySQL(); conex.open();
                string query = "SELECT rut FROM EMPLEADO WHERE ";
                DataTable oldest = conex.selectQuery("SELECT e.rut as rut, TIMESTAMPDIFF(YEAR, fechaContratacion, CURDATE()) as year FROM EMPLEADO e WHERE fechaContratacion = (SELECT MIN(fechaContratacion) FROM EMPLEADO)");
                DataTable newest = conex.selectQuery("SELECT e.rut as rut, TIMESTAMPDIFF(YEAR, fechaContratacion, CURDATE()) as year FROM EMPLEADO e WHERE fechaContratacion = (SELECT MAX(fechaContratacion) FROM EMPLEADO)");
                string rutOldest = oldest.Rows[0]["rut"].ToString();
                string rutNewest = newest.Rows[0]["rut"].ToString();
                string yearOldest = oldest.Rows[0]["year"].ToString();
                string yearNewest = newest.Rows[0]["year"].ToString();
                MessageBox.Show("Rut del trabajador mas antiguo: " + rutOldest + " Años de antiguedad: " + yearOldest + "\n Rut del trabajador mas nuevo: " + rutNewest + " Años de antiguedad: " + yearNewest, "Estadísticas");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error de tipo " + ex.Message, "Error");
            }
        }
        

        
    }
}
