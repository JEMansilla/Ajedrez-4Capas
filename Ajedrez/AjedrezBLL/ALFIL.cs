using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AjedrezBLL
{
    public class ALFIL : PIEZA
    {
        public override IEnumerable<AjedrezBE.MOVIMIENTO> ObtenerMovimientos(AjedrezBE.POSICION inicio, AjedrezBE.TABLERO tab)
        {
            return MoverEnDireccion(inicio, tab, AjedrezBE.ALFIL.direcciones).Select(final => new AjedrezBE.MOVIMIENTO_NORMAL(inicio, final));
        }

        
    }
}