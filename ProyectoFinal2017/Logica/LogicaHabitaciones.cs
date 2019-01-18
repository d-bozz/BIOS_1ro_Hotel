using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Persistencia;
using EntidadesCompartidas;

namespace Logica
{
    public class LogicaHabitaciones
    {

        public static List<Habitacion> ListarHabitaciones(Hotel pHotel)
        {
            return PersistenciaHabitaciones.ListarHabitaciones(pHotel);
        }

        public static Habitacion Buscar(Hotel pHotel, int pHabitacion)
        {
            Habitacion hab = PersistenciaHabitaciones.Buscar(pHotel, pHabitacion); 
            return hab;
        }

        public static void Modificar(Habitacion hab)
        {
            PersistenciaHabitaciones.Modificar(hab);
        }

        public static void Agregar(Habitacion hab)
        {
            PersistenciaHabitaciones.Agregar(hab);
        }

        public static void Eliminar(Habitacion hab)
        {
            PersistenciaHabitaciones.Eliminar(hab);
        }

    }
}
