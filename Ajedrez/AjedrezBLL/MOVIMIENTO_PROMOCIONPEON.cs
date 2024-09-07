using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace AjedrezBLL
{
    public class MOVIMIENTO_PROMOCIONPEON:MOVIMIENTO
    {
        private AjedrezBE.PIEZA CrearPiezaPromovida(AjedrezBE.MOVIMIENTO_PROMOCIONPEON mov, AjedrezBE.PIEZA pieza)
        {
            if(mov.nuevapieza == AjedrezBE.TipoPieza.TORRE)
            {
                return new AjedrezBE.TORRE(pieza.Blanca);
            }
            else if(mov.nuevapieza == AjedrezBE.TipoPieza.ALFIL)
            {
                return new AjedrezBE.ALFIL(pieza.Blanca);
            }
            else if(mov.nuevapieza == AjedrezBE.TipoPieza.CABALLO)
            {
                return new AjedrezBE.CABALLO(pieza.Blanca);
            }
            else
            {
                return new AjedrezBE.REINA(pieza.Blanca);
            }
        }

        public override void Ejecutar(AjedrezBE.MOVIMIENTO mov, AjedrezBE.TABLERO tab)
        {
            if (mov is AjedrezBE.MOVIMIENTO_PROMOCIONPEON)
            {
                AjedrezBE.MOVIMIENTO_PROMOCIONPEON movpromocion = (AjedrezBE.MOVIMIENTO_PROMOCIONPEON)mov;
                AjedrezBE.PIEZA peon = tab[mov.Inicio];
                tab[mov.Inicio] = null;

                AjedrezBE.PIEZA piezapromocion = CrearPiezaPromovida(movpromocion, peon);


                piezapromocion.Movida = true;
                tab[mov.Final] = piezapromocion;
            }
        }
    }
}
