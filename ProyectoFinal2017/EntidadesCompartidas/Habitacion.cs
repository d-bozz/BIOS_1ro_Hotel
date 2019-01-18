using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Habitacion
    {

        //Atributos
        private Hotel _Hotel;
        private int _nroHabitacion;
        private int _piso;
        private string _descripcion;
        private int _cantHuespedes;
        private int _costoDiario;

        //propiedades
        public Hotel Hotel
        {
            get { return _Hotel; }
            set
            {
                if (value != null)
                {
                    _Hotel = value;
                }
                else
                {
                    throw new Exception("El hotel de la habitacion no puede ser vacio.");
                }
            }

        }


        public int NroHabitacion
        {
            get { return _nroHabitacion; }
            set
            {
                if (value > 0)
                {
                    _nroHabitacion = value;
                }
                else
                {
                    throw new Exception("El numero de habitacion debe ser mayor a cero.");
                }
            }
        }


        public int Piso
        {
            get { return _piso; }
            set
            {
                if (value >= 0)
                {
                    _piso = value;
                }
                else
                {
                    throw new Exception("El piso de la habitacion debe ser positivo.");
                }
            }
        }


        public int CantHuespedes
        {
            get { return _cantHuespedes; }
            set
            {
                if (value > 0)
                    _cantHuespedes = value;
                else
                    throw new Exception("La cantidad de huespedes debe ser mayor a 0.");
            }
        }


        public int CostoDiario
        {
            get { return _costoDiario; }
            set
            {
                if (value >= 0)
                {
                    _costoDiario = value;
                }
                else
                {
                    throw new Exception("El costo diario de la habitacion debe ser positivo.");
                }
            }
        }

        public string Descripcion
        {
            get { return _descripcion; }
            set
            {
                if (value.Length >= 0)
                {
                    if (value.Length <= 50)
                        _descripcion = value;
                    else
                        throw new Exception("La descripcion no puede tener mas de 50 caracteres.");
                    
                }
                else
                {
                    throw new Exception("La descripcion de la habitacion no puede ser vacia.");
                }
            }
        }

        //Constructor
        public Habitacion(Hotel pHotel, int pNroHabitacion, int pPiso, int pCantHuespedes, int pCostoDiario, string pDescripcion)
        {
            Hotel = pHotel;
            NroHabitacion = pNroHabitacion;
            Piso = pPiso;
            Descripcion = pDescripcion;
            CantHuespedes = pCantHuespedes;
            CostoDiario = pCostoDiario;
        }

        //Operaciones

        public override string ToString()
        {
            string frase = "Habitacion numero "+this.NroHabitacion;
            frase += ", en el piso "+ this.Piso;
            frase += ", capacidad para " + this.CantHuespedes + " huespedes, ";
            frase += "en el hotel " + this.Hotel.NombreHotel;
            frase += " con un costo de $" + this.CostoDiario+" por dia.";
            frase+="\n "+this.Descripcion;
            return frase;
        }

    }
}