using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using dominio;


namespace negocio
{
    public class RubroNegocio
    {
        public List<Dom_Rubro> listar()
        {
            List<Dom_Rubro> lista = new List<Dom_Rubro>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select * from rubros");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Dom_Rubro aux = new Dom_Rubro();

                    aux.idRubro = (int)datos.Lector["id_rubro"];
                    aux.descripcion = (string)datos.Lector["descripcion"];     
                    aux.estado = (bool)datos.Lector["estado"];


                    lista.Add(aux);
                }


            }
            catch (Exception ex)
            {

                lista = new List<Dom_Rubro>();
            }
            finally
            {
                datos.cerrarConexion();
            }

            return lista;

        }

        public void agregar(Dom_Rubro nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("insert into rubros (descripcion, estado) values (@descripcion, @estado)");
                datos.setearParametro("@descripcion", nuevo.descripcion.ToUpper());
                datos.setearParametro("@estado", nuevo.estado);

                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public void modificar(Dom_Rubro categoria)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("update rubros set descripcion = @descripcion, estado = @estado where id_rubro = @idRubro");
                datos.setearParametro("@idRubro", categoria.idRubro);
                datos.setearParametro("@descripcion", categoria.descripcion.ToUpper());
                datos.setearParametro("@estado", categoria.estado);

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
                datos.setearConsulta("DELETE rubros where id_rubro = @id_rubro");
                datos.setearParametro("@id_rubro", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Dom_Rubro> filtrar(string campo, string criterio, string filtro)
        {
            List<Dom_Rubro> lista = new List<Dom_Rubro>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "select descripcion, estado from rubros where ";

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
                    Dom_Rubro aux = new Dom_Rubro();
                    aux.descripcion = (string)datos.Lector["descripcion"];
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