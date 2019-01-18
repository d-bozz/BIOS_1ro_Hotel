using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EntidadesCompartidas;

namespace Persistencia
{
    public class PersistenciaAdministradores
    {

        public static List<Usuario> ListarAdministradores()
        {
            List<Usuario> ListaUsuarios = new List<Usuario>();
            SqlConnection cnn = new SqlConnection(Constantes.CONEXION);
            try
            {
                 Administrador admin = null;
                SqlCommand cmd = new SqlCommand("ListarAdmin", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cnn.Open();
                SqlDataReader lector = cmd.ExecuteReader();
                while (lector.Read())
                {
                    admin = new Administrador((string)lector[0], (string)lector[1], (string)lector[2], (string)lector[3]);
                    ListaUsuarios.Add(admin);
                }
                lector.Close();
                return ListaUsuarios;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            { cnn.Close(); }
        }

        public static Administrador Buscar(string pUsuario)
        {
            SqlConnection cnn = new SqlConnection(Constantes.CONEXION);
            try
            {
                Administrador admin = null;
                SqlCommand cmd = new SqlCommand("BuscarAdministrador", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@usuario", pUsuario);
               
                cnn.Open();
                SqlDataReader lector = cmd.ExecuteReader();
                if (lector.Read())
                {
                    
                    string usuario = (string)lector[0];
                    string contraseña = (string)lector[1];
                    string nombre = (string)lector[2];
                    string cargo = (string)lector[3];
                    
                    admin = new Administrador(usuario, contraseña, nombre, cargo);
                }
                return admin;
            }
            catch (Exception ex)
            { throw ex; }
            finally
            { cnn.Close(); }
        }

        public static void Modificar(Administrador admin)
        {
            SqlConnection cnn = new SqlConnection(Constantes.CONEXION);
            try
            {
                SqlCommand cmd = new SqlCommand("ModificarAdministrador", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@usuario", admin.Name);
                cmd.Parameters.AddWithValue("@contraseña", admin.Contraseña);
                cmd.Parameters.AddWithValue("@nombreCompleto", admin.NombreCompleto);
                cmd.Parameters.AddWithValue("@cargo", admin.Cargo);


                

                SqlParameter prmRetorno = new SqlParameter();
                prmRetorno.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(prmRetorno);
                cnn.Open();
                cmd.ExecuteNonQuery();
                int valorRetorno = (int)prmRetorno.Value;
                if (valorRetorno == -1)
                    throw new Exception("No se existe un administrador: " + admin.Name);
                if (valorRetorno == -2)
                    throw new Exception("El usuario " + admin.Name + " corresponde a un CLIENTE");
                if (valorRetorno == -6)
                    throw new Exception("Error de SQL");
            }
            catch (Exception ex)
            { throw ex; }
            finally
            { cnn.Close(); }
        }

        public static void Agregar(Administrador admin)
        {
            SqlConnection cnn = new SqlConnection(Constantes.CONEXION);
            try
            {
                SqlCommand cmd = new SqlCommand("AgregarAdministrador", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@usuario", admin.Name);
                cmd.Parameters.AddWithValue("@contraseña", admin.Contraseña);
                cmd.Parameters.AddWithValue("@nombreCompleto", admin.NombreCompleto);
                cmd.Parameters.AddWithValue("@cargo", admin.Cargo);
                SqlParameter prmRetorno = new SqlParameter();
                prmRetorno.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(prmRetorno);
                cnn.Open();
                cmd.ExecuteNonQuery();
                int valorRetorno = (int)prmRetorno.Value;
                if (valorRetorno == -1)
                    throw new Exception("Ya se encuentra el usuario "+ admin.Name + " en la base de datos.");
                if (valorRetorno == -6)
                    throw new Exception("Error de SQL");
            }
            catch (Exception ex)
            { throw ex; }
            finally
            { cnn.Close(); }
        }

        public static void Eliminar(string pUsuario)
        {
            SqlConnection cnn = new SqlConnection(Constantes.CONEXION);
            try
            {
                SqlCommand cmd = new SqlCommand("EliminarAdministrador", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@usuario", pUsuario);
                SqlParameter prmRetorno = new SqlParameter();
                prmRetorno.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(prmRetorno);
                cnn.Open();
                cmd.ExecuteNonQuery();
                int valorRetorno = (int)prmRetorno.Value;
                if (valorRetorno == -1)
                    throw new Exception("No se existe un administrador" + pUsuario);
                if (valorRetorno == -2)
                    throw new Exception("El usuario " + pUsuario + " corresponde a un cliente.");
                if (valorRetorno == -3)
                    throw new Exception("Error de SQL");

            }
            catch (Exception ex)
            { throw ex; }
            finally
            { cnn.Close(); }
        }

        public static Administrador Logueo(string pUsu, string pName)
        {
            //variables
            SqlConnection cnn = new SqlConnection(Constantes.CONEXION);
            SqlCommand _comando = new SqlCommand("LogueoAdministrador", cnn);
            _comando.CommandType = CommandType.StoredProcedure;
            Administrador unAdmin = null;

            //parametros
            _comando.Parameters.AddWithValue("@usuario", pUsu);
            _comando.Parameters.AddWithValue("@contraseña", pName);

            try
            {
                cnn.Open();
                SqlDataReader _lector = _comando.ExecuteReader();
                if (_lector.HasRows)
                {
                    _lector.Read();
                    unAdmin = new Administrador((string)_lector["name"], (string)_lector["contraseña"], (string)_lector["nombreCompleto"], (string)_lector["cargo"]);
                }
                _lector.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cnn.Close();
            }
            return unAdmin;
        }


    }
}
