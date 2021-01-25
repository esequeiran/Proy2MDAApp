using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class OrdenDeTrabajo : BaseEntity
    {
        public string NombreCliente { get; set; }

        public string CorreoCliente { get; set; }

        public string FechaEventoS { get; set; }

        public string DescripcionNecesidad { get; set; }

        public string ExplicacionTrabajo { get; set; }

        public string CodigoQr { get; set; }

        public string Provincia { get; set; }

        public string Canton { get; set; }

        public string Distrito { get; set; }

        public string OtrasSennas { get; set; }

        public string NombreEmpresa { get; set; }

        public string CorreoEmpresa { get; set; }

        public string CostoMonetario { get; set; }

        public OrdenDeTrabajo() { 
        
        }
    }
}
