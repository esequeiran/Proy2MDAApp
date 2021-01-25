using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entities_POJO
{
    public class CorreoEstructura : BaseEntity
    {
        public string correoDestinatario { get; set; }

        public string nombreDestinatario { get; set; }
                
        public string Asunto { get; set; }

        public string ContenidoTextoPlano { get; set; }

        public string PlantillaContenidoHtml { get; set; }

        public byte[] AdjuntoQR { get; set; }

        public CorreoEstructura()
        {

        }

    }
}