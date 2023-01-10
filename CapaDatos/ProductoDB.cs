using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;

namespace CapaDatos
{
    public class ProductoDB
    {
        public List<Producto> ListarProductos()
        {

            AccesoDB datos = new AccesoDB();
            try
            {
                datos.setearSP("sp_listarProductos");
                datos.EjecutarLectura();
                List<Producto> lista = new List<Producto>();

                while (datos.Lector.Read())
                {
                    Producto aux = new Producto();
                    aux.IdProducto = (int)datos.Lector["IdProducto"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    if(!(datos.Lector["UrlImagen"] is DBNull))
                        aux.UrlImagen = (string)datos.Lector["UrlImagen"];
                    aux.Activo = (bool)datos.Lector["Activo"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    aux.Stock = (int)datos.Lector["Stock"];
                    
                    aux.Marca = new Marca();
                    aux.Marca.IdMarca = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];

                    aux.Categoria = new Categoria();
                    aux.Categoria.IdCategoria = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];

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

        public List<Producto> ListarActivos(int categoria, int marca)
        {

            AccesoDB datos = new AccesoDB();
            try
            {
                string query = "select IdProducto,Nombre,P.Descripcion , P.IdMarca, M.Descripcion as Marca,P.IdCategoria, " +
                "C.Descripcion as Categoria, Precio, Stock, UrlImagen, P.Activo from Producto as P " +
                "inner join Marca as M on M.IdMarca = P.IdMarca " +
                "inner join Categoria as C on C.IdCategoria = P.IdCategoria where P.Activo = 1 ";

                if (categoria != 0)
                    query += "and P.IdCategoria = " + categoria + " ";
                if (marca != 0)
                    query += "and P.IdMarca = " + marca + " ";

                datos.HacerConsulta(query);
               
                datos.EjecutarLectura();
                List<Producto> lista = new List<Producto>();

                while (datos.Lector.Read())
                {
                    Producto aux = new Producto();
                    aux.IdProducto = (int)datos.Lector["IdProducto"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    if (!(datos.Lector["UrlImagen"] is DBNull))
                        aux.UrlImagen = (string)datos.Lector["UrlImagen"];
                    aux.Activo = (bool)datos.Lector["Activo"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    aux.Stock = (int)datos.Lector["Stock"];

                    aux.Marca = new Marca();
                    aux.Marca.IdMarca = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];

                    aux.Categoria = new Categoria();
                    aux.Categoria.IdCategoria = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];

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

        public int RegistrarProducto(Producto prod)
        {
            AccesoDB datos = new AccesoDB();
            int id;
            try
            {
                datos.setearSP("sp_RegistrarProducto");
                datos.setearParametro("Nombre", prod.Nombre);
                datos.setearParametro("Descripcion", prod.Descripcion);
                datos.setearParametro("IdMarca", prod.Marca.IdMarca);
                datos.setearParametro("IdCategoria", prod.Categoria.IdCategoria);
                datos.setearParametro("Precio", prod.Precio);
                datos.setearParametro("Stock", prod.Stock);
                datos.setearParametro("Activo", prod.Activo);
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

        public int EditarProducto(Producto prod)
        {
            AccesoDB datos = new AccesoDB();
            int id;
            try
            {
                datos.setearSP("sp_EditarProducto");
                datos.setearParametro("IdProducto", prod.IdProducto);
                datos.setearParametro("Nombre", prod.Nombre);
                datos.setearParametro("Descripcion", prod.Descripcion);
                datos.setearParametro("IdMarca", prod.Marca.IdMarca);
                datos.setearParametro("IdCategoria", prod.Categoria.IdCategoria);
                datos.setearParametro("Precio", prod.Precio);
                datos.setearParametro("Stock", prod.Stock);
                datos.setearParametro("Activo", prod.Activo);
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

        public void GuardarRutaImg(Producto prod)
        {
            AccesoDB datos = new AccesoDB();
            try
            {
                string query = "update Producto set UrlImagen = @UrlImagen where IdProducto = @IdProducto";
                datos.HacerConsulta(query);
                datos.setearParametro("IdProducto", prod.IdProducto);
                datos.setearParametro("UrlImagen", prod.UrlImagen);

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
    }
}
