using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Iva : BaseEntity
    {
        public int Id { get; set; }
        public double PorcentajeIVA { get; set; }

        public Iva()
        {
        }
    }
}