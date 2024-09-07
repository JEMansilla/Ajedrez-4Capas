using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace AjedrezBE
{
	public class JUEGO
	{
		public RESULTADO Resultado = null;
		public JUEGO(JUGADOR jugador, TABLERO tablero)
		{

			Turno = jugador;
			Tablero = tablero;
			jugadores = new JUGADOR[2];
			jugadores[0] = jugador;
		}

		public JUGADOR[] jugadores;
		

		public TABLERO Tablero;


		public JUGADOR Turno;

	}

	
}