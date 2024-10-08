﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="AplicacionWeblvl3.MiPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        .validacion {
            color: red;
            font-size: 16px;
        }
    </style>

    <script>
        function validar() {
            const txtNombre = document.getElementById('txtNombre');
            const txtApellido = document.getElementById('txtApellido');
            const txtEmail = document.getElementById('txtEmail');

            let valid = true;

            // Validar nombre
            if (txtNombre.value.trim() === "") {
                txtNombre.classList.add("is-invalid");
                txtNombre.classList.remove("is-valid");
                valid = false;
            } else {
                txtNombre.classList.remove("is-invalid");
                txtNombre.classList.add("is-valid");
            }

            // Validar apellido
            if (txtApellido.value.trim() === "") {
                txtApellido.classList.add("is-invalid");
                txtApellido.classList.remove("is-valid");
                valid = false;
            } else {
                txtApellido.classList.remove("is-invalid");
                txtApellido.classList.add("is-valid");
            }

            // Validar email
            const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
            if (!emailRegex.test(txtEmail.value.trim())) {
                txtEmail.classList.add("is-invalid");
                txtEmail.classList.remove("is-valid");
                valid = false;
            } else {
                txtEmail.classList.remove("is-invalid");
                txtEmail.classList.add("is-valid");
            }

            return valid; // Solo se enviará el formulario si todo es válido
        }
    </script>






</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Mi perfil</h1>

    <div class="container mt-5">
        <div class="row">
            <div class="col-md-6">
                <div class="mb-3">
                    <label for="txtNombre" class="form-label">Nombre</label>
                    <asp:TextBox ID="txtNombre" ClientIDMode="Static" runat="server" CssClass="form-control" />
<%--                    <asp:RequiredFieldValidator ErrorMessage="El nombre es requerido" CssClass="validacion" ControlToValidate="txtNombre" runat="server" />--%>
                </div>
                <div class="mb-3">
                    <label for="txtApellido" class="form-label">Apellido</label>
                    <asp:TextBox ID="txtApellido" runat="server" ClientIDMode="Static" CssClass="form-control" />
                    <asp:RequiredFieldValidator ErrorMessage="El apellido es requerido" CssClass="validacion" ControlToValidate="txtApellido" runat="server" />
                </div>
                <div class="mb-3">
                    <label for="txtEmail" class="form-label">Email</label>
                    <asp:TextBox ID="txtEmail" runat="server" ClientIDMode="Static" CssClass="form-control" />
                </div>
                <div class="mb-3">
                    <label for="txtFecha" class="form-label">Fecha de nacimiento</label>
                    <asp:TextBox ID="txtFecha" runat="server" CssClass="form-control" TextMode="Date" />
                </div>fsfas
                <div class="mb-3">
                    <asp:Button Text="Guardar" ID="btnGuardar" CssClass="btn btn-success" OnClientClick="return validar()" OnClick="btnGuardar_Click1" runat="server" />
                </div>

            </div>

            <div class="col-md-4">
                <div class="mb-3">
                    <label class="form-label">Imagen Perfil</label>
                    <input type="file" id="txtImagen" runat="server" class="form-control" />
                </div>
                <asp:Image ID="imgNuevoPerfil" ImageUrl="https://media.istockphoto.com/id/1128826884/es/vector/ning%C3%BAn-s%C3%ADmbolo-de-vector-de-imagen-falta-icono-disponible-no-hay-galer%C3%ADa-para-este-momento.jpg?s=612x612&w=0&k=20&c=9vnjI4XI3XQC0VHfuDePO7vNJE7WDM8uzQmZJ1SnQgk=" runat="server" CssClass="img-fluid mb-3" />
            </div>
        </div>

    </div>


</asp:Content>
