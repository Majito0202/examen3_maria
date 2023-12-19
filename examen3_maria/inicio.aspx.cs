using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace examen3_maria
{
    public partial class inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["PartidosPoliticos"].ConnectionString))
                (
                   SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = 
                    
                 

            }
        }

        private void CargarPartidosPoliticos()
        {
            string connectionString = ""//conexion
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT IdPartido, NombrePartido FROM PartidosPoliticos", connection);
                SqlDataReader reader = cmd.ExecuteReader();
                ddlPartido.DataSource = reader;
                ddlPartido.DataTextField = "NombrePartido";
                ddlPartido.DataValueField = "IdPartido";
                ddlPartido.DataBind();
                reader.Close();
            }
        }

        protected void btnAgregarEncuesta_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            int edad = Convert.ToInt32(txtEdad.Text);
            string correo = txtCorreo.Text;
            int idPartido = Convert.ToInt32(ddlPartido.SelectedValue);

            string connectionString = "TuCadenaDeConexion"; // Reemplaza con tu cadena de conexión
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("AgregarEncuesta", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@Edad", edad);
                cmd.Parameters.AddWithValue("@CorreoElectronico", correo);
                cmd.Parameters.AddWithValue("@IdPartido", idPartido);
                cmd.ExecuteNonQuery();
            }

            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            txtNombre.Text = string.Empty;
            txtEdad.Text = string.Empty;
            txtCorreo.Text = string.Empty;
            ddlPartido.SelectedIndex = 0;
        }
    }

    public partial class ReporteEncuestas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarEncuestas();
            }
        }

        private void CargarEncuestas()
        {
            string connectionString = ""//Conexion
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("ObtenerTodasLasEncuestas", connection);
                SqlDataReader reader = cmd.ExecuteReader();
                gvEncuestas.DataSource = reader;
                gvEncuestas.DataBind();
                reader.Close();
            }
        }
    }
}
    