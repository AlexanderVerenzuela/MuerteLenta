<%@ Page Title="" Language="C#" MasterPageFile="~/Plantilla.Master" AutoEventWireup="true" CodeBehind="frmtipoplato.aspx.cs" Inherits="pe.com.muertelenta.ui.tipoplato.frmtipoplato" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--cuando trabajas con paginas maestras se diseña en esta etiqueta--%>
    <h1>Mantenimiento Tipo Plato</h1>
    <!-- Panel para controles -->
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="col-5">
                <asp:Label ID="Label1" runat="server" Text="Codigo:" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txtCod" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-5">
                <asp:Label ID="Label2" runat="server" Text="Nombre:" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txtNom" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-5">
                <asp:Label ID="Label3" runat="server" Text="Estado:" CssClass="form-label"></asp:Label>
                <div class="mb-3 form-check">
                    <asp:CheckBox ID="chkEst" runat="server" CssClass="form-check-input" />
                    <asp:Label ID="Label4" runat="server" Text="Habilitado" CssClass="form-check-label"></asp:Label>
                </div>
            </div>
            <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" CssClass="btn btn-dark" OnClick="btnNuevo_Click" />
            <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" CssClass="btn btn-primary" OnClick="btnRegistrar_Click" />
            <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" CssClass="btn btn-success" OnClick="btnActualizar_Click" />
            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger" OnClick="btnEliminar_Click" />
            <asp:Button ID="btnHabilitar" runat="server" Text="Habilitar" CssClass="btn btn-warning" OnClick="btnHabilitar_Click" />
        </ContentTemplate>
    </asp:UpdatePanel>

    <div class="mb-3"></div>

    <!-- Panel para GridView y paginación -->
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <div class="table-responsive">
                <asp:GridView ID="gvTipoPlato" runat="server"
                    AutoGenerateColumns="false"
                    CssClass="table table-striped table-hover table-bordered"
                    OnRowCommand="gvTipoPlato_RowCommand"
                    AllowPaging="true" PageSize="5"
                    OnPageIndexChanging="gvTipoPlato_PageIndexChanging"
                    PagerSettings-Visible="false">
                    <Columns>
                        <asp:BoundField DataField="codigo" HeaderText="Codigo" HeaderStyle-CssClass="table-dark" />
                        <asp:BoundField DataField="nombre" HeaderText="Nombre" HeaderStyle-CssClass="table-dark" />
                        <asp:TemplateField HeaderText="Estado" HeaderStyle-CssClass="table-dark">
                            <ItemTemplate>
                                <%# Convert.ToBoolean(Eval("estado")) ? "Habilitado":"Deshabilitado" %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:ButtonField Text="Seleccionar" CommandName="Seleccionar" HeaderStyle-CssClass="table-dark" />
                    </Columns>
                </asp:GridView>

                <!-- Paginación personalizada -->
                <div class="pagination-container">
                    <div class="d-flex justify-content-center mt-3">
                        <asp:Button ID="btnPrevious" runat="server" Text="Anterior" CssClass="btn btn-outline-secondary mx-1" OnClick="btnPrevious_Click" />

                        <asp:Repeater ID="rptPager" runat="server" OnItemCommand="rptPager_ItemCommand">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkPage" runat="server" CommandName="Page" CommandArgument="<%# Container.DataItem %>"
                                    CssClass='<%# Convert.ToInt32(Container.DataItem.ToString()) == gvTipoPlato.PageIndex + 1 ? "btn btn-outline-primary active mx-1" : "btn btn-outline-primary mx-1" %>'>
                                    <%# Container.DataItem %>
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:Repeater>

                        <asp:Button ID="btnNext" runat="server" Text="Siguiente" CssClass="btn btn-outline-secondary mx-1" OnClick="btnNext_Click" />
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
