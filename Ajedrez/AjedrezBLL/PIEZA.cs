using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AjedrezBLL
{
    public abstract class PIEZA : IDisposable
    {
        public abstract IEnumerable<AjedrezBE.MOVIMIENTO> ObtenerMovimientos(AjedrezBE.POSICION inicio, AjedrezBE.TABLERO tab);
        protected IEnumerable<AjedrezBE.POSICION> MoverEnDireccion(AjedrezBE.POSICION inicio, AjedrezBE.TABLERO tab, AjedrezBE.DIRECCION dir)
        {
            for (AjedrezBE.POSICION pos = inicio + dir; TABLERO.ValidarPosicion(pos); pos += dir)
            {
                if (TABLERO.EstaVacio(tab, pos))
                {
                    yield return pos;
                    continue;
                }

                AjedrezBE.PIEZA pieza = tab[pos];
                if (pieza.Blanca != tab[inicio].Blanca)
                {
                    yield return pos;
                }
                yield break;
            }

        }

        protected IEnumerable<AjedrezBE.POSICION> MoverEnDireccion(AjedrezBE.POSICION inicio, AjedrezBE.TABLERO tab, AjedrezBE.DIRECCION[] dirs)
        {
            return dirs.SelectMany(dir => MoverEnDireccion(inicio, tab, dir));
        }

        public virtual bool PuedeCapturarRey(AjedrezBE.POSICION inicio, AjedrezBE.TABLERO tab)
        {
            return ObtenerMovimientos(inicio, tab).Any(mov =>
            {
                AjedrezBE.PIEZA pieza = tab[mov.Final];
                return pieza != null && pieza.Tipo == AjedrezBE.TipoPieza.REY;
            });
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}