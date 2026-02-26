<%@ Page Title="" Language="C#" MasterPageFile="~/Plantilla.Master" AutoEventWireup="true" CodeBehind="frmtipoplato.aspx.cs" Inherits="pe.com.muertelenta.ui.tipoplato.frmtipoplato" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--cuando trabajas con paginas maestras se diseña en esta etiqueta--%>
    <h1>Mantenimiento Tipo Plato</h1>
    <form id="frmTipoPlato" runat="server">
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

        <div class="mb-3"></div>
        <%--iniciando la tabla--%>
        <div class="table-responsive">
            <asp:GridView ID="gvTipoPlato" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-hover table-bordered" OnRowCommand="gvTipoPlato_RowCommand">
                <%--agregamos las columnas--%>
                <%--por cada columna de la tabla agregamos un Bounfield--%>
                <Columns>
                    <%--DataField: es el valor que va agregar y viene del BO--%>
                    <%--HeaderText: es el valor que va a mostrar en la cabecera de la tabla--%>
                    <asp:BoundField DataField="codigo" HeaderText="Codigo" HeaderStyle-CssClass="table-dark" />
                    <asp:BoundField DataField="nombre" HeaderText="Nombre" HeaderStyle-CssClass="table-dark" />
                    <%--estado trabaja con TemplateField por que viene true o false y lo convertimos a texto--%>
                    <asp:TemplateField HeaderText="Estado" HeaderStyle-CssClass="table-dark">
                        <ItemTemplate>
                            <%# Convert.ToBoolean(Eval("estado")) ? "Habilitado":"Deshabilitado" %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--agregamos un boton para la seleccion--%>
                    <asp:ButtonField Text="Seleccionar" CommandName="Seleccionar" HeaderStyle-CssClass="table-dark"/>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</asp:Content>
