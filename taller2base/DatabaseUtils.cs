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
    class DatabaseUtils
    {   
        
        /**
         * Recibe dos listas paralelas e imprime nombre y dato
         **/
        public void Display(string[] tipoDato, string[] dato)
        {
            if (tipoDato.Length != dato.Length) return;
            string mensaje = "";
            for(int i = 0; i < tipoDato.Length; i++)
            {
                mensaje += tipoDato[i] + ": " + dato[i] + "\n";
            }
        }
        /**
         * Inserta o actualiza un valor
         **/
        public void Modificar(string query)
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
        public string GetDato(string query)
        {
            try
            {
                ConexMySQL conex = new ConexMySQL(); conex.open();
                string resultado = conex.selectQueryScalar("query"); conex.close();
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
        public DataTable GetTabla(string query)
        {
            try
            {
                DataTable tabla = new DataTable();
                ConexMySQL conex = new ConexMySQL(); conex.open();
                DataTable resultado = conex.selectQuery("query"); conex.close();
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
        public DataTable GetListado(string tipoDato) { return GetTabla("SELECT * FROM " + tipoDato); }

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
