using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AjedrezBE
{
    public class MOVIMIENTO_NORMAL : MOVIMIENTO
    {
       public MOVIMIENTO_NORMAL(POSICION inicio, POSICION final)
        {
            Tipo = TipoMovimiento.Normal;
            Inicio = inicio;
            Final = final;
        }
    }
}