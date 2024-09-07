using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AjedrezBE
{
    public class MOVIMIENTO_ENROQUE: MOVIMIENTO
    {
        public MOVIMIENTO_ENROQUE(TipoMovimiento tipo, POSICION posicionrey)
        {
            Tipo = tipo;
            Inicio = posicionrey;

            if(Tipo == TipoMovimiento.EnroqueLadoRey)
            {
                direccionrey = DIRECCION.Este;
                Final = new POSICION( 6,posicionrey.Y);
                torreinicio = new POSICION( 7, posicionrey.Y);
                torrefinal = new POSICION(5,posicionrey.Y);
            }    
            else if(Tipo == TipoMovimiento.EnroqueLadoReina)
            {
                direccionrey = DIRECCION.Oeste;
                Final = new POSICION( 2, posicionrey.Y);
                torreinicio = new POSICION( 0, posicionrey.Y);
                torrefinal = new POSICION( 3, posicionrey.Y);
            }
        }
        public DIRECCION direccionrey;
        public POSICION torreinicio;
        public POSICION torrefinal;
        
    }
}
