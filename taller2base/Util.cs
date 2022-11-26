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


namespace DatabaseUtil
{
    public static class Util
    {
        public static string[] FilaALista(DataTable tabla, int posicion)
        {
            string[] resultado = new string[tabla.Rows.Count];
            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                resultado[i] = tabla.Rows[i][0].ToString();
            }
            return resultado;
        }
        /**
         * Rellena una combo box con los elementos de un string separados por comas
         **/
        public static void RellenarComboBox(ComboBox box, string[] fields)
        {
            box.Items.Clear();
            for (int i = 0; i < fields.Length; i++)
            {
                box.Items.Add(fields[i]);
            }
        }
        /**
         * Recibe una DataTable de una sola entidad y despliega sus datos
         **/
        public static void DesplegarDatos(DataTable entidadUnica)
        {
            string mensaje = "";
            for (int i = 0; i < entidadUnica.Columns.Count; i++) {mensaje += entidadUnica.Columns[i].ColumnName.ToUpper() + ": " + entidadUnica.Rows[0][i] + "\n";}
            MessageBox.Show(mensaje, "Datos de "+entidadUnica.TableName);
        }
        /**
         * Inserta o actualiza un valor
         **/
        public static void Modificar(string query)
        {
            try
            {
                ConexMySQL conex = new ConexMySQL(); conex.open();
                conex.executeNonQuery(query); conex.close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error de tipo : " + ex.Message);
            }
        }
        /**
         * Selecciona un solo dato de una columna
         **/
        public static string GetDato(string query)
        {
            try
            {
                ConexMySQL conex = new ConexMySQL(); 
                conex.open();
                string resultado = conex.selectQueryScalar(query); 
                conex.close();
                return resultado;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error de tipo " + ex.Message, "Error");
            }
            return null;
        }
        /**
         * Selecciona multiples columnas
         **/
        public static DataTable GetTabla(string query)
        {
            try
            {
                ConexMySQL conex = new ConexMySQL(); conex.open(); 
                DataTable resultado = conex.selectQuery(query); conex.close();
                return resultado;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error de tipo " + ex.Message, "Error");
            }
            return null;
        }
        /**
         * Retorna el listado completo del elemento dado
         **/
        public static DataTable GetListado(string tipoDato) { return GetTabla("SELECT * FROM " + tipoDato); }

        /* Codigo obsoleto
        public static int checkFields(TextBox[] fields)
        {
            for(int i = 0; i < fields.Length; i++)
            {
                if(fields[i].Text == "") { return 0; }
            }
            return 1;
        }
        public static void cargarClientes(ComboBox list)
        {
            ConexMySQL conex = new ConexMySQL(); conex.open();
            string query = "SELECT rut, nombre, inactivo FROM CLIENTE";
            DataTable clientes = conex.selectQuery(query);
            for (int i = 0; i < clientes.Rows.Count; i++)
            {
                if(int.Parse(clientes.Rows[i]["inactivo"].ToString()) == 0) list.Items.Add(clientes.Rows[i]["RUT"]);

            }
            conex.close();
        }
        public static void cargarLibros(ComboBox list, string datoMostrado, int mostrarSinStock)
        {
            ConexMySQL conex = new ConexMySQL(); conex.open();
            string query = "SELECT ISBN, titulo, stock FROM LIBRO";
            DataTable libros = conex.selectQuery(query);
            for (int i = 0; i < libros.Rows.Count; i++)
            {
                if(libros.Rows[i]["stock"].ToString() != "0" || mostrarSinStock == 1) list.Items.Add(libros.Rows[i][datoMostrado]);
            }
            conex.close();
        }
        public static void cargarCategorias(ComboBox list)
        {
            ConexMySQL conex = new ConexMySQL(); conex.open();
            DataTable categorias = conex.selectQuery("SELECT ID, nombre FROM CATEGORIA");
            for(int i = 0; i < categorias.Rows.Count; i++)
            {
                list.Items.Add(categorias.Rows[i]["nombre"]);
            }
            conex.close();
        }
        public static void cargarEmpleados(ComboBox list)
        {
            ConexMySQL conex = new ConexMySQL(); conex.open();
            DataTable empleados = conex.selectQuery("SELECT rut, nombre FROM EMPLEADO");
            for (int i = 0; i < empleados.Rows.Count; i++)
            {
                list.Items.Add(empleados.Rows[i]["rut"]);
            }
            conex.close();
        }
        */
    }
}
