using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ComponentesInformaticos
{
    public partial class Vender : System.Web.UI.Page
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
                cargarDatosSexo();
                consultarClientesBDD();
                //Llamar el metodo de consultarComponentesBDD

            }
        }
        public void cargarDatosSexo()
        {
            slt_sexo_cli.Items.Add(new ListItem("Seleccionar sexo", ""));
            slt_sexo_cli.Items.Add(new ListItem("HOMBRE", "HOMBRE"));
            slt_sexo_cli.Items.Add(new ListItem("MUJER", "MUJER"));
            slt_sexo_cli.Items.Add(new ListItem("NINGUNO", "NINGUNO"));
        }
        public void consultarClientesBDD()
        {
            SqlCommand comandoConsulta = new SqlCommand("sp_consultar_clientes", conexion); //2 parametros, el 1ro es el store procedure y el otro es la conexion de la bdd
            comandoConsulta.CommandType = CommandType.StoredProcedure;
            try
            {
                this.conexion.Open(); //Abrir conexion
                SqlDataAdapter adaptadorGeneros = new SqlDataAdapter(comandoConsulta); //Intermediario de sql a csharp
                DataTable tablaDatos = new DataTable();
                adaptadorGeneros.Fill(tablaDatos);
                grid_clientes.DataSource = tablaDatos;
                grid_clientes.DataBind();
                this.conexion.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }
        }
        public void insertarClienteBDD(string ci, string nombre, string apellido, string sexo, string fechaNacimiento, string direccion, string correo, string telefono)
        {
            SqlCommand comandoInsercion = new SqlCommand("sp_crear_cliente", conexion);
            comandoInsercion.CommandType = CommandType.StoredProcedure;
            comandoInsercion.Parameters.AddWithValue("@ci", ci);
            comandoInsercion.Parameters.AddWithValue("@nombre", nombre);
            comandoInsercion.Parameters.AddWithValue("@apellido", apellido);
            comandoInsercion.Parameters.AddWithValue("@sexo", sexo);
            comandoInsercion.Parameters.AddWithValue("@fecha_nacimiento_cli", fechaNacimiento);
            comandoInsercion.Parameters.AddWithValue("@direccion_cli", direccion);
            comandoInsercion.Parameters.AddWithValue("@correo_cli", correo);
            comandoInsercion.Parameters.AddWithValue("@telefono_cli", telefono);

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
            txt_ci_cli.Text = "";
            txt_nombre_cli.Text = "";
            txt_apellido_cli.Text = "";
            slt_sexo_cli.SelectedValue = "";
            txt_fecha_nacimiento_cli.Text = "";
            txt_direccion_cli.Text = "";
            txt_correo_cli.Text = "";
            txt_telefono_cli.Text = "";
        }

        protected void btn_guardar_cliente_Click(object sender, EventArgs e)
        {

            string ci = txt_ci_cli.Text;
            string nombre = txt_nombre_cli.Text;
            string apellido = txt_apellido_cli.Text;
            string sexo = slt_sexo_cli.SelectedValue;
            string fechaNacimiento = txt_fecha_nacimiento_cli.Text;
            string direccion = txt_direccion_cli.Text;
            string correo = txt_correo_cli.Text;
            string telefeno = txt_telefono_cli.Text;
            insertarClienteBDD(ci,nombre, apellido, sexo, fechaNacimiento, direccion, correo, telefeno);

            limpiarCajas();//Llamar al metodo limpiar campos
            consultarClientesBDD();
        }
        //Poner en mayusuclas en la bdd cuando ingresen en minusxulas 
        protected void txt_nombre_cli_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.Text = textBox.Text.ToUpper();
        }
        //Poner en mayusuclas en la bdd cuando ingresen en minusxulas 
        protected void txt_apellido_cli_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.Text = textBox.Text.ToUpper();
        }
    }
}