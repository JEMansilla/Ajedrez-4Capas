using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AjedrezBE
{
    public class CABALLO : PIEZA
    {
        public CABALLO(bool blanca)
        {
            Tipo = TipoPieza.CABALLO;
            Blanca = blanca;
            Movida = false;

        }

        public override PIEZA Copiar()
        {
            CABALLO copia = new CABALLO(Blanca);
            copia.Movida = Movida;
            return copia;
        }
    }
}