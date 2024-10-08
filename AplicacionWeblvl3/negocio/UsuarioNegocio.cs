﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class UsuarioNegocio
    {

        public bool Loguear(Dom_Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select Id,nombre, apellido, urlImagenPerfil, admin, fecha_nacimiento from users where email = @email and pass = @pass");
                datos.setearParametro("@email", usuario.email);
                datos.setearParametro("@pass", usuario.password);

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    usuario.idUsuario = (int)datos.Lector["Id"];
                    usuario.nombre = datos.Lector["nombre"] != DBNull.Value ? (string)datos.Lector["nombre"] : null;
                    usuario.apellido = datos.Lector["apellido"] != DBNull.Value ? (string)datos.Lector["apellido"] : null;

                    // Manejo de posibles valores DBNull
                    usuario.urlImagenPerfil = datos.Lector["urlImagenPerfil"] == DBNull.Value
                        ? null
                        : (string)datos.Lector["urlImagenPerfil"];

                    usuario.fecha_nacimiento = datos.Lector["fecha_nacimiento"] == DBNull.Value
    ? (DateTime?)null
    : (DateTime)datos.Lector["fecha_nacimiento"];


                    usuario.TipoUsuario = (bool)datos.Lector["admin"] ? TipoUsuario.ADMIN : TipoUsuario.NORMAL;
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al intentar loguear el usuario: " + ex.Message);
            }
        }

        public int AgregarUsuario(Dom_Usuario nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("insert into USERS (email,pass,admin) OUTPUT INSERTED.Id VALUES (@email, @pass, @admin);");

                datos.setearParametro("@email", nuevo.email);
                datos.setearParametro("@pass", nuevo.password);
                datos.setearParametro("@admin", nuevo.TipoUsuario);

                return datos.ejecutarAccionEscalar();







            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void actualizar(Dom_Usuario usuario)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();

                datos.setearConsulta("update users set nombre = @nombre, apellido = @apellido, urlImagenPerfil = @urlImagenPerfil, fecha_nacimiento = @fecha_nacimiento where Id = @Id");

                datos.setearParametro("@nombre", usuario.nombre);
                datos.setearParametro("@apellido", usuario.apellido);
                datos.setearParametro("@urlImagenPerfil", usuario.urlImagenPerfil != null ? usuario.urlImagenPerfil : (object)DBNull.Value);
                datos.setearParametro("fecha_nacimiento", usuario.fecha_nacimiento);
                datos.setearParametro("@Id", usuario.idUsuario);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
