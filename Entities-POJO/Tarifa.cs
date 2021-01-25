using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Tarifa : BaseEntity
    {
        public int IdParametro { get; set; }
        public string DescripcionParametro { get; set; }
        public double  PrecioPorCancelar { get; set; }

      

        public Tarifa()
        {

        }
    }
}
