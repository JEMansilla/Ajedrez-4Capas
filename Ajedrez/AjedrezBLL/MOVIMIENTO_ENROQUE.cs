using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AjedrezBLL
{
    public class MOVIMIENTO_ENROQUE : MOVIMIENTO
    {
        public override void Ejecutar(AjedrezBE.MOVIMIENTO mov, AjedrezBE.TABLERO tab)
        {
            if(mov is AjedrezBE.MOVIMIENTO_ENROQUE)
            {
                AjedrezBE.MOVIMIENTO_ENROQUE movenroque = (AjedrezBE.MOVIMIENTO_ENROQUE)mov;
                using (MOVIMIENTO_NORMAL movnbll = new MOVIMIENTO_NORMAL())
                {
                    AjedrezBE.MOVIMIENTO mov1 = new AjedrezBE.MOVIMIENTO_NORMAL(movenroque.Inicio,movenroque.Final);
                    AjedrezBE.MOVIMIENTO mov2 = new AjedrezBE.MOVIMIENTO_NORMAL(movenroque.torreinicio,movenroque.torrefinal);
                    movnbll.Ejecutar(mov1, tab);
                    movnbll.Ejecutar(mov2, tab);
                }
            }
            
        }
        public override bool MovimientoEsLegal(AjedrezBE.MOVIMIENTO movi, AjedrezBE.JUEGO juego)
        {
            using(AjedrezBLL.TABLERO tabbll = new AjedrezBLL.TABLERO())
            {
                using(AjedrezBLL.JUEGO juegobll = new AjedrezBLL.JUEGO())
                {
                  
                    
                        AjedrezBE.MOVIMIENTO_ENROQUE movenroque = (AjedrezBE.MOVIMIENTO_ENROQUE)movi;
                        if (tabbll.HayJaque(juego.Turno, juego.Tablero,juegobll.Oponente(juego)))
                        {
                            return false;
                        }
                        AjedrezBE.TABLERO copiatablero = tabbll.Copiar(juego.Tablero);
                        AjedrezBE.POSICION iniciorey = movi.Inicio;
                        using(AjedrezBLL.MOVIMIENTO_NORMAL movnbll = new MOVIMIENTO_NORMAL())
                        {
                            for (int i = 0; i < 2; i++)
                            {
                                movnbll.Ejecutar(new AjedrezBE.MOVIMIENTO_NORMAL(iniciorey, iniciorey + movenroque.direccionrey), copiatablero);
                                iniciorey += movenroque.direccionrey;
                                if(tabbll.HayJaque(juego.Turno,copiatablero,juegobll.Oponente(juego)))
                                {
                                    return false;
                                }
                            }
                            return true;
                        }
                        
                    
                }
                
            }
            
            
        }
    }
}
