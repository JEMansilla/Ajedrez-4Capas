using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AjedrezDAL
{
    public class BD:IDisposable
    {
        internal ACCESO acceso = new ACCESO();

        public void Backup()
        {
            string carpetaproyecto = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string rutabackup = Path.Combine(carpetaproyecto, "AjedrezBD.bak");
            string sql = "BACKUP DATABASE AjedrezBD TO DISK = '"+ rutabackup + "'";
            acceso.AbrirConexion();
            acceso.Escribir(sql);
            acceso.CerrarConexion();
        }

        public void Restore()
        {
            string carpetaproyecto = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string rutarestore = Path.Combine(carpetaproyecto, "AjedrezBD.bak");
            string sql = "RESTORE DATABASE AjedrezBD FROM DISK = '" + rutarestore + "' WITH REPLACE";
            acceso.AbrirConexion();
            acceso.Escribir(sql);
            acceso.CerrarConexion();
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
