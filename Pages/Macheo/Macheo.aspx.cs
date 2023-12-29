using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.OleDb;
using System.Security.Cryptography;

namespace QMS.Pages.Macheo
{
    public partial class Macheo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Visible = false;
            CargarGrilla();
        }

        private void CargarGrilla()
        {
            ddlFormato.Items.Clear();
            ListItem item0 = new ListItem("GPOWER", "0");
            ListItem item1 = new ListItem("OLDELVAL", "1");
            ListItem item2 = new ListItem("OTASA", "2");
            ListItem item3 = new ListItem("ROSEN", "3");
            ListItem item4 = new ListItem("YPF", "4");

            ddlFormato.Items.Add(item0);
            ddlFormato.Items.Add(item1);
            ddlFormato.Items.Add(item2);
            ddlFormato.Items.Add(item3);
            ddlFormato.Items.Add(item4);
        }

        private DataTable ReadExcelFile(string filePath, int formatoTally)
        {
            try
            {
                string connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={filePath};Extended Properties='Excel 12.0 Xml;HDR=YES;'";

                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();

                    DataTable schemaTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    if (schemaTable == null || schemaTable.Rows.Count == 0)
                    {
                        // No se encontraron hojas en el archivo Excel
                        return null;
                    }

                    string firstSheetName = schemaTable.Rows[0]["TABLE_NAME"].ToString();
                    string query = $"SELECT * FROM [{firstSheetName}]";


                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            string columnTitle;
                            string columnTitle2;
                            string columnTitle3;

                            string valorABuscar = "SOLDADURA";

                            switch (formatoTally)
                            {
                                case 0:
                                    columnTitle = "JointNumber";
                                    columnTitle2 = "Distance";
                                    columnTitle3 = "LJoint";
                                    break;
                                case 1:
                                    columnTitle = "nSoldadura";
                                    columnTitle2 = "nDistanciaRefUmt[m]";
                                    columnTitle3 = "nLongTuboUmt[m]";
                                    break;
                                default:
                                    columnTitle = "nSoldadura";
                                    columnTitle2 = "Distance";
                                    columnTitle3 = "LJoint";
                                    break;
                            }
                            // Filtrar las columnas basadas en el título
                            List<DataColumn> columnsToRemove = new List<DataColumn>();

                            
                            foreach (DataColumn column in dt.Columns)
                            {
                                if (!string.Equals(column.ColumnName, columnTitle, StringComparison.OrdinalIgnoreCase) &&
                                        !string.Equals(column.ColumnName, columnTitle2, StringComparison.OrdinalIgnoreCase) &&
                                        !string.Equals(column.ColumnName, columnTitle3, StringComparison.OrdinalIgnoreCase))
                                {
                                    columnsToRemove.Add(column);
                                }
                            }

                            // Remover las columnas que no coinciden con el título deseado
                            foreach (DataColumn columnToRemove in columnsToRemove)
                            {
                                dt.Columns.Remove(columnToRemove);
                            }

                            return dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (fileUpload.HasFile && fileUploadCliente.HasFile)
            {
                // Obtener la ruta del escritorio del usuario
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                // Obtener solo el nombre del archivo seleccionado por el usuario
                string fileName = Path.GetFileName(fileUpload.PostedFile.FileName);
                string fileNameCliente = Path.GetFileName(fileUploadCliente.PostedFile.FileName);

                // Combinar la ruta del escritorio con el nombre del archivo
                string filePath = Path.Combine(desktopPath, fileName);
                string filePathCliente = Path.Combine(desktopPath, fileNameCliente);

                try
                {
                    fileUpload.SaveAs(filePath);
                    fileUpload.SaveAs(filePathCliente);

                    // Lógica para cargar el archivo en el GridView
                    DataTable dt = ReadExcelFile(filePath, 0); // Función para leer el archivo Excel y convertirlo a un DataTable
                    DataTable dtCliente = ReadExcelFile(filePathCliente, int.Parse(ddlFormato.SelectedItem.Value)); // Función para leer el archivo Excel del tally cliente y convertirlo a un DataTable

                    if (dt != null && dtCliente != null)
                    {
                        // Agregar las columnas del segundo DataTable al primero
                        foreach (DataColumn col in dtCliente.Columns)
                        {
                            dt.Columns.Add(new DataColumn(col.ColumnName, col.DataType));
                        }

                        // Copiar filas del segundo DataTable al primero
                        foreach (DataRow row in dtCliente.Rows)
                        {
                            DataRow newRow = dt.NewRow();
                            newRow.ItemArray = row.ItemArray;
                            dt.Rows.Add(newRow);
                        }

                        dgvMacheo.DataSource = dt;
                        dgvMacheo.DataBind();
                    }
                    else
                    {
                        dgvMacheo.DataSource = null;
                        dgvMacheo.DataBind();
                        lblError.Text = "No se pudieron obtener datos del archivo Excel.";
                        lblError.Visible = true;
                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
            else
            {
                lblError.Text = "Seleccione un archivo.";
                lblError.Visible = true;
            }
        }
    }
}