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
using taller2base;


namespace DatabaseUtil
{
    public static class Util
    {
        /**
         * Retorna vector de strings con los campos de la entidad
         **/
        public static string[] getCamposEntidad(string entidad)
        {
            DataTable tabla = getTabla("SELECT * FROM " + entidad);
            string[] resultado = new string[tabla.Columns.Count];
            for (int i = 0; i < tabla.Columns.Count; i++)
            {
                resultado[i] = tabla.Columns[i].ColumnName;
            }
            return resultado;
        }
        public static Boolean componenteLleno(ComboBox sender){ return sender.SelectedItem != null; }
        public static Boolean componenteLleno(TextBox sender) { return sender.Text != ""; }
        public static void DesplegarListado(ComboBox box, string nombreTabla)
        {
            box.Items.Clear();
            string pk = getTabla("SELECT * FROM " + nombreTabla).Columns[0].ColumnName; //Se asume que la primera columna es la PK ya que solo se usa para entidades especificas
            DataTable tabla = getTabla("SELECT * FROM " + nombreTabla + " ORDER BY " + pk);
            DataTableDisplay display = new DataTableDisplay(tabla, tabla.TableName);
            display.Show();
        }
        /**
         * Rellena una combo box con los valores de las claves primarias de los registros de una entidad dada
         */
        public static void RellenarConRegistros(ComboBox box, string nombreTabla)
        {
            box.Items.Clear();
            string pk = getTabla("SELECT * FROM " + nombreTabla).Columns[0].ColumnName; //Se asume que la primera columna es la PK ya que solo se usa para entidades especificas
            DataTable tabla = getTabla("SELECT DISTINCT " + pk +" FROM " +nombreTabla +" ORDER BY " +pk);
            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                box.Items.Add(tabla.Rows[i][0].ToString());
            }
        }
        /**
         * Rellena una combo box con los elementos de un vector de strings
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
        public static void añadirDato(string query)
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
        public static DataTable getTabla(string query)
        {
            try
            {
                ConexMySQL conex = new ConexMySQL(); conex.open();
                DataTable resultado = conex.selectQuery(query); conex.close();
                //MessageBox.Show(query);
                return resultado;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error de tipo " + ex.Message, "Error");
            }
            return null;
        }
    }
}
