using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class TipoDeTrabajo : BaseEntity
    {
        //VERSION NUEVA
        public int Id_TipoTrabajo { get; set; }
        public string Nombre_TipoTrabajo { get; set; }
        public int Id_Estado { get; set; }
        public int Id_Especialidad { get; set; }
        public string Id_Number { get; set; }
        public string Nombre_Especialidad { get; set; }
        public string Nombre_Estado { get; set; }
        public double Costo_Por_Hora { get; set; }

        public double HorasTrabajadas { get; set; }


        public TipoDeTrabajo()
        {

        }
    }
}
