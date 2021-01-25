using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Bitacora : BaseEntity
    {

        public int IdBitacora { get; set; }
        public string CedulaUsuario { get; set; }
        public string Nombre { get; set; }     
        public string DescripcionAccion { get; set; }
        public string Fecha { get; set; }
        
        public Bitacora()
        {

        }
    }
}
