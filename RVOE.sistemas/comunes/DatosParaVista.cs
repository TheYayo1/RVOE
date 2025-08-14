using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVOE.sistemas.comunes
{
    public class DatosParaVista<T> : Resultado<T>
    {
        /// <summary>
        /// Puede contener el id sobre el cual se obtuvo el resultado en DATOS
        /// </summary>
        public object? Id { get; set; }
        /// <summary>
        /// Se usa para indicarle a la vista si el usuario tiene permisos de lectura
        /// </summary>
        public bool TienePermisoDeLectura { get; set; }
        /// <summary>
        /// se usa para indicarle a la vista el usuario tiene permisos de escritura
        /// ej: habilitar los botones de nuevo o edicion
        /// </summary>
        public bool TienePermisoDeEscritura { get; set; }

        public bool TienePermisoParaVer { get; set; }
        public bool TienePermisoParaAgregar { get; set; }
        public bool TienePermisoParaEditar { get; set; }
        public bool TienePermisoParaEliminar { get; set; }
        public bool TienePermisoParaImprimir { get; set; }

        public int MaximoDeRegistros { get; set; }
        /// <summary>
        /// indica a la vista el numero de pagina activa empezando en cero
        /// </summary>
        public int Pagina { get; set; }
        /// <summary>
        /// patron de busqueda que se envia para filtrar los resultados por un texto especifico
        /// </summary>
        public string PatronDeBusqueda { get; set; } = string.Empty;
        /// <summary>
        /// indicar aqui el valor equivalente en la enumeracion respectiva de la clase para especificar la o las columnas por las cuales se ordenan los datos
        /// </summary>
        public int Orden { get; set; }
        /// <summary>
        /// indica el numero total de registros del conjunto de datos (todas las paginas)
        /// </summary>
        public int TotalDeRegistros { get; set; }
        /// <summary>
        /// Es el numero de registro inicial de la pagina actual
        /// </summary>
        public int RegistroInicial => Pagina == 0 ? 1 : Pagina * MaximoDeRegistros + 1;
        /// <summary>
        /// Numero de paginas calculadas con base en el numero de registros obtenidos
        /// </summary>
        public int Paginas => TotalDeRegistros <= MaximoDeRegistros || MaximoDeRegistros <= 0 ? 1 : (int)Math.Ceiling(TotalDeRegistros / (decimal)MaximoDeRegistros);
    }

    public class DatosParaVista : DatosParaVista<Object>
    {

    }
}

