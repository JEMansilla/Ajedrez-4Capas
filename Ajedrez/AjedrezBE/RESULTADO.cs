using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AjedrezBE
{
    public class RESULTADO
    {
        public JUGADOR Ganador;
        public TipoFinalPartida Razon;

        public RESULTADO(JUGADOR ganador, TipoFinalPartida razon)
        {
            Ganador = ganador;
            Razon = razon;
        }
    }
}