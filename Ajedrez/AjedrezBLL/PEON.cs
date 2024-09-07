using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AjedrezBLL
{
    public class PEON : PIEZA
    {
        public override IEnumerable<AjedrezBE.MOVIMIENTO> ObtenerMovimientos(AjedrezBE.POSICION inicio, AjedrezBE.TABLERO tab)
        {
            return MovimientosAdelante(inicio, tab).Concat(MovimientosDiagonales(inicio, tab));
        }

        private static bool PuedeMoverse(AjedrezBE.POSICION pos, AjedrezBE.TABLERO tab)
        {
            return TABLERO.ValidarPosicion(pos) && TABLERO.EstaVacio(tab, pos);
        }
        
        private bool PuedeCapturar(AjedrezBE.POSICION pos, AjedrezBE.TABLERO tab, AjedrezBE.POSICION inicio)
        {
            if (!TABLERO.ValidarPosicion(pos) || TABLERO.EstaVacio(tab,pos))
            {
                return false;
            }
            return tab[pos].Blanca != tab[inicio].Blanca;
        }

        private IEnumerable<AjedrezBE.MOVIMIENTO> MovimientosAdelante(AjedrezBE.POSICION inicio, AjedrezBE.TABLERO tab)
        {
            AjedrezBE.DIRECCION dir;
            if (tab[inicio].Blanca)
            {
                dir = AjedrezBE.DIRECCION.Norte;
            }
            else
            {
                dir = AjedrezBE.DIRECCION.Sur;
            }
            AjedrezBE.POSICION mov = inicio + dir;
            if(PuedeMoverse(mov,tab))
            {
                if(mov.Y == 0 || mov.Y == 7)
                {
                    foreach(AjedrezBE.MOVIMIENTO promov in MovimientosPromocion(inicio,mov))
                    {
                        yield return promov;
                    }
                }
                else
                {
                  yield return new AjedrezBE.MOVIMIENTO_NORMAL(inicio, mov);
                }
                
                AjedrezBE.POSICION mov2 = mov + dir;
                if (!tab[inicio].Movida && PuedeMoverse(mov2, tab))
                {
                    yield return new AjedrezBE.MOVIMIENTO_DOBLEPEON(inicio, mov2);
                }
            }
        }

        private IEnumerable<AjedrezBE.MOVIMIENTO> MovimientosDiagonales(AjedrezBE.POSICION inicio, AjedrezBE.TABLERO tab)
        {
            AjedrezBE.DIRECCION direcc;
            if (tab[inicio].Blanca)
            {
                direcc = AjedrezBE.DIRECCION.Norte;
            }
            else
            {
                direcc = AjedrezBE.DIRECCION.Sur;
            }
            foreach (AjedrezBE.DIRECCION dir in new AjedrezBE.DIRECCION[] { AjedrezBE.DIRECCION.Oeste, AjedrezBE.DIRECCION.Este })
            {
                AjedrezBE.POSICION final = inicio + direcc + dir;
                using(AjedrezBLL.TABLERO tabbll = new TABLERO())
                {
                    if (final == tabbll.ObtenerPosicionPassant(!tab[inicio].Blanca, tab))
                    {
                        yield return new AjedrezBE.MOVIMIENTO_ENPASSANT(inicio, final);
                    }
                }
                

                if (PuedeCapturar(final, tab, inicio))
                {
                   if (final.Y == 0 || final.Y == 7)
                    {
                        foreach (AjedrezBE.MOVIMIENTO promov in MovimientosPromocion(inicio, final))
                        {
                            yield return promov;
                        }
                    }
                    else
                   {
                        yield return new AjedrezBE.MOVIMIENTO_NORMAL(inicio, final);
                   }
                }
            }
        }

        public override bool PuedeCapturarRey(AjedrezBE.POSICION inicio, AjedrezBE.TABLERO tab)
        {
            return MovimientosDiagonales(inicio, tab).Any(mov =>
            {
                AjedrezBE.PIEZA pieza = tab[mov.Final];
                return pieza != null && pieza.Tipo == AjedrezBE.TipoPieza.REY;
            });
        }

        private static IEnumerable<AjedrezBE.MOVIMIENTO> MovimientosPromocion(AjedrezBE.POSICION inicio, AjedrezBE.POSICION final)
        {
            yield return new AjedrezBE.MOVIMIENTO_PROMOCIONPEON(inicio, final, AjedrezBE.TipoPieza.CABALLO);
            yield return new AjedrezBE.MOVIMIENTO_PROMOCIONPEON(inicio, final, AjedrezBE.TipoPieza.ALFIL);
            yield return new AjedrezBE.MOVIMIENTO_PROMOCIONPEON(inicio, final, AjedrezBE.TipoPieza.TORRE);
            yield return new AjedrezBE.MOVIMIENTO_PROMOCIONPEON(inicio, final, AjedrezBE.TipoPieza.REINA);
        }

    }
}