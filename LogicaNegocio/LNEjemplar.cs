using System;
using System.Collections.Generic;
using System.Text;
using AccesoDatos;
using System.Data;

namespace LogicaNegocio
{
    public class LNEjemplar
    {
        public string CadConexion{ get; set; }

        public LNEjemplar()
        {
            CadConexion = string.Empty;
        }

        public LNEjemplar(string cad)
        {
            CadConexion = cad;
        }

        public DataTable listarTodos(string condicion)
        {
            ADEjemplar adE = new ADEjemplar(CadConexion);
            try
            {
                return adE.listarTodos(condicion);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool buscarEditorial(string condicion)
        {
            ADEjemplar adE = new ADEjemplar(CadConexion);

            try
            {
                return adE.BuscarEditorial(condicion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
