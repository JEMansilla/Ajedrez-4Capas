using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AjedrezBLL
{
    public class MOVIMIENTO_DOBLEPEON : MOVIMIENTO
    {
        public override void Ejecutar(AjedrezBE.MOVIMIENTO mov, AjedrezBE.TABLERO tab)
        {
            using(TABLERO tabbll = new TABLERO())
            {
                AjedrezBE.MOVIMIENTO_DOBLEPEON movdoblepeon = (AjedrezBE.MOVIMIENTO_DOBLEPEON)mov;
                tabbll.EstablecerPosicionPassant(tab[movdoblepeon.Inicio].Blanca, movdoblepeon.posicionpassant, tab);
                using(MOVIMIENTO_NORMAL movnormalbll = new MOVIMIENTO_NORMAL())
                {

                    movnormalbll.Ejecutar(new AjedrezBE.MOVIMIENTO_NORMAL(movdoblepeon.Inicio, movdoblepeon.Final), tab);
                }
            }
        }
    }
}
