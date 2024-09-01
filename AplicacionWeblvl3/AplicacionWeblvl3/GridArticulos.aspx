<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="GridArticulos.aspx.cs" Inherits="AplicacionWeblvl3.Pagina1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" ID="scriptmanager1" />
    <h2>Listado de Articulos</h2>

    <asp:UpdatePanel runat="server" ID="updatepanel1">
        <ContentTemplate>




            <div class="row">
                <div class="col-6">
                    <div class="mb-3">
                        <asp:Label Text="Filtro" runat="server" />
                        <asp:TextBox runat="server" ID="txtFiltroRapido" OnTextChanged="txtFiltroRapido_TextChanged" CssClass="form-control" AutoPostBack="true" />
                    </div>
                </div>
                <div class="col-6" style="display:flex; flex-direction: column; justify-content:  flex-end;">
                    <div class="mb-3">
                        <asp:CheckBox Text="Filtro Avanzado" CssClass="" ID="chkAvanzado" AutoPostBack="true" OnCheckedChanged="chkAvanzado_CheckedChanged" runat="server" />
                    </div>
                </div>
            </div>


            <%if (FiltroAvanzado)
                { %>

            <div class="row">   

                <div class="col-3">
                    <div class="mb-3">
                        <asp:Label Text="Campo" ID="lblCampo" runat="server" />
                        <asp:DropDownList runat="server" CssClass="form-control" AutoPostBack="true" ID="ddlCampo" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged">
                            <asp:ListItem Text="Codigo" />
                            <asp:ListItem Text="Nombre" />
                            <asp:ListItem Text="Marca" />
                            <asp:ListItem Text="Categoria" />

                        </asp:DropDownList>
                    </div>
                </div>

                <div class="col-3">
                    <div class="mb-3">
                        <asp:Label Text="Criterio" runat="server" />
                        <asp:DropDownList runat="server" ID="ddlCriterio" CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="col-3">
                    <div class="mb-3">
                        <asp:Label Text="Fitlro" runat="server" />
                        <asp:TextBox runat="server" ID="txtFiltroAvanzado" CssClass="form-control" />
                    </div>
                </div>

                <div class="col-3">
                    <div class="mb-3">
                        <asp:Label Text="Estado" runat="server" />
                        <asp:DropDownList runat="server" ID="ddlEstado" CssClass="form-control">
                            <asp:ListItem Text="Todos" />
                            <asp:ListItem Text="Activo" />
                            <asp:ListItem Text="Inactivo" />
                        </asp:DropDownList>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-3">
                    <div class="mb-3">
                        <asp:Button Text="Buscar" ID="btnBuscar" CssClass="btn btn-primary" OnClick="btnBuscar_Click" runat="server" />
                    </div>
                </div>

            </div>
            <%
                } %>


            <div class="row">
            </div>

            <div class="row">
                <div class="col">
                    <asp:GridView runat="server" ID="dgvArticulos" DataKeyNames="idProducto" CssClass="table" AutoGenerateColumns="false"
                        OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged"
                        OnPageIndexChanging="dgvArticulos_PageIndexChanging" AllowPaging="true" PageSize="10">
                        <Columns>
                            <asp:BoundField HeaderText="Codigo" DataField="codigo" />
                            <asp:BoundField HeaderText="Nombre" DataField="nombre" />
                            <asp:BoundField HeaderText="Descripcion" DataField="descripcion" />
                            <asp:BoundField HeaderText="Marca" DataField="marca" />
                            <asp:BoundField HeaderText="Categoria" DataField="categoria" />
                            <asp:BoundField HeaderText="Precio" DataField="precio_compra" />
                            <asp:CheckBoxField HeaderText="Activo" DataField="Activo" />
                            <asp:CommandField HeaderText="Acción" ShowSelectButton="true" SelectText="✍" />

                        </Columns>

                    </asp:GridView>
                    <div>
                        <asp:Button ID="btnAgregar" Text="Agregar" runat="server" class="btn btn-primary" OnClick="btnAgregar_Click" />
                    </div>
                </div>
            </div>



        </ContentTemplate>
    </asp:UpdatePanel>



</asp:Content>
