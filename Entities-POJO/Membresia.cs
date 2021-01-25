using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Membresia : BaseEntity
    {
        public int IdMembresia { get; set; }
        public string NombreMembresia { get; set; }
        public string TipoMembresia { get; set; }
        public double Precio { get; set; }
        public int VigenciaMeses { get; set; }
        public int? Id_Estado { get; set; }
        public string Estado { get; set; }
        public double FeeReagendar { get; set; }
        public double FeeCancelar { get; set; }
        public double FeeServicio { get; set; }
        public string CedulaEmpresa { get; set; } 
        public string NombreEmpresa { get; set; }
        public DateTime? FechaContratacion { get; set; }

        public string FechaContratacionS { get; set; }
        public Membresia()
        {

        }

    }
}
