using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using negocio;


namespace negocio
{
    public class UnidadMedidaNegocio
    {
        public List<Dom_UnidadDeMedida> listar()
        {
            List<Dom_UnidadDeMedida> lista = new List<Dom_UnidadDeMedida>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select * from unidades_medida");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Dom_UnidadDeMedida aux = new Dom_UnidadDeMedida();

                    aux.id_unidad_de_medida = (int)datos.Lector["id_unidad_medida"];
                    aux.descripcion = (string)datos.Lector["descripcion"];


                    lista.Add(aux);
                }


            }
            catch (Exception ex)
            {

                lista = new List<Dom_UnidadDeMedida>();
            }
            finally
            {
                datos.cerrarConexion();
            }

            return lista;

        }

        public void agregar(Dom_UnidadDeMedida nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("insert into unidades_medida (descripcion) values (@descripcion)");
                datos.setearParametro("@descripcion", nuevo.descripcion.ToUpper());

                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public void modificar(Dom_UnidadDeMedida unidadMedida)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("update unidades_medida set descripcion = @descripcion where id_unidad_medida = @id_unidad_medida");
                datos.setearParametro("@id_unidad_medida", unidadMedida.id_unidad_de_medida);
                datos.setearParametro("@descripcion", unidadMedida.descripcion.ToUpper());

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
                datos.setearConsulta("DELETE unidades_medida where id_unidad_medida = @id_unidad_medida");
                datos.setearParametro("@id_unidad_medida", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Dom_UnidadDeMedida> filtrar(string campo, string criterio, string filtro)
        {
            List<Dom_UnidadDeMedida> lista = new List<Dom_UnidadDeMedida>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "select descripcion from unidades_medida where ";

                switch (campo)
                {
                    case "Descripción":
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "descripcion like '" + filtro + "%' ";
                                break;
                            case "Termina con":
                                consulta += "descripcion like '%" + filtro + "'";
                                break;
                            default:
                                consulta += "descripcion like '%" + filtro + "%'";
                                break;
                        }
                        break;

                }

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Dom_UnidadDeMedida aux = new Dom_UnidadDeMedida();
                    aux.descripcion = (string)datos.Lector["descripcion"];


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
