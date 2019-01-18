using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Cliente : Usuario
    {
        //Atributo
        private string _Tarjeta;
        private string _Direccion;
        private List<int> _Telefonos;

        //Propiedades
        public string Tarjeta
        {
            get { return _Tarjeta; }
            set {
                if (value.Length != 0)
                {
                    if (value.Length <= 16)
                        _Tarjeta = value;
                    else
                        throw new Exception("La tarjeta no puede tener mas de 16 caracteres.");
                    
                }
                else
                {
                    throw new Exception("No puede ingresar una tarjeta de credito vacia.");
                }
            }
        }

        public string Direccion
        {
            get { return _Direccion; }
            set {
                if (value.Length != 0)
                {
                    if (value.Length <= 50)
                        _Direccion = value;
                    else
                        throw new Exception("La tarjeta no puede tener mas de 50 caracteres.");
                    
                }
                else
                {
                    throw new Exception("La direccion no puede ser vacia.");
                }
            }
        }

        public List<int> Telefonos
        {
            get { return _Telefonos; }
            set { _Telefonos = value; }
        }
        

        //Constructor
        public Cliente(string pName, string pContraseña, string pNombreCompleto, string pTarjeta, string pDireccion, List<int> pTelefonos)
            : base(pName, pContraseña, pNombreCompleto)
        {
            Tarjeta = pTarjeta;
            Direccion = pDireccion;
            Telefonos = pTelefonos;
        }

        //Operaciones
        public void AgregarTelefonoExtra(int pTelefono)
        {
            int i = 0;
            while (i < _Telefonos.Count)
            {
                if (_Telefonos[i] == pTelefono)
                    throw new Exception(base.NombreCompleto + " ya tiene el numero " + pTelefono + " agendado.");
                i++;
            }
            _Telefonos.Add(pTelefono);
        }

        public override string ToString()
        {

            string frase = "";
            frase += base.ToString() + ", direccion: " + Direccion + ", tarjeta: " + Tarjeta + ", telefono(s): ";
            foreach (int a in Telefonos)
            {
                frase += a + " - ";
            }
            return frase;
        }

    }
}
