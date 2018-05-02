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
        private int PostBackCount
        {
            get
            {
                return
                   null == ViewState["PostBackCount"]
                   ? 0
                   : Convert.ToInt32(ViewState["PostBackCount"]);
            }
            set { ViewState["PostBackCount"] = value; }
        }

        SqlConnection conn = new SqlConnection("Server = DESKTOP-2F7769Q;Database = AplicacionesWeb; User Id =Rhapsodic; Password=wonderland01");
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                PostBackCount++;
                lmao.Text = PostBackCount.ToString();
            }
            volver.Attributes.Add("onClick", "history.go" + "(-" + (PostBackCount+1) + "); return false;");
            siguiente.Enabled = false;
            siguiente.Attributes.Add("onClick", "history.go" + "(-" + (PostBackCount + 1) + "); return false;");
            ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "CallJS", "afterpostback();", true);
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
                    siguiente.Enabled = true;
                    row.BackColor = System.Drawing.Color.LightGray;
                    row.ToolTip = string.Empty;
                }
                else
                {
                    row.ToolTip = "Click to select this row.";
                }
            }
        }
        protected void Seleccionar(object sender, HistoryEventArgs e)
        {
            
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