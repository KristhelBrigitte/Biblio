using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace AccesoDatos
{
    public class ADEjemplar
    {
        public string CadConexion { get; set; }

        public ADEjemplar()
        {
            CadConexion = "";
        }

        public ADEjemplar(string cad)
        {
            CadConexion = cad;
        }

        public bool BuscarEditorial(string condicion)
        {
            bool result = false;
            object obEscalar;

         
            SqlCommand comando = new SqlCommand();
            SqlConnection conexion = new SqlConnection(CadConexion);
    
            comando.CommandText = "Select 1 from Ejemplar Where claveEditorial=@Editorial";
            comando.Parameters.AddWithValue("@Editorial", condicion);
            comando.Connection = conexion;


            try
            {
                conexion.Open();
                obEscalar = comando.ExecuteScalar();

                if (obEscalar != null)
                {
                    result = true;
                }
                 
                conexion.Close();

            }
            catch (Exception)
            {
                conexion.Close();
                throw new Exception("Error cargando los datos");
            }
            finally
            {
                comando.Dispose();
                conexion.Dispose();
            }

            return result;
        }

        public DataTable listarTodos(string condicion)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter ad;
            SqlConnection conexion = new SqlConnection(CadConexion);
            string sentencia = "Select EJ.claveEjemplar as claveEj, L.titulo as Titulol, C.descripcion as Condicion,E.descripcion as Estado, EJ.edicion as Edicion,  EJ.numeroPaginas as Paginas,ED.nombre as Editorial from Ejemplar EJ inner join Editorial ED On EJ.claveEditorial = ED.claveEditorial inner join Libro L On L.claveLibro = EJ.claveLibro inner join Condicion C On  C.claveCondicion = EJ.claveCondicion inner join Estado E On EJ.claveEstado = E.claveEstado";

            if (!string.IsNullOrEmpty(condicion))
            {
                sentencia += $" Where EJ.claveEditorial = '{condicion}'";
            } 
            try
            {
                ad = new SqlDataAdapter(sentencia, conexion);
                ad.Fill(dt);
            }
            catch (Exception)
            {

                throw new Exception("Se ha presentado algún error");
            }
            finally
            {
                conexion.Dispose();
            }
            return dt;
        }
    }
}
