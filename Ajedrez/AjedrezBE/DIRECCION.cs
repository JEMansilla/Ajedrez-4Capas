using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AjedrezBE
{
    public class DIRECCION
    {
        public static DIRECCION Norte = new DIRECCION(0, 1);
        public static DIRECCION Sur = new DIRECCION(0, -1);
        public static DIRECCION Este = new DIRECCION(1, 0);
        public static DIRECCION Oeste = new DIRECCION(-1, 0);
        public static DIRECCION Noreste = Norte + Este;
        public static DIRECCION Noroeste = Norte + Oeste;
        public static DIRECCION Sureste = Sur + Este;
        public static DIRECCION Suroeste = Sur + Oeste;

        public int Fila;
        public int Columna;
        public DIRECCION(int x,int y)
        {
            Fila = y;
            Columna = x;
        }

        public static DIRECCION operator +(DIRECCION dir1, DIRECCION dir2)
        {
            return new DIRECCION(dir2.Columna + dir1.Columna, dir1.Fila + dir2.Fila);
        }

        public static DIRECCION operator *(int a, DIRECCION dir)
        {
            return new DIRECCION(a * dir.Columna, a * dir.Fila);
        }
        
    }
}