<%@ Page Title="" Language="C#" MasterPageFile="~/wfrPlantilla.Master" AutoEventWireup="true" CodeBehind="wfrEditoriales.aspx.cs" Inherits="PresentacionWeb.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="frmHead" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="frmBody" runat="server">
     <div class="container col-11">
        <div class="card-header text-center">
            <h1>Mantenimiento de Editoriales</h1>

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

              <%if (Session["_exito"] != null) { %>
                <div class="alert alert-info" role="alert">
                    <%=Session["_exito"]%>
                   <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                </div>

              <%Session["_exito"] = null;
                }%>


        </div>
         <asp:Label ID="Label1" runat="server" Text="Clave de Editorial:"></asp:Label>
         
         <asp:TextBox ID="txtClaveEditorial" runat="server"></asp:TextBox>

         <asp:Label ID="Label2" runat="server" Text="Nombre:"></asp:Label>
         
         <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
         <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click"/>
         <asp:Button ID="btnRegresar" runat="server" Text="Button" CssClass="btn btn-warning" />
         </div>
</asp:Content>
