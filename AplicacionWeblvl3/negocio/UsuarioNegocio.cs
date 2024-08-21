using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class UsuarioNegocio
    {
        public List<Usuario> listar()
        {
            List<Usuario> lista = new List<Usuario>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select u.id_usuario, u.documento, u.nombre_completo, u.correo, u.clave, r.id_rol, u.estado, r.id_rol, r.descripcion from usuario u inner join rol r on r.id_rol = u.id_rol");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Usuario aux = new Usuario();
                    aux.oRol = new Rol();

                    aux.idUsuario = (int)datos.Lector["id_usuario"];
                    aux.documento = (string)datos.Lector["documento"];
                    aux.nombreCompleto = (string)datos.Lector["nombre_completo"];
                    aux.correo = (string)datos.Lector["correo"];
                    aux.clave = (string)datos.Lector["clave"];
                    aux.oRol.idRol = (int)datos.Lector["id_rol"];
                    aux.estado = (bool)datos.Lector["estado"];
                    aux.oRol.descripcion = (string)datos.Lector["descripcion"];


                    lista.Add(aux);
                }


            }
            catch (Exception ex)
            {

                lista = new List<Usuario>();
            }
            finally
            {
                datos.cerrarConexion();
            }

            return lista;

        }

        public void agregar(Usuario nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("insert into usuario(documento,nombre_completo, correo, clave, id_rol,estado) values (@documento, @nombre_completo, @correo, @clave, @id_rol, @estado)");
                datos.setearParametro("@documento", nuevo.documento);
                datos.setearParametro("@nombre_completo", nuevo.nombreCompleto.ToUpper());
                datos.setearParametro("@correo", nuevo.correo.ToUpper());
                datos.setearParametro("@clave", nuevo.clave);
                datos.setearParametro("@id_rol", nuevo.oRol.idRol);
                datos.setearParametro("@estado", nuevo.estado);

                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public void modificar(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("update usuario set documento = @documento, nombre_completo = @nombreCompleto, correo = @correo, clave = @clave, id_rol = @idRol, estado = @estado where id_usuario = @idUsuario");
                datos.setearParametro("@documento", usuario.documento);
                datos.setearParametro("@nombreCompleto", usuario.nombreCompleto.ToUpper());
                datos.setearParametro("@correo", usuario.correo.ToUpper());
                datos.setearParametro("@clave", usuario.clave);
                datos.setearParametro("@idRol", usuario.oRol.idRol);
                datos.setearParametro("@estado", usuario.estado);
                datos.setearParametro("@idUsuario", usuario.idUsuario);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void eliminar(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("DELETE usuario where id_usuario = @id_usuario");
                datos.setearParametro("@id_usuario", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Usuario> filtrar(string campo, string criterio, string filtro)
        {
            List<Usuario> lista = new List<Usuario>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "select u.id_usuario, u.documento, u.nombre_completo, u.correo, u.clave, r.id_rol, u.estado, r.id_rol, r.descripcion from usuario u inner join rol r on r.id_rol = u.id_rol and ";

                switch (campo)
                {
                    case "Documento":
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "documento like '" + filtro + "%' ";
                                break;
                            case "Termina con":
                                consulta += "documento like '%" + filtro + "'";
                                break;
                            default:
                                consulta += "documento like '%" + filtro + "%'";
                                break;
                        }
                        break;

                    case "Nombre":
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "nombre_completo like '" + filtro + "%' ";
                                break;
                            case "Termina con":
                                consulta += "nombre_completo like '%" + filtro + "'";
                                break;
                            default:
                                consulta += "nombre_completo like '%" + filtro + "%'";
                                break;
                        }
                        break;

                    case "Correo":
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "correo like '" + filtro + "%' ";
                                break;
                            case "Termina con":
                                consulta += "correo like '%" + filtro + "'";
                                break;
                            default:
                                consulta += "correo like '%" + filtro + "%'";
                                break;
                        }
                        break;

                    case "Rol":
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "id_rol like '" + filtro + "%' ";
                                break;
                            case "Termina con":
                                consulta += "id_rol like '%" + filtro + "'";
                                break;
                            default:
                                consulta += "id_rol like '%" + filtro + "%'";
                                break;
                        }
                        break;

                    case "Estado":
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "estado like '" + filtro + "%' ";
                                break;
                            case "Termina con":
                                consulta += "estado like '%" + filtro + "'";
                                break;
                            default:
                                consulta += "estado like '%" + filtro + "%'";
                                break;
                        }
                        break;

                }

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Usuario aux = new Usuario();
                    aux.oRol = new Rol();

                    aux.idUsuario = (int)datos.Lector["id_usuario"];
                    aux.documento = (string)datos.Lector["documento"];
                    aux.nombreCompleto = (string)datos.Lector["nombre_completo"];
                    aux.correo = (string)datos.Lector["correo"];
                    aux.clave = (string)datos.Lector["clave"];
                    aux.oRol.idRol = (int)datos.Lector["id_rol"];
                    aux.estado = (bool)datos.Lector["estado"];
                    aux.oRol.descripcion = (string)datos.Lector["descripcion"];


                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }


            throw new NotImplementedException();
        }
    }
}
