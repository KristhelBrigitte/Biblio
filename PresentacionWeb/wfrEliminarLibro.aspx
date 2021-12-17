<%@ Page Language="C#" MasterPageFile="~/wfrPlantilla.Master"  AutoEventWireup="true" CodeBehind="wfrEliminarLibro.aspx.cs" Inherits="PresentacionWeb.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="frmHead" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="frmBody" runat="server">
        <div class="container">

            <div class="card-header">
                <h1>Eliminar Libro</h1>
            </div>


              <%if (Session["_err"] != null) { %>
               <div class="alert alert-danger" role="alert">
                    <%=Session["_err"] %> 
                     <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
               </div>
               
            <% }%>

                 <%if (Session["_wrn"] != null) { %>
               <div class="alert alert-warning" role="alert">
                    <%=Session["_wrn"] %> 
                     <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
               </div>
               
            <% }%>


            <div class="row">
               <div class="card position-absolute top-50 start-50 translate-middle">
                   <div class="card-body">  
                   <h5 class="card-title">Titulo <%=ViewState["_titulo"] %> </h5>
                   <h6 class="card-subtittle">Clave <%=Session["_claveLibro"]%></h6>
                   <h6 class="card-subtittle">Autor <%=ViewState["_autor"] %>  </h6>
                   <h6 class="card-subtittle">Categoria <%=ViewState["_categoria"] %> </h6>
                   <p class="card-text">El libro será Eliminado! Confirma la eliminación?</p>

                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClas="btn btn-danger" OnClick="btnEliminar_Click" />

                    <asp:Button ID="btnRegresar" runat="server" Text="Regresar" cssClass="btn btn-warning"/>
                </div>
            </div>
           </div>
            

        </div>

     
 </asp:Content>