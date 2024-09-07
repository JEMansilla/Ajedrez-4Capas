using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AjedrezBLL
{
    public class MOVIMIENTO_ENPASSANT : MOVIMIENTO
    {
        public override void Ejecutar(AjedrezBE.MOVIMIENTO mov, AjedrezBE.TABLERO tab)
        {
            using(AjedrezBLL.MOVIMIENTO_NORMAL movnormalbll = new MOVIMIENTO_NORMAL())
            {
                AjedrezBE.MOVIMIENTO_ENPASSANT movpassant = (AjedrezBE.MOVIMIENTO_ENPASSANT)mov;
                AjedrezBE.MOVIMIENTO_NORMAL movnormal = new AjedrezBE.MOVIMIENTO_NORMAL(movpassant.Inicio,movpassant.Final);
                movnormalbll.Ejecutar(movnormal, tab);
                tab[movpassant.posicioncaptura] = null;
            }
        }
    }
}
