using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public abstract class Conexion : IDisposable
    {
        public Conexion(string key)
        {
            if (string.IsNullOrEmpty(Cadena))
                Cadena = System.Configuration.ConfigurationManager.ConnectionStrings[key]?.ConnectionString;
        }

        public static string Cadena { get; set; }

        public void Dispose()
        {

        }
    }
}
