using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace AjedrezBLL
{
    public class POSICION:IDisposable
    {
		public bool DeterminarColor(AjedrezBE.POSICION pos)
        {
            if((pos.X + pos.Y) % 2 ==0)
            {
                return true;
            }
            return false;
            
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}