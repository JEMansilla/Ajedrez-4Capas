using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AjedrezBLL
{
    public class MOVIMIENTO_NORMAL : MOVIMIENTO
    {
        public override void Ejecutar(AjedrezBE.MOVIMIENTO mov, AjedrezBE.TABLERO tab)
        {
            AjedrezBE.PIEZA pieza = tab[mov.Inicio];
            tab[mov.Final] = pieza;
            tab[mov.Inicio] = null;
            pieza.Movida = true;
        }
    }
}