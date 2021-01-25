using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class SolicitudRegistro : BaseEntity
    {
        public Oferente Oferente { get; set; }
        public Localizacion Localizacion { get; set; }
        public List<Documento> Documentos { get; set; }

    }

}
