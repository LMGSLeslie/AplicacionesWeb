using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace ProyectoFinal.Pages
{
    public partial class SeleccionPlantilla : System.Web.UI.Page
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

        SqlConnection conn = new SqlConnection("Server = DESKTOP-LIN2QNI;Database = AplicacionesWeb; User Id =lesma; Password=Database2350.");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                PostBackCount++;
                lmao.Text = PostBackCount.ToString();
            }
            volver.Attributes.Add("onClick", "history.go" + "(-" + (PostBackCount + 1) + "); return false;");
            siguiente.Attributes.Add("onClick", "history.go" + "(-" + (PostBackCount + 1) + "); return false;");
            ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "CallJS", "afterpostback();", true);
            conn.Open();
            SqlCommand cmnd = new SqlCommand("SELECT plantilla_id, nombre as Nombre FROM Plantilla");
            cmnd.CommandType = System.Data.CommandType.Text;
            cmnd.Connection = conn;

            SqlDataReader reader = cmnd.ExecuteReader();

            SqlDataAdapter adp = new SqlDataAdapter(cmnd);

            plantillas.DataSource = reader;
            plantillas.DataBind();
            conn.Close();
        }

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(plantillas, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click para selecionar esta plantilla.";
            }
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in plantillas.Rows)
            {
                if (row.RowIndex == plantillas.SelectedIndex)
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