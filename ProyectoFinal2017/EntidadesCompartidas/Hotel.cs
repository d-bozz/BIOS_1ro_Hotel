using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Hotel
    {

        //Atributos
        private string _nombreHotel;
        private string _calle;
        private int _nroPuerta;
        private string _ciudad;
        private int _telefono;
        private int _fax;
        private bool _accesoPlaya;
        private bool _piscina;
        private int _estrellas;
        private string _foto;

        //Propiedades
        public string NombreHotel
        {
            get { return _nombreHotel; }
            set
            {
                if (value.Length != 0)
                {
                    if (value.Length <= 50)
                        _nombreHotel = value;
                    else
                        throw new Exception("El nombre no puede tener mas de 50 caracteres.");
                    
                }
                else
                {
                    throw new Exception("El nombre del Hotel no puede ser vacio.");
                }
            }
        }

        public string Calle
        {
            get { return _calle; }
            set
            {
                if (value.Length != 0)
                {
                    if (value.Length <= 50)
                        _calle = value;
                    else
                        throw new Exception("La calle no puede tener mas de 50 caracteres.");
                    
                }
                else
                {
                    throw new Exception("La calle del Hotel no puede ser vacia.");
                }
            }
        }

        public int NroPuerta
        {
            get { return _nroPuerta; }
            set
            {

                if (value >= 0)
                {
                    _nroPuerta = value;
                }
                else
                {
                    throw new Exception("El numero de puerta del Hotel debe ser positivo.");
                }
            }
        }

        public string Ciudad
        {
            get { return _ciudad; }
            set
            {
                if (value.Length != 0)
                {
                    if (value.Length <= 50)
                        _ciudad = value;
                    else
                        throw new Exception("La ciudad no puede tener mas de 50 caracteres."); 
                }
                else
                {
                    throw new Exception("La ciudad del Hotel no puede ser vacia.");
                }
            }
        }

        public int Telefono
        {
            get { return _telefono; }
            set
            {
                if (value > 0)
                {
                    _telefono = value;
                }
                else
                {
                    throw new Exception("El numero de telefono no puede ser negativo.");
                }
            }
        }

        public int Fax
        {
            get { return _fax; }
            set
            {
                if (value > 0)
                {
                    _fax = value;
                }
                else
                {
                    throw new Exception("El numero de fax no puede ser negativo.");
                }
            }
        }

        public bool AccesoPlaya
        {
            get { return _accesoPlaya; }
            set { _accesoPlaya = value; }
        }

        public bool Piscina
        {
            get { return _piscina; }
            set { _piscina = value; }
        }

        public int Estrellas
        {
            get { return _estrellas; }
            set
            {
                if (value >= 1 && value <= 5)
                {
                    _estrellas = value;
                }
                else
                {
                    throw new Exception("Las estrellas del Hotel deben ser entre 1 y 5.");
                }
            }
        }

        public string Foto
        {
            get { return _foto; }
            set
            {
                if (value.Length != 0)
                {
                    if (value.Length <= 82)
                        _foto = value;
                    else
                        throw new Exception("El nombre de la imagen es muy largo."); 
                }
                else
                {
                    throw new Exception("No se puede ingresar una foto vacia.");
                }
            }
        }


        //Constructor
        public Hotel(string pNombreHotel, string pCalle, int pNroPuerta, string pCiudad, int pTelefono, int pFax, bool pAccesoPlaya, bool pPiscina, int pEstrellas, string pFoto)
        {
            NombreHotel = pNombreHotel;
            Calle = pCalle;
            NroPuerta = pNroPuerta;
            Ciudad = pCiudad;
            Telefono = pTelefono;
            Fax = pFax;
            AccesoPlaya = pAccesoPlaya;
            Piscina = pPiscina;
            Estrellas = pEstrellas;
            Foto = pFoto;
        }


        //Operaciones
        public override string ToString()
        {
            string accesoAplaya = "no tiene acceso a playa";
            if (this.AccesoPlaya)
                accesoAplaya = "tiene acceso a playa";
            string piscina = "no tiene piscina";
            if (this.Piscina)
                piscina = "tiene piscina";
            string frase = "Hotel: " + this.NombreHotel;
            frase += ", Direccion: " + this.Calle + " Nro de Puerta: "+ this.NroPuerta;
            frase += ", ciudad: " + this.Ciudad;
            frase += ", telefono " + this.Telefono + " fax: "+this.Fax;
            frase += accesoAplaya + ", " + piscina+".";
            frase += "Cuenta con: " + this.Estrellas + " estrellas.";
            return frase;
        }


    }
}
