using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistencia;
using EntidadesCompartidas;

namespace Logica
{
    public class LogicaUsuarios
    {

         public static List<Usuario> ListarUsuarios()
        {
            try
            {
                List<Usuario> listarUsuarios = new List<Usuario>();
                listarUsuarios = PersistenciaAdministradores.ListarAdministradores();
                listarUsuarios.AddRange(PersistenciaClientes.ListarClientes());
                
                return listarUsuarios;
            }
            catch (Exception ex)
            { throw ex; }
        }
        public static Usuario Buscar(string pUsuario)
        {
            Usuario user = PersistenciaAdministradores.Buscar(pUsuario);
            if (user == null)
                user = PersistenciaClientes.Buscar(pUsuario);
            return user;
        }
        public static void Modificar(Usuario user)
        {
            if (user is Administrador)
                PersistenciaAdministradores.Modificar((Administrador)user);
           
        }
        public static void Agregar(Usuario user)
        {
            if (user is Administrador)
                PersistenciaAdministradores.Agregar((Administrador)user);
            else if (user is Cliente)
                PersistenciaClientes.Agregar((Cliente)user);
        }
        public static void Eliminar(Usuario user)
        {
            if (user is Administrador)
                PersistenciaAdministradores.Eliminar(user.Name);
        }
        public static Usuario Logueo(string pUsu, string pPass)
        {
            Usuario user = null;

            //Verifico Administrador
            user = PersistenciaAdministradores.Logueo(pUsu, pPass);

            //verifico cliente
            if (user == null)
                user = PersistenciaClientes.Logueo(pUsu, pPass);

            //retorno lo que encontre
            return user;
        }

        public static void AgregarTelefono(Cliente pCli, int pTel)
        {
            PersistenciaClientes.AgregarTelefono(pCli,pTel );
        }

    }

}

