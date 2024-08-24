<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="FormularioArticulos.aspx.cs" Inherits="AplicacionWeblvl3.FormularioArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div class="row">
        <div class="col-6">

            <div class="mb-3">
                <label for="txtCodigo" class="form-label">Código</label>
                <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
            </div>

            <div class="mb-3">
                <label for="txtPrecio" class="form-label">Precio</label>
                <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control" />
            </div>


            <div class="mb-3">
                <label for="ddlMarcas" class="form-label">Marca</label>
                <asp:DropDownList ID="ddlMarcas" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>

            <div class="mb-3">
                <label for="ddlCategorias" class="form-label">Categoria</label>
                <asp:DropDownList ID="ddlCategorias" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>

            <div class="mb-3">
                <asp:Button Text="Aceptar" ID="btnAceptar" CssClass="btn btn-success" OnClick="btnAceptar_Click" runat="server" />
                <a href="GridArticulos.aspx">Cancelar</a>
            </div>
        </div>


        <div class="col-6">
            <div class="mb-3">
                <label for="txtDescripcion" class="form-label">Descripción</label>
                <asp:TextBox ID="txtDescripcion" TextMode="MultiLine" runat="server" CssClass="form-control" />
            </div>


            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>

                    <div class="mb-3">
                        <label for="txtImg" class="form-label">URL Imagen</label>
                        <asp:TextBox ID="txtImg" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtImg_TextChanged" />
                    </div>
                    <asp:Image ImageUrl="https://www.smarttools.com.mx/wp-content/uploads/2019/05/imagen-no-disponible.png" runat="server" ID="imgArticulo" Width="60%" Style="margin-left: 180px;" />


                </ContentTemplate>
            </asp:UpdatePanel>





        </div>
</asp:Content>
