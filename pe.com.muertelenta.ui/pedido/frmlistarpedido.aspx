
<%@ Page Title="" Language="C#" MasterPageFile="~/Plantilla.Master" AutoEventWireup="true" CodeBehind="frmlistarpedido.aspx.cs" Inherits="pe.com.muertelenta.ui.pedido.frmlistarpedido" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Listado de Ordenes de Pedido</h1>
    <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" CssClass="btn btn-primary" OnClick="btnRegistrar_Click" />
    <asp:Button ID="btnHabilitar" runat="server" Text="Habilitar" CssClass="btn btn-warning" OnClick="btnHabilitar_Click" />
    <asp:Button ID="btnAnular" runat="server" Text="Anular" CssClass="btn btn-danger" OnClick="btnAnular_Click" />
    <asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="btn btn-dark" OnClick="btnRegresar_Click" />
    <asp:Label ID="lblCodPlat" runat="server" Text="Label" Visible="False"></asp:Label>
    <div class="mb-3"></div>

    <%# Convert.ToBoolean(Eval("estado")) ? "Habilitado":"Deshabilitado" %>
    <div class="table-responsive">
        <asp:GridView ID="gvOrdenPedido" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-hover table-bordered" OnRowCommand="gvOrdenPedido_RowCommand">
            <Columns>
                <asp:BoundField DataField="codigo" HeaderText="Codigo" HeaderStyle-CssClass="table-dark" />
                <asp:BoundField DataField="fecha" HeaderText="Fecha" HeaderStyle-CssClass="table-dark" />
                <asp:TemplateField HeaderText="Empleado" HeaderStyle-CssClass="table-dark">
                    <ItemTemplate>
                        <%# Eval("empleado.nombre")+" "+Eval("empleado.apellidopaterno")+" "+Eval("empleado.apellidomaterno")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Cliente" HeaderStyle-CssClass="table-dark">
                    <ItemTemplate>
                        <%# Eval("cliente.nombre")+" "+Eval("cliente.apellidopaterno")+" "+Eval("cliente.apellidomaterno")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="total" HeaderText="Total" HeaderStyle-CssClass="table-dark" />
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
</asp:Content>
