using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AjedrezBLL
{
    public class JUGADOR: IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        public void Backup()
        {
            using (AjedrezDAL.BD bd = new AjedrezDAL.BD())
            {
                bd.Backup();
            }
        }
        public void Restore()
        {
            using (AjedrezDAL.BD bd = new AjedrezDAL.BD())
            {
                bd.Restore();
            }
        }
        public AjedrezBE.JUGADOR IniciarSesion(string nombre, string contraseña)
        {
            using (AjedrezDAL.MP_JUGADOR jug = new AjedrezDAL.MP_JUGADOR())
            {
                AjedrezBE.JUGADOR jugador = new AjedrezBE.JUGADOR();
                jugador = jug.Buscar(nombre, contraseña);
                return jugador;
            }
        }

        public void GuardarEstadisticas(AjedrezBE.JUGADOR jugador)
        {
            using(AjedrezDAL.MP_JUGADOR jugdal = new AjedrezDAL.MP_JUGADOR())
            {
                jugdal.Editar(jugador);
            }
        }

        public int Registrar(string nombre, string contraseña)
        {
            using (AjedrezDAL.MP_JUGADOR jug = new AjedrezDAL.MP_JUGADOR())
            { 
                if (!jug.Verificar(nombre))
                {
                    AjedrezBE.JUGADOR jugador = new AjedrezBE.JUGADOR();
                    jugador.Id = 0;
                    jugador.Nombre = nombre;
                    jugador.HorasJugadas = 0;
                    jugador.Empates = 0;
                    jugador.Victorias = 0;
                    jugador.Derrotas = 0;
                    jugador.Promedio = 0;
                    jug.Insertar(jugador, contraseña);
                    return 1;
                }

            return 0;
             }
        }

	}
}