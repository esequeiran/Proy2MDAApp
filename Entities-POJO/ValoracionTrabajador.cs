using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class ValoracionTrabajador : BaseEntity
    {
        public int IdSolicitud { get; set; }

        public string IdEmpresa { get; set; }

        public string IdTrabajador { get; set; }

        public string NombreTrabajador { get; set; }

        public int ValoracionEstrellasTrabajador { get; set; }

        public string ComentarioTrabajador { get; set; }

        public ValoracionTrabajador() { 
        
        
        }
    }
}
