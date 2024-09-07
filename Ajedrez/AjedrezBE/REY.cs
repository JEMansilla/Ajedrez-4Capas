using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AjedrezBE
{
    public class REY : PIEZA
    {
        public REY(bool blanco)
        {
            Tipo = TipoPieza.REY;
            Blanca = blanco;
            Enroque = false;
            Movida = false;
        }

        private bool enroque;

		public bool Enroque
		{
			get { return enroque; }
			set { enroque = value; }
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
            REY copia = new REY(Blanca);
            copia.Movida = Movida;
            return copia;
        }
    }
}