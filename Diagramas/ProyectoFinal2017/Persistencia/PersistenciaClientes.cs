using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EntidadesCompartidas;

namespace Persistencia
{
    public class PersistenciaClientes
    {
        public static List<Usuario> ListarClientes()
        {
            List<Usuario> ListarClientes = new List<Usuario>();
            SqlConnection cnn = new SqlConnection(Constantes.CONEXION);
            try
            {
                Cliente cli = null;
                List<int> Telefonos = new List<int>(); //VER ** falta implementar que agrege los telefonos

                SqlCommand cmd = new SqlCommand("ListarClientes", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cnn.Open();
                SqlDataReader lector = cmd.ExecuteReader();
                while (lector.Read())
                {
                    // u.name, u.contraseña, u.nombreCompleto, c.direccion, c.tarjeta
                    cli = new Cliente((string)lector[0], (string)lector[1], (string)lector[2], (string)lector[4], (string)lector[3], Telefonos);
                    ListarClientes.Add(cli);
                }
                lector.Close();
                return ListarClientes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            { cnn.Close(); }
        }


        public static Cliente Buscar(string pUsuario)
        {
            SqlConnection cnn = new SqlConnection(Constantes.CONEXION);
            try
            {
                List<int> Telefonos = new List<int>();
                Cliente cli = null;
                SqlCommand cmd = new SqlCommand("BuscarCliente", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@usuario", pUsuario);

                cnn.Open();
                SqlDataReader lector = cmd.ExecuteReader();
                if (lector.Read())
                {
                    string usuario = (string)lector[0];
                    string contraseña = (string)lector[1];
                    string nombre = (string)lector[2];
                    string direccion = (string)lector[3];
                    string tarjeta = (string)lector[4];
                    cli = new Cliente(usuario, contraseña, nombre, tarjeta, direccion, Telefonos);
                }

                lector.Close();
                cnn.Close();

                cmd = new SqlCommand("ListarTelefonosPorCliente", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("user", pUsuario);

                cnn.Open();
                {
                    lector = cmd.ExecuteReader();
                    while (lector.Read())
                    {
                        cli.AgregarTelefonoExtra((int)lector[1]);
                    }
                }
                return cli;
            }
            catch (Exception ex)
            { throw ex; }
            finally
            { cnn.Close(); }
        }

        public static void Agregar(Cliente cli)
        {
            SqlConnection cnn = new SqlConnection(Constantes.CONEXION);
            try
            {
                SqlCommand cmd = new SqlCommand("AgregarCliente", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@usuario", cli.Name);
                cmd.Parameters.AddWithValue("@contraseña", cli.Contraseña);
                cmd.Parameters.AddWithValue("@nombreCompleto", cli.NombreCompleto);
                cmd.Parameters.AddWithValue("@tarjeta", cli.Tarjeta);
                cmd.Parameters.AddWithValue("@direccion", cli.Direccion);
                SqlParameter prmRetorno = new SqlParameter();
                prmRetorno.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(prmRetorno);
                cnn.Open();
                cmd.ExecuteNonQuery();
                int valorRetorno = (int)prmRetorno.Value;
                if (valorRetorno == -1)
                    throw new Exception("Ya se encuentra el usuario " + cli.Name + " en la base de datos.");
                if (valorRetorno == -6)
                    throw new Exception("Error de SQL");

                for (int i = 0; cli.Telefonos.Count > i; i++)
                {
                    cmd = new SqlCommand("AgregarTelefono", cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    prmRetorno = new SqlParameter();
                    prmRetorno.Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(prmRetorno);
                    cmd.Parameters.AddWithValue("@name", cli.Name);
                    cmd.Parameters.AddWithValue("@telefono", cli.Telefonos[i]);
                    //cnn.Open();
                    cmd.ExecuteNonQuery();
                    valorRetorno = (int)prmRetorno.Value;
                    //if (valorRetorno == -1)
                    //throw new Exception("La cuenta: " + cli.Name + " ya tiene agendado el numero: " + cli.Telefonos[i]);
                    if (valorRetorno == -6)
                        throw new Exception("Error de SQL");
                }
            }
            catch (Exception ex)
            { throw ex; }
            finally
            { cnn.Close(); }
        }

        public static Cliente Logueo(string pUsu, string pName)
        {
            //variables
            SqlConnection cnn = new SqlConnection(Constantes.CONEXION);
            SqlCommand _comando = new SqlCommand("LogueoCliente", cnn);
            _comando.CommandType = CommandType.StoredProcedure;
            Cliente unCli = null;
            List<int> Telefonos = new List<int>();

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
                    //SELECT u.name, u.contraseña, u.nombreCompleto, C.tarjeta, C.direccion
                    string usuario = (string)_lector["name"];
                    string contraseña = (string)_lector["contraseña"];
                    string nombre = (string)_lector["nombreCompleto"];
                    string tarjeta = (string)_lector["tarjeta"];
                    string direccion = (string)_lector["direccion"];
                    unCli = new Cliente(usuario, contraseña, nombre, tarjeta, direccion, Telefonos);
                }
                _lector.Close();
                if (unCli != null)
                {
                    _comando = new SqlCommand("ListarTelefonosPorCliente", cnn);
                    _comando.CommandType = CommandType.StoredProcedure;
                    _comando.Parameters.AddWithValue("@user", pUsu);
                    _lector = _comando.ExecuteReader();
                    while (_lector.Read())
                    {
                        Telefonos.Add((int)_lector[1]);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cnn.Close();
            }
            return unCli;
        }




        public static void AgregarTelefono(Cliente pCli, int pTel)
        {
            SqlConnection cnn = new SqlConnection(Constantes.CONEXION);
            try
            {
                SqlCommand cmd = new SqlCommand("AgregarTelefono", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter prmRetorno = new SqlParameter();
                prmRetorno.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(prmRetorno);
                cmd.Parameters.AddWithValue("@name", pCli.Name);
                cmd.Parameters.AddWithValue("@telefono", pTel);
                cnn.Open();
                cmd.ExecuteNonQuery();
                int valorRetorno = (int)prmRetorno.Value;
                if (valorRetorno == -1)
                    throw new Exception("La cuenta: " + pCli.Name + " ya tiene agendado el numero: " + pTel);
                if (valorRetorno == -6)
                    throw new Exception("Error de SQL");

            }
            catch (Exception ex)
            { throw ex; }
            finally
            { cnn.Close(); }
        }
    }
}
