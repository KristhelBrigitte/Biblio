using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Entidades;

namespace AccesoDatos
{
    public class ADEditorial
    {
        public string CadConexion { get; set; }

        public ADEditorial()
        {
            CadConexion =string.Empty;
        }

        public ADEditorial(string cad)
        {
            CadConexion = cad;
        }

        public bool editorialRepetida(EEditorial editorial)
        {
            bool result = false;
            string sentencia;
            sentencia = $"Select 1 From editorial Where editorial='{editorial.Nombre}'";

            SqlCommand comandoSQL = new SqlCommand();
            SqlConnection conexionSQL = new SqlConnection(CadConexion);
            SqlDataReader datos; 


        
            comandoSQL.Connection = conexionSQL;
            comandoSQL.CommandText = sentencia;

           
            try
            {
                conexionSQL.Open();
                datos = comandoSQL.ExecuteReader();
                result = datos.HasRows ? true : false;
                conexionSQL.Close();
               
            }
            catch (Exception)
            {
                throw new Exception("Se ha presentado un error realizando la consulta");
            }
          
            finally
            {
                comandoSQL.Dispose();
                conexionSQL.Dispose();
            }

            return result;
        }

        public bool claveEditorialRepetida(string clave)
        {
            bool result = false;
            object obEscalar;

            SqlCommand comando = new SqlCommand();
            SqlConnection conexion = new SqlConnection(CadConexion);
           
            comando.CommandText = "Select 1 from Editorial Where claveEditorial=@claveEditorial";
            comando.Parameters.AddWithValue("@claveEditorial", clave);
            comando.Connection = conexion;

            try
            {
                conexion.Open();
                obEscalar = comando.ExecuteScalar();

                if (obEscalar != null)
                    result = true;
                else
                    result = false;

                conexion.Close();

            }
            catch (Exception)
            {
                conexion.Close();
                throw new Exception("Error buscando la clave de Editorial");
            }
            
            finally
            {
                comando.Dispose();
                conexion.Dispose();
            }

            return result;
        }

        public EEditorial buscarRegistro(string condicion)
        {
            EEditorial editorial= new EEditorial();

            string sentencia = "Select claveEditorial,nombre From Editorial";

            sentencia = $"{sentencia} where {condicion}";


            SqlConnection conexion = new SqlConnection(CadConexion);
            SqlCommand comando = new SqlCommand(sentencia, conexion);
            SqlDataReader dato;

            try
            {
                conexion.Open();
                dato = comando.ExecuteReader();
                if (dato.HasRows)
                {
                    dato.Read();//
                    editorial.ClaveEditorial = dato.GetString(0);
                    editorial.Nombre = dato.GetString(1);
                 
                }

                conexion.Close();
            }
            catch (Exception)
            {
                throw new Exception("No se ha encontrado la Editorial");
            }
            finally
            {
                conexion.Dispose();
                comando.Dispose();
            }
            return editorial;
        }

        public DataTable listarTodos(string condicion)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter ad;
            SqlConnection conexion = new SqlConnection(CadConexion);
            string sentencia = "Select claveEditorial as Clave, nombre as Editorial from Editorial";
            if (!string.IsNullOrEmpty(condicion))
            {
                sentencia = $"{sentencia} Where {condicion}";
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

        public int insertar(EEditorial edit)
        {
            int result = -1;
            string sentencia = "Insert into Editorial(claveEditorial, nombre)" +
                " values(@claveEdit,@nom)";

            SqlConnection conexion = new SqlConnection(CadConexion);
            SqlCommand comando = new SqlCommand(sentencia, conexion);

            comando.Parameters.AddWithValue("@claveEdit", edit.ClaveEditorial);
            comando.Parameters.AddWithValue("@nom", edit.Nombre);
            try
            {
                conexion.Open();
                result = comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception)
            {
                conexion.Close();
                throw new Exception("No se ha logrado insertar la editorial");
            }
            finally
            {
                conexion.Dispose();
                comando.Dispose();
            }

            return result;
        }

        public int eliminar(string condicion)
        {
            int result = -1;
            string sentencia = $"Delete from Editorial where {condicion}";

            SqlConnection conexion = new SqlConnection(CadConexion);
            SqlCommand comando = new SqlCommand(sentencia, conexion);
            try
            {
                conexion.Open();
                result = comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception)
            {
                conexion.Close();
                throw new Exception("No se ha logrado eliminar la editorial");
            }
            finally
            {
                conexion.Dispose();
                comando.Dispose();
            }

            return result;
        }

        public int modificar(EEditorial editorial, string claveVieja = "")
        {
            int result = -1;
            string sentencia;

            SqlConnection conexion = new SqlConnection(CadConexion);
            SqlCommand comando = new SqlCommand();

            if (string.IsNullOrEmpty(claveVieja))
                sentencia = "Update Editorial set Nombre=@nombre, claveEditorial=@claveEditorial Where claveEditorial=@claveEditorial";
            else
                sentencia = $"Update Editorial set claveEditorial=@claveEditorial,Nombre=@nombre Where claveEditorial='{claveVieja}'";

            comando.Connection = conexion;
            comando.CommandText = sentencia;

            comando.Parameters.AddWithValue("@claveEditorial",editorial.ClaveEditorial);
            comando.Parameters.AddWithValue("@Nombre", editorial.Nombre);

   

            try
            {
                conexion.Open();
                result = comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception)
            {
                throw new Exception("Error Actualizando");
            }
            finally
            {
                comando.Dispose();
                conexion.Dispose();
            }
            return result;
        }
    }
}
