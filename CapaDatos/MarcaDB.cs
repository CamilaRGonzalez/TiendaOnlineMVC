using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;

namespace CapaDatos
{
    public class MarcaDB
    {
        public List<Marca> ListarMarcas()
        {

            AccesoDB datos = new AccesoDB();
            try
            {
                string query = "select IdMarca,Descripcion,Activo from Marca";
                datos.HacerConsulta(query);
                datos.EjecutarLectura();
                List<Marca> lista = new List<Marca>();

                while (datos.Lector.Read())
                {
                    Marca aux = new Marca();
                    aux.IdMarca = (int)datos.Lector["IdMarca"];
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

        public List<Marca> ListarSegunCateg(int categoria)
        {

            AccesoDB datos = new AccesoDB();
            try
            {
                string query;
                if (categoria != 0)
                {
                    query = "select distinct m.IdMarca, m.Descripcion from PRODUCTO p " +
                        "inner join CATEGORIA c on c.IdCategoria = p.IdCategoria " +
                        "inner join MARCA m on m.IdMarca = p.IdMarca and m.Activo = 1 " +
                        "where c.IdCategoria = " + categoria;
                }
                else
                    query = "select * from Marca where Activo = 1";

                datos.HacerConsulta(query);
                datos.EjecutarLectura();
                List<Marca> lista = new List<Marca>();

                while (datos.Lector.Read())
                {
                    Marca aux = new Marca();
                    aux.IdMarca = (int)datos.Lector["IdMarca"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

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

        public int RegistrarMarca(Marca objeto)
        {
            AccesoDB datos = new AccesoDB();
            int id;
            try
            {
                datos.setearSP("sp_registroMarca");
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

        public int EditarMarca(Marca objeto)
        {
            AccesoDB datos = new AccesoDB();
            int id;
            try
            {
                datos.setearSP("sp_editarMarca");
                datos.setearParametro("@IdMarca", objeto.IdMarca);
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
