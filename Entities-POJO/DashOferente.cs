using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class DashOferente: BaseEntity
    {
        public int IdSolicitud { get; set; }
        public DateTime FechaEvento { get; set; }
        public string IdEstado { get; set; }

    }
}
