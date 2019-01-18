using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Administrador : Usuario
    {
        //Atributo
        private string _Cargo;

        //Propiedades
        public string Cargo
        {
          get { return _Cargo; }
          set {

              if (value.ToLower() == "gerente" || value.ToLower() == "jefe" || value.ToLower() == "administrativo")
              {
                  _Cargo = value.ToLower(); 
              }
              else
              {
                  throw new Exception("El cargo debe ser uno de los siguientes: Gerente, Jefe o Administrativo.");
              }
              
          
          }
        }


        //Constructor
        public Administrador(string pName, string pContraseña, string pNombreCompleto, string pCargo)
            :base(pName, pContraseña, pNombreCompleto)
        {
            Cargo = pCargo;
        }



    }
}
