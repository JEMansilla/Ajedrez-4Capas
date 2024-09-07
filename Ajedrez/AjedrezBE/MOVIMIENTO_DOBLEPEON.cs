using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AjedrezBE
{
    public class MOVIMIENTO_DOBLEPEON:MOVIMIENTO
    {
        public MOVIMIENTO_DOBLEPEON(POSICION inicio, POSICION final)
        {
            Tipo = TipoMovimiento.DoblePeon;
            Inicio = inicio;
            Final = final;
            posicionpassant = new POSICION(inicio.X, (inicio.Y + final.Y) / 2);
        }

        public POSICION posicionpassant;
    }
}
