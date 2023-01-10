using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;

namespace CapaDatos
{
    public class CategoriaDB
    {
        public List<Categoria> ListarCategorias(bool filtro = false)
        {

            AccesoDB datos = new AccesoDB();
            try
            {
                string query = "select IdCategoria,Descripcion,Activo from Categoria";

                if (filtro)
                    query += " where Activo = 1";

                datos.HacerConsulta(query);
                datos.EjecutarLectura();
                List<Categoria> lista = new List<Categoria>();

                while (datos.Lector.Read())
                {
                    Categoria aux = new Categoria();
                    aux.IdCategoria = (int)datos.Lector["IdCategoria"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Activo = (bool)datos.Lector["Activo"];

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

        public int RegistrarCategoria(Categoria objeto)
        {
            AccesoDB datos = new AccesoDB();
            int id;
            try
            {
                datos.setearSP("sp_registroCategoria");
                datos.setearParametro("@Descripcion", objeto.Descripcion);
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

        public int EditarCategoria(Categoria objeto)
        {
            AccesoDB datos = new AccesoDB();
            int id;
            try
            {
                datos.setearSP("sp_editarCategoria");
                datos.setearParametro("@IdCategoria", objeto.IdCategoria);
                datos.setearParametro("@Descripcion", objeto.Descripcion); 
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

    }
}
