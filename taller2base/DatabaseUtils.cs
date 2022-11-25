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
