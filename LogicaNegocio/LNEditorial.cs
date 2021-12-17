using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using AccesoDatos;
using System.Data;

namespace LogicaNegocio
{
    public class LNEditorial
    {

        private string mensaje;
        private string cadConexion;

        #region Constructores

        public LNEditorial()
        {
            mensaje = string.Empty;
            cadConexion = string.Empty;
        }

        public LNEditorial(string cadena)
        {
            mensaje = string.Empty;
            cadConexion = cadena;
        }

        #endregion

        #region Metodos

        public bool editorialRepetido(EEditorial editorial)
        {
            bool result = false;
            ADEditorial adEditorial = new ADEditorial(cadConexion);

            try
            {
                result = adEditorial.editorialRepetida(editorial);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public bool claveEditorialRepetida(string clave)
        {
            bool result = false;
            ADEditorial adEditorial = new ADEditorial(cadConexion);

            try
            {
                result = adEditorial.claveEditorialRepetida(clave);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public int insertar(EEditorial editorial)
        {
            int result;
            ADEditorial adEditorial = new ADEditorial(cadConexion);

            try
            {
                result = adEditorial.insertar(editorial);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public DataTable listarTodos(string condicion = "")
        {
            DataTable dt;
            ADEditorial adEditorial = new ADEditorial(cadConexion);

            try
            {
                dt= adEditorial.listarTodos(condicion);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return dt ;
        }



        public EEditorial buscarRegistro(string condicion)
        {
            EEditorial editorial;
            ADEditorial adEdit = new ADEditorial(cadConexion);


            try
            {
                editorial = adEdit.buscarRegistro(condicion);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return editorial;
        }


        public int eliminar(string claveEditorial)
        {
            int result;
            ADEditorial adEdit = new ADEditorial(cadConexion);

            try
            {
                result = adEdit.eliminar(claveEditorial);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

  
        public int modificar(EEditorial editorial, string claveVieja = "")
        {
            int result;

            ADEditorial adE = new ADEditorial(cadConexion);

            try
            {
                result = adE.modificar(editorial, claveVieja);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }


     
        /*
        public DataTable listarTodos(string condicion,string desdeVista)
        {
            DataTable dt;
            ADEditorial adEdit = new ADEditorial(cadConexion);

            try
            {
                dt = adEdit.listarTodos(condicion);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return setLibros;
        }*/





        #endregion

    }
}
