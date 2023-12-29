using DataAccess;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain;
using WebGrease.Activities;

namespace QMS.Pages
{
    public partial class AltaCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            ClienteNegocio clienteNegocio = new ClienteNegocio();
            Cliente cliente = new Cliente();
            try
            {
                if (fileUpload.HasFile)
                {
                    string fileName = Path.GetFileName(fileUpload.FileName);
                    string fileExtension = Path.GetExtension(fileName).ToLower();
                    string[] allowedExtensions = { ".jpg", ".jpeg", ".png", ".gif" };

                    cliente.ExtensionLogo = fileExtension;

                    if (allowedExtensions.Contains(fileExtension))
                    {
                        byte[] fileBytes;

                        byte[] imagenBytes = fileUpload.FileBytes;

                        using (BinaryReader br = new BinaryReader(fileUpload.PostedFile.InputStream))
                        {
                            fileBytes = br.ReadBytes(fileUpload.PostedFile.ContentLength);
                        }
                        cliente.Logo = imagenBytes;

                        // Mostrar la imagen en el control Image
                        string base64String = Convert.ToBase64String(fileBytes);
                        imgPreview.ImageUrl = "data:image/" + fileExtension.Replace(".", "") + ";base64," + base64String;
                        imgPreview.Visible = true;
                    }
                    else
                    {
                        // Manejar el caso en que no se carga una imagen válida
                    }
                }
                cliente.NombreCliente = txtNombreCliente.Text;

                clienteNegocio.CrearCliente(cliente);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
            }
        }
    }