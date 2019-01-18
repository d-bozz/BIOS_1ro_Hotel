using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EntidadesCompartidas;

namespace Persistencia
{
    public class PersistenciaReservas
    {
        public static void RealizarRes(Reserva res)
        {
            SqlConnection cnn = new SqlConnection(Constantes.CONEXION);
            try
            {
                SqlCommand cmd = new SqlCommand("RealizarReserva", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombreHotel", res.Habitacion.Hotel.NombreHotel);
                cmd.Parameters.AddWithValue("@nroHabitacion", res.Habitacion.NroHabitacion);
                cmd.Parameters.AddWithValue("@name", res.Cliente.Name);
                cmd.Parameters.AddWithValue("@fechaInicio", res.FechaInicio);
                cmd.Parameters.AddWithValue("@fechaFin", res.FechaFin);
                cmd.Parameters.AddWithValue("@estadoActual", res.EstadoActual);
                SqlParameter prmRetorno = new SqlParameter();
                prmRetorno.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(prmRetorno);

                cnn.Open();
                cmd.ExecuteNonQuery();
                int valorRetorno = (int)prmRetorno.Value;
                if (valorRetorno == -2)
                    throw new Exception("No pueden haber reservas que duren menos de un dia.");
                if (valorRetorno == -4)
                    throw new Exception("No esta el usuario");
                if (valorRetorno == -1)
                    throw new Exception("No esta el hotel que me pidieron");
                if (valorRetorno == -3)
                    throw new Exception("No esta la habitacion");
                if (valorRetorno == -5)
                    throw new Exception("Lo siento, no se encuentra disponible");
                if (valorRetorno == -6)
                    throw new Exception("Error SQL, contacte con el Administrador del sistema.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            { cnn.Close(); }



        }

        public static List<Reserva> ListarReservas()  
        {
            List<Reserva> ListarReservas = new List<Reserva>();
            SqlConnection cnn = new SqlConnection(Constantes.CONEXION);
            try
            {
                SqlCommand cmd = new SqlCommand("ListarReservas", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cnn.Open();
                SqlDataReader lector = cmd.ExecuteReader();
                while (lector.Read())
                {
                    Hotel hotel = PersistenciaHoteles.Buscar((string)lector[0]);            
                    Habitacion hab = PersistenciaHabitaciones.Buscar(hotel, (int)lector[1]);
                    Cliente cli = PersistenciaClientes.Buscar((string)lector[2]);           
                    Reserva res = new Reserva(hab, cli, (DateTime)lector[3], (DateTime)lector[4], (string)lector[5], (int)lector[6]);
                    ListarReservas.Add(res);
                }
                return ListarReservas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            { cnn.Close(); }
        }

        public static List<Reserva> ListarReservasActivas()  
        {
            List<Reserva> ListarReservas = new List<Reserva>();
            SqlConnection cnn = new SqlConnection(Constantes.CONEXION);
            try
            {
                SqlCommand cmd = new SqlCommand("ListarReservasActivas", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cnn.Open();
                SqlDataReader lector = cmd.ExecuteReader();
                while (lector.Read())
                {
                    Hotel hotel = PersistenciaHoteles.Buscar((string)lector[0]);            
                    Habitacion hab = PersistenciaHabitaciones.Buscar(hotel, (int)lector[1]);
                    Cliente cli = PersistenciaClientes.Buscar((string)lector[2]);           
                    Reserva res = new Reserva(hab, cli, (DateTime)lector[3], (DateTime)lector[4], (string)lector[5], (int)lector[6]);
                    ListarReservas.Add(res);
                }
                return ListarReservas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            { cnn.Close(); }
        }

        public static List<Reserva> ListarReservasPorCliente(Usuario pUser) 
        {
            SqlConnection cnn = new SqlConnection(Constantes.CONEXION);
            try
            {
                List<Reserva> lista = new List<Reserva>();
                SqlCommand cmd = new SqlCommand("ListarReservasPorCliente", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", pUser.Name);
                cnn.Open();
                SqlDataReader lector = cmd.ExecuteReader();
                while (lector.Read())
                {
                    Hotel hotel = PersistenciaHoteles.Buscar((string)lector[0]);            
                    Habitacion hab = PersistenciaHabitaciones.Buscar(hotel, (int)lector[1]);
                    Cliente cli = PersistenciaClientes.Buscar((string)lector[2]);           

                    Reserva res = new Reserva(hab, cli, (DateTime)lector[3], (DateTime)lector[4], (string)lector[5], (int)lector[6]);
                    lista.Add(res);
                }

                return lista;
            }
            catch (Exception ex)
            { throw ex; }
            finally { cnn.Close(); }

        }

        public static List<Reserva> ListarReservasActivasPorCliente(Usuario pUser)
        {
            SqlConnection cnn = new SqlConnection(Constantes.CONEXION);
            try
            {
                List<Reserva> lista = new List<Reserva>();
                SqlCommand cmd = new SqlCommand("ListarReservasActivasPorCliente", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", pUser.Name);
                cnn.Open();
                SqlDataReader lector = cmd.ExecuteReader();
                while (lector.Read())
                {
                    Hotel hotel = PersistenciaHoteles.Buscar((string)lector[0]);
                    Habitacion hab = PersistenciaHabitaciones.Buscar(hotel, (int)lector[1]);
                    Cliente cli = PersistenciaClientes.Buscar((string)lector[2]);

                    Reserva res = new Reserva(hab, cli, (DateTime)lector[3], (DateTime)lector[4], (string)lector[5], (int)lector[6]);
                    lista.Add(res);
                }

                return lista;
            }
            catch (Exception ex)
            { throw ex; }
            finally { cnn.Close(); }

        }

        public static void Eliminar(int id)
        {
            SqlConnection cnn = new SqlConnection(Constantes.CONEXION);
            try
            {
                SqlCommand cmd = new SqlCommand("EliminarReserva", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                //Agrego los parámetros con sus valores
                cmd.Parameters.AddWithValue("@id", id);
                
                SqlParameter prmRetorno = new SqlParameter();
                prmRetorno.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(prmRetorno);
                cnn.Open();
                cmd.ExecuteNonQuery();
                int valorRetorno = (int)prmRetorno.Value;
                if (valorRetorno == -1)
                    throw new Exception("No se existe un id con ese numero: " + id);
                if (valorRetorno == -2)
                    throw new Exception("Error de SQL");

            }
            catch (Exception ex)
            { throw ex; }
            finally
            { cnn.Close(); }
        }

        public static void Finalizar(Reserva r)
        {
            SqlConnection cnn = new SqlConnection(Constantes.CONEXION);
            try
            {
                SqlCommand cmd = new SqlCommand("FinalizarReserva", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", r.Id);
                SqlParameter prmRetorno = new SqlParameter();
                prmRetorno.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(prmRetorno);
                cnn.Open();

                cmd.ExecuteNonQuery();
                int valorRetorno = (int)prmRetorno.Value;
                if (valorRetorno == -6)
                    throw new Exception("Error de SQL");
                if (valorRetorno == -1)
                    throw new Exception("No existe la reserva con id " + r.Id);

            }
            catch (Exception ex)
            { throw ex; }
            finally
            { cnn.Close(); }
        }

        public static Reserva Buscar(int id)
        {
            SqlConnection cnn = new SqlConnection(Constantes.CONEXION);
            Reserva r = null;
            try
            {
                SqlCommand cmd = new SqlCommand("BuscarReserva", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cnn.Open();
                SqlDataReader lector = cmd.ExecuteReader();
                if (lector.Read())
                {
                    Hotel hotel = PersistenciaHoteles.Buscar((string)lector[1]);            
                    Habitacion hab = PersistenciaHabitaciones.Buscar(hotel, (int)lector[2]);
                    Cliente cli = PersistenciaClientes.Buscar((string)lector[3]);           
                    r = new Reserva(hab, cli, (DateTime)lector[4], (DateTime)lector[5], (string)lector[6], (int)lector[0]);
                }
            }
            catch (Exception ex)
            { throw ex; }
            finally
            { cnn.Close(); }
            return r;
        }

        public static void Cancelar(Reserva r)
        {
            SqlConnection cnn = new SqlConnection(Constantes.CONEXION);
            try
            {
                SqlCommand cmd = new SqlCommand("CancelarReserva", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", r.Id);
                SqlParameter prmRetorno = new SqlParameter();
                prmRetorno.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(prmRetorno);
                cnn.Open();
                cmd.ExecuteNonQuery();
                int valorRetorno = (int)prmRetorno.Value;
                if (valorRetorno == -6)
                    throw new Exception("Error de SQL");
                if (valorRetorno == -1)
                    throw new Exception("No se encuentra la reserva con id " + r.Id + " en la base de datos.");

            }
            catch (Exception ex)
            { throw ex; }
            finally { cnn.Close(); }
        }

        public static List<Reserva> ListarReservasPorHabitacion(Habitacion hab)
        {
            SqlConnection cnn = new SqlConnection(Constantes.CONEXION);
            try
            {
                List<Reserva> ListaReservas = new List<Reserva>();
                SqlCommand cmd = new SqlCommand("ListarReservasPorHabitacion", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NombreHotel", hab.Hotel.NombreHotel);
                cmd.Parameters.AddWithValue("@NroHabitacion", hab.NroHabitacion);
                cnn.Open();
                SqlDataReader lector = cmd.ExecuteReader();
                while (lector.Read())
                {
                    //id, nom, nro, name, fi, ff, estado
                    Cliente cliente = PersistenciaClientes.Buscar((string)lector[3]);
                    Reserva res = new Reserva(hab, cliente, (DateTime)lector[4], (DateTime)lector[5], (string)lector[6], (int)lector[0]);
                    ListaReservas.Add(res);
                }
                return ListaReservas;
            }
            catch (Exception ex)
            { throw ex; }
            finally
            { cnn.Close(); }
        }
    }
}
