using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace ProyectoFinal.Pages
{
    public partial class SeleccionPlantillaMovil : System.Web.UI.Page
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

        SqlConnection conn = new SqlConnection("Server = DESKTOP-2F7769Q; Database = AplicacionesWeb; User Id = Rhapsodic; Password = wonderland01" + "");

        protected void Page_Load(object sender, EventArgs e)
        {
            int usuario = int.Parse(Request.QueryString["Usuario"]);
            if (IsPostBack)
            {
                PostBackCount++;
            }
            volver.Attributes.Add("onClick", "history.go" + "(-" + (PostBackCount + 1) + "); return false;");
            siguiente.Enabled = false;
            ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "CallJS", "afterpostback();", true);
            conn.Open();
            SqlCommand cmnd = new SqlCommand("SELECT plantilla_id, nombre as Nombre FROM Plantilla WhERE usuario_id=" + usuario + "");
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

        protected void Seleccionar(object sender, EventArgs e)
        {
            string data = plantillas.SelectedRow.Cells[0].Text;
            int id = int.Parse(data);
            SqlCommand cmnd = new SqlCommand("SELECT * FROM Coordenadas WHERE plantilla_id =" + id);
            conn.Open();
            cmnd.CommandType = System.Data.CommandType.Text;
            cmnd.Connection = conn;

            SqlDataReader reader = cmnd.ExecuteReader();
            if (reader.HasRows)
            {
                string[] x = new string[12];
                string[] y = new string[12];
                string[] width = new string[12];
                string[] height = new string[12];
                int i = 0;
                string sx = "";
                string sy = "";
                string sh = "";
                string sw = "";
                while (reader.Read())
                {
                    sx = reader[2].ToString();
                    sy = reader[3].ToString();
                    sw = reader[4].ToString();
                    sh = reader[5].ToString();

                    x[i] = sx;
                    y[i] = sy;
                    width[i] = sw;
                    height[i] = sh;

                    i++;
                }
                conn.Close();
                string main = "&PDX=" + x[0] + "&PDY=" + y[0] + "&PDW=" + width[0] + "&PDH=" + height[0]
                    + "&PIX=" + x[1] + "&PIY=" + y[1] + "&PIW=" + width[1] + "&PIH=" + height[1]
                    + "&IDX=" + x[2] + "&IDY=" + y[2] + "&IDW=" + width[2] + "&IDH=" + height[2]
                    + "&IIX=" + x[3] + "&IIY=" + y[3] + "&IIW=" + width[3] + "&IIH=" + height[3]
                    + "&MDX=" + x[4] + "&MDY=" + y[4] + "&MDW=" + width[4] + "&MDH=" + height[4]
                    + "&MIX=" + x[5] + "&MIY=" + y[5] + "&MIW=" + width[5] + "&MIH=" + height[5]
                    + "&ADX=" + x[6] + "&ADY=" + y[6] + "&ADW=" + width[6] + "&ADH=" + height[6]
                    + "&AIX=" + x[7] + "&AIY=" + y[7] + "&AIW=" + width[7] + "&AIH=" + height[7]
                    + "&MñDX=" + x[8] + "&MñDY=" + y[8] + "&MñDW=" + width[8] + "&MñDH=" + height[8]
                    + "&MñIX=" + x[9] + "&MñIY=" + y[9] + "&MñIW=" + width[9] + "&MñIH=" + height[9]
                    + "&PlDX=" + x[10] + "&PlDY=" + y[10] + "&PlDW=" + width[10] + "&PlDH=" + height[10]
                    + "&PlIX=" + x[11] + "&PlIY=" + y[11] + "&PlIW=" + width[11] + "&PlIH=" + height[11];


                Response.Redirect("~/Pages/PantallaPrincipalMovil.aspx?Usuario=" + Request.QueryString["Usuario"] + main);

            }
        }
    }
}