using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AjedrezBLL
{
    public class RESULTADO
    {
        public static AjedrezBE.RESULTADO Victoria(AjedrezBE.JUGADOR jugador)
        {
            return new AjedrezBE.RESULTADO(jugador, AjedrezBE.TipoFinalPartida.JaqueMate);
        }

        public static AjedrezBE.RESULTADO Empate(AjedrezBE.TipoFinalPartida razon)
        {
            AjedrezBE.JUGADOR jugador = new AjedrezBE.JUGADOR();
            jugador.Nombre = "NADIE";
            jugador.Usablancos = true;
            return new AjedrezBE.RESULTADO(jugador, razon);
        }
    }
}