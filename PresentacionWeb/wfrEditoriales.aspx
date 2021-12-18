<%@ Page Title="" Language="C#" MasterPageFile="~/wfrPlantilla.Master" AutoEventWireup="true" CodeBehind="wfrEditoriales.aspx.cs" Inherits="PresentacionWeb.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="frmHead" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="frmBody" runat="server">
     <div class="container col-11">
        <div class="card-header text-center  text-white bg-primary mb-3">
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
         <br />
         <div class="card">
             <h3>Clave de Editorial</h3>
           
         
         <asp:TextBox ID="txtClaveEditorial" runat="server"  CssClass="form-control"></asp:TextBox>
         <asp:RequiredFieldValidator ID="rfvClaveE" runat="server" validationGroup="11" forecolor="red"  ControlToValidate="txtClaveEditorial" ErrorMessage="*Debe digitar la clave">*</asp:RequiredFieldValidator>
        <h3>Nombre </h3>
         
         <asp:TextBox ID="txtNombre" runat="server"  CssClass="form-control"></asp:TextBox>
         <asp:RequiredFieldValidator ID="rfvNombreE" runat="server" validationGroup="11" forecolor="red" ControlToValidate="txtNombre" ErrorMessage="*Debe digitar el nombre de la Editorial">*</asp:RequiredFieldValidator>
         <br />
             <div class="row mt-4">
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" validationGroup="11" OnClick="btnGuardar_Click" width="25%" />
                
                    <asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="btn btn-warning" OnClick="btnRegresar_Click"  width="25%"   />
             </div>
      
         </div>
         </div>

    <asp:ValidationSummary ID="ValidationSummary1" forecolor="Red" ValidationGroup="11" runat="server" />
</asp:Content>
