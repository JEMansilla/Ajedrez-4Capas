using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AjedrezBE
{
    public class MOVIMIENTO
    {

		public TipoMovimiento Tipo;
		private POSICION inicio;

		public POSICION Inicio
		{
			get { return inicio; }
			set { inicio = value; }
		}

		private POSICION final;

		public POSICION Final
		{
			get { return final; }
			set { final = value; }
		}


	}
}