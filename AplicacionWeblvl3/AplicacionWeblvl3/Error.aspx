﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="AplicacionWeblvl3.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1> Error de autenticación </h1>
    <asp:Label Text="" ID="lblMensaje" runat="server" />
    <a href="Login.aspx">Login</a>
</asp:Content>
