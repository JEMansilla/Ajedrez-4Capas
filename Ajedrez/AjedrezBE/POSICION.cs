using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AjedrezBE
{
    public class POSICION
    {
		public POSICION(int x, int y)
		{
			X = x;
			Y = y;
		}
		private int x;

		public int X
		{
			get { return x; }
			set { x = value; }
		}
		private int y;

		public int Y
		{
			get { return y; }
			set { y = value; }
		}

		public static POSICION operator +(POSICION pos, DIRECCION dir)
		{
			return new POSICION(pos.X + dir.Columna, pos.Y + dir.Fila);
		}

		public static bool operator ==(POSICION left, POSICION right)
		{
			return EqualityComparer<POSICION>.Default.Equals(left, right);
		}

		public static bool operator !=(POSICION left, POSICION right)
		{
			return !(left == right);
		}

		public override bool Equals(object obj)
		{
			return obj is POSICION pOSICION &&
				   X == pOSICION.X &&
				   Y == pOSICION.Y;
		}

		public override int GetHashCode()
		{
			int hashCode = 1861411795;
			hashCode = hashCode * -1521134295 + X.GetHashCode();
			hashCode = hashCode * -1521134295 + Y.GetHashCode();
			return hashCode;
		}


	}
}