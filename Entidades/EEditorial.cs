using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class EEditorial
    {

        public string ClaveEditorial { get; set; }
        public string Nombre { get; set; }

        public EEditorial()
        {
            ClaveEditorial = string.Empty;
            Nombre = string.Empty;
        }

        public EEditorial(string clavEdit, string nom)
        {
            ClaveEditorial = clavEdit;
            Nombre = nom;
        }
    }
}
