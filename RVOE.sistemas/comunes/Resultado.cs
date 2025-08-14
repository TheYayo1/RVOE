using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVOE.sistemas.comunes
{
    public class Resultado
    {
        public bool Error { get; set; } = false;
        public string Mensaje { get; set; } = string.Empty;
    }

    public class Resultado<T> : Resultado
    {
        public bool Error { get; set; } = false;
        public string Mensaje { get; set; } = "";
        public T? Datos { get; set; }
    }
}

