<%@ Page Title="" Language="C#" MasterPageFile="~/wfrPlantilla.Master" AutoEventWireup="true" CodeBehind="wfrListaEditoriales.aspx.cs" Inherits="PresentacionWeb.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="frmHead" runat="server">


</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="frmBody" runat="server">
    <div class="container">
         <div class="card-header text-center">
              <h1>Gestionar Editoriales</h1>        
         </div>
        

        <div class="row mt-4">
         <asp:Label ID="Label2" runat="server" Text="Nombre de Editorial:"></asp:Label>
             <div class="col-auto">
                 <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
             </div>

             <div class="col-auto">
                   <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary"/>
             </div>
            <asp:GridView ID="grvEditoriales" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal">
                <Columns>
                    <asp:TemplateField HeaderText="Modificar">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("claveEditorial").ToString() %>'></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Eliminar">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%# Eval("nombre").ToString() %>'>LinkButton</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="claveEditorial" HeaderText="Clave" />
                    <asp:BoundField DataField="nombre" HeaderText="Editorial" />
                </Columns>
                <FooterStyle BackColor="White" ForeColor="#333333" />
                <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="White" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#487575" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#275353" />
            </asp:GridView>
        </div>
      
    </div>
</asp:Content>
