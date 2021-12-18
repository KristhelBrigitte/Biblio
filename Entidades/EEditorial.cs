using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class EEditorial
    {

        public string ClaveEditorial { get; set; }
        public string Nombre { get; set; }
        public bool Existe { get; set; }

        public EEditorial()
        {
            ClaveEditorial = string.Empty;
            Nombre = string.Empty;
            Existe = false;
        }

        public EEditorial(string clavEdit, string nom, bool ex)
        {
            ClaveEditorial = clavEdit;
            Nombre = nom;
            Existe = ex;
        }
    }
}
