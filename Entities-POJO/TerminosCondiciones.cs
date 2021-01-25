using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class TerminosCondiciones : BaseEntity
    {
        public string Terminos {get; set; } //unico campo modificable
        public int Id_Parametro {get; set; } //no se modifica
        public string Descripcion { get; set; } //no se modifica ESTE VENDRIA SIENDO EL TITULO

        public TerminosCondiciones()
        {

        }
    }
}
