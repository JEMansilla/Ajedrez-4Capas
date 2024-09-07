using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AjedrezBLL
{
    public class CABALLO : PIEZA
    {
        public override IEnumerable<AjedrezBE.MOVIMIENTO> ObtenerMovimientos(AjedrezBE.POSICION inicio, AjedrezBE.TABLERO tab)
        {
            return MoverPosiciones(inicio, tab).Select(final => new AjedrezBE.MOVIMIENTO_NORMAL(inicio, final));
        }


        private static IEnumerable<AjedrezBE.POSICION> PosicionesPotenciales(AjedrezBE.POSICION inicio)
        {
            foreach (AjedrezBE.DIRECCION dir1 in new AjedrezBE.DIRECCION[] {AjedrezBE.DIRECCION.Norte,AjedrezBE.DIRECCION.Sur})
            { 
                foreach(AjedrezBE.DIRECCION dir2 in new AjedrezBE.DIRECCION[] {AjedrezBE.DIRECCION.Oeste, AjedrezBE.DIRECCION.Este})
                {
                    yield return inicio + 2 * dir1 + dir2;
                    yield return inicio + 2 * dir2 + dir1;
                }
            }
        }

        private IEnumerable<AjedrezBE.POSICION> MoverPosiciones(AjedrezBE.POSICION inicio, AjedrezBE.TABLERO tab)
        {
            return PosicionesPotenciales(inicio).Where(pos => TABLERO.ValidarPosicion(pos) && (TABLERO.EstaVacio(tab,pos) || tab[inicio].Blanca != tab[pos].Blanca));
        }
    }
}