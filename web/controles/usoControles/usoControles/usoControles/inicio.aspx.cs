using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace usoControles
{
    public partial class inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ddColores.Items.Count == 0)
            {
                ddColores.Items.Add("Rojo");
                ddColores.Items.Add("Verde");
                ddColores.Items.Add("Rosa");
                ddColores.Items.Add("Amarillo");
            }

            if(rbSabores.Items.Count == 0)
            {
                rbSabores.Items.Add("vainilla");
                rbSabores.Items.Add("fresa");
                rbSabores.Items.Add("chocolate");
            }

            if (cbCafe.Items.Count == 0)
            {
                cbCafe.Items.Add("Americano");
                cbCafe.Items.Add("Capuchino");
                cbCafe.Items.Add("Latte");
            }
        }

        protected void ddColores_SelectedIndexChanged(object sender, EventArgs e)
        {
            int seleccion = 0;
            seleccion = ddColores.SelectedIndex;
            lbColores.Text = "Índice seleccionado: " + seleccion.ToString();

            Session["controles"] = "Cambio al DropDownList";
            lbSession.Text = Session["controles"].ToString();
;        }

        protected void rbSabores_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbIndiceS.Text = "Índice seleccionado: " + rbSabores.SelectedIndex.ToString();
            lbContenidoS.Text = "El contenido seleccinoado: " + rbSabores.SelectedValue.ToString();

            Session["controles"] = "Cambio al RadioButtonList";
            lbSession.Text = Session["controles"].ToString();
        }

        protected void cbCafe_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox1.Items.Clear();
            ListBox2.Items.Clear();
            for (int i=0; i<cbCafe.Items.Count; i++ )
            {
                if (cbCafe.Items[i].Selected)
                {
                    ListBox1.Items.Add(i.ToString());
                    ListBox2.Items.Add(cbCafe.Items[i].ToString());
                }

            }

            Session["controles"] = "Cambio al CheckBoxList";
            lbSession.Text = Session["controles"].ToString();
        }
    }
}