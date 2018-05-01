using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace ProyectoFinal.Pages
{
    public partial class AgregarPersona : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void agregarPersona(object sender, EventArgs e)
        {
            if (nombre.Text == "" || apellido.Text == "")
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "<script type = 'text/javascript'> window.onload=function(){alert('Por favor llena todos los campos')};</script>");
            }

            else {
                string nom = nombre.Text.ToString();
                string ape = apellido.Text.ToString();
                SqlConnection conn = new SqlConnection("Server = DESKTOP-LIN2QNI;Database = AplicacionesWeb; User Id = lesma; Password=Database2350.");
                conn.Open();
                SqlCommand cmnd = new SqlCommand("INSERT INTO Persona (nombre,apellido) VALUES('"+nom+"','"+ape+"')");
                cmnd.CommandType = System.Data.CommandType.Text;
                cmnd.Connection = conn;

                cmnd.ExecuteNonQuery();
                conn.Close();

                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "<script type = 'text/javascript'> window.onload=function(){alert('Persona Agregada. Por favor cierre la ventana')};</script>");

            }
        }

    }
}