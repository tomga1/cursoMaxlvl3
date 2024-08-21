using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace negocio
{
    public class ClientesNegocio
    {
        public List<Clientes> listar()
        {
            List<Clientes> lista = new List<Clientes>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select id_cliente, C.nombre, apellido, razonsocial, telefono, celular, mail, localidad, t.nombre contacto, cuit,t.id_contacto  from clientes C, contacto T where T.id_contacto = c.id_contactado");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Clientes aux = new Clientes();
                    aux.id = (int)datos.Lector["id_cliente"];
                    aux.nombre = (string)datos.Lector["nombre"];
                    aux.apellido = (string)datos.Lector["apellido"];
                    aux.razonsocial = (string)datos.Lector["razonsocial"];
                    aux.telefono = (string)datos.Lector["telefono"];
                    aux.celular = (string)datos.Lector["celular"];
                    aux.mail = (string)datos.Lector["mail"];
                    aux.localidad = (string)datos.Lector["localidad"];

                    aux.Tipo = new Contacto();
                    aux.Tipo.id = (int)datos.Lector["id_contacto"];
                    aux.Tipo.nombrecontacto = (string)datos.Lector["contacto"];

                    aux.cuit = (string)datos.Lector["cuit"];   
                     
                    lista.Add(aux);
                }
                
                 return lista; 
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }

        public void agregar(Clientes nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("INSERT INTO clientes(nombre, apellido, razonsocial, telefono, celular, mail, localidad, id_contactado, cuit) VALUES (@nombre, @apellido, @razonsocial, @telefono, @celular,@mail,@localidad, @id_contactado,@cuit)");
                datos.setearParametro("@nombre", nuevo.nombre.ToUpper());
                datos.setearParametro("@apellido", nuevo.apellido.ToUpper());
                datos.setearParametro("@razonsocial", nuevo.razonsocial.ToUpper());
                datos.setearParametro("@telefono", nuevo.telefono);
                datos.setearParametro("@celular", nuevo.celular);
                datos.setearParametro("@mail", nuevo.mail.ToUpper());
                datos.setearParametro("@localidad", nuevo.localidad.ToUpper());
                
                datos.setearParametro("@id_contactado", nuevo.Tipo.id);
                datos.setearParametro("@cuit", nuevo.cuit.ToUpper());
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void modificar(Clientes cli)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE clientes set nombre = @nombre, apellido = @apellido, razonsocial = @razonsocial, telefono = @telefono, celular = @celular, mail = @mail, localidad = @localidad, id_contactado = @id_contactado, cuit = @cuit where id_cliente = @id");
                datos.setearParametro("@nombre",cli.nombre.ToUpper());
                datos.setearParametro("@apellido", cli.apellido.ToUpper());
                datos.setearParametro("@razonsocial", cli.razonsocial.ToUpper());
                datos.setearParametro("@telefono", cli.telefono);
                datos.setearParametro("@celular", cli.celular);
                datos.setearParametro("@mail", cli.mail.ToUpper());
                datos.setearParametro("@localidad", cli.localidad.ToUpper());
                datos.setearParametro("@id_contactado", cli.Tipo.id);
                datos.setearParametro("@cuit", cli.cuit.ToUpper());
                datos.setearParametro("@id", cli.id);

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
                datos.setearConsulta("DELETE clientes where id_cliente = @id_cliente");
                datos.setearParametro("@id_cliente", id);
                datos.ejecutarAccion();
            }
            catch (SqlException ex)
            {
                throw new Exception("Ocurrió un error al intentar elimiar el cliente. Debe seleccionarlo en la grilla.", ex);
            }
        }
        
    }
}
