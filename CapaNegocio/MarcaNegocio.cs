using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class MarcaNegocio
    {
        public List<Marca> ListarMarcas()
        {
            MarcaDB accesoDB = new MarcaDB();
            return accesoDB.ListarMarcas();
        }

        public List<Marca> ListarSegunCateg(int categoria)
        {
            MarcaDB accesoDB = new MarcaDB();
            return accesoDB.ListarSegunCateg(categoria);
        }

        public int RegistrarMarca(Marca categ, out string mensaje)
        {
            int id;
            MarcaDB accesoDB = new MarcaDB();

            if (string.IsNullOrEmpty(categ.Descripcion) || string.IsNullOrWhiteSpace(categ.Descripcion))
            {
                mensaje = "No puede haber campos vacíos";
                return 0;
            }

            if (categ.IdMarca == 0)
                id = accesoDB.RegistrarMarca(categ);
            else
                id = accesoDB.EditarMarca(categ);

            if (id == 0)
            {
                mensaje = "Ya exsiste la marca " + categ.Descripcion;
                return 0;
            }

            mensaje = "ok";
            return id;
        }
    }
}

