using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class TipoTrabajoPorEmpresa : BaseEntity
    {
        public string Cedula_Usuario { get; set; }
        public int Id_TipoTrabajo { get; set; }// tipo trabajo
        public double Costo_Por_Hora { get; set; }
        public double Costo_Por_Servicio { get; set; }
        public string Nombre_TipoTrabajo { get; set; } // tipo trabajo
        public  TipoTrabajoPorEmpresa()
        {

        }
    }
}
