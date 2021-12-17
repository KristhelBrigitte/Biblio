<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="zEliminar.aspx.cs" Inherits="PresentacionWeb.wfrListarLibros" %>
<asp:Content ID="Content1" ContentPlaceHolderID="frmHead" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="frmBody" runat="server">
    <div class="container">
        <div class="card-header text-center">
            <h1>Gestionar Libros</h1>


            <%--ALERT--%>

              <%if (Session["_exito"] != null) { %>
                <div class="alert alert-info" role="alert">
                    <%=Session["_exito"]%>
                   <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                </div>

              <%Session["_exito"] = null;
                }%>

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

        </div>
        <br />

        <div class="row mt-3">
            <div class="col-auto">
                <asp:Label ID="Label1" runat="server" Text="Titulo de libro"></asp:Label>
            </div>

            <div class="col-auto">
               <asp:TextBox ID="txtTitulo" runat="server" CssClass="form-control" ValidationGroup="1"></asp:TextBox>
               
            </div>

            <div class="col-auto">
               <asp:Button ID="btnBuscar" runat="server"   Text ="Buscar" CssClass="btn btn-primary"   OnClick="btnBuscar_Click"
               validationGroup="1" />

               <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" type="button" cssClass="btn btn-secondary" OnClick="btnLimpiar_Click"/>

              <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" cssClass="btn btn-success" OnClick="btnNuevo_Click" />
              </div>

               <asp:RequiredFieldValidator ID="rfvTxtTitulo" runat="server" ErrorMessage="* Debe escribir parte del titulo para buscar" 
               ControlToValidate ="txtTitulo" Font-Italic="true" ForeColor="red" ValidationGroup="1"></asp:RequiredFieldValidator>
        </div>



        <br />
        <asp:GridView ID="grdLibros" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" Width="100%" AllowPaging="True" OnPageIndexChanging="grdLibros_PageIndexChanging" PageSize="15">
            <AlternatingRowStyle BackColor="Gainsboro" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkModificar" runat="server" CommandArgument='<%# Eval("Clave").ToString() %>' OnClick="lnkModificar_Click" OnCommand="lnkModificar_Command" ForeColor="#0099CC"  >Modificar<i class="fas fa-pen-alt"></i></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkEliminar" runat="server" CommandArgument='<%# Eval("Clave").ToString() %>' ForeColor="Red" OnCommand="lnkEliminar_Command">Eliminar <i class="fas fa-trash"></i></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Clave" HeaderText="Clave" />
                <asp:BoundField DataField="Titulo" HeaderText="Titulo" />
                <asp:BoundField DataField="Autor" HeaderText="Autor" />
                <asp:BoundField DataField="Categoria" HeaderText="Categoría" />
            </Columns>
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#0000A9" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#000065" />

        </asp:GridView>
    </div>
</asp:Content>
