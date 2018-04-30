using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Windows;

namespace ProyectoFinal.Pages
{
    public partial class SeleccionPersona : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection("Server = DESKTOP-LIN2QNI;Database = AplicacionesWeb; User Id = lesma; Password=Database2350.");

        protected void Page_Load(object sender, EventArgs e)
        {
            siguiente.Attributes.Add("onClick", "javascript:history.back(-1); return false;");
            conn.Open();
                SqlCommand cmnd = new SqlCommand("SELECT persona_id, nombre+' ' + apellido as FULLNAME FROM Persona");
                cmnd.CommandType = System.Data.CommandType.Text;
                cmnd.Connection = conn;

                SqlDataReader reader = cmnd.ExecuteReader();

                SqlDataAdapter adp = new SqlDataAdapter(cmnd);

                personas.DataSource = reader;
                personas.DataBind();
                conn.Close();
        }
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(personas, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click para selecionar esta persona.";
            }
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in personas.Rows)
            {
                if (row.RowIndex == personas.SelectedIndex)
                {
                    row.BackColor = System.Drawing.Color.LightGray;
                    row.ToolTip = string.Empty;
                }
                else
                {
                    row.ToolTip = "Click to select this row.";
                }
                lmao.Text = personas.SelectedRow.Cells[0].Text;
            }
        }
        protected void Seleccionar(object sender, EventArgs e)
        {
            Response.Redirect(Request.UrlReferrer.ToString(), true);
        }

        protected void Volver(object sender, EventArgs e)
        {
            Response.Redirect("../Pages/PantallaPrincipal.html",true);
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