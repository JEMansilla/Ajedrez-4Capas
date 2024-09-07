using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AjedrezBE
{
    public class MOVIMIENTO_ENPASSANT:MOVIMIENTO
    {
        public MOVIMIENTO_ENPASSANT(POSICION inicio,POSICION final)
        {
            Tipo = TipoMovimiento.EnPassant;
            Inicio = inicio;
            Final = final;
            posicioncaptura = new POSICION(final.X, inicio.Y);
        }

        public POSICION posicioncaptura;
    }
}
