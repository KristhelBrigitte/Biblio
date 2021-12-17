<%@ Page Title="" Language="C#" MasterPageFile="~/wfrPlantilla.Master" AutoEventWireup="true" CodeBehind="wfrLibros.aspx.cs" Inherits="PresentacionWeb.wfrLibros" %>

<asp:Content ID="Content1" ContentPlaceHolderID="frmHead" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>

    <script src="myScript.js"></script>


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="frmBody" runat="server">
    <div class="container col-11">
        <div class="card-header text-center">
            <h1>Mantenimiento de Libros</h1>

         <%-- ALERTS--%>

          
               <%if (Session["_exito"] != null) { %>
                <div class="alert alert-info" role="alert">

                    <%=Session["_exito"]%>

                   <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                </div>

            <%Session["_exito"] = null;
                }%>


              <%if (Session["_wrn"] != null) { %>
                <div class="alert alert-warning" role="alert">

                    <%=Session["_wrn"]%>

               <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                </div>

            <%Session["_wrn"] = null;
                }%>


             <%if (Session["_err"] != null) { %>
                <div class="alert alert-danger" role="alert">

                    <%=Session["_err"]%>

               <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                </div>

            <%Session["_err"] = null;
                }%>

        </div>


        <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>


        <br />
       <div class="row mt-3">
            <div class="col-2">
                <asp:Label ID="Label1" runat="server" Text="Clave Libro"></asp:Label>
                <asp:TextBox ID="txtClaveLibro" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

               <div class="col-4">
                <asp:Label ID="Label2" runat="server" Text="Titulo"></asp:Label>
                <asp:TextBox ID="txtTitulo" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="col-3">
                <asp:TextBox ID="txtIdAutor" runat="server" Visible="false"></asp:TextBox>
                <asp:Label ID="Label3" runat="server" Text="Autor"></asp:Label>

                 <div class="input-group mb-3">

                    <asp:TextBox ID="txtAutor" runat="server"
                        CssClass="form-control"
                        aria-describedby="btnModalAutor"
                        ReadOnly="true" ValidationGroup="3"> </asp:TextBox>

                    <button class="btn btn-outline-primary" type="button" id="btnModalAutor"
                        data-bs-toggle="modal"
                        data-bs-target="#autorModal">

                        Buscar</button>

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtAutor" ValidationGroup="3" runat="server" ErrorMessage=""></asp:RequiredFieldValidator>

                </div>
            </div>

              <div class="col-3">
                <asp:TextBox ID="txtIdCategoria" Visible="false" runat="server"></asp:TextBox>
                <asp:Label ID="Label4" runat="server" Text="Categoria"></asp:Label>

                <div class="input-group mb-3">
                    <asp:TextBox ID="txtCategoria" ReadOnly="true" runat="server" CssClass="form-control"
                        aria-describedby="btnModalCategoria"></asp:TextBox>

                    <button class="btn btn-outline-primary" type="button" id="btnModalCategoria" style="width: 62px"
                        data-bs-toggle="modal"
                        data-bs-target="#categoriaModal">
                        Buscar
                    </button>
                </div>
            </div>
        </div>

        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Debe registrar una Categoria" ControlToValidate="txtCategoria" ValidationGroup="3"></asp:RequiredFieldValidator>
     
        <br />

        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary"  ValidationGroup="3" OnClick="btnGuardar_Click" />

        <asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="btn btn-warning" OnClick="btnRegresar_Click" />
       
        <asp:ValidationSummary ID="ValidationSummary" runat="server" ValidationGroup="3" />
    </div>
   

   <%-- ku quitar y kc comentar y kd identa--%>

    <%--Modales--%>
    <%--Modal Autores--%>

    <div class="modal " tabindex="-1" id="autorModal">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Buscar Autor</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <div class="row mt-3">
                        <div class="col-auto">
                            <asp:Label ID="Label5" runat="server" Text="Autor"></asp:Label>
                        </div>
                        <div class="col-auto">
                            <asp:TextBox ID="txtNombreAutor" runat="server" ValidationGroup="1"></asp:TextBox>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="* Debe escribir un nombre para buscar un autor" ValidationGroup="1" ControlToValidate="txtNombreAutor"></asp:RequiredFieldValidator>

                        </div>
                        <div class="col-auto">
                            <asp:Button ID="btnBuscarAutor" runat="server" Text="Filtrar"
                                CssClass="btn btn-secondary" OnClick="btnBuscarAutor_Click" ValidationGroup="1" />
                        </div>
                        <br />

                        <asp:GridView ID="grvAutores" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" Width="100%" AllowPaging="True" OnSelectedIndexChanging="grvAutores_SelectedIndexChanging">
                            <AlternatingRowStyle BackColor="#F7F7F7" />
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkSeleccionarAutor" runat="server" CommandArgument='<%# Eval("claveAutor").ToString() %>' OnCommand="lnkSeleccionarAutor_Command" ValidationGroup="9">Seleccionar</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="claveAutor" HeaderText="Clave Autor" Visible="False" />
                                <asp:BoundField DataField="apPaterno" HeaderText="Apellido" />
                                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                            </Columns>
                            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                            <SortedAscendingCellStyle BackColor="#F4F4FD" />
                            <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                            <SortedDescendingCellStyle BackColor="#D8D8F0" />
                            <SortedDescendingHeaderStyle BackColor="#3E3277" />
                        </asp:GridView>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>

    <%--Modal Categorias--%>
    <div class="modal " tabindex="-1" id="categoriaModal">

        <div class="modal-dialog">
            <div class="modal-content">

                <div class="modal-header">
                    <h5 class="modal-title">Seleccionar Categoría</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>

                <div class="modal-body">
                    <p>Modal body text goes here.</p>

                    <div class="col-auto">
                        <asp:Label ID="Label6" runat="server" Text="Categoria"></asp:Label>
                    </div>

                    <div class="col-auto">
                        <asp:TextBox ID="txtNombreCategoria" runat="server"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNombreCategoria"></asp:RequiredFieldValidator>

                    </div>

                    <div class="col-auto">
                        <asp:Button ID="btnFiltrarCategoria" runat="server" Text="Filtrar"
                            CssClass="btn btn-secondary" OnClick="btnFiltrarCategoria_Click1" />

                    </div>


                    <asp:GridView ID="grvCategorias" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" Width="100%" AllowPaging="True" OnPageIndexChanging="grvCategorias_PageIndexChanging">
                        <AlternatingRowStyle BackColor="#F7F7F7" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkSeleccionarCategoria" runat="server" CommandArgument='<%# Eval("claveCategoria").ToString() %>' OnCommand="lnkSeleccionarCategoria_Command" ValidationGroup="9">Seleccionar</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="claveCategoria" HeaderText="Clave Categoría" />
                            <asp:BoundField DataField="descripcion" HeaderText="Descripción" />
                        </Columns>
                        <EmptyDataTemplate>
                            <asp:LinkButton ID="lnkSeleccionarC" runat="server" CommandArgument='<%# Eval("claveCategoria").ToString() %>'>Seleccionar</asp:LinkButton>
                        </EmptyDataTemplate>
                        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                        <SortedAscendingCellStyle BackColor="#F4F4FD" />
                        <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                        <SortedDescendingCellStyle BackColor="#D8D8F0" />
                        <SortedDescendingHeaderStyle BackColor="#3E3277" />
                    </asp:GridView>

                </div>

                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
                </div>


            </div>
        </div>

    </div>


</asp:Content>
