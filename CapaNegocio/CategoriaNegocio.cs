using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CategoriaNegocio
    {
        public List<Categoria> ListarCategorias(bool filtro =false)
        {
            CategoriaDB accesoDB = new CategoriaDB();
            return accesoDB.ListarCategorias(filtro);
        }

        public int RegistrarCategoria(Categoria categ, out string mensaje)
        {
            int id;
            CategoriaDB accesoDB = new CategoriaDB();

            if (string.IsNullOrEmpty(categ.Descripcion) || string.IsNullOrWhiteSpace(categ.Descripcion))
            {
                mensaje = "No puede haber campos vacíos";
                return 0;
            }

            if(categ.IdCategoria == 0)
                id = accesoDB.RegistrarCategoria(categ);
            else
                id = accesoDB.EditarCategoria(categ);

            if (id == 0)
            {
                mensaje = "Ya exsiste la categoría " + categ.Descripcion;
                return 0;
            }

            mensaje = "ok";
            return id;
        }

    }
}
