using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace ProyectoFinal.Pages
{
    public partial class SeleccionPersona : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Server = DESKTOP-LIN2QNI;Database = AplicacionesWeb; User Id = lesma; Password=Database2350.");
            conn.Open();

            SqlCommand cmnd = new SqlCommand("SELECT nombre+' ' + apellido as FULLNAME FROM Persona");
            cmnd.CommandType = System.Data.CommandType.Text;
            cmnd.Connection = conn;

            SqlDataReader reader = cmnd.ExecuteReader();

            SqlDataAdapter adp = new SqlDataAdapter(cmnd);

            personas.DataSource = reader;
            personas.DataBind();
            conn.Close();

        }
        protected void PeopleGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.personas, "Select$" + e.Row.RowIndex);
            }
        }

         /*   protected void HazAlgoALV(object sender, EventArgs e)
           {
               var nombreText = nombre.Text;
               var apellidoText = apellido.Text;

               if (nombreText == "" || apellidoText == "") { 

                //   ClientScript.RegisterStartupScript(this.GetType(), "Campos Requeridos", "alert('" + "Por favor llena todos los campos" + "');", true);


               }
           }*/
    }
}