using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AjedrezBE
{
    public class MOVIMIENTO_PROMOCIONPEON:MOVIMIENTO
    {
        public MOVIMIENTO_PROMOCIONPEON(POSICION inicio, POSICION final, TipoPieza pieza)
        {
            Tipo = TipoMovimiento.PromocionPeon;
            Inicio = inicio;
            Final = final;
            this.nuevapieza = pieza;
        }

        public TipoPieza nuevapieza;
    }
}
