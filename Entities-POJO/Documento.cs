using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Documento : BaseEntity
    {
        public string IdDocumento { get; set; }
        public string NombreDocumento { get; set; }
        public string Extension { get; set; }
        public string IdUsuario { get; set; }
        public string TipoDocumento { get; set; }

        public int IdSolicitud { get; set; }

        public Documento()
        {

        }

        public Documento(string[] infoArray)
        {
            if (infoArray != null && infoArray.Length >= 5)
            {
                NombreDocumento = infoArray[0];
                IdDocumento = infoArray[1];
                Extension = infoArray[2];
                IdUsuario = infoArray[3];
                TipoDocumento = infoArray[4];
     

            }
            else
            {
                throw new Exception("Todos los valores son necesarios");
            }
        }
    }
}
