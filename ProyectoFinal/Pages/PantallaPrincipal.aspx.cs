using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;

namespace ProyectoFinal.Pages
{
    public partial class PantallaPrincipal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
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
            Response.Redirect("~/Pages/SeleccionPlantilla.html");
        }

        protected void asignarHuellas(object sender, EventArgs e)
        {
            if(MñI.Enabled==true|| AI.Enabled == true|| MI.Enabled == true|| II.Enabled == true|| PI.Enabled == true|| PlI.Enabled == true|| MñD.Enabled == true|| AD.Enabled == true|| MD.Enabled == true|| ID.Enabled == true|| PD.Enabled == true|| PlD.Enabled == true)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "<script type = 'text/javascript'> window.onload=function(){alert('Por favor asigne todas las huellas')};</script>");
            }
            else
            {
                Response.Redirect("~/Pages/SeleccionPersona.aspx");
            }
            
        }

        protected void guardarPlantilla(object sender, EventArgs e)
        {

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
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
    }
}