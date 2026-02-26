<%@ Page Title="" Language="C#" MasterPageFile="~/Plantilla.Master" AutoEventWireup="true" CodeBehind="frmhabilitartipoplato.aspx.cs" Inherits="pe.com.muertelenta.ui.tipoplato.frmhabilitartipoplato" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--cuando trabajas con paginas maestras se diseña en esta etiqueta--%>
    <h1>Habilitacion de Tipo de Plato</h1>
    <asp:Button ID="btnHabilitar" runat="server" Text="Habilitar" CssClass="btn btn-warning" OnClick="btnHabilitar_Click" />
    <asp:Button ID="btnDeshabilitar" runat="server" Text="Deshabilitar" CssClass="btn btn-danger" OnClick="btnDeshabilitar_Click" />
    <asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="btn btn-dark" OnClick="btnRegresar_Click" />
    <asp:Label ID="lblCodTipp" runat="server" Text="Label" Visible="false"></asp:Label>
    <div class="mb-3"></div>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <%--iniciando la tabla--%>
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
