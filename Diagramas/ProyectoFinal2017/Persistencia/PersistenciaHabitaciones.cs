using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using EntidadesCompartidas;

namespace Persistencia
{
    public class PersistenciaHabitaciones
    {

        public static List<Habitacion> ListarHabitaciones(Hotel pHotel)
        {
            List<Habitacion> ListarHabitaciones = new List<Habitacion>();
            SqlConnection cnn = new SqlConnection(Constantes.CONEXION);
            try
            {
                SqlCommand cmd = new SqlCommand("ListarHabitaciones", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombreHotel", pHotel.NombreHotel);
                
                cnn.Open();
                SqlDataReader lector = cmd.ExecuteReader();
                while (lector.Read())
                {
                    //SELECT hot.nombreHotel ,hab.nroHabitacion, hab.piso, hab.cantHuepedes, hab.costoDiario, hab.descripcion
                    Hotel hotel = PersistenciaHoteles.Buscar((string)lector[0]);
                    Habitacion hab = new Habitacion(hotel, Convert.ToInt32(lector[1]), Convert.ToInt32(lector[2]), Convert.ToInt32(lector[3]), Convert.ToInt32(lector[4]), (string)lector[5]); 
                    ListarHabitaciones.Add(hab);
                }
                return ListarHabitaciones;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            { cnn.Close(); }
        }

        public static Habitacion Buscar(Hotel pHotel, int pHabitacion)
        {
            SqlConnection cnn = new SqlConnection(Constantes.CONEXION);
            try
            {
                Habitacion hab = null;
                SqlCommand cmd = new SqlCommand("BuscarHabitacion", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombreHotel", pHotel.NombreHotel);
                cmd.Parameters.AddWithValue("@nroHabitacion", pHabitacion);
                cnn.Open();
                SqlDataReader lector = cmd.ExecuteReader();
                if (lector.Read())
                {

                    string hotel = (string)lector[0];
                    int nroHabitacion = Convert.ToInt32(lector[1].ToString());
                    int piso = Convert.ToInt32(lector[2].ToString());
                    int cantHuepedes = Convert.ToInt32(lector[3].ToString());
                    int costoDiario = Convert.ToInt32(lector[4].ToString());
                    string descripcion = (string)lector[5];

                    hab = new Habitacion(pHotel, nroHabitacion, piso, cantHuepedes, costoDiario, descripcion);
                }
                return hab;
            }
            catch (Exception ex)
            { throw ex; }
            finally
            { cnn.Close(); }
        }

        public static void Modificar(Habitacion hab)
        {
            SqlConnection cnn = new SqlConnection(Constantes.CONEXION);
            try
            {
                SqlCommand cmd = new SqlCommand("ModificarHabitacion", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                //Agrego los parámetros con sus valores
                cmd.Parameters.AddWithValue("@nombreHotel", hab.Hotel.NombreHotel);
                cmd.Parameters.AddWithValue("@nroHabitacion", hab.NroHabitacion);
                cmd.Parameters.AddWithValue("@piso", hab.Piso);
                cmd.Parameters.AddWithValue("@cantHuepedes", hab.CantHuespedes);
                cmd.Parameters.AddWithValue("@costoDiario", hab.CostoDiario);
                cmd.Parameters.AddWithValue("@descripcion", hab.Descripcion);
                
                SqlParameter prmRetorno = new SqlParameter();
                prmRetorno.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(prmRetorno);
                cnn.Open();
                cmd.ExecuteNonQuery();
                int valorRetorno = (int)prmRetorno.Value;
                 if (valorRetorno == -2)
                    throw new Exception("No se existe una habitacion con el numero " + hab.NroHabitacion);
                if (valorRetorno == -6)
                    throw new Exception("Error de SQL");
            }
            catch (Exception ex)
            { throw ex; }
            finally
            { cnn.Close(); }
        }

        public static void Agregar(Habitacion hab)
        {
            SqlConnection cnn = new SqlConnection(Constantes.CONEXION);
            try
            {
                SqlCommand cmd = new SqlCommand("AgregarHabitacion", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                //Agrego los parámetros con sus valores
                cmd.Parameters.AddWithValue("@nombreHotel", hab.Hotel.NombreHotel);
                cmd.Parameters.AddWithValue("@nroHabitacion", hab.NroHabitacion);
                cmd.Parameters.AddWithValue("@piso", hab.Piso);
                cmd.Parameters.AddWithValue("@cantHuepedes", hab.CantHuespedes);
                cmd.Parameters.AddWithValue("@costoDiario", hab.CostoDiario);
                cmd.Parameters.AddWithValue("@descripcion", hab.Descripcion);

                SqlParameter prmRetorno = new SqlParameter();
                prmRetorno.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(prmRetorno);
                cnn.Open();
                cmd.ExecuteNonQuery();
                int valorRetorno = (int)prmRetorno.Value;
               
                if (valorRetorno == -2)
                    throw new Exception("La Habitacion " + hab.NroHabitacion + " Ya se encuentra en el sistema.");
                if (valorRetorno == -6)
                    throw new Exception("Error de SQL");
            }
            catch (Exception ex)
            { throw ex; }
            finally
            { cnn.Close(); }
        }

        public static void Eliminar(Habitacion pHabitacion)
        {
            SqlConnection cnn = new SqlConnection(Constantes.CONEXION);
            try
            {
                SqlCommand cmd = new SqlCommand("EliminarHabitacion", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                //Agrego los parámetros con sus valores
                cmd.Parameters.AddWithValue("@nombreHotel", pHabitacion.Hotel.NombreHotel);
                cmd.Parameters.AddWithValue("@nroHabitacion", pHabitacion.NroHabitacion);

                SqlParameter prmRetorno = new SqlParameter();
                prmRetorno.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(prmRetorno);
                cnn.Open();
                cmd.ExecuteNonQuery();
                int valorRetorno = (int)prmRetorno.Value;
                if (valorRetorno == -1)
                    throw new Exception("No se existe un hotel con el nombre: " + pHabitacion.Hotel.NombreHotel);
                if (valorRetorno == -1)
                    throw new Exception("No se existe una habitacion con el numero: " + pHabitacion.NroHabitacion);
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
