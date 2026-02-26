<%@ Page Title="" Language="C#" MasterPageFile="~/Plantilla.Master" AutoEventWireup="true" CodeBehind="frmhabilitarplato.aspx.cs" Inherits="pe.com.muertelenta.ui.plato.frmhabilitarplato" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <h1>Habilitacion de Platos</h1>
    <form id="Plato" runat="server">

        <asp:Button ID="btnHabilitar" runat="server" Text="Habilitar" CssClass="btn btn-warning" OnClick="btnHabilitar_Click"/>
        <asp:Button ID="btnDeshabilitar" runat="server" Text="Deshabilitar" CssClass="btn btn-danger" OnClick="btnDeshabilitar_Click"/>
        <asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="btn btn-dark" OnClick="btnRegresar_Click"/>
        <asp:Label ID="lblCodPlat" runat="server" Text="Label" Visible="False"></asp:Label>
        <div class="mb-3"></div>

        <%# Convert.ToBoolean(Eval("estado")) ? "Habilitado":"Deshabilitado" %>
        <div class="table-responsive">
            <asp:GridView ID="gvPlato" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-hover table-bordered" OnRowCommand="gvPlato_RowCommand">
                <Columns>
                    <asp:BoundField DataField="codigo" HeaderText="Codigo" HeaderStyle-CssClass="table-dark" />
                    <asp:BoundField DataField="nombre" HeaderText="Nombre" HeaderStyle-CssClass="table-dark" />
                    <asp:BoundField DataField="descripcion" HeaderText="Descripcion" HeaderStyle-CssClass="table-dark" />
                    <asp:BoundField DataField="precio" HeaderText="Precio" HeaderStyle-CssClass="table-dark" />
                    <asp:BoundField DataField="cantidad" HeaderText="Cantidad" HeaderStyle-CssClass="table-dark" />
                    <asp:BoundField DataField="fechaingreso" HeaderText="Fec. Ingreso" HeaderStyle-CssClass="table-dark" />
                    <asp:BoundField DataField="fechacaducidad" HeaderText="Fec. Caducidad" HeaderStyle-CssClass="table-dark" />
                    <asp:BoundField DataField="tipoplato.nombre" HeaderText="Tipo de Plato" HeaderStyle-CssClass="table-dark" />
                    <asp:BoundField DataField="refrigerableplato.nombre" HeaderText="Refrigerable Plato" HeaderStyle-CssClass="table-dark" />
                    <%--estado trabaja con TemplateField por que viene true o false y lo convertimos a texto--%>
                    <asp:TemplateField HeaderText="Estado" HeaderStyle-CssClass="table-dark">
                        <ItemTemplate>
                            <%# Convert.ToBoolean(Eval("estado")) ? "Habilitado":"Deshabilitado" %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--agregamos un boton para la seleccion--%>
                    <asp:ButtonField Text="Seleccionar" CommandName="Seleccionar" HeaderStyle-CssClass="table-dark" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</asp:Content>
