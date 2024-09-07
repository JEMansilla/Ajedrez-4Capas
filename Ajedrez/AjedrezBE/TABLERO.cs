using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AjedrezBE
{
    public class TABLERO
    {

        private PIEZA[,] cuadrados = new PIEZA[8,8];

        public Dictionary<bool, POSICION> posicionespassantporcolor = new Dictionary<bool, POSICION>
        {
            {true,null },
            {false,null }
        };
        

        public PIEZA this[int x, int y]
        {
            get { return cuadrados[x,y]; }
            set { cuadrados[x,y] = value; }
        }
        public PIEZA this[POSICION pos]
        {
            get { return this[pos.X,pos.Y]; }
            set { this[pos.X,pos.Y] = value; }
        }

       
    }
}