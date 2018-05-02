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

        SqlConnection conn = new SqlConnection("Server = DESKTOP-2F7769Q; Database = AplicacionesWeb; User Id = Rhapsodic; Password = wonderland01");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                PostBackCount++;
            }
            volver.Attributes.Add("onClick", "history.go" + "(-" + (PostBackCount + 1) + "); return false;");
            siguiente.Enabled = false;
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
        protected void Seleccionar(object sender, EventArgs e)
        {
            string data = personas.SelectedRow.Cells[0].Text;
            int id = int.Parse(data);

            SqlCommand cmnd = new SqlCommand("INSERT INTO Relacion_huellas_persona VALUES(" + id + "," + int.Parse(Request.QueryString["PDPath"].ToString()) + "," + 1 + ")");
            conn.Open();
            cmnd.Connection = conn;
            cmnd.ExecuteNonQuery();
            cmnd = new SqlCommand("INSERT INTO Relacion_huellas_persona VALUES(" + id + "," + int.Parse(Request.QueryString["PIPath"].ToString()) + "," + 2 + ")");
            cmnd.Connection = conn;
            cmnd.ExecuteNonQuery();
            cmnd = new SqlCommand("INSERT INTO Relacion_huellas_persona VALUES(" + id + "," + int.Parse(Request.QueryString["IDPath"].ToString()) + "," + 3 + ")");
            cmnd.Connection = conn;
            cmnd.ExecuteNonQuery();
            cmnd = new SqlCommand("INSERT INTO Relacion_huellas_persona VALUES(" + id + "," + int.Parse(Request.QueryString["IIPath"].ToString()) + "," + 4 + ")");
            cmnd.Connection = conn;
            cmnd.ExecuteNonQuery();
            cmnd = new SqlCommand("INSERT INTO Relacion_huellas_persona VALUES(" + id + "," + int.Parse(Request.QueryString["MDPath"].ToString()) + "," + 5 + ")");
            cmnd.Connection = conn;
            cmnd.ExecuteNonQuery();
            cmnd = new SqlCommand("INSERT INTO Relacion_huellas_persona VALUES(" + id + "," + int.Parse(Request.QueryString["MIPath"].ToString()) + "," + 6 + ")");
            cmnd.Connection = conn;
            cmnd.ExecuteNonQuery();
            cmnd = new SqlCommand("INSERT INTO Relacion_huellas_persona VALUES(" + id + "," + int.Parse(Request.QueryString["ADPath"].ToString()) + "," + 7 + ")");
            cmnd.Connection = conn;
            cmnd.ExecuteNonQuery();
            cmnd = new SqlCommand("INSERT INTO Relacion_huellas_persona VALUES(" + id + "," + int.Parse(Request.QueryString["AIPath"].ToString()) + "," + 8 + ")");
            cmnd.Connection = conn;
            cmnd.ExecuteNonQuery();
            cmnd = new SqlCommand("INSERT INTO Relacion_huellas_persona VALUES(" + id + "," + int.Parse(Request.QueryString["MñDPath"].ToString()) + "," + 9 + ")");
            cmnd.Connection = conn;
            cmnd.ExecuteNonQuery();
            cmnd = new SqlCommand("INSERT INTO Relacion_huellas_persona VALUES(" + id + "," + int.Parse(Request.QueryString["MñIPath"].ToString()) + "," + 10 + ")");
            cmnd.Connection = conn;
            cmnd.ExecuteNonQuery();
            cmnd = new SqlCommand("INSERT INTO Relacion_huellas_persona VALUES(" + id + "," + int.Parse(Request.QueryString["PlDPath"].ToString()) + "," + 11 + ")");
            cmnd.Connection = conn;
            cmnd.ExecuteNonQuery();
            cmnd = new SqlCommand("INSERT INTO Relacion_huellas_persona VALUES(" + id + "," + int.Parse(Request.QueryString["PlIPath"].ToString()) + "," + 12 + ")");
            cmnd.Connection = conn;
            cmnd.ExecuteNonQuery();
            conn.Close();
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "<script type = 'text/javascript'> window.onload=function(){alert('Huellas asignadas, por favor regrese a la página anterior con el botón volver')};</script>");

        }

    }
}