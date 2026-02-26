<%@ Page Title="" Language="C#" MasterPageFile="~/Plantilla.Master" AutoEventWireup="true" CodeBehind="frmregistrarpedido.aspx.cs" Inherits="pe.com.muertelenta.ui.pedido.frmregistrarpedido" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        //funcion para agregar filas
        function agregarFila() {
            var table = document.getElementById("tbDetalleCompra");
            var filanueva = table.insertRow(table.rows.length);
            var rowIndex = table.rows.length - 2;
            filanueva.innerHTML = "<tr>" +
                "<td>" +
                "<select class='form-select' name='productos[" + rowIndex + "]'" +
                "onchange='actualizaPrecio(this)' requiered>" +
                "<option value='0'>Seleccione un producto</option>" +
                "<c:forEach items='${productos}' var='producto'>" +
                "<option value='${producto.getCodigo()}' data-precio='${producto.getPrecio()}'>" +
                "${producto.getNombre()}</option>" +
                "</c:forEach>" +
                "</select>" +
                "</td>" +
                "<td>" +
                "<input type='text' class='form-control' id='precio_" + rowIndex + "' name='precio[" + rowIndex + "]' readonly/>" +
                "</td>" +
                "<td>" +
                "<input type='number' step='0.01' class='form-control' name='cantidad[" + rowIndex + "]' required/>" +
                "</td>" +
                "<td>" +
                "<button type='button' onclick='eliminarFila(this)'>Eliminar</button>" +
                "</td>" +
                "</tr>";
        }

        //funcion para eliminar fila del detalle
        function eliminarFila(button) {
            var tbody = document.querySelector("#tbDetalleCompra tbody");
            var rowCount = tbody.querySelectorAll("tr").length;
            if (rowCount > 1) {
                var row = button.parentNode.parentNode;
                row.parentNode.removeChild(row);
            } else {
                alert("Debe de existir al menos un producto");
            }
        }

        //funcion para actualizar el precio
        function actualizaPrecio(selectElement) {
            var precio = selectElement.options[selectElement.selectedIndex].getAttribute("data-precio");
            var row = selectElement.closest('tr');
            var inputPrecio = row.querySelector('input[name^="precio"]');
            inputPrecio.value = precio ? precio : 0;
        }
        //funcion para mostrar la fecha y la hor actual        
        function actualizarFecha() {
            var fecha = new Date();
            var dia = String(fecha.getDate()).padStart(2, '0');
            var mes = String(fecha.getMonth() + 1).padStart(2, '0');
            var anio = fecha.getFullYear();
            var hora = String(fecha.getHours()).padStart(2, '0');
            var minutos = String(fecha.getMinutes()).padStart(2, '0');
            var segundos = String(fecha.getSeconds()).padStart(2, '0');
            var fechahora = dia + '/' + mes + '/' + anio + ' ' + hora + ':' + minutos + ':' + segundos;
            document.getElementById("txtFec").value = fechahora;
        }
        setInterval(actualizarFecha, 1000);
        window.onload = actualizarFecha;
    </script>
    <div class="container">
        <!-- inicio barra menu -->
        <!-- fin barra menu -->
        <div clss="mb-3"></div>
        <!-- inicio del card -->
        <div class="card">
            <div class="card-header">
                <h1>Registro de Compras</h1>
            </div>
            <div class="card-body">
                <!-- inicio formulario -->
                <div class="col-6">
                    <asp:Label ID="Label1" runat="server" Text="Codigo:" CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txtCod" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-6">
                    <asp:Label ID="Label2" runat="server" Text="Fecha:" CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txtFec" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-6">
                    <asp:Label ID="Label3" runat="server" Text="Empleado:" CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txtEmp" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:TextBox ID="txtCodEmp" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-6">
                    <asp:Label ID="Label4" runat="server" Text="Cliente:" CssClass="form-label"></asp:Label>
                    <asp:DropDownList ID="cboCliente" runat="server" CssClass="form-select"></asp:DropDownList>
                </div>
                <div class="col-6">
                    <asp:Label ID="Label5" runat="server" Text="Estado:" CssClass="form-label"></asp:Label>
                    <div class="mb-3 form-check">
                        <asp:CheckBox ID="chkEst" runat="server" CssClass="form-check-input" />
                        <asp:Label ID="Label6" runat="server" Text="Estado" CssClass="form-check-label"></asp:Label>
                    </div>
                </div>

                <h3>Detalle de Compra</h3>
                <button type="button" onclick="agregarFila()" class="btn btn-dark">Agregar Detalle</button>
                <div class="mb-3"></div>
                <div class="table-responsive">
                    <table id="tbDetalleCompra" class="table table-striped table-hover table-bordered">
                        <thead class="table-dark">
                            <tr>
                                <th>Codigo</th>
                                <th>Producto</th>
                                <th>Precio</th>
                                <th>Cantidad</th>
                                <th>Eliminar</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>
                                    <input type="text" class="form-control" id="precio_0" name="precio[0]" readonly />
                                </td>
                                <td>
                                    <select class="form-select" name="productos[0]" onchange="actualizaPrecio(this)" requiered>
                                        <option value="0">Seleccione un producto</option>
                                    </select>
                                </td>
                                <td>
                                    <input type="text" class="form-control" id="txtCodPre" name="precio[0]" readonly />
                                </td>
                                <td>
                                    <input type="number" step="0.01" class="form-control" name="cantidad[0]" required="" />
                                </td>
                                <td>
                                    <button type="button" onclick="eliminarFila(this)" class="btn btn-danger">Eliminar</button>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" CssClass="btn btn-primary" />
                <asp:Button ID="btnRegresar" runat="server" Text="Regresas" CssClass="btn btn-dark" />
                <!-- fin del formulario -->
            </div>
        </div>
        <!-- fin del card -->


    </div>
</asp:Content>

