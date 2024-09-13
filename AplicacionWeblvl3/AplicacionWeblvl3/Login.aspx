<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AplicacionWeblvl3.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .btn-margin {
            margin-top: 40px;
        }

        .validacion {
            color: red;
            font-size: 16px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Login ! </h1>
    <br />
    <div class="row">
        <div class="col-2"></div>
        <div class="col">
            <div class="mb-3">
                <label for="txtEmail" class="form-label">Email address</label>
                <asp:TextBox runat="server" REQUIRED ID="txtEmail" CssClass="form-control" />
                <%--                    <asp:RegularExpressionValidator ErrorMessage="Solo numeros" ControlToValidate="txtPrecio" CssClass="validacion" ValidationExpression="^[0-9]+$" runat="server" />--%>
              <%--  <asp:RegularExpressionValidator ErrorMessage="Debe ingresar un mail" CssClass="validacion" ControlToValidate="txtEmail" ValidationExpression="^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$
"
                    runat="server" />--%>
            </div>
            <div class="mb-3">
                <label for="txtPassword" class="form-label">Password</label>
                <asp:TextBox runat="server" ID="txtPassword" CssClass="form-control" type="password" />
            </div>

            <div class="d-grid gap-2 col-6 mx-auto mb-4">

                <asp:Button Text="Ingresar" CssClass="btn btn-outline-success btn-margin" ID="btnAceptar" OnClick="btnAceptar_Click" runat="server" />
                <asp:Button Text="Registrar" CssClass="btn btn-outline-info btn-margin2" ID="btnRegistrar" OnClick="btnRegistrar_Click" runat="server" />
            </div>
            <div class="d-grid gap-2 col-6 mx-auto mb-4">

                <asp:Button Text="Olvide mi contraseña" CssClass="btn btn-outline-dark btn-olvide" ID="btnOlvido" OnClick="btnOlvido_Click" runat="server" />
            </div>
        </div>
        <div class="col-2"></div>
    </div>


</asp:Content>
