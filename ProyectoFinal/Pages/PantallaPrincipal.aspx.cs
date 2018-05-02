using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;
using System.Drawing;

namespace ProyectoFinal.Pages
{
    public partial class PantallaPrincipal : System.Web.UI.Page
    {
        public static string [] ax = new string[12];
        public static string [] ay = new string[12];
        public static string [] aw = new string[12];
        public static string [] ah = new string[12];

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["PDX"] != null)
            {
                PDX.Text = Request.QueryString["PDX"];
                PDY.Text = Request.QueryString["PDY"];
                PDW.Text = Request.QueryString["PDW"];
                PDH.Text = Request.QueryString["PDH"];
                PIX.Text = Request.QueryString["PIX"];
                PIY.Text = Request.QueryString["PIY"];
                PIW.Text = Request.QueryString["PIW"];
                PIH.Text = Request.QueryString["PIH"];
                IDX.Text = Request.QueryString["IDX"];
                IDY.Text = Request.QueryString["IDY"];
                IDW.Text = Request.QueryString["IDW"];
                IDH.Text = Request.QueryString["IDH"];
                IIX.Text = Request.QueryString["IIX"];
                IIY.Text = Request.QueryString["IIY"];
                IIW.Text = Request.QueryString["IIW"];
                IIH.Text = Request.QueryString["IIH"];
                MDX.Text = Request.QueryString["MDX"];
                MDY.Text = Request.QueryString["MDY"];
                MDW.Text = Request.QueryString["MDW"];
                MDH.Text = Request.QueryString["MDH"];
                MIX.Text = Request.QueryString["MIX"];
                MIY.Text = Request.QueryString["MIY"];
                MIW.Text = Request.QueryString["MIW"];
                MIH.Text = Request.QueryString["MIH"];
                ADX.Text = Request.QueryString["ADX"];
                ADY.Text = Request.QueryString["ADY"];
                ADW.Text = Request.QueryString["ADW"];
                ADH.Text = Request.QueryString["ADH"];
                AIX.Text = Request.QueryString["AIX"];
                AIY.Text = Request.QueryString["AIY"];
                AIW.Text = Request.QueryString["AIW"];
                AIH.Text = Request.QueryString["AIH"];
                MñDX.Text = Request.QueryString["MñDX"];
                MñDY.Text = Request.QueryString["MñDY"];
                MñDW.Text = Request.QueryString["MñDW"];
                MñDH.Text = Request.QueryString["MñDH"];
                MñIX.Text = Request.QueryString["MñIX"];
                MñIY.Text = Request.QueryString["MñIY"];
                MñIW.Text = Request.QueryString["MñIW"];
                MñIH.Text = Request.QueryString["MñIH"];
                PlDX.Text = Request.QueryString["PlDX"];
                PlDY.Text = Request.QueryString["PlDY"];
                PlDW.Text = Request.QueryString["PlDW"];
                PlDH.Text = Request.QueryString["PlDH"];
                PlIX.Text = Request.QueryString["PlIX"];
                PlIY.Text = Request.QueryString["PlIY"];
                PlIW.Text = Request.QueryString["PlIW"];
                PlIH.Text = Request.QueryString["PlIH"];
                plantillaNombre.Enabled = false;
            }
            else
            {
                plantillaNombre.Enabled = true;
            }
        }
        
        protected void reset(object sender, EventArgs e)
        {
            
            MñI.Enabled = true;
            AI.Enabled = true;
            MI.Enabled = true;
            II.Enabled = true;
            PI.Enabled = true;
            PlI.Enabled = true;
            MñD.Enabled = true;
            AD.Enabled = true;
            MD.Enabled = true;
            ID.Enabled = true;
            PD.Enabled = true;
            PlD.Enabled = true;
        }

        protected void CambiarPlantilla(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/SeleccionPlantilla.aspx?Usuario="+Request.QueryString["Usuario"]);
        }

        protected void asignarHuellas(object sender, EventArgs e)
        {
            if(MñI.Enabled==true|| AI.Enabled == true|| MI.Enabled == true|| II.Enabled == true|| PI.Enabled == true|| PlI.Enabled == true|| MñD.Enabled == true|| AD.Enabled == true|| MD.Enabled == true|| ID.Enabled == true|| PD.Enabled == true|| PlD.Enabled == true)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "<script type = 'text/javascript'> window.onload=function(){alert('Por favor asigne todas las huellas')};</script>");
            }
            else
            {
                Response.Redirect("~/Pages/SeleccionPersona.aspx?Usuario="+Request.QueryString["Usuario"]);
            }
            
        }

        protected void guardarPlantilla(object sender, EventArgs e)
        {
            if (MñI.Enabled == true || AI.Enabled == true || MI.Enabled == true || II.Enabled == true || PI.Enabled == true || PlI.Enabled == true || MñD.Enabled == true || AD.Enabled == true || MD.Enabled == true || ID.Enabled == true || PD.Enabled == true || PlD.Enabled == true)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "<script type = 'text/javascript'> window.onload=function(){alert('Por favor asigne todas las huellas')};</script>");
            }
            else
            {
                if (ax[0] != null)
                {
                    if (plantillaNombre.Text == "") {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "<script type = 'text/javascript'> window.onload=function(){alert('Por favor asigne un nombre a la plantilla')};</script>");
                    }
                    else
                    {
                        SqlConnection conn = new SqlConnection("Server = DESKTOP-LIN2QNI;Database = AplicacionesWeb; User Id =lesma; Password=Database2350." + "");
                        SqlCommand cmnd = new SqlCommand("INSERT INTO Plantilla (nombre, usuario_id)VALUES('" + plantillaNombre.Text.ToString() + "','" + int.Parse(Request.QueryString["Usuario"]) + "')");

                        conn.Open();

                        cmnd.Connection = conn;
                        cmnd.CommandType = System.Data.CommandType.Text;

                        cmnd.ExecuteNonQuery();

                        cmnd = new SqlCommand("SELECT plantilla_id FROM Plantilla WHERE nombre ='" + plantillaNombre.Text.ToString() + "' AND usuario_id =" + int.Parse(Request.QueryString["Usuario"]));
                        cmnd.Connection = conn;
                        SqlDataReader reader = cmnd.ExecuteReader();
                        reader.Read();
                        int plantilla_id = int.Parse(reader[0].ToString());
                        reader.Close();
                        for (int i = 0; i < 12; i++)
                        {
                            cmnd = new SqlCommand("INSERT INTO Coordenadas VALUES(" + plantilla_id + "," + (i + 1) + "," + float.Parse(ax[i]) + "," + float.Parse(ay[i]) + "," + float.Parse(aw[i]) + "," + float.Parse(ah[i])+")");
                            cmnd.Connection = conn;
                            cmnd.ExecuteNonQuery();
                        }
                        conn.Close();

                    }
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "<script type = 'text/javascript'> window.onload=function(){alert('Error, por favor traté de nuevo ')};</script>");
                }
            }
        }

        protected void cargarImagen(object sender, EventArgs e)
        {
            string uploadFileName = "";
            string uploadFilePath = "";
            if (FU1.HasFile)
            {
                string ext = Path.GetExtension(FU1.FileName).ToLower();
                if (ext == ".jpg" || ext == ".jpeg" || ext == ".gif" || ext == ".png")
                {
                    uploadFileName = Guid.NewGuid().ToString() + ext;
                    uploadFilePath = Path.Combine(Server.MapPath("~/Huellas"), uploadFileName);
                    try
                    {
                        FU1.SaveAs(uploadFilePath);
                        imgUpload.ImageUrl = "~/Huellas/" + uploadFileName;
                    }
                    catch (Exception)
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "<script type = 'text/javascript'> window.onload=function(){alert('Error, por favor trate de nuevo ')};</script>");
                    }
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "<script type = 'text/javascript'> window.onload=function(){alert('El tipo de archivo seleccionado no es válido')};</script>");
                }
            }
        }

        protected void meñiqueIzquierdo(object sender, EventArgs e)
        {
            string fileName = Path.GetFileName(imgUpload.ImageUrl);
            string filePath = Path.Combine(Server.MapPath("~/Huellas"), fileName);
            string cropFileName = "";
            string cropFilePath = "";
            if (File.Exists(filePath))
            {
                System.Drawing.Image orgImg = System.Drawing.Image.FromFile(filePath);
                Rectangle CropArea = new Rectangle(Convert.ToInt32(x1.Value), Convert.ToInt32(y1.Value), Convert.ToInt32(w.Value), Convert.ToInt32(h.Value));
                try
                {
                    Bitmap bitMap = new Bitmap(CropArea.Width, CropArea.Height);
                    using (Graphics g = Graphics.FromImage(bitMap))
                    {
                        g.DrawImage(orgImg, new Rectangle(0, 0, bitMap.Width, bitMap.Height), CropArea, GraphicsUnit.Pixel);
                    }
                    cropFileName = "MeñiqueIzquierdo_" + fileName;
                    cropFilePath = Path.Combine(Server.MapPath("~/Huellas/"), cropFileName);
                    bitMap.Save(cropFilePath);
                    MñI.Enabled = false;
                    ax[9] = x1.Value.ToString();
                    ay[9] = y1.Value.ToString();
                    aw[9] = w.Value.ToString();
                    ah[9] = h.Value.ToString();
                    MñIX.Text = x1.Value.ToString();
                    MñIY.Text = y1.Value.ToString();
                    MñIW.Text = w.Value.ToString();
                    MñIH.Text = h.Value.ToString();

                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
        protected void anularIzquierdo(object sender, EventArgs e)
        {
            string fileName = Path.GetFileName(imgUpload.ImageUrl);
            string filePath = Path.Combine(Server.MapPath("~/Huellas"), fileName);
            string cropFileName = "";
            string cropFilePath = "";
            if (File.Exists(filePath))
            {
                System.Drawing.Image orgImg = System.Drawing.Image.FromFile(filePath);
                Rectangle CropArea = new Rectangle(Convert.ToInt32(x1.Value), Convert.ToInt32(y1.Value), Convert.ToInt32(w.Value), Convert.ToInt32(h.Value));
                try
                {
                    Bitmap bitMap = new Bitmap(CropArea.Width, CropArea.Height);
                    using (Graphics g = Graphics.FromImage(bitMap))
                    {
                        g.DrawImage(orgImg, new Rectangle(0, 0, bitMap.Width, bitMap.Height), CropArea, GraphicsUnit.Pixel);
                    }
                    cropFileName = "AnularIzquierdo_" + fileName;
                    cropFilePath = Path.Combine(Server.MapPath("~/Huellas/"), cropFileName);
                    bitMap.Save(cropFilePath);
                    AI.Enabled = false;
                    ax[7] = x1.Value.ToString();
                    ay[7] = y1.Value.ToString();
                    aw[7] = w.Value.ToString();
                    ah[7] = h.Value.ToString();
                    AIX.Text = x1.Value.ToString();
                    AIY.Text = y1.Value.ToString();
                    AIW.Text = w.Value.ToString();
                    AIH.Text = h.Value.ToString();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
        protected void medioIzquierdo(object sender, EventArgs e)
        {
            string fileName = Path.GetFileName(imgUpload.ImageUrl);
            string filePath = Path.Combine(Server.MapPath("~/Huellas"), fileName);
            string cropFileName = "";
            string cropFilePath = "";
            if (File.Exists(filePath))
            {
                System.Drawing.Image orgImg = System.Drawing.Image.FromFile(filePath);
                Rectangle CropArea = new Rectangle(Convert.ToInt32(x1.Value), Convert.ToInt32(y1.Value), Convert.ToInt32(w.Value), Convert.ToInt32(h.Value));
                try
                {
                    Bitmap bitMap = new Bitmap(CropArea.Width, CropArea.Height);
                    using (Graphics g = Graphics.FromImage(bitMap))
                    {
                        g.DrawImage(orgImg, new Rectangle(0, 0, bitMap.Width, bitMap.Height), CropArea, GraphicsUnit.Pixel);
                    }
                    cropFileName = "MedioIzquierdo_" + fileName;
                    cropFilePath = Path.Combine(Server.MapPath("~/Huellas/"), cropFileName);
                    bitMap.Save(cropFilePath);
                    MI.Enabled = false;
                    ax[5] = x1.Value.ToString();
                    ay[5] = y1.Value.ToString();
                    aw[5] = w.Value.ToString();
                    ah[5] = h.Value.ToString();
                    MIX.Text = x1.Value.ToString();
                    MIY.Text = y1.Value.ToString();
                    MIW.Text = w.Value.ToString();
                    MIH.Text = h.Value.ToString();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
        protected void indiceIzquierdo(object sender, EventArgs e)
        {
            string fileName = Path.GetFileName(imgUpload.ImageUrl);
            string filePath = Path.Combine(Server.MapPath("~/Huellas"), fileName);
            string cropFileName = "";
            string cropFilePath = "";
            if (File.Exists(filePath))
            {
                System.Drawing.Image orgImg = System.Drawing.Image.FromFile(filePath);
                Rectangle CropArea = new Rectangle(Convert.ToInt32(x1.Value), Convert.ToInt32(y1.Value), Convert.ToInt32(w.Value), Convert.ToInt32(h.Value));
                try
                {
                    Bitmap bitMap = new Bitmap(CropArea.Width, CropArea.Height);
                    using (Graphics g = Graphics.FromImage(bitMap))
                    {
                        g.DrawImage(orgImg, new Rectangle(0, 0, bitMap.Width, bitMap.Height), CropArea, GraphicsUnit.Pixel);
                    }
                    cropFileName = "'IndiceIzquierdo_" + fileName;
                    cropFilePath = Path.Combine(Server.MapPath("~/Huellas/"), cropFileName);
                    bitMap.Save(cropFilePath);
                    II.Enabled = false;
                    ax[3] = x1.Value.ToString();
                    ay[3] = y1.Value.ToString();
                    aw[3] = w.Value.ToString();
                    ah[3] = h.Value.ToString();
                    IIX.Text = x1.Value.ToString();
                    IIY.Text = y1.Value.ToString();
                    IIW.Text = w.Value.ToString();
                    IIH.Text = h.Value.ToString();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
        protected void pulgarIzquierdo(object sender, EventArgs e)
        {
            string fileName = Path.GetFileName(imgUpload.ImageUrl);
            string filePath = Path.Combine(Server.MapPath("~/Huellas"), fileName);
            string cropFileName = "";
            string cropFilePath = "";
            if (File.Exists(filePath))
            {
                System.Drawing.Image orgImg = System.Drawing.Image.FromFile(filePath);
                Rectangle CropArea = new Rectangle(Convert.ToInt32(x1.Value), Convert.ToInt32(y1.Value), Convert.ToInt32(w.Value), Convert.ToInt32(h.Value));
                try
                {
                    Bitmap bitMap = new Bitmap(CropArea.Width, CropArea.Height);
                    using (Graphics g = Graphics.FromImage(bitMap))
                    {
                        g.DrawImage(orgImg, new Rectangle(0, 0, bitMap.Width, bitMap.Height), CropArea, GraphicsUnit.Pixel);
                    }
                    cropFileName = "PulgarIzquierdo" + fileName;
                    cropFilePath = Path.Combine(Server.MapPath("~/Huellas/"), cropFileName);
                    bitMap.Save(cropFilePath);
                    PI.Enabled = false;
                    ax[1] = x1.Value.ToString();
                    ay[1] = y1.Value.ToString();
                    aw[1] = w.Value.ToString();
                    ah[1] = h.Value.ToString();
                    PIX.Text = x1.Value.ToString();
                    PIY.Text = y1.Value.ToString();
                    PIW.Text = w.Value.ToString();
                    PIH.Text = h.Value.ToString();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
        protected void palmaIzquierda(object sender, EventArgs e)
        {
            string fileName = Path.GetFileName(imgUpload.ImageUrl);
            string filePath = Path.Combine(Server.MapPath("~/Huellas"), fileName);
            string cropFileName = "";
            string cropFilePath = "";
            if (File.Exists(filePath))
            {
                System.Drawing.Image orgImg = System.Drawing.Image.FromFile(filePath);
                Rectangle CropArea = new Rectangle(Convert.ToInt32(x1.Value), Convert.ToInt32(y1.Value), Convert.ToInt32(w.Value), Convert.ToInt32(h.Value));
                try
                {
                    Bitmap bitMap = new Bitmap(CropArea.Width, CropArea.Height);
                    using (Graphics g = Graphics.FromImage(bitMap))
                    {
                        g.DrawImage(orgImg, new Rectangle(0, 0, bitMap.Width, bitMap.Height), CropArea, GraphicsUnit.Pixel);
                    }
                    cropFileName = "PalmaIzquierda_" + fileName;
                    cropFilePath = Path.Combine(Server.MapPath("~/Huellas/"), cropFileName);
                    bitMap.Save(cropFilePath);
                    PlI.Enabled = false;
                    ax[11] = x1.Value.ToString();
                    ay[11] = y1.Value.ToString();
                    aw[11] = w.Value.ToString();
                    ah[11] = h.Value.ToString();
                    PlIX.Text = x1.Value.ToString();
                    PlIY.Text = y1.Value.ToString();
                    PlIW.Text = w.Value.ToString();
                    PlIH.Text = h.Value.ToString();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
        protected void meñiqueDerecho(object sender, EventArgs e)
        {
            string fileName = Path.GetFileName(imgUpload.ImageUrl);
            string filePath = Path.Combine(Server.MapPath("~/Huellas"), fileName);
            string cropFileName = "";
            string cropFilePath = "";
            if (File.Exists(filePath))
            {
                System.Drawing.Image orgImg = System.Drawing.Image.FromFile(filePath);
                Rectangle CropArea = new Rectangle(Convert.ToInt32(x1.Value), Convert.ToInt32(y1.Value), Convert.ToInt32(w.Value), Convert.ToInt32(h.Value));
                try
                {
                    Bitmap bitMap = new Bitmap(CropArea.Width, CropArea.Height);
                    using (Graphics g = Graphics.FromImage(bitMap))
                    {
                        g.DrawImage(orgImg, new Rectangle(0, 0, bitMap.Width, bitMap.Height), CropArea, GraphicsUnit.Pixel);
                    }
                    cropFileName = "MeñiqueDerecho_" + fileName;
                    cropFilePath = Path.Combine(Server.MapPath("~/Huellas/"), cropFileName);
                    bitMap.Save(cropFilePath);
                    MñD.Enabled = false;
                    ax[8] = x1.Value.ToString();
                    ay[8] = y1.Value.ToString();
                    aw[8] = w.Value.ToString();
                    ah[8] = h.Value.ToString();
                    MñDX.Text = x1.Value.ToString();
                    MñDY.Text = y1.Value.ToString();
                    MñDW.Text = w.Value.ToString();
                    MñDH.Text = h.Value.ToString();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
        protected void anularDerecho(object sender, EventArgs e)
        {
            string fileName = Path.GetFileName(imgUpload.ImageUrl);
            string filePath = Path.Combine(Server.MapPath("~/Huellas"), fileName);
            string cropFileName = "";
            string cropFilePath = "";
            if (File.Exists(filePath))
            {
                System.Drawing.Image orgImg = System.Drawing.Image.FromFile(filePath);
                Rectangle CropArea = new Rectangle(Convert.ToInt32(x1.Value), Convert.ToInt32(y1.Value), Convert.ToInt32(w.Value), Convert.ToInt32(h.Value));
                try
                {
                    Bitmap bitMap = new Bitmap(CropArea.Width, CropArea.Height);
                    using (Graphics g = Graphics.FromImage(bitMap))
                    {
                        g.DrawImage(orgImg, new Rectangle(0, 0, bitMap.Width, bitMap.Height), CropArea, GraphicsUnit.Pixel);
                    }
                    cropFileName = "AnularDerecho_" + fileName;
                    cropFilePath = Path.Combine(Server.MapPath("~/Huellas/"), cropFileName);
                    bitMap.Save(cropFilePath);
                    AD.Enabled = false;
                    ax[6] = x1.Value.ToString();
                    ay[6] = y1.Value.ToString();
                    aw[6] = w.Value.ToString();
                    ah[6] = h.Value.ToString();
                    ADX.Text = x1.Value.ToString();
                    ADY.Text = y1.Value.ToString();
                    ADW.Text = w.Value.ToString();
                    ADH.Text = h.Value.ToString();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
        protected void medioDerecho(object sender, EventArgs e)
        {
            string fileName = Path.GetFileName(imgUpload.ImageUrl);
            string filePath = Path.Combine(Server.MapPath("~/Huellas"), fileName);
            string cropFileName = "";
            string cropFilePath = "";
            if (File.Exists(filePath))
            {
                System.Drawing.Image orgImg = System.Drawing.Image.FromFile(filePath);
                Rectangle CropArea = new Rectangle(Convert.ToInt32(x1.Value), Convert.ToInt32(y1.Value), Convert.ToInt32(w.Value), Convert.ToInt32(h.Value));
                try
                {
                    Bitmap bitMap = new Bitmap(CropArea.Width, CropArea.Height);
                    using (Graphics g = Graphics.FromImage(bitMap))
                    {
                        g.DrawImage(orgImg, new Rectangle(0, 0, bitMap.Width, bitMap.Height), CropArea, GraphicsUnit.Pixel);
                    }
                    cropFileName = "MedioDerecho_" + fileName;
                    cropFilePath = Path.Combine(Server.MapPath("~/Huellas/"), cropFileName);
                    bitMap.Save(cropFilePath);
                    MD.Enabled = false;
                    ax[4] = x1.Value.ToString();
                    ay[4] = y1.Value.ToString();
                    aw[4] = w.Value.ToString();
                    ah[4] = h.Value.ToString();
                    MDX.Text = x1.Value.ToString();
                    MDY.Text = y1.Value.ToString();
                    MDW.Text = w.Value.ToString();
                    MDH.Text = h.Value.ToString();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
        protected void indiceDerecho(object sender, EventArgs e)
        {
            string fileName = Path.GetFileName(imgUpload.ImageUrl);
            string filePath = Path.Combine(Server.MapPath("~/Huellas"), fileName);
            string cropFileName = "";
            string cropFilePath = "";
            if (File.Exists(filePath))
            {
                System.Drawing.Image orgImg = System.Drawing.Image.FromFile(filePath);
                Rectangle CropArea = new Rectangle(Convert.ToInt32(x1.Value), Convert.ToInt32(y1.Value), Convert.ToInt32(w.Value), Convert.ToInt32(h.Value));
                try
                {
                    Bitmap bitMap = new Bitmap(CropArea.Width, CropArea.Height);
                    using (Graphics g = Graphics.FromImage(bitMap))
                    {
                        g.DrawImage(orgImg, new Rectangle(0, 0, bitMap.Width, bitMap.Height), CropArea, GraphicsUnit.Pixel);
                    }
                    cropFileName = "ÍndiceDerecho" + fileName;
                    cropFilePath = Path.Combine(Server.MapPath("~/Huellas/"), cropFileName);
                    bitMap.Save(cropFilePath);
                    ID.Enabled = false;
                    ax[2] = x1.Value.ToString();
                    ay[2] = y1.Value.ToString();
                    aw[2] = w.Value.ToString();
                    ah[2] = h.Value.ToString();
                    IDX.Text = x1.Value.ToString();
                    IDY.Text = y1.Value.ToString();
                    IDW.Text = w.Value.ToString();
                    IDH.Text = h.Value.ToString();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
        protected void pulgarDerecho(object sender, EventArgs e)
        {
            string fileName = Path.GetFileName(imgUpload.ImageUrl);
            string filePath = Path.Combine(Server.MapPath("~/Huellas"), fileName);
            string cropFileName = "";
            string cropFilePath = "";

            if (File.Exists(filePath))
            {
                System.Drawing.Image orgImg = System.Drawing.Image.FromFile(filePath);
                Rectangle CropArea = new Rectangle(Convert.ToInt32(x1.Value), Convert.ToInt32(y1.Value), Convert.ToInt32(w.Value), Convert.ToInt32(h.Value));
                try
                {
                    Bitmap bitMap = new Bitmap(CropArea.Width, CropArea.Height);
                    using (Graphics g = Graphics.FromImage(bitMap))
                    {
                        g.DrawImage(orgImg, new Rectangle(0, 0, bitMap.Width, bitMap.Height), CropArea, GraphicsUnit.Pixel);
                    }
                    cropFileName = "PulgarDerecho_" + fileName;
                    cropFilePath = Path.Combine(Server.MapPath("~/Huellas/"), cropFileName);
                    bitMap.Save(cropFilePath);
                    PD.Enabled = false;
                    ax[0] = x1.Value.ToString();
                    ay[0] = y1.Value.ToString();
                    aw[0] = w.Value.ToString();
                    ah[0] = h.Value.ToString();

                    PDX.Text = x1.Value.ToString();
                    PDY.Text = y1.Value.ToString();
                    PDW.Text = w.Value.ToString();
                    PDH.Text = h.Value.ToString();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
        protected void palmaDerecha(object sender, EventArgs e)
        {
            string fileName = Path.GetFileName(imgUpload.ImageUrl);
            string filePath = Path.Combine(Server.MapPath("~/Huellas"), fileName);
            string cropFileName = "";
            string cropFilePath = "";
            if (File.Exists(filePath))
            {
                System.Drawing.Image orgImg = System.Drawing.Image.FromFile(filePath);
                Rectangle CropArea = new Rectangle(Convert.ToInt32(x1.Value), Convert.ToInt32(y1.Value), Convert.ToInt32(w.Value), Convert.ToInt32(h.Value));
                try
                {
                    Bitmap bitMap = new Bitmap(CropArea.Width, CropArea.Height);
                    using (Graphics g = Graphics.FromImage(bitMap))
                    {
                        g.DrawImage(orgImg, new Rectangle(0, 0, bitMap.Width, bitMap.Height), CropArea, GraphicsUnit.Pixel);
                    }
                    cropFileName = "PalmaDerecha_" + fileName;
                    cropFilePath = Path.Combine(Server.MapPath("~/Huellas/"), cropFileName);
                    bitMap.Save(cropFilePath);
                    PlD.Enabled = false;
                    ax[10] = x1.Value.ToString();
                    ay[10] = y1.Value.ToString();
                    aw[10] = w.Value.ToString();
                    ah[10] = h.Value.ToString();
                    PlDX.Text = x1.Value.ToString();
                    PlDY.Text = y1.Value.ToString();
                    PlDW.Text = w.Value.ToString();
                    PlDH.Text = h.Value.ToString();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
    }
}