using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sueldo
{
    public partial class Index : System.Web.UI.Page
    {
        protected OdbcConnection agregarConexion()
        {
            try
            {
                OdbcConnection conexion = new OdbcConnection("Driver={SQL Server Native Client 11.0};Server=CC102-09\\SA;Uid=sa;Pwd=adminadmin;Database=sueldos;");
                conexion.Open();
                return conexion;
            }
            catch (Exception ex)
            {
                return null;
            }
        } 

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void bSiguiente_Click(object sender, EventArgs e)
        {
            Session["nombre"] = tbNombre.Text;
            Response.Redirect("Sueldo.aspx");
        }

        protected void bReporte_Click(object sender, EventArgs e)
        {
            Response.Redirect("Reportes.aspx");
        }
    }
}