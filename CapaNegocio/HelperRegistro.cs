using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaDatos;

namespace CapaNegocio
{
    public class HelperRegistro
    {
        public static string camposVacios(Cliente cliente)
        {
            if (string.IsNullOrEmpty(cliente.Nombre) || string.IsNullOrWhiteSpace(cliente.Nombre))
                return "No puede haber campos vacíos";
            else if (string.IsNullOrEmpty(cliente.Apellido) || string.IsNullOrWhiteSpace(cliente.Apellido))
                return "No puede haber campos vacíos";
            else if (string.IsNullOrEmpty(cliente.Email) || string.IsNullOrWhiteSpace(cliente.Email))
                return "No puede haber campos vacíos";
            else
                return "";
        }

        public static void enviarMail(string destino,string asunto,string mensaje)
        {
            EmailService mail = new EmailService();

            mail.ArmarCorreo(destino, asunto, mensaje);
            mail.EnviarMail();
        }
    }
}
