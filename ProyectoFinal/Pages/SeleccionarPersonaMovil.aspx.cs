using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace ProyectoFinal.Pages
{
    public partial class SeleccionarPersonaMovil : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection("Server = DESKTOP-LIN2QNI;Database = AplicacionesWeb; User Id = lesma; Password=Database2350.");
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
        protected void Page_Load(object sender, EventArgs e)
        {
            volver.Attributes.Add("onClick", "history.go" + "(-" + (PostBackCount + 1) + "); return false;");
            siguiente.Attributes.Add("onClick", "history.go" + "(-" + (PostBackCount + 1) + "); return false;");
            conn.Open();
            SqlCommand cmnd = new SqlCommand("SELECT persona_id , nombre+' ' + apellido as FULLNAME FROM Persona");
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
            }
        }

    }
}