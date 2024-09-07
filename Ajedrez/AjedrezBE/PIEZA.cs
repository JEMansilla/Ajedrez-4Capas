using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AjedrezBE
{
    public abstract class PIEZA
    {
		private TipoPieza tipo;

		public TipoPieza Tipo
		{
			get { return tipo; }
			set { tipo = value; }
		}

		private bool blanca;

		public bool Blanca
		{
			get { return blanca; }
			set { blanca = value; }
		}

		private bool movida;

		public bool Movida
		{
			get { return movida; }
			set { movida = value; }
		}

		public abstract PIEZA Copiar();

	}
}