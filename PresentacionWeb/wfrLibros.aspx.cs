using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Entidades;
using LogicaNegocio;
namespace PresentacionWeb
{ 
    public partial class wfrLibros : System.Web.UI.Page
    {
        ELibro elibro = new ELibro();
        LNLibro lnL = new LNLibro(Config.getCadConec);
        LNCategoria lnC = new LNCategoria(Config.getCadConec);
        LNAutor lnA = new LNAutor(Config.getCadConec);
        HttpCookie cookie = new HttpCookie("MyCookie");


        private void cargarAutores(string condicion = "")
        {
            DataTable dt;
            try
            {
                dt = lnA.ListarRegistros(condicion);
                if (dt != null)
                {
                    grvAutores.DataSource = dt;
                    grvAutores.DataBind();

                }
            }
            catch (Exception ex)
            {
                Session["_err"] = $"Error:{ex.Message}";
            }

        }

        private void cargarCategorias(string condicion = "")
        {
            DataTable dt;
            try
            {
                dt = lnC.ListarRegistros(condicion);
                if (dt != null)
                {
                    grvCategorias.DataSource = dt;
                    grvCategorias.DataBind();
                }
            }
            catch (Exception ex)
            {
                Session["_err"] = $"Error:{ex.Message}";
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string condicion = "";
            if (!IsPostBack) {
                limpiar();
            
                if (Session["_claveLibro"] != null)
                {
                    condicion = $"claveLibro='{Session["_claveLibro"].ToString()}'";
                    elibro = lnL.buscarRegistro(condicion);

                    if (elibro != null)
                    {

                   
                        cookie["_clav1"] = elibro.ClaveLibro;
                        cookie["_titulo1"] = elibro.Titulo;
                        cookie["_autor1"] = elibro.ClaveAutor;
                        cookie["_categoria1"] = elibro.Clavecategoria.ClaveCategoria;
                        cookie.Expires = DateTime.Now.AddMinutes(15);
                        Response.Cookies.Add(cookie);

                        txtClaveLibro.Text = elibro.ClaveLibro;
                        txtTitulo.Text = elibro.Titulo;
                        recuperarAutor(elibro.ClaveAutor);
                        recuperarCategoria(elibro.Clavecategoria.ClaveCategoria);
                    }
                }
                cargarAutores("");
                cargarCategorias("");
            }
          
        }

        

        private bool hayCambios(ref string bCL,ref string bT,ref string bAu,ref string bCat)
        {
            bool result = false;
            //if (cookie != null)
           // {
                if(txtClaveLibro.Text!= Request.Cookies["MyCookie"]["_clav1"])
                {
                    result=true;
                    bCL = Request.Cookies["MyCookie"]["_clav1"];
                }

                if (txtTitulo.Text != Request.Cookies["MyCookie"]["_titulo1"])
                {
                    result = true;
                    bT = Request.Cookies["MyCookie"]["_titulo1"];
                
                }
                if (txtIdAutor.Text != Request.Cookies["MyCookie"]["_autor1"])
                {
                    result = true;
                    bAu = Request.Cookies["MyCookie"]["_autor1"];
                }

                if (txtIdCategoria.Text != Request.Cookies["MyCookie"]["_categoria1"])
                {
                    result = true;
                    bCat = Request.Cookies["MyCookie"]["_categoria1"];
                }
           // }
            return result;
        }


        protected void btnBuscarAutor_Click(object sender, EventArgs e)
        {
            
            string javaScript = "AbrirModal(1)";
            cargarAutores($"nombre like '%{txtNombreAutor.Text}%'");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript,true);
        }

        //Escrito 
     
        protected void btnFiltrarCategoria_Click1(object sender, EventArgs e)
        {
            string javaScript = "AbrirModal(2)";
            cargarCategorias($"descripcion like '%{txtNombreCategoria.Text}%'");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
        }

        protected void grvCategorias_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvCategorias.PageIndex = e.NewPageIndex;
            btnFiltrarCategoria_Click1(sender, e);
        }

        protected void grvAutores_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            grvAutores.PageIndex = e.NewSelectedIndex;
            btnBuscarAutor_Click(sender, e);
        }

        protected void lnkSeleccionarAutor_Command(object sender, CommandEventArgs e)
        {
            recuperarAutor(e.CommandArgument.ToString());

        }

        private void recuperarAutor(string claveAutor)
        {
            string condicion = $"claveAutor='{claveAutor}'";
            EAutor autor;
            try
            {
                autor = lnA.BuscarRegistro(condicion);
                if (autor != null)
                {
                    txtIdAutor.Text = autor.ClaveAutor;
                    txtAutor.Text =autor.ApPaterno+" "+ autor.Nombre;
                }
            }
            catch (Exception ex )
            {
                Session["_err"]=$"Error:{ex.Message}";
                throw;
            }
        }

      

        private void recuperarCategoria(string claveCategoria)
        {
            string condicion = $"claveCategoria='{claveCategoria}'";
            ECategoria cate;

            try
            {
                cate = lnC.BuscarRegistro(condicion);
                if (cate != null)
                {
                    txtIdCategoria.Text = cate.ClaveCategoria;
                    txtCategoria.Text = cate.Descripcion;
                }
            }
            catch (Exception ex)
            {
                Session["_err"] = $"Error:{ex.Message}";
            }
        }

        protected void lnkSeleccionarCategoria_Command(object sender, CommandEventArgs e)
        {
            recuperarCategoria(e.CommandArgument.ToString());
        }

        private void limpiar()
        {
            txtAutor.Text = string.Empty;
            txtCategoria.Text = string.Empty;
            txtClaveLibro.Text = string.Empty;
            txtIdAutor.Text = string.Empty;
            txtIdCategoria.Text = string.Empty;
            txtNombreAutor.Text = string.Empty;
            txtNombreCategoria.Text = string.Empty;
            txtTitulo.Text = string.Empty;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string clave = "";
            string titulo = "";
            string autor = "";
            string categoria = "";

            try
            {
                ECategoria cate = new ECategoria();
                cate.ClaveCategoria = txtIdCategoria.Text;
                if(Session["_claveLibro"] == null){
                    elibro = new ELibro(txtClaveLibro.Text, txtTitulo.Text, txtIdAutor.Text, cate, false);
                }
                else{
                     if(hayCambios(ref clave,ref titulo,ref autor, ref categoria))
                     {
                        elibro.ClaveAutor = txtIdAutor.Text;
                        elibro.Titulo = txtTitulo.Text;
                        elibro.ClaveLibro = txtClaveLibro.Text;
                        elibro.Clavecategoria.ClaveCategoria = txtIdCategoria.Text;
                        elibro.Existe = true;
                     }

                }
                if (!elibro.Existe)
                {
                    insertarLibro();
                }
                else
                {
                    //update
                    if (!string.IsNullOrEmpty(clave))//false
                    {
                        if (!lnL.claveLibroRepetida(elibro.ClaveLibro))
                        {
                            cambiosTituloAutor(clave, autor, titulo);
                        }
                        else
                        {
                            Session["_err"] = "Error:La nueva clave de libro ya está en uso.";
                            txtClaveLibro.Focus();
                        }
                    }
                    else
                    {
                        cambiosTituloAutor(string.Empty, autor, titulo);
                    }
                    cargarAutores();
                }  
            }
            catch (Exception ex)
            {
                Session["_err"] = $"Error:{ex.Message}";
            }
           
        }

        private void insertarLibro()
        {
            if (lnL.claveLibroRepetida(txtClaveLibro.Text) == false)
            {
                if (lnL.libroRepetido(elibro) == false)
                {
                    if (lnL.insertar(elibro) > 0)
                    {
                        Session["_exito"] = "El libro se ha insertado de manera exitosa";
                        limpiar();
                    }
                    else
                    {
                        Session["_wrn"] = "No se ha podido guardar el libro!!";
                    }
                }
                else
                {
                    Session["_wrn"] = "EL titulo ya existe para el autor selecionado";
                }
            }
            else
            {
                Session["_wrn"] = "Atención:La clave de libro ya está en uso.";
            }
        }

        private void cambiosTituloAutor(string clave, string autor, string titulo)
        {
            if (!string.IsNullOrEmpty(titulo) || !string.IsNullOrEmpty(autor))
            {
                if (!lnL.libroRepetido(elibro))
                {
                    hacerModificacion(clave);
                }
                else
                {
                    Session["_wrn"] = "No se puede actualizar porque el autor y el titulo ya existen";
                    limpiar();
                }
            }
            else
            {
                hacerModificacion(clave);
            }
        }

        private void hacerModificacion(string clave)
        {
            if (lnL.modificar(elibro, clave) > 0)
            {
                Session["_exito"] = "Actualizacion realizada";
            }
            else
            {
                Session["_wrn"] = "No se pudo modificar";
            }
            limpiar();
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("wrfListalibros.aspx");
        }
    }
}