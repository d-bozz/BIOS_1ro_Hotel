using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using EntidadesCompartidas;


namespace Persistencia
{
    public class PersistenciaHoteles
    {

        public static List<Hotel> ListarHoteles()
        {
            List<Hotel> ListarHoteles = new List<Hotel>();
            SqlConnection cnn = new SqlConnection(Constantes.CONEXION);
           
            try
            {
                
                SqlCommand cmd = new SqlCommand("ListarHoteles", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cnn.Open();
                SqlDataReader lector = cmd.ExecuteReader();
                while (lector.Read())
                {
                    Hotel hot = new Hotel((string)lector[0], (string)lector[1], Convert.ToInt32(lector[2]),
                                         (string)lector[3], Convert.ToInt32(lector[4]), Convert.ToInt32(lector[5]),
                                         (bool)lector[6], (bool)lector[7], 
                                         Convert.ToInt32(lector[8]), (string)lector[9]);
                    ListarHoteles.Add(hot);
                }
                return ListarHoteles;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            { cnn.Close(); }
        }

        public static Hotel Buscar(string pHotel)
        {
            SqlConnection cnn = new SqlConnection(Constantes.CONEXION);
            try
            {
                Hotel hot = null;
                SqlCommand cmd = new SqlCommand("BuscarHotel", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombreHotel", pHotel);
                cnn.Open();
                SqlDataReader lector = cmd.ExecuteReader();
                if (lector.Read())
                {

                    string hotel = (string)lector[0];
                    string calle = (string)lector[1];
                    int nroPuerta = Convert.ToInt32(lector[2].ToString());
                    string direccion = (string)lector[3];
                    int telefono = Convert.ToInt32(lector[4]);
                    int fax = Convert.ToInt32(lector[5]);
                    bool playa = (bool)lector[6];
                    bool piscina = (bool)lector[7];
                    int estrellas = Convert.ToInt32(lector[8].ToString());
                    string foto = (string)lector[9];

                    hot = new Hotel(hotel, calle, nroPuerta, direccion, telefono, fax, playa, piscina, estrellas, foto);
                }
                return hot;
            }
            catch (Exception ex)
            { throw ex; }
            finally
            { cnn.Close(); }
        }

        public static void Modificar(Hotel hot)
        {
            SqlConnection cnn = new SqlConnection(Constantes.CONEXION);
            try
            {
                SqlCommand cmd = new SqlCommand("ModificarHotel", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                //Agrego los parámetros con sus valores
                cmd.Parameters.AddWithValue("@nombreHotel", hot.NombreHotel);
                cmd.Parameters.AddWithValue("@calle", hot.Calle);
                cmd.Parameters.AddWithValue("@nroPuerta", hot.NroPuerta);
                cmd.Parameters.AddWithValue("@ciudad", hot.Ciudad);
                cmd.Parameters.AddWithValue("@telefono", hot.Telefono);
                cmd.Parameters.AddWithValue("@fax", hot.Fax);
                cmd.Parameters.AddWithValue("@accesoPlaya", hot.AccesoPlaya);
                cmd.Parameters.AddWithValue("@piscina", hot.Piscina);
                cmd.Parameters.AddWithValue("@estrellas", hot.Estrellas);
                cmd.Parameters.AddWithValue("@foto", hot.Foto);


                SqlParameter prmRetorno = new SqlParameter();
                prmRetorno.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(prmRetorno);
                cnn.Open();
                cmd.ExecuteNonQuery();
                int valorRetorno = (int)prmRetorno.Value;
                if (valorRetorno == -1)
                    throw new Exception("No se existe un Hotel con el nombre " + hot.NombreHotel);
                if (valorRetorno == -6)
                    throw new Exception("Error de SQL");
            }
            catch (Exception ex)
            { throw ex; }
            finally
            { cnn.Close(); }
        }

        public static void Agregar(Hotel hot)
        {
            SqlConnection cnn = new SqlConnection(Constantes.CONEXION);
            try
            {
                SqlCommand cmd = new SqlCommand("AgregarHotel", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                //Agrego los parámetros con sus valores
                cmd.Parameters.AddWithValue("@nombreHotel", hot.NombreHotel);
                cmd.Parameters.AddWithValue("@calle", hot.Calle);
                cmd.Parameters.AddWithValue("@nroPuerta", hot.NroPuerta);
                cmd.Parameters.AddWithValue("@ciudad", hot.Ciudad);
                cmd.Parameters.AddWithValue("@telefono", hot.Telefono);
                cmd.Parameters.AddWithValue("@fax", hot.Fax);
                cmd.Parameters.AddWithValue("@accesoPlaya", hot.AccesoPlaya);
                cmd.Parameters.AddWithValue("@piscina", hot.Piscina);
                cmd.Parameters.AddWithValue("@estrellas", hot.Estrellas);
                cmd.Parameters.AddWithValue("@foto", hot.Foto);

                SqlParameter prmRetorno = new SqlParameter();
                prmRetorno.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(prmRetorno);
                cnn.Open();
                cmd.ExecuteNonQuery();
                int valorRetorno = (int)prmRetorno.Value;
                if (valorRetorno == -1)
                    throw new Exception("El Hotel " + hot.NombreHotel + " Ya se encuentra en el sistema.");
                if (valorRetorno == -6)
                    throw new Exception("Error de SQL");
            }
            catch (Exception ex)
            { throw ex; }
            finally
            { cnn.Close(); }
        }

        public static void Eliminar(string pHotel)
        {
            SqlConnection cnn = new SqlConnection(Constantes.CONEXION);
            try
            {
                SqlCommand cmd = new SqlCommand("EliminarHotel", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                //Agrego los parámetros con sus valores
                cmd.Parameters.AddWithValue("@nombreHotel", pHotel);

                SqlParameter prmRetorno = new SqlParameter();
                prmRetorno.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(prmRetorno);
                cnn.Open();
                cmd.ExecuteNonQuery();
                int valorRetorno = (int)prmRetorno.Value;
                if (valorRetorno == -1)
                    throw new Exception("No se existe un hotel con el nombre: " + pHotel);
                if (valorRetorno == -6)
                    throw new Exception("Error de SQL");

            }
            catch (Exception ex)
            { throw ex; }
            finally
            { cnn.Close(); }
        }


        public static List<Hotel> ListarHoteles(int pEstrellas)
        {
            SqlConnection cnn = new SqlConnection(Constantes.CONEXION);
            List<Hotel> ListaHoteles = new List<Hotel>();
            try
            {
                SqlCommand cmd = new SqlCommand("ListarHotelesPorEstrellas", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@estrellas", pEstrellas);
                cnn.Open();
                SqlDataReader lector = cmd.ExecuteReader();
                while (lector.Read())
                { 
                    Hotel hotel = new Hotel ((string)lector[0], (string)lector[1], Convert.ToInt32(lector[2]),
                                         (string)lector[3], Convert.ToInt32(lector[4]), Convert.ToInt32(lector[5]),
                                         (bool)lector[6], (bool)lector[7], 
                                         Convert.ToInt32(lector[8]), (string)lector[9]);
                    ListaHoteles.Add(hotel);
                }
            }
            catch (Exception ex)
            { throw ex; }
            finally
            { 
                cnn.Close();
            }
            return ListaHoteles;
        }
    }
}
