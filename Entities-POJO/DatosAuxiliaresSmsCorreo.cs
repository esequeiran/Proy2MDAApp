using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class DatosAuxiliaresSmsCorreo : BaseEntity
    {
        public string CedulaEmpresa { get; set; }
        public string Correo { get; set; }
        public string NombreEmpresa { get; set; }
        public string NombreVista { get; set; }

        public string Cedula { get; set; }
        public string CodigoVerificacion { get; set; }
        
        public string MensajeSMS { get; set; }

        public string NombreUsuario { get; set; }

        public string Telefono { get; set; }

        public DatosAuxiliaresSmsCorreo()
        {
            
        }

    }
}
