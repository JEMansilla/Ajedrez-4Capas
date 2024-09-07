using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AjedrezBE
{
    public class PEON : PIEZA
    {
        public PEON(bool blanca)
        {
            Tipo = TipoPieza.PEON;
            Blanca = blanca;

            Movida = false;
            if(blanca)
            {
                adelante = DIRECCION.Norte;
            }
            else
            {
                adelante = DIRECCION.Sur;
            }
        }

        public DIRECCION adelante;

        public override PIEZA Copiar()
        {
            PEON copia = new PEON(Blanca);
            copia.Movida = Movida;
            return copia;
        }
    }
}