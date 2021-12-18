using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
     public class EEjemplar
     {
        public string ClaveEjem { get; set; }
        public string ClaveLib { get; set; }
        public string ClaveCond { get; set; }
        public string ClaveEstado { get; set; }
        public string Edicion { get; set; }
        public string ClaveEditorial { get; set; }
        public int Paginas { get; set; }

        public EEjemplar()
        {
            ClaveEjem = string.Empty;
            ClaveLib = string.Empty;
            ClaveCond = string.Empty;
            ClaveEstado = string.Empty;
            Edicion = string.Empty;
            ClaveEditorial = string.Empty;
            Paginas = 0;
        }

        public EEjemplar(string claveEje, string claveLibro, string claveCondicion, string claveEst,
            string edi, string claveEdit, int pag)
        {
            ClaveEjem = claveEje;
            ClaveLib = claveLibro;
            ClaveCond = claveCondicion;
            ClaveEstado = claveEst;
            Edicion = edi;
            ClaveEditorial = claveEdit;
            Paginas = pag;
        }

     }
}
