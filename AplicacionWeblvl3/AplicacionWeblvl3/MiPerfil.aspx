<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="AplicacionWeblvl3.MiPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Mi perfil</h1>

    <div class="container mt-5">
        <div class="row">
            <div class="col-md-6">
                <div class="mb-3">
                    <label for="txtCodigo" class="form-label">Nombre</label>
                    <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control" />
                </div>
                <div class="mb-3">
                    <label for="txtNombre" class="form-label">Apellido</label>
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
                </div>
                <div class="mb-3">
                    <asp:Button Text="Aceptar" ID="btnAceptar" CssClass="btn btn-success" OnClick="btnAceptar_Click" runat="server" />
                </div>

            </div>

        </div>

    </div>


</asp:Content>
