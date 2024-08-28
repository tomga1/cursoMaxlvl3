//using dominio;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace negocio
//{
//    public class CategoriasNegocio
//    {
//        public List<Dom_Categoria> listar()
//        {
//            List<Dom_Categoria> lista = new List<Dom_Categoria>();
//            AccesoDatos datos = new AccesoDatos();

//            try
//            {
//                datos.setearConsulta("select * from marcas");
//                datos.ejecutarLectura();

//                while (datos.Lector.Read())
//                {
//                    Dom_Categoria aux = new Dom_Categoria();

//                    aux.idMarca = (int)datos.Lector["id_marca"];
//                    aux.descripcion = (string)datos.Lector["descripcion_marca"];


//                    lista.Add(aux);
//                }


//            }
//            catch (Exception ex)
//            {

//                lista = new List<Dom_Categoria>();
//            }
//            finally
//            {
//                datos.cerrarConexion();
//            }

//            return lista;

//        }

//        public void agregar(Dom_Categoria nuevo)
//        {
//            AccesoDatos datos = new AccesoDatos();

//            try
//            {
//                datos.setearConsulta("insert into marcas (descripcion_marca) values (@descripcion_marca)");
//                datos.setearParametro("@descripcion_marca", nuevo.descripcion.ToUpper());

//                datos.ejecutarAccion();

//            }
//            catch (Exception ex)
//            {

//                throw ex;
//            }
//        }


//        public void modificar(Dom_Categoria marca)
//        {
//            AccesoDatos datos = new AccesoDatos();

//            try
//            {
//                datos.setearConsulta("update marcas set descripcion_marca = @descripcion_marca where id_marca = @id_marca");
//                datos.setearParametro("@id_unidad_medida", marca.idMarca);
//                datos.setearParametro("@descripcion_marca", marca.descripcion.ToUpper());

//                datos.ejecutarAccion();
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//            finally
//            {
//                datos.cerrarConexion();
//            }
//        }

//        public void eliminar(int id)
//        {
//            try
//            {
//                AccesoDatos datos = new AccesoDatos();
//                datos.setearConsulta("DELETE marcas where id_marca = @id_marca");
//                datos.setearParametro("@id_marca", id);
//                datos.ejecutarAccion();
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }

//        //public List<Dom_Categoria> filtrar(string campo, string criterio, string filtro)
//        //{
//        //    List<Dom_Categoria> lista = new List<Dom_Categoria>();
//        //    AccesoDatos datos = new AccesoDatos();
//        //    try
//        //    {
//        //        string consulta = "select descripcion from unidades_medida where ";

//        //        switch (campo)
//        //        {
//        //            case "Descripción":
//        //                switch (criterio)
//        //                {
//        //                    case "Comienza con":
//        //                        consulta += "descripcion like '" + filtro + "%' ";
//        //                        break;
//        //                    case "Termina con":
//        //                        consulta += "descripcion like '%" + filtro + "'";
//        //                        break;
//        //                    default:
//        //                        consulta += "descripcion like '%" + filtro + "%'";
//        //                        break;
//        //                }
//        //                break;

//        //        }

//        //        datos.setearConsulta(consulta);
//        //        datos.ejecutarLectura();

//        //        while (datos.Lector.Read())
//        //        {
//        //            Dom_Categoria aux = new Dom_Categoria();
//        //            aux.descripcion = (string)datos.Lector["descripcion"];


//        //            lista.Add(aux);
//        //        }

//        //        return lista;
//        //    }
//        //    catch (Exception ex)
//        //    {

//        //        throw ex;
//        //    }


//        //    throw new NotImplementedException();
//        //}

//    }
//}
