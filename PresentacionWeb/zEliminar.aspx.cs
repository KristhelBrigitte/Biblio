using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using LogicaNegocio;
using System.Data;

namespace PresentacionWeb
{
    public partial class wfrListarLibros : System.Web.UI.Page
    {
        ELibro libro = new ELibro();
        LNLibro lnLibro = new LNLibro(Config.getCadConec);
        
        private void cargarDataGrid(string condicion="")
        {
            DataTable dt;
            try
            {
                dt = lnLibro.listarTodos(condicion, true);
                if (dt != null)
                {
                    grdLibros.DataSource = dt;
                    grdLibros.DataBind();
                }
                else
                    Session["_wrn"] = "No se encontraron libros";
            }
            catch (Exception ex)
            {

                Session["_err"] = $"Error:{ex.Message}";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            string Prueba = Session["_exito"].ToString();

            if (!IsPostBack)
            {
                txtTitulo.Text = string.Empty;
                txtTitulo.Focus();
                cargarDataGrid("");

            }
        }

        protected void lnkModificar_Click(object sender, EventArgs e)
        {

        }

        protected void lnkModificar_Command(object sender, CommandEventArgs e)
        {
            Session["_wrn"] = e.CommandArgument.ToString();
        }

        protected void grdLibros_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdLibros.PageIndex = e.NewPageIndex;
            cargarDataGrid();

        }

        protected void Limpiar()
        {
            cargarDataGrid("");
            txtTitulo.Text = "";
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            cargarDataGrid($"titulo like '%{txtTitulo.Text}%'");
           
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("wfrLibros.aspx");
        
        }

        protected void lnkEliminar_Command(object sender, CommandEventArgs e)
        {
            Session["_claveLibro"] = e.CommandArgument.ToString();
            Response.Redirect("wfrEliminarLibro.aspx");
        }
    }
}