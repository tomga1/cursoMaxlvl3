<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Nosotros.aspx.cs" Inherits="AplicacionWeblvl3.Nosotros" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="container mt-5">
        <h1>¿Quienes somos?</h1>
        <p>Somos un equipo apasionado de profesionales comprometidos con la excelencia y la innovación. Fundada en 2024, nuestra misión es proporcionar soluciones de alta calidad que superen las expectativas de nuestros clientes.</p>
        <h2> Nuestra Vision</h2>
        <p>Aspiramos a ser el líder en e-commerce de tecnología, reconocido por nuestra amplia selección de productos, precios competitivos y un servicio al cliente insuperable.</p>
    </div>

    <div id="carouselExampleAutoplaying" class="carousel slide" data-bs-ride="carousel">
  <div class="carousel-inner">
    <div class="carousel-item active">
      <img src="https://www.eude.es/wp-content/uploads/2021/09/Dise%C3%B1o-sin-t%C3%ADtulo-66.png" class="d-block w-100" alt="...">
    </div>
    <div class="carousel-item">
      <img src="https://miro.medium.com/v2/resize:fit:992/1*bFd8ijOumsmhoGZv-w5PeA.jpeg" class="d-block w-100" alt="...">
    </div>
    <div class="carousel-item">
      <img src="https://www.kyoceradocumentsolutions.es/renditions/content/dam/kyocera/es/images/hero/hero-1536x960-Comunicaci%C3%B3n,%20empresa%20y%20tecnolog%C3%ADa.jpg/jcr%3Acontent/renditions/cq5dam.resized.img.1536.large.time1579090362737.jpg" class="d-block w-100" alt="...">
    </div>
  </div>
  <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleAutoplaying" data-bs-slide="prev">
    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
    <span class="visually-hidden">Previous</span>
  </button>
  <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleAutoplaying" data-bs-slide="next">
    <span class="carousel-control-next-icon" aria-hidden="true"></span>
    <span class="visually-hidden">Next</span>
  </button>
</div>
</asp:Content>
