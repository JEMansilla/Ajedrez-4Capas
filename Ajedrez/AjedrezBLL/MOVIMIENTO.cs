using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AjedrezBLL
{
    public abstract class MOVIMIENTO :IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public abstract void Ejecutar(AjedrezBE.MOVIMIENTO mov, AjedrezBE.TABLERO tab);

        public virtual bool MovimientoEsLegal(AjedrezBE.MOVIMIENTO movi,AjedrezBE.JUEGO juego)
        {
            using (AjedrezBLL.TABLERO tablerobll = new AjedrezBLL.TABLERO())
            {
                AjedrezBE.JUGADOR jugador = juego.Turno;
                AjedrezBE.TABLERO copiatablero = tablerobll.Copiar(juego.Tablero);
                AjedrezBE.JUGADOR jugadoroponente;
                if (juego.jugadores[0] == jugador)
                {
                    jugadoroponente = juego.jugadores[1];
                }
                else
                {
                    jugadoroponente = juego.jugadores[0];
                }
                this.Ejecutar(movi, copiatablero);
                return !tablerobll.HayJaque(jugador, copiatablero, jugadoroponente);
            }
            
        }
	}
}