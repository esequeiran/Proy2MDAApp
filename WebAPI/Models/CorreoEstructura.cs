using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class CorreoEstructura
    {
        public string correoDestinatario { get; set; }

        public string nombreDestinatario { get; set; }
                
        public string Asunto { get; set; }

        public string ContenidoTextoPlano { get; set; }

        public string PlantillaContenidoHtml { get; set; }

        public CorreoEstructura()
        {

        }

    }
}