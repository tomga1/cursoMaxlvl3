<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Registrar.aspx.cs" Inherits="AplicacionWeblvl3.Registrar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
    .btn-margin {
        margin-top: 40px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Registre su usuario </h1>
    <br />  

    <div class="row">
        <div class="col-2"></div>
        <div class="col">
            <div class="mb-3">
                <label for="txtEmail" class="form-label">Email address</label>
                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtPassword" class="form-label">Password</label>
                <asp:TextBox runat="server" ID="txtPassword" CssClass="form-control" type="password" />
            </div>

            <div class="d-grid gap-2 col-6 mx-auto mb-4">

                <asp:Button Text="Registrar" CssClass="btn btn-outline-success btn-margin" ID="btnAceptar" OnClick="btnAceptar_Click" runat="server" />
                <asp:Button Text="Cancelar" CssClass="btn btn-outline-danger btn-margin2" ID="btnCancelar" OnClick="btnCancelar_Click"     runat="server" />

            </div>
        </div>
        <div class="col-2"></div>
    </div>


</asp:Content>
