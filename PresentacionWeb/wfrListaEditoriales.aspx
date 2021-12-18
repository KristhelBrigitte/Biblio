<%@ Page Title="" Language="C#" MasterPageFile="~/wfrPlantilla.Master" AutoEventWireup="true" CodeBehind="wfrListaEditoriales.aspx.cs" Inherits="PresentacionWeb.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="frmHead" runat="server">
    <script src="myScript.js"></script>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="frmBody" runat="server">
    <div class="container">
         <div class="card-header text-center">
              <h1>Gestionar Editoriales</h1> 
             
               <%if (Session["_err"] != null) { %>
               <div class="alert alert-danger" role="alert">
                    <%=Session["_err"] %> 
                     <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
               </div>
              <% }%>              <%if (Session["_wrn"] != null) { %>
               <div class="alert alert-warning" role="alert">
                    <%=Session["_wrn"] %> 
                     <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
               </div> 
              <% }%>              <%if (Session["_exito"] != null) { %>
                <div class="alert alert-info" role="alert">
                    <%=Session["_exito"]%>
                   <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                </div>

              <%Session["_exito"] = null;
                }%>
         </div>
        
        <div class="row mt-4">
               <div class="col-6">
                   <h4>Nombre de Editorial:</h4>
                   <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" width="80%"></asp:TextBox>
          
                   <asp:Button ID="btnBuscar" runat="server" Text="Buscar" cssClass="btn btn-primary" OnClick="btnBuscar_Click"  validationGroup="15"/>
                   <asp:Button ID="btnNueva" runat="server" Text="Nueva"   cssClass="btn btn-success" OnClick="btnNueva_Click"/>
                   <asp:RequiredFieldValidator validationGroup="15" ID="rfvTxtNombre" runat="server" ControlToValidate="txtNombre" ForeColor="red" ErrorMessage="*Debe escribir el nombre o algunas letras para buscar la Editorial"></asp:RequiredFieldValidator>
               </div>
               <br />

               <div class="col-6 text-center">
                   <h4>Ejemplares</h4>

              </div>


            <div class="row">

                <div class="col-6">
                      <asp:GridView ID="grvEditoriales" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal">
                <Columns>
                    <asp:TemplateField HeaderText="Modificar">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkModificar" runat="server" CommandArgument='<%# Eval("claveEditorial").ToString() %>' OnCommand="lnkModificar_Command" ForeColor="#0066FF"><i class="fas fa-pencil-alt"></i></asp:LinkButton>
                           
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Eliminar">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkEliminar" runat="server" CommandArgument='<%# Eval("claveEditorial").ToString() %>' OnCommand="lnkEliminar_Command" ForeColor="#990000"><i class="fas fa-trash-alt"></i></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Ejemplares">
                        <ItemTemplate>
                            <asp:LinkButton ID="LnkEjemplares"  OnCommand="LnkEjemplares_Command"  runat="server" CommandArgument='<%# Eval("claveEditorial").ToString() %>' ForeColor="#339966" ><i class="fas fa-book-open"></i></asp:LinkButton>
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
         
                <div class="col-6">
                  
                       <asp:GridView ID="grvEjemplares" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>

                <asp:BoundField DataField="claveEj" HeaderText="Clave de Ejemplar" />
                <asp:BoundField DataField="Titulol" HeaderText="Libro" />
                <asp:BoundField DataField="Condicion" HeaderText="Condicion" />
                <asp:BoundField DataField="Estado" HeaderText="Estado" />
                <asp:BoundField DataField="Edicion" HeaderText="Edicion" />
                <asp:BoundField DataField="Paginas" HeaderText="# Páginas" />
                <asp:BoundField DataField="Editorial" HeaderText="Editorial" />

                </Columns>
                <EditRowStyle BackColor="#7C6F57" />
                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#E3EAEB" />
                <SelectedRowStyle BackColor="#C5BBAF" ForeColor="#333333" Font-Bold="True"  />
                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                <SortedAscendingHeaderStyle BackColor="#246B61" />
                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                <SortedDescendingHeaderStyle BackColor="#15524A" />
            </asp:GridView>
                </div>



            </div>

        </div>
      
    </div>
</asp:Content>
