using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class ProveedoresNegocio
    {

        public List<Dom_Proveedor> listar()
        {
            List<Dom_Proveedor> lista = new List<Dom_Proveedor>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select * from proveedor");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Dom_Proveedor aux = new Dom_Proveedor();

                    aux.idProveedor = (int)datos.Lector["id_proveedor"];
                    aux.documento = (string)datos.Lector["documento"];
                    aux.razon_social = (string)datos.Lector["razon_social"];
                    aux.correo = (string)datos.Lector["correo"];
                    aux.telefono = (string)datos.Lector["telefono"];
                    aux.estado = (bool)datos.Lector["estado"];


                    lista.Add(aux);
                }


            }
            catch (Exception ex)
            {

                lista = new List<Dom_Proveedor>();
            }
            finally
            {
                datos.cerrarConexion();
            }

            return lista;

        }

        public void agregar(Dom_Proveedor nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("insert into proveedor (documento, razon_social, correo, telefono, estado, fecha_creacion) values (@documento, @razon_social, @correo, @telefono, @estado, @fecha_creacion)");
                datos.setearParametro("@documento", nuevo.documento);
                datos.setearParametro("@razon_social", nuevo.razon_social.ToUpper());
                datos.setearParametro("@correo", nuevo.correo.ToUpper());
                datos.setearParametro("@telefono", nuevo.telefono);
                datos.setearParametro("@estado", nuevo.estado);
                datos.setearParametro("@fecha_creacion", nuevo.fechaCreacion);

                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public void modificar(Dom_Proveedor proveedor)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("update proveedor set documento = @documento, razon_social = @razon_social, correo = @correo, telefono = @telefono, estado = @estado where id_proveedor = @id_proveedor");
                datos.setearParametro("id_proveedor", proveedor.idProveedor);
                datos.setearParametro("@documento", proveedor.documento);
                datos.setearParametro("@razon_social", proveedor.razon_social.ToUpper());
                datos.setearParametro("@correo", proveedor.correo.ToUpper());
                datos.setearParametro("@telefono", proveedor.telefono);
                datos.setearParametro("@estado", proveedor.estado);

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
                datos.setearConsulta("DELETE proveedor where id_proveedor = @id_proveedor");
                datos.setearParametro("@id_proveedor", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Dom_Proveedor> filtrar(string campo, string criterio, string filtro)
        {
            List<Dom_Proveedor> lista = new List<Dom_Proveedor>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "select * from proveedor where ";

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

                    case "Razon Social":
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "razon_social like '" + filtro + "%' ";
                                break;
                            case "Termina con":
                                consulta += "razon_social like '%" + filtro + "'";
                                break;
                            default:
                                consulta += "razon_social like '%" + filtro + "%'";
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

                    case "Telefono":
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "telefono like '" + filtro + "%' ";
                                break;
                            case "Termina con":
                                consulta += "telefono like '%" + filtro + "'";
                                break;
                            default:
                                consulta += "telefono like '%" + filtro + "%'";
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
                    Dom_Proveedor aux = new Dom_Proveedor();
 
                    aux.idProveedor = (int)datos.Lector["id_proveedor"];
                    aux.documento = (string)datos.Lector["documento"];
                    aux.razon_social = (string)datos.Lector["razon_social"];
                    aux.correo = (string)datos.Lector["correo"];
                    aux.telefono = (string)datos.Lector["telefono"];
                    aux.estado = (bool)datos.Lector["estado"];


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
