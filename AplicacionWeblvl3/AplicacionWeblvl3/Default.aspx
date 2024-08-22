<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AplicacionWeblvl3.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <br />

    <div class="container">
        <div class="row">
            <asp:Repeater runat="server" ID="repRepetidor">
                <ItemTemplate>
                    <div class="card" style="width: 18rem; margin: 10px;">
                        <img src="<%# Eval("UrlImagen")%>" class="card-img-top" alt="..." style="height: 200px; width: 100%; object-fit: contain;">
                        <div class="card-body">
                            <h5 class="card-title"><%# Eval("nombre")%></h5>
                            <p class="card-text"><%# Eval("descripcion")%></p>
                        </div>
                        <ul class="list-group list-group-flush">
                            <li class="list-group-item">$<%# Convert.ToDecimal(Eval("precio_compra")).ToString("N2", System.Globalization.CultureInfo.CreateSpecificCulture("es-AR")) %> </li>           
                            <li class="list-group-item"><%# ((dominio.Dom_Marca)Eval("marca")).descripcion%></li>
                            <li class="list-group-item"><%# ((dominio.Dom_Categoria)Eval("categoria")).descripcion%></li>
                        </ul>
                        <div class="card-body">
                            <a href="#" class="card-link">Agregar</a>
                            <a href="#" class="card-link">Más detalles</a>
                        </div>
                    </div>

                </ItemTemplate>
            </asp:Repeater>

        </div>
    </div>


</asp:Content>
