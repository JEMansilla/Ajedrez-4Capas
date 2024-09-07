using AjedrezBE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace AjedrezDAL
{
    public class MP_JUGADOR : MAPPER<AjedrezBE.JUGADOR>
    {
        public override int Borrar(JUGADOR obj)
        {
            string sql = "DELETE from JUGADOR Where Id_Jugador = @Id_Jugador";
            acceso.AbrirConexion();
            List<SqlParameter> parametros = new List<SqlParameter>();
            acceso.CrearParametro("@Id_Jugador", obj.Id);
            acceso.Escribir(sql, parametros);
            acceso.CerrarConexion();
            return 1;
        }

        public override int Editar(JUGADOR obj)
        {
            string sql = $"UPDATE JUGADOR SET Id_Jugador = @Id_Jugador, Nombre_Jugador = @Nombre_Jugador, Victorias = @Victorias, Derrotas = @Derrotas, Empates = @Empates, Promedio = @Promedio, Horas = @Horas Where Id_Jugador = @Id_Jugador";

            acceso.AbrirConexion();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@Id_Jugador", obj.Id));
            parametros.Add(acceso.CrearParametro("@Nombre_Jugador", obj.Nombre));
            parametros.Add(acceso.CrearParametro("@Victorias", obj.Victorias));
            parametros.Add(acceso.CrearParametro("@Derrotas", obj.Derrotas));
            parametros.Add(acceso.CrearParametro("@Promedio", obj.Promedio));
            parametros.Add(acceso.CrearParametro("@Horas", obj.HorasJugadas));
            parametros.Add(acceso.CrearParametro("@Empates", obj.Empates));
            acceso.Escribir(sql, parametros);
            acceso.CerrarConexion();
            return 1;
        }

        public int Insertar(JUGADOR obj, string contraseña)
        {
            string sql = $"SELECT isnull(max(Id_Jugador),0) + 1 from JUGADOR";
            List<SqlParameter> parametros = new List<SqlParameter>();

            acceso.AbrirConexion();

            int id = acceso.DevolverEscalar(sql);

            sql = $"INSERT INTO JUGADOR (Id_Jugador, Nombre_Jugador, Contraseña, Victorias, Derrotas,Empates, Promedio, Horas) VALUES (@Id_Jugador, @Nombre_Jugador, @Contraseña, @Victorias, @Derrotas, @Empates,@Promedio,@Horas)";
            parametros.Add(acceso.CrearParametro("@Id_Jugador", id));
            parametros.Add(acceso.CrearParametro("@Nombre_Jugador", obj.Nombre));
            parametros.Add(acceso.CrearParametro("@Contraseña", contraseña));
            parametros.Add(acceso.CrearParametro("@Victorias", obj.Victorias));
            parametros.Add(acceso.CrearParametro("@Derrotas", obj.Derrotas));
            parametros.Add(acceso.CrearParametro("@Promedio", obj.Promedio));
            parametros.Add(acceso.CrearParametro("@Horas", obj.HorasJugadas));
            parametros.Add(acceso.CrearParametro("@Empates", obj.Empates));
            acceso.Escribir(sql, parametros);
            acceso.CerrarConexion();
            return 1;
        }

        public override List<JUGADOR> Listar()
        {
            return null;
        }

        public AjedrezBE.JUGADOR Buscar(string nombre, string contraseña)
        {

            string sql = $"SELECT Id_Jugador,Nombre_Jugador,Victorias,Derrotas,Promedio,Horas FROM JUGADOR WHERE Nombre_Jugador = @nombre and Contraseña = @contraseña";
            bool encontrado = false;

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@nombre", nombre));

            parametros.Add(acceso.CrearParametro("@contraseña", contraseña));

            acceso.AbrirConexion();
            
            SqlDataReader lector = acceso.Leer(sql, parametros);
            encontrado = lector.HasRows;
            if(encontrado)
            {

                lector.Read();
                    AjedrezBE.JUGADOR item = new AjedrezBE.JUGADOR();
                    item.Nombre = lector["Nombre_Jugador"].ToString();
                    item.Id = int.Parse(lector["Id_Jugador"].ToString());
                    item.Victorias = int.Parse(lector["Victorias"].ToString());
                    item.Derrotas = int.Parse(lector["Derrotas"].ToString());
                    item.Promedio = decimal.Parse(lector["Promedio"].ToString());
                    item.HorasJugadas = decimal.Parse(lector["Horas"].ToString());
                    return item;
                
            }
            else
            {
                lector.Close();
                acceso.CerrarConexion();
                return null;
            }
            

        }

        public bool Verificar(string nombre)
        {

            string sql = $"SELECT Id_Jugador,Nombre_Jugador,Victorias,Derrotas,Promedio,Horas FROM JUGADOR WHERE Nombre_Jugador = @nombre";
            bool encontrado = false;

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@nombre", nombre));
            acceso.AbrirConexion();
            SqlDataReader lector = acceso.Leer(sql, parametros);
            encontrado = lector.HasRows;
            lector.Close();
            acceso.CerrarConexion();
            return encontrado;

        }
    }
}