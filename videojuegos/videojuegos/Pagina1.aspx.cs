using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Odbc;

namespace videojuegos
{
    public partial class Pagina1 : System.Web.UI.Page
    {
        public OdbcConnection conectarBD()
        {
            String stringConexion = "Driver={SQL Server Native Client 11.0};Server=CC102-09\\SA;Uid=sa;Pwd=adminadmin;Database=gameSpot";
            try
            {
                OdbcConnection conexion = new OdbcConnection(stringConexion);
                conexion.Open();
                lbContador.Text = "conexion exitosa";
                return conexion;
            }
            catch (Exception ex)
            {
                lbContador.Text = ex.StackTrace.ToString();
                return null;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btPagina2_Click(object sender, EventArgs e)
        {
            OdbcConnection miConexion = conectarBD();
            
            if(miConexion != null){
                String query = "SELECT claveU FROM usuario WHERE email='" + txUsuario.Text + "'AND password='" + txContraseña.Text + "'";
                OdbcCommand cmd = new OdbcCommand(query, miConexion);
                OdbcDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows){
                    rd.Read();
                    Session["claveUnica"] = rd.GetInt32(0).ToString();
                    Response.Redirect("./Pagina2.aspx");
                }
                else{
                    lbContador.Text = "El usuario o contraseña son incorrectos";
                }
            }
        }
    }
}