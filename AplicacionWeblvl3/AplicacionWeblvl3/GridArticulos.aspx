<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="GridArticulos.aspx.cs" Inherits="AplicacionWeblvl3.Pagina1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Listado de Articulos</h2>

    <div>

        <asp:GridView runat="server" ID="dgvArticulos" DataKeyNames="idProducto" CssClass="table" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField HeaderText="Codigo" DataField="codigo" />
                <asp:BoundField HeaderText="Nombre" DataField="nombre" />
                <asp:BoundField HeaderText="Descripcion" DataField="descripcion" />
                <asp:BoundField HeaderText="Marca" DataField="marca" />
                <asp:BoundField HeaderText="Categoria" DataField="categoria" />
                <asp:BoundField HeaderText="Precio" DataField="precio_compra" />
            </Columns>




        </asp:GridView>

    </div>

</asp:Content>
