﻿using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;


namespace AplicacionWeblvl3
{
    public partial class Registrar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx", false);
        }


        protected void btnAceptar_Click1(object sender, EventArgs e)
        {
            try
            {
                UsuarioNegocio negocio = new UsuarioNegocio();


                Dom_Usuario usuario = new Dom_Usuario(
                    txtEmail.Text,
                    txtPassword.Text,
                    false);

               
                int id = negocio.AgregarUsuario(usuario);
                Session.Add("Login.aspx", usuario);

                Response.Redirect("MiPerfil.aspx", false); 

            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
            }
        }
    }
}