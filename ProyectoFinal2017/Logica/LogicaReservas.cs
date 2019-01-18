using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistencia;
using EntidadesCompartidas;

namespace Logica
{
    public class LogicaReservas
    {
        public static void RealizarRes(Reserva res)
        {
            try
            {
                PersistenciaReservas.RealizarRes(res);
            }
            catch (Exception ex)
            { throw ex; }
        }


        public static List<Reserva> ListarReservas()
        {
            return PersistenciaReservas.ListarReservas();
        }

        public static List<Reserva> ListarReservasActivas()
        {
            return PersistenciaReservas.ListarReservasActivas();
        }

        public static List<Reserva> ListarReservasActivasPorCliente(Usuario pUser)
        {
            return PersistenciaReservas.ListarReservasActivasPorCliente(pUser);
        }

        public static List<Reserva> ListarReservasPorCliente(Usuario pUser)
        {
            return PersistenciaReservas.ListarReservasPorCliente(pUser);
        }

        public static void Eliminar(Reserva res)
        {
            PersistenciaReservas.Eliminar(res.Id);
        }

        public static void Finalizar(Reserva res)
        {
            PersistenciaReservas.Finalizar(res);
        }

        public static Reserva Buscar(int id)
        {
            return PersistenciaReservas.Buscar(id);
        }

        public static void Cancelar(Reserva res)
        {
            PersistenciaReservas.Cancelar(res);
        }

        public static List<Reserva> ListarReservasPorHabitacion(Habitacion hab)
        {
            return PersistenciaReservas.ListarReservasPorHabitacion(hab);
        }
    }
}
