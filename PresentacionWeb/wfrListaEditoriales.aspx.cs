using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using LogicaNegocio;

namespace PresentacionWeb
{
    public partial class WebForm2 : System.Web.UI.Page
    {


        LNEditorial lnE = new LNEditorial(Config.getCadConec);
        LNEjemplar lnEJ = new LNEjemplar(Config.getCadConec);
        protected void Page_Load(object sender, EventArgs e)
        {
            cargarEditoriales();
            cargarEjemplares("");

        }

        private void cargarEditoriales(string condicion = "")
        {
            DataTable dt;

            try
            {
                dt = lnE.listarTodos(condicion);
                if (dt != null)
                {

                    grvEditoriales.DataSource = dt;
                    grvEditoriales.DataBind();
                }
                else
                    Session["_wrn"] = "No se encontraron Editoriales";
            }
            catch (Exception ex)
            {

                Session["_err"] = $"Error:{ex.Message}";
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            cargarEditoriales($"nombre like '%{txtNombre.Text}%'");
        }

        protected void btnNueva_Click(object sender, EventArgs e)
        {
            Response.Redirect("wfrEditoriales.aspx");
        }

      

        protected void lnkModificar_Command(object sender, CommandEventArgs e)
        {
            Session["_claveEditorial"] = e.CommandArgument.ToString();
            Response.Redirect("wfrEditoriales.aspx");
        }

        protected void lnkEliminar_Command(object sender, CommandEventArgs e)
        {
            Session["_claveEditorial"] = e.CommandArgument.ToString();
            Response.Redirect("wfrEliminarEditorial.aspx");
        }

        protected void LnkEjemplares_Command(object sender, CommandEventArgs e)
        {
            Session["_claveEditEje"] = e.CommandArgument.ToString();
            cargarEjemplares(Session["_claveEditEje"].ToString());
        }

        private void cargarEjemplares(string condicion)
        {
            DataTable dt;

            try
            {

                dt = lnEJ.listarTodos(condicion);
                if (dt != null)
                {
                    grvEjemplares.DataSource = dt;
                    grvEjemplares.DataBind();
                }
                else
                    Session["_wrn"] = "No se encontraron ejemplares";
            }
            catch (Exception ex)
            {

                Session["_err"] = $"Error:{ex.Message}";
            }
        }

        protected void btnVerEjemplares_Click(object sender, EventArgs e)
        {

        }
    }
}