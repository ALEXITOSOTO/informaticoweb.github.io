using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ComponentesInformaticos
{
    public partial class Componentes : System.Web.UI.Page
    {
        string cadenaConexion;
        SqlConnection conexion;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Conexion
            this.cadenaConexion = ConfigurationManager.ConnectionStrings["conexionBddInformatico"].ConnectionString;
            this.conexion = new SqlConnection(cadenaConexion);
            if (!IsPostBack) // Reacargar pagina y que se vuelva a conectar a la bdd
            {
                //Cargar los datos del form
                cargarDatosMarca();
                cargarDatosColor();
                consultarComponentesBDD();
                //Llamar el metodo de consultarComponentesBDD

            }
        }
        public void cargarDatosMarca()
        {
            slt_marca_comp.Items.Add(new ListItem("Seleccionar marca", ""));
            slt_marca_comp.Items.Add(new ListItem("HP", "HP"));
            slt_marca_comp.Items.Add(new ListItem("DELL", "DELL"));
            slt_marca_comp.Items.Add(new ListItem("LENOVO", "LENOVO"));
            slt_marca_comp.Items.Add(new ListItem("ASUS", "ASUS"));
            slt_marca_comp.Items.Add(new ListItem("ACER", "ACER"));
            slt_marca_comp.Items.Add(new ListItem("APPLE", "APPLE"));
            slt_marca_comp.Items.Add(new ListItem("SAMSUNG", "SAMSUNG"));
            slt_marca_comp.Items.Add(new ListItem("SONY", "SONY"));
            slt_marca_comp.Items.Add(new ListItem("MICROSOFT", "MICROSOFT"));
            slt_marca_comp.Items.Add(new ListItem("LOGITECH", "LOGITECH"));
        }
        public void cargarDatosColor()
        {
            slt_color_comp.Items.Add(new ListItem("Seleccionar color", ""));
            slt_color_comp.Items.Add(new ListItem("ROJO", "ROJO"));
            slt_color_comp.Items.Add(new ListItem("AZUL", "AZUL"));
            slt_color_comp.Items.Add(new ListItem("VERDE", "VERDE"));
            slt_color_comp.Items.Add(new ListItem("AMARILLO", "AMARILLO"));
            slt_color_comp.Items.Add(new ListItem("NARANJA", "NARANJA"));
            slt_color_comp.Items.Add(new ListItem("BLANCO", "BLANCO"));
            slt_color_comp.Items.Add(new ListItem("NEGRO", "NEGRO"));
            slt_color_comp.Items.Add(new ListItem("MARRÓN", "MARRÓN"));
            slt_color_comp.Items.Add(new ListItem("GRIS", "GRIS"));
            slt_color_comp.Items.Add(new ListItem("ROSADO", "ROSADO"));
        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            string nombre = txt_nombre_comp.Text;
            string marca = slt_marca_comp.SelectedValue;
            string disponibilidad = txt_disponibilidad_comp.Text;
            string color = slt_color_comp.SelectedValue;
            float precio = float.Parse(txt_precio_comp.Text);
            insertarComponenteBDD(nombre, marca, disponibilidad, color, precio);
 
            limpiarCajas();//Llamar al metodo limpiar campos
            consultarComponentesBDD();
        }
        public void insertarComponenteBDD(string nombre,string marca, string disponibilidad, string color, float precio)
        {
            SqlCommand comandoInsercion = new SqlCommand("sp_crear_componente", conexion);
            comandoInsercion.CommandType = CommandType.StoredProcedure;
            comandoInsercion.Parameters.AddWithValue("@nombre", nombre);
            comandoInsercion.Parameters.AddWithValue("@marca", marca);
            comandoInsercion.Parameters.AddWithValue("@disponibilidad", disponibilidad);
            comandoInsercion.Parameters.AddWithValue("@color", color);
            comandoInsercion.Parameters.AddWithValue("@precio", precio);

            //Codigo error try catch para que no se cuelgue el sistema
            try
            {
                this.conexion.Open(); //Abrir conexion
                comandoInsercion.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Tienes un error" + ex.Message); //Error que se vea en la consola
            }
        }
        public void limpiarCajas()
        {
            txt_id_comp.Text = "";
            slt_marca_comp.SelectedValue = "";
            slt_color_comp.SelectedValue = "";
            txt_nombre_comp.Text = "";
            txt_disponibilidad_comp.Text = "";
            txt_precio_comp.Text = "";
        }
        public void consultarComponentesBDD()
        {
            SqlCommand comandoConsulta = new SqlCommand("sp_consultar_componentes", conexion); //2 parametros, el 1ro es el store procedure y el otro es la conexion de la bdd
            comandoConsulta.CommandType = CommandType.StoredProcedure;
            try
            {
                this.conexion.Open(); //Abrir conexion
                SqlDataAdapter adaptadorGeneros = new SqlDataAdapter(comandoConsulta); //Intermediario de sql a csharp
                DataTable tablaDatos = new DataTable();
                adaptadorGeneros.Fill(tablaDatos);
                grid_componentes.DataSource = tablaDatos;
                grid_componentes.DataBind();
                this.conexion.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }
        }
        //Hacer que los textbox guarden en MAYUSCULAS el contenido en la base de datos
        protected void txt_nombre_comp_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.Text = textBox.Text.ToUpper();
        }
    }
}