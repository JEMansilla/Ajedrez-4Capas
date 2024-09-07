using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AjedrezBE
{
    public class TORRE : PIEZA
    {
        public TORRE(bool blanca)
        {
            Tipo = TipoPieza.TORRE;
            Blanca = blanca;
            Movida = false;

        }

        public static DIRECCION[] direcciones = new DIRECCION[]
        {
            DIRECCION.Norte,
            DIRECCION.Sur,
            DIRECCION.Este,
            DIRECCION.Oeste
        };

        public override PIEZA Copiar()
        {
            TORRE copia = new TORRE(Blanca);
            copia.Movida = Movida;
            return copia;
        }
    }
}