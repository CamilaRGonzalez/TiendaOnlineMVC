using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;


namespace CapaDatos
{
    public class ClienteDB
    {
        public List<Cliente> ListarClientes(bool filtroAdmin = true)
        {
            
            AccesoDB datos = new AccesoDB();
            try
            {
                string query;
                if (!filtroAdmin)
                    query = "Select IdCliente,Nombre,Apellido,Email,Password,FechaRegistro, Reestablecer,Activo, Admin from Cliente where Admin = 0";
                else
                    query = "Select IdCliente,Nombre,Apellido,Email,Password,FechaRegistro, Reestablecer,Activo, Admin from Cliente where Admin = 1";
                
                datos.HacerConsulta(query);
                datos.EjecutarLectura();
                List<Cliente> lista = new List<Cliente>();

                while (datos.Lector.Read())
                {
                    Cliente aux = new Cliente();
                    aux.IdCliente = (int)datos.Lector["IdCliente"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.Email = (string)datos.Lector["Email"];
                    aux.Password = (string)datos.Lector["Password"];
                    aux.FechaRegistro = (DateTime)datos.Lector["FechaRegistro"];
                    aux.Reestablecer =(bool)datos.Lector["Reestablecer"];
                    aux.Activo = (bool)datos.Lector["Activo"];
                    aux.Admin = (bool)datos.Lector["Admin"];


                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally 
            {
                datos.CerrarConexion();
            }
            
        }

        public int RegistrarUsuario(Cliente objeto)
        {
            AccesoDB datos = new AccesoDB();
            int id;
            try
            {
                datos.setearSP("sp_registroUsuario");
                datos.setearParametro("@Nombre", objeto.Nombre);
                datos.setearParametro("@Apellido", objeto.Apellido);
                datos.setearParametro("@Email", objeto.Email);
                datos.setearParametro("@Password", objeto.Password);
                datos.setearParametro("@Activo", objeto.Activo);
                datos.setearParametroSalida("Resultado");

                datos.EjecutarAccion();

                id = (int)datos.obtenerOutput("Resultado");
                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public bool ModificarUsuario(Cliente objeto)
        {
            AccesoDB datos = new AccesoDB();
            bool id;
            try
            {
                datos.setearSP("sp_editarUsuario");
                datos.setearParametro("@IdCliente", objeto.IdCliente);
                datos.setearParametro("@Nombre", objeto.Nombre);
                datos.setearParametro("@Apellido", objeto.Apellido);
                datos.setearParametro("@Email", objeto.Email);
                datos.setearParametro("@Activo", objeto.Activo);
                datos.setearParametroSalida("Resultado");

                datos.EjecutarAccion();

                id = (int)datos.obtenerOutput("Resultado") == 1;
                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public void CambiarPass(int id, string pass)
        {
            AccesoDB datos = new AccesoDB();
            try
            {
                string query = "UPDATE Cliente set Password = @Password where IdCliente = @IdCliente";

                datos.HacerConsulta(query);
                datos.setearParametro("@IdCliente", id);
                datos.setearParametro("@Password", pass);

                datos.EjecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public bool EliminarUsuario(int idCliente)
        {
            AccesoDB datos = new AccesoDB();
            bool id;
            try
            {
                datos.setearSP("sp_eliminarUsuario");
                datos.setearParametro("@IdCliente", idCliente);
                datos.setearParametroSalida("Resultado");

                datos.EjecutarAccion();

                id = (int)datos.obtenerOutput("Resultado") == 1;
                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
    }
}
