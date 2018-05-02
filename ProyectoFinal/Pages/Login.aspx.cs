using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace ProyectoFinal.Pages
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void login(object sender, EventArgs e)
        {
            if (email.Text == "" || password.Text == "")
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "<script type = 'text/javascript'> window.onload=function(){alert('Por favor llene todos los campos')};</script>");
            }
            else { 

                SqlConnection conn = new SqlConnection("Server = DESKTOP-LIN2QNI;Database = AplicacionesWeb; User Id = lesma; Password=Database2350.");
                SqlCommand cmnd = new SqlCommand("SELECT * FROM Usuario WHERE email = '" + email.Text + "'");
                cmnd.Connection = conn;
                cmnd.CommandType = System.Data.CommandType.Text;

                conn.Open();
                SqlDataReader reader = cmnd.ExecuteReader();
                if (reader.Read())
                {
                    int count = (int)reader[0];
                    lbl.Text = count.ToString();
                    if (count == 0)
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "<script type = 'text/javascript'> window.onload=function(){alert('El usuario no existe')};</script>");
                    }
                }
                conn.Close();
            }
        }
    }
}