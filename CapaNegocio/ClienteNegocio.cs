using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaDatos;


namespace CapaNegocio
{
    public class ClienteNegocio
    {
        public List<Cliente> ListarClientes(bool filtro=true)
        {
            ClienteDB accesoDB = new ClienteDB();
            return accesoDB.ListarClientes(filtro);
        }

        public void CambiarPassword(int id, string pass)
        {
            ClienteDB accesoDB = new ClienteDB();
            accesoDB.CambiarPass(id, pass);
        }

        public int RegistrarUsuario(Cliente usuario, out string mensaje)
        {
            int id;
            string cuerpo = "Bienvenido a Tienda Online, su contraseña temporal es test123";           
            ClienteDB accesoDB = new ClienteDB();

            EmailService servicio = new EmailService();
            servicio.ArmarCorreo(usuario.Email, "Creación cuenta", cuerpo);

            //comprobar campos vacíos
            mensaje = HelperRegistro.camposVacios(usuario);
            if (mensaje != "")
                return 0;

            //agregar a db 
            usuario.Password = "test123";
            id = accesoDB.RegistrarUsuario(usuario);
            
            if (id == 0)
            {
                //si no se agregó por estar repetido el email
                mensaje = "Email ya existe en la base de datos";
                return 0;
            }              
            else
            {
                //si se agregó se envía email con la contraseña
                servicio.EnviarMail();
                return id;
            }
                       
        }

        public bool ModificarUsuario(Cliente usuario, out string mensaje)
        {
            bool exito;
            ClienteDB accesoDB = new ClienteDB();

            mensaje = HelperRegistro.camposVacios(usuario);
            if (mensaje != "")
                return false;

            exito = accesoDB.ModificarUsuario(usuario);
            if (!exito)
                mensaje = "Email ya existe en la base de datos";
            return exito;
        }

        public bool EliminarUsuario(int idUsuario, out string mensaje)
        {
            bool exito;
            ClienteDB accesoDB = new ClienteDB();

            exito = accesoDB.EliminarUsuario(idUsuario);

            mensaje = exito ? "OK" : "No existe el id de usuario";

            return exito;
        }
    }
}
