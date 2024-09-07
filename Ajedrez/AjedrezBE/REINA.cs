using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AjedrezBE
{
    public class REINA : PIEZA
    {
        public REINA(bool blanca)
        {
            Tipo = TipoPieza.REINA;
            Blanca = blanca;
            Movida = false;

        }

        public static DIRECCION[] direcciones = new DIRECCION[]
        {
            DIRECCION.Noreste,
            DIRECCION.Noroeste,
            DIRECCION.Sureste,
            DIRECCION.Suroeste,
            DIRECCION.Norte,
            DIRECCION.Sur,
            DIRECCION.Este,
            DIRECCION.Oeste
    };

        public override PIEZA Copiar()
        {
            REINA copia = new REINA(Blanca);
            copia.Movida = Movida;
            return copia;
        }
    }
}