using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public abstract class Usuario
    {
        //Atributos
        private string _name;
        private string _contraseña;
        private string _nombreCompleto;


        //Propiedades

        public string Name
        {
            get { return _name; }
            set
            {
                if (value.Length != 0)
                    if (value.Length <= 50)
                        _name = value;
                    else
                        throw new Exception("El nombre no puede tener mas de 50 caracteres.");
                else
                {
                    throw new Exception("El nombre de usuario no puede ser vacio.");
                }
            }
        }

        public string Contraseña
        {
            get { return _contraseña; }
            set
            {
                if (value.Length != 0)
                {
                    if (value.Length <= 50)
                        _contraseña = value;
                    else
                        throw new Exception("La contraseña no puede tener mas de 50 caracteres.");
                }
                else
                {
                    throw new Exception("La contraseña no puede ser vacia.");
                }
            }
        }

        public string NombreCompleto
        {
            get { return _nombreCompleto; }
            set
            {
                if (value.Length != 0)
                {
                    if (value.Length <= 50)
                        _nombreCompleto = value;
                    else
                        throw new Exception("El nombre completo no puede tener mas de 50 caracteres.");
                }
                else
                {
                    throw new Exception("El nombre completo no puede ser vacio.");
                }
            }
        }

        //Constructor
        public Usuario(string pName, string pContraseña, string pNombreCompleto)
        {
            Name = pName;
            Contraseña = pContraseña;
            NombreCompleto = pNombreCompleto;
        }

        //Operaciones
        public override string ToString()
        {

            string frase = "";
            frase += "Nombre: " + NombreCompleto + ", usuario: " + Name;
            return frase;
        }
    }
}
