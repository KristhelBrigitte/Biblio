<%@ Page Title="" Language="C#" MasterPageFile="~/wfrPlantilla.Master" AutoEventWireup="true" CodeBehind="wfrEliminarEditorial.aspx.cs" Inherits="PresentacionWeb.wfrEliminarEditorial" %>
<asp:Content ID="Content1" ContentPlaceHolderID="frmHead" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="frmBody" runat="server">
      <div class="container">

            <div class="card-header">
                <h1>Eliminar Libro</h1>
            </div>

              <div class="row">
               <div class="card position-absolute top-50 start-50 translate-middle">
                   <div class="card-body">  
                   <h5 class="card-title">Clave Editorial <%=Session["_claveEditorial"] %> </h5>
                   <h6 class="card-subtittle">Nombre de Editorial: <%=ViewState["_nombreEditorial"]%></h6>

                   <p class="card-text">El Editorial será eliminado! Confirma la eliminación?</p>
                 
                   <asp:Button ID="btnEliminar" runat="server" Text="Eliminar"  cssClass="btn btn-danger" OnClick="btnEliminar_Click" />
                       
                   <asp:Button ID="btnRegresar" runat="server" Text="Regresar" cssClass="btn btn-warning" />
                        
                </div>
                 
            </div>
           </div>
            

      </div>

</asp:Content>
