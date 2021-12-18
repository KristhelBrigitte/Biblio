using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaNegocio;
using Entidades;
namespace PresentacionWeb
{
    public partial class wfrEliminarEditorial : System.Web.UI.Page
    {
        LNEditorial lnE = new LNEditorial(Config.getCadConec);
        EEditorial eEditorial;
        LNEjemplar lnEje = new LNEjemplar(Config.getCadConec);
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string condicion = string.Empty;
                if (Session["_claveEditorial"] != null)
                {
                    condicion= $"claveEditorial='{Session["_claveEditorial"].ToString()}'";
                    eEditorial=lnE.buscarRegistro(condicion);
                    ViewState["_nombreEditorial"]=eEditorial.Nombre;

                }
                else
                {
                    Session["_wrn"] = "No se ha seleccionado una Editorial que eliminar";
                }
            }
            catch (Exception ex)
            {

                Session["_err"] = $"Error{ex.Message}";
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int result;
            if (Session["_claveEditorial"] != null)
            {
                try
                {
                    if (!lnEje.buscarEditorial(Session["_claveEditorial"].ToString()))
                    {
                        result = lnE.eliminar(Session["_claveEditorial"].ToString());
                        if (result > 0)
                        {
                            Session.Remove("_err");
                            Session.Remove("_wrn");
                            Session["_exito"] = "El Editorial se ha eliminado";
                            Response.Redirect("wrfListaLibros.aspx", false);
                        }
                    }
                    else
                    {
                        Session["_wrn"] = "No se puede eliminar, porque existen ejemplares asociados a la Editorial";
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