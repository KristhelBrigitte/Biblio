using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using LogicaNegocio;

namespace PresentacionWeb
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        EEditorial eEditorial = new EEditorial();
        LNEditorial lnE = new LNEditorial(Config.getCadConec);
        HttpCookie cookieE = new HttpCookie("CookieEdit");
        protected void Page_Load(object sender, EventArgs e)
        {
         
            string condicion = "";
            if (!IsPostBack)
            {
                Session["_exito"] = null;
                Session["_wrn"] = null;
                Session["_err"] = null;
                limpiar();

                if (Session["_claveEditorial"] != null)
                {
                    condicion = $"claveEditorial='{Session["_claveEditorial"].ToString()}'";
                    eEditorial = lnE.buscarRegistro(condicion);

                    if (eEditorial != null)
                    {

                        cookieE["_clavEdit"] = eEditorial.ClaveEditorial;
                        cookieE["_nomEdit"] = eEditorial.Nombre;

                        cookieE.Expires = DateTime.Now.AddMinutes(15);
                        Response.Cookies.Add(cookieE);

                        txtClaveEditorial.Text = eEditorial.ClaveEditorial;
                        txtNombre.Text = eEditorial.Nombre;

                    }
                }
            }
        }

        private void limpiar()
        {
            txtClaveEditorial.Text = string.Empty;
            txtNombre.Text = string.Empty;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string clave=string.Empty, nombre=string.Empty;
            try
            {
                if (Session["_claveEditorial"] == null)
                {
                    eEditorial = new EEditorial(txtClaveEditorial.Text, txtNombre.Text, false);
                }
                else
                {
                    if (hayCambios(ref clave, ref nombre))
                    {
                        eEditorial.ClaveEditorial = txtClaveEditorial.Text;
                        eEditorial.Nombre = txtNombre.Text;
                        eEditorial.Existe = true;
                    }
                }

                if (!eEditorial.Existe)
                {
                    insertarEditorial();
                }
                else
                {
                    if (!string.IsNullOrEmpty(clave))
                    {
                        if (!lnE.claveEditorialRepetida(eEditorial.ClaveEditorial))
                        {
                            hacerModificacion(clave);
                        }
                        else
                        {
                            Session["_err"] = "Error:La nueva clave de Editorial ya está en uso.";
                        }
                    }
                    else
                    {
                        hacerModificacion(clave);
                    }
                }
            }
            catch (Exception ex)
            {
                Session["_err"] = $"Error:{ex.Message}";
            }
        }

        private void hacerModificacion(string clave)
        {
            if (lnE.modificar(eEditorial, clave) > 0)
            {
                Session["_exito"] = "Actualizacion realizada";
            }
            else
            {
                Session["_wrn"] = "No se pudo modificar";
            }
            limpiar();
        }

        private void insertarEditorial()
        {
            if (lnE.claveEditorialRepetida(txtClaveEditorial.Text) == false)
            {
                if (lnE.editorialRepetido(eEditorial) == false)
                {
                    if (lnE.insertar(eEditorial) > 0)
                    {
                        Session["_exito"] = " Editorial insertado de manera exitosa";
                        limpiar();
                    }
                    else
                    {
                        Session["_wrn"] = "No se ha podido guardar el editorial!";
                        limpiar();
                    }
                }
                else
                {
                    Session["_wrn"] = "Está editorial ya ha sido registrada";
                    limpiar();
                }
            }
            else
            {
                Session["_wrn"] = "Atención:La clave de editorial ya está en uso.";
                limpiar();
            }
        }

        private bool hayCambios(ref string clave, ref string nombre)
        {
            bool result = false;

            if (txtClaveEditorial.Text != Request.Cookies["CookieEdit"]["_clavEdit"])
            {
                result = true;
                clave = Request.Cookies["CookieEdit"]["_clavEdit"];
            }

            if (txtNombre.Text != Request.Cookies["CookieEdit"]["_nomEdit"])
            {
                result = true;
                nombre = Request.Cookies["CookieEdit"]["_nomEdit"];
            }
            return result;
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("wfrListaEditoriales.aspx");
        }
    }
}