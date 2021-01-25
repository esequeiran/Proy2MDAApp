using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Especialidad : BaseEntity
    {
        //VERSION NUEVA
        public int Id_Especialidad { get; set; }
        public string Nombre_Especialidad { get; set; }
        public int Id_Estado { get; set; }
        public string Id_Number { get; set; }

        public string Nombre_Estado { get; set; }

        public Especialidad()
        {

        }
    }
}
