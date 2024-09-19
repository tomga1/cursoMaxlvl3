<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="FormularioArticulos.aspx.cs" Inherits="AplicacionWeblvl3.FormularioArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

      <style>
          .validacion {
              color: red;
              font-size: 16px;
          }
      </style>
    <script>
        function validar() {
            const txtCodigo = document.getElementById('<%= txtCodigo.ClientID %>');
            const txtNombre = document.getElementById('<%= txtNombre.ClientID %>');
            const txtPrecio = document.getElementById('<%= txtPrecio.ClientID %>')
            const txtDescripcion = document.getElementById('<%= txtDescripcion.ClientID %>');


            let valid = true;

            if (txtCodigo.value.trim() === "") {
                txtCodigo.classList.add("is-invalid");
                txtCodigo.classList.remove("is-valid");
                valid = false;
            } else {
                txtCodigo.classList.remove("is-invalid");
                txtCodigo.classList.add("is-valid");
            }
            if (txtNombre.value.trim() === "") {
                txtNombre.classList.add("is-invalid");
                txtNombre.classList.remove("is-valid");
                valid = false;
            } else {
                txtNombre.classList.remove("is-invalid");
                txtNombre.classList.add("is-valid");
            }

            const precioValue = txtPrecio.Value.Trim()
            if (txtPrecio.value.trim() === "") {
                txtPrecio.classList.add("is-invalid");
                txtPrecio.classList.remove("is-valid");
                valid = false;
            } else {
                txtPrecio.classList.remove("is-invalid");
                txtPrecio.classList.add("is-valid");
            }

            if (txtDescripcion.value.trim() === "") {
                txtDescripcion.classList.add("is-invalid");
                txtDescripcion.classList.remove("is-valid");
                valid = false;
            } else {
                txtDescripcion.classList.remove("is-invalid");
                txtDescripcion.classList.add("is-valid");
            }


            return valid; // Solo se enviará el formulario si todo es válido
        }
</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div class="container">
        <div class="row">
            <!-- Columna izquierda -->
            <div class="col-md-6">
                <div class="mb-3">
                    <label for="txtCodigo" class="form-label">Código</label>
                    <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control" />
<%--                    <asp:RequiredFieldValidator ErrorMessage="Codigo es requerido" CssClass="validacion" ControlToValidate="txtCodigo" runat="server" />--%>
                </div>
                <div class="mb-3">
                    <label for="txtNombre" class="form-label">Nombre</label>
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
<%--                    <asp:RequiredFieldValidator ErrorMessage="Nombre es requerido"  CssClass="validacion" ControlToValidate="txtNombre" runat="server" />--%>
                </div>
                <div class="mb-3">
                    <label for="txtPrecio" class="form-label">Precio</label>
                    <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control" />
<%--                    <asp:RegularExpressionValidator ErrorMessage="Solo numeros" ControlToValidate="txtPrecio" CssClass="validacion" ValidationExpression="^[0-9]+$" runat="server" />--%>
                </div>
                <div class="mb-3">
                    <label for="ddlMarcas" class="form-label">Marca</label>
                    <asp:DropDownList ID="ddlMarcas" CssClass="form-select" runat="server"></asp:DropDownList>
                </div>
                <div class="mb-3">
                    <label for="ddlCategorias" class="form-label">Categoría</label>
                    <asp:DropDownList ID="ddlCategorias" CssClass="form-select" runat="server"></asp:DropDownList>
                </div>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <div class="mb-3">
                            <asp:Button Text="Aceptar" ID="btnAceptar" CssClass="btn btn-success" OnClientClick="return validar()" OnClick="btnAceptar_Click" runat="server" />
                            <asp:Button Text="Eliminar" ID="btnEliminar" CssClass="btn btn-danger" OnClick="btnEliminar_Click" runat="server" />
                            <asp:Button Text="Inactivar" ID="btnInactivar" OnClick="btnInactivar_Click" CssClass="btn btn-secondary" runat="server" />
                        </div>
                        <% if (ConfirmaEliminacion)
                            { %>
                        <div class="mb-3">
                            <asp:CheckBox Text="Confirmar Eliminación" ID="chkConfirmaEliminacion" runat="server" />
                            <asp:Button Text="Eliminar" ID="ConfirmaEliminar" OnClientClick="return validar()" OnClick="ConfirmaEliminar_Click" CssClass="btn btn-outline-danger" runat="server" />
                        </div>
                        <% } %>

                            
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>

            <!-- Columna derecha -->
            <div class="col-md-6">
                <div class="row">
                    <div class="col-12 mb-3">
                        <label for="txtDescripcion" class="form-label">Descripción</label>
                        <asp:TextBox ID="txtDescripcion" TextMode="MultiLine" runat="server" CssClass="form-control" />
                    </div>
                    <div class="col-12 mb-3">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <div class="mb-3">
                                    <label for="txtImg" class="form-label">URL Imagen</label>
                                    <asp:TextBox ID="txtImg" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtImg_TextChanged" />
                                </div>
                                <asp:Image ImageUrl="https://www.smarttools.com.mx/wp-content/uploads/2019/05/imagen-no-disponible.png" runat="server" ID="imgArticulo" Width="60%" Style="margin-left: 0;" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
