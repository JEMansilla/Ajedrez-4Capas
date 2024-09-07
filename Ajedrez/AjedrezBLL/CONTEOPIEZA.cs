using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AjedrezBLL
{
    public class CONTEOPIEZA:IDisposable
    {
        public void Incrementar (bool Color, AjedrezBE.TipoPieza tipo, AjedrezBE.CONTEOPIEZA cont)
        {
            if(Color == true)
            {
                cont.ConteoBlancas[tipo]++;
            }
            else if (Color == false)
            {
                cont.ConteoNegras[tipo]++;
            }
            cont.Total++;
        }

        public int Blancas(AjedrezBE.TipoPieza tipo, AjedrezBE.CONTEOPIEZA cont)
        {
            return cont.ConteoBlancas[tipo];
        }

        public int Negras(AjedrezBE.TipoPieza tipo, AjedrezBE.CONTEOPIEZA cont)
        {
            return cont.ConteoNegras[tipo];
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }

    
        
}

