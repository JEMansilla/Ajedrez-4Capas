using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AjedrezBLL
{
    public class REY : PIEZA
    {

        private bool TorreNoMovida(AjedrezBE.POSICION pos, AjedrezBE.TABLERO tab)
        {
            using(TABLERO tabbll = new TABLERO())
            {
                if(TABLERO.EstaVacio(tab,pos))
                {
                    return false;
                }

                AjedrezBE.PIEZA pieza = tab[pos];
                return pieza.Tipo == AjedrezBE.TipoPieza.TORRE && !pieza.Movida;

            }
            
        }

        private bool CaminoVacio(IEnumerable<AjedrezBE.POSICION> posiciones, AjedrezBE.TABLERO tab)
        {
            using (TABLERO tabbll = new TABLERO())
            {
                return posiciones.All(pos => TABLERO.EstaVacio(tab, pos));
            }
        }

        private bool PuedeEnroqueLadoRey(AjedrezBE.POSICION inicio, AjedrezBE.TABLERO tab)
        {
            if (tab[inicio].Movida)
            {
                return false;
            }
            AjedrezBE.POSICION posiciontorre = new AjedrezBE.POSICION(7, inicio.Y);
            AjedrezBE.POSICION[] posicionesintermedias = new AjedrezBE.POSICION[2];
            posicionesintermedias[0] = new AjedrezBE.POSICION(5,inicio.Y);
            posicionesintermedias[1] = new AjedrezBE.POSICION( 6,inicio.Y);
            return TorreNoMovida(posiciontorre, tab) && CaminoVacio(posicionesintermedias, tab);
        }

        private bool PuedeEnroqueLadoReina(AjedrezBE.POSICION inicio, AjedrezBE.TABLERO tab)
        {
            if (tab[inicio].Movida)
            {
                return false;
            }
            AjedrezBE.POSICION posiciontorre = new AjedrezBE.POSICION(0, inicio.Y);
            AjedrezBE.POSICION[] posicionesintermedias = new AjedrezBE.POSICION[3];
            posicionesintermedias[0] = new AjedrezBE.POSICION(1, inicio.Y);
            posicionesintermedias[1] = new AjedrezBE.POSICION(2, inicio.Y);
            posicionesintermedias[2] = new AjedrezBE.POSICION(3, inicio.Y);
            return TorreNoMovida(posiciontorre, tab) && CaminoVacio(posicionesintermedias, tab);
        }
        public override IEnumerable<AjedrezBE.MOVIMIENTO> ObtenerMovimientos(AjedrezBE.POSICION inicio, AjedrezBE.TABLERO tab)
        {
            foreach (AjedrezBE.POSICION final in MoverPosicion(inicio,tab))
            {
                yield return new AjedrezBE.MOVIMIENTO_NORMAL(inicio, final);
            }
            if (PuedeEnroqueLadoRey(inicio,tab))
            {
                yield return new AjedrezBE.MOVIMIENTO_ENROQUE(AjedrezBE.TipoMovimiento.EnroqueLadoRey, inicio);
            }
            if(PuedeEnroqueLadoReina(inicio,tab))
            {
                yield return new AjedrezBE.MOVIMIENTO_ENROQUE(AjedrezBE.TipoMovimiento.EnroqueLadoReina, inicio);
            }
        }

        private IEnumerable<AjedrezBE.POSICION> MoverPosicion(AjedrezBE.POSICION inicio, AjedrezBE.TABLERO tab)
        {
            foreach(AjedrezBE.DIRECCION dir in AjedrezBE.REY.direcciones)
            {
                AjedrezBE.POSICION final = inicio + dir;
                if(!TABLERO.ValidarPosicion(final))
                {
                    continue;
                }
                if(TABLERO.EstaVacio(tab,final) || tab[final].Blanca != tab[inicio].Blanca)
                {
                    yield return final;
                }
            }
        }

        public override bool PuedeCapturarRey(AjedrezBE.POSICION inicio, AjedrezBE.TABLERO tab)
        {
            return MoverPosicion(inicio, tab).Any(Final =>
            {
                AjedrezBE.PIEZA pieza = tab[Final];
                return pieza != null && pieza.Tipo == AjedrezBE.TipoPieza.REY;
            });
        }
    }
}