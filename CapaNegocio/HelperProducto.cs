using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace CapaNegocio
{
    public class HelperProducto
    {
        public static string camposVacios(Producto prod)
        {
            if (string.IsNullOrEmpty(prod.Nombre) || string.IsNullOrWhiteSpace(prod.Nombre))
                return "No puede haber campos vacíos";
            else if (string.IsNullOrEmpty(prod.Descripcion) || string.IsNullOrWhiteSpace(prod.Descripcion))
                return "No puede haber campos vacíos";
            else if (string.IsNullOrEmpty(prod.strPrecio) || string.IsNullOrWhiteSpace(prod.strPrecio))
                return "No puede haber campos vacíos";
            else if (string.IsNullOrEmpty(prod.strStock) || string.IsNullOrWhiteSpace(prod.strStock))
                return "No puede haber campos vacíos";
            else
                return "";
        }

        public static bool EsDecimal(string numero, out decimal numDecimal)
        {
            NumberStyles style = NumberStyles.Any;
            CultureInfo culture = CultureInfo.InvariantCulture;

            foreach (char letra in numero)
            {
                if ((letra < '0' || letra > '9') && letra != '.')
                {
                    numDecimal = 0;
                    return false;
                }
            }

            if (Decimal.TryParse(numero, style, culture, out numDecimal))
                return true;
            else
                return false;
        }

        public static bool EsEntero(string numero, out int numEntero)
        {
            NumberStyles style = NumberStyles.Number;
            CultureInfo culture = CultureInfo.CreateSpecificCulture("es-ES");

            foreach (char letra in numero)
            {
                if(letra< '0' || letra >'9')
                {
                    numEntero = 0;
                    return false;
                }
            }

            Int32.TryParse(numero, style, culture, out numEntero);
            return true;

        }

        public static string ConvertirBase64(string ruta, out bool conversion)
        {

            string textoBase64 = string.Empty;
            conversion = true;

            try
            {
                byte[] bytes = File.ReadAllBytes(ruta);
                textoBase64 = Convert.ToBase64String(bytes);
                return textoBase64;
            }
            catch
            {
                conversion = false;
                return "";
            }         
        }

        public static string rutaBase64(string url)
        {
            bool conversion;
            string ruta = ConfigurationManager.AppSettings["CarpetaImagenesProductos"] + url;
            string textoBase64 = ConvertirBase64((ruta), out conversion);
            string ext = Path.GetExtension(url);
            
            return "data:image/" + ext + ";base64," + textoBase64;
        }
    }
}
