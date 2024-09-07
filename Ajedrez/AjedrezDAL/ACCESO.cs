using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;

namespace AjedrezDAL
{
    internal class ACCESO
    {
        private SqlConnection coneccion;

        public void AbrirConexion()
        {
            coneccion = new SqlConnection();
            coneccion.ConnectionString = @"Data Source=.; Initial Catalog=AjedrezBD; Integrated Security=SSPI";
            coneccion.Open();
        }

        public void CerrarConexion()
        {
            coneccion.Close();
            coneccion = null;
            GC.Collect();
        }

        private SqlCommand CrearComando(string sql, List<SqlParameter> param = null)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;
            if (param != null && param.Count > 0)
            {
                cmd.Parameters.AddRange(param.ToArray());
            }
            cmd.Connection = coneccion;
            return cmd;
        }

        public int Escribir(string sql, List<SqlParameter> param = null)
        {
            int filasAfectadas;
            SqlCommand cmd = CrearComando(sql, param);
            try
            {
                filasAfectadas = cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                filasAfectadas = -1;
            }
            return filasAfectadas;

        }

        public int DevolverEscalar(string sql, List<SqlParameter> param = null)
        {
            SqlCommand cmd = CrearComando(sql, param);
            int escalar = int.Parse(cmd.ExecuteScalar().ToString());
            return escalar;

        }

        public SqlDataReader Leer(string sql, List<SqlParameter> param = null)
        {
            SqlCommand cmd = CrearComando(sql, param);
            SqlDataReader lector = cmd.ExecuteReader();
            return lector;
        }

        public SqlParameter CrearParametro(string nombreParam, string valorParam)
        {
            SqlParameter param = new SqlParameter();
            param.ParameterName = nombreParam;
            param.Value = valorParam;
            param.DbType = DbType.String;
            return param;

        }

        public SqlParameter CrearParametro(string nombreParam, decimal valorParam)
        {
            SqlParameter param = new SqlParameter();
            param.ParameterName = nombreParam;
            param.Value = valorParam;
            param.DbType = DbType.Decimal;
            return param;

        }

        public SqlParameter CrearParametro(string nombreParam, int valorParam)
        {
            SqlParameter param = new SqlParameter();
            param.ParameterName = nombreParam;
            param.Value = valorParam;
            param.DbType = DbType.Int32;
            return param;

        }
    }
}