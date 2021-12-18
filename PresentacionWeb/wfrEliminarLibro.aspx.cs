using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using LogicaNegocio;
namespace PresentacionWeb
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        ELibro eLibro= new ELibro();
        LNLibro lnL = new LNLibro(Config.getCadConec);

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["_claveLibro"] != null)
                {
                    recuperarLibro(Session["_claveLibro"].ToString());
                    btnEliminar.Enabled = true;
                }
                else
                {
                    Session["_wrn"] = "No se ha seleccionado un libro que eliminar";
                }
            }
            catch (Exception ex)
            {

                Session["_err"] = $"Error{ex.Message}";
            }
        }

        private void recuperarLibro(string claveLibro)
        {
            DataTable dt;
            string condicion = $"Clave='{claveLibro}'";

            dt = lnL.listarTodos(condicion, true);
            if (dt != null)
            {
                ViewState["_titulo"] = dt.Rows[0][1];
                ViewState["_autor"] = dt.Rows[0][2];
                ViewState["_categoria"] = dt.Rows[0][3];
            }else
            {
                Session["_wrn"] = "El libro seleccionado ya no existe en la base de datos";
                btnEliminar.Enabled = false;
            }
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Session.Remove("_claveLibro");
            Session.Remove("_err");
            Session.Remove("_wrn");
            Response.Redirect("wrfListaLibros.aspx");

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int result=-1;
            if (Session["_claveLibro"] != null)
            {
                try
                {
                    result = lnL.eliminar(Session["_claveLibro"].ToString());
                    if (result>0)
                    {
                        Session.Remove("_err");
                        Session.Remove("_wrn");
                        Session["_exito"] = "El libro se ha eliminado";
                        Response.Redirect("wrfListaLibros.aspx", false);
                    }
                  
                }
                catch (Exception ex)
                {

                    Session["_err"] = $"Error:{ex.Message}";
                }
            }
        }
    }
}