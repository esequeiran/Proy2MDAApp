using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class DatosEmpresaCorreo : BaseEntity
    {
        public string Correo { get; set; }
        public string NombreEmpresa { get; set; }

        public DatosEmpresaCorreo()
        {

        }
    }
}
