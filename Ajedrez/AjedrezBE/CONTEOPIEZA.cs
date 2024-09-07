using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AjedrezBE
{
    public class CONTEOPIEZA
    {
        public CONTEOPIEZA()
        {
            foreach(TipoPieza tipo in Enum.GetValues(typeof(TipoPieza)))
            {
                ConteoBlancas[tipo] = 0;
                ConteoNegras[tipo] = 0;
            }
        }
        public Dictionary<TipoPieza, int> ConteoBlancas = new Dictionary<TipoPieza, int>();
        public Dictionary<TipoPieza, int> ConteoNegras = new Dictionary<TipoPieza, int>();

        public int Total;
    }
}
