using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Reserva
    {
        //Atributos
        private Habitacion _Habitacion;
        private Cliente _Cliente;
        private DateTime _fechaInicio;
        private DateTime _fechaFin;
        private string _estadoActual;
        private int _id;


        //Propiedades
        public int Id
        {
            get { return _id; }
            set { _id =  value;} //pongo esto solo para agregarla al constructor, asi puedo buscarla en la base y armarla.
        }

        public Habitacion Habitacion
        {
            get { return _Habitacion; }
            set
            {
                if (value != null)
                {
                    _Habitacion = value;
                }
                else
                {
                    throw new Exception("No existe Habitacion para esa reserva.");
                }
            }
        }


        public Cliente Cliente
        {
            get { return _Cliente; }
            set
            {
                if (value != null)
                {
                    _Cliente = value;
                }
                else
                {
                    throw new Exception("No existe Cliente para esta reserva.");
                }
            }
        }


        public DateTime FechaInicio
        {
            get { return _fechaInicio; }
            set
            {
                if (value.Date >= DateTime.Now.Date)
                {
                    _fechaInicio = value;
                }
                else
                {
                    throw new Exception("La fecha de inicio debe ser mayor o igual a hoy.");
                }
            }
        }


        public DateTime FechaFin
        {
            get { return _fechaFin; }
            set
            {
                TimeSpan dif = value.Subtract(FechaInicio);
                if (dif.TotalDays >= 1)
                {
                    _fechaFin = value;
                }
                else
                {
                    throw new Exception("La reserva minima es de un dia.");
                }
            }
        }


        public string EstadoActual
        {
            get { return _estadoActual; }
            set
            {
                if (value.ToLower() == "activa" || value.ToLower() == "cancelada" || value.ToLower() == "finalizada")
                {
                    _estadoActual = value;
                }
                else
                {
                    throw new Exception("No es un estado valido.");
                }

            }
        }


        //Constructor
        public Reserva(Habitacion pHabitacion, Cliente pCliente, DateTime pFechaInicio, DateTime pFechaFin, string pEstadoActual, int pID)
        {
            Habitacion = pHabitacion;
            Cliente = pCliente;
            FechaInicio = pFechaInicio;
            FechaFin = pFechaFin;
            EstadoActual = pEstadoActual;
            Id = pID;
        }


    }
}
