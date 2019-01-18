using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Persistencia;
using EntidadesCompartidas;

namespace Logica
{
    public class LogicaHoteles
    {

        public static List<Hotel> ListarHoteles()
        {
            try
            {
                return PersistenciaHoteles.ListarHoteles();
            }
            catch (Exception ex)
            { throw ex; }
        }

        public static Hotel Buscar(string pHotel)
        {
            return PersistenciaHoteles.Buscar(pHotel);
        }

        public static void Modificar(Hotel hot)
        {
            PersistenciaHoteles.Modificar(hot);
        }

        public static void Agregar(Hotel hot)
        {

            PersistenciaHoteles.Agregar(hot);
        }

        public static void Eliminar(Hotel hot)
        {
            PersistenciaHoteles.Eliminar(hot.NombreHotel);
        }


        public static List<Hotel> ListarHoteles(int pEstrellas)
        {
            return PersistenciaHoteles.ListarHoteles(pEstrellas);
        }
    }
}
