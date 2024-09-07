using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AjedrezDAL
{
    public abstract class MAPPER<T>:IDisposable
    {
        internal ACCESO acceso = new ACCESO();

        public abstract int Editar(T obj);
        public abstract int Borrar(T obj);
        public abstract List<T> Listar();

        public void Dispose()
        {
          GC.SuppressFinalize(this);
        }
    }
}