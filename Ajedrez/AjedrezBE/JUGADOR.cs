using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AjedrezBE
{
    public class JUGADOR
    {
		private int id;

		public int Id
		{
			get { return id; }
			set { id = value; }
		}

		private string nombre;

		public string Nombre
		{
			get { return nombre; }
			set { nombre = value; }
		}

		private bool usablancos;

		public bool Usablancos
		{
			get { return usablancos; }
			set { usablancos = value; }
		}

		private int victorias;

		public int Victorias
		{
			get { return victorias; }
			set { victorias = value; }
		}

		private int derrotas;

		public int Derrotas
		{
			get { return derrotas; }
			set { derrotas = value; }
		}

		private decimal promedio;

		public decimal Promedio
		{
			get { return promedio; }
			set { promedio = value; }
		}

		private decimal horasjugadas;

		public decimal HorasJugadas
		{
			get { return horasjugadas; }
			set { horasjugadas = value; }
		}

		private int empates;

		public int Empates
		{
			get { return empates; }
			set { empates = value; }
		}


	}
}