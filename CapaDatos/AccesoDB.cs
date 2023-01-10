using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class AccesoDB
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        public SqlDataReader Lector
        {
            get { return lector; }
        }

        public AccesoDB()
        {
            conexion = new SqlConnection("server=.\\SQLEXPRESS; database=TiendaOnline; integrated security=true");
            comando = new SqlCommand();
        }

        public object obtenerOutput(string param)
        {
            return comando.Parameters[param].Value;
        }

        public void HacerConsulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }

        public void setearSP(string storedProcedure)
        {
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandText = storedProcedure;
        }

        public int EjecutarAccionEscalar() //va a devolver un entero que obtengo desde la DB
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                int num = (int)comando.ExecuteScalar();
                return num;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int EjecutarAccion()
        {
            comando.Connection = conexion;

            try
            {
                conexion.Open();
                return comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void setearParametro(string nombre, object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);
        }

        public void setearParametroSalida(string valor)
        {
            comando.Parameters.Add(valor, SqlDbType.Int).Direction = ParameterDirection.Output;
            //comando.Parameters[valor].Direction = ParameterDirection.Output;
        }

        public void EjecutarLectura()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CerrarConexion()
        {
            if(lector != null)
                lector.Close();
            conexion.Close();
        }
    }

}
