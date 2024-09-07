using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AjedrezBE
{
    public class ALFIL : PIEZA
    {
        public ALFIL(bool blanca)
        {
            Tipo = TipoPieza.ALFIL;
            Blanca = blanca;
            Movida = false;

        }

        public static DIRECCION[] direcciones = new DIRECCION[]
        {
            DIRECCION.Noreste,
            DIRECCION.Noroeste,
            DIRECCION.Sureste,
            DIRECCION.Suroeste
        };

        public override PIEZA Copiar()
        {
            ALFIL copia = new ALFIL(Blanca);
            copia.Movida = Movida;
            return copia;
        }
    }
}