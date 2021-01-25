using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Factura : BaseEntity
    {
        public int IdFactura { get; set; }
        public DateTime FechaEvento { get; set; }
        public double Subtotal { get; set; }
        public double Fee { get; set; }
        public double Iva { get; set; }
        public double Total { get; set; }
        public int TransaccionFinanciera { get; set; }
        public int IdSolicitud  { get; set; }
        public string IdCliente  { get; set; }
        public double CantHoras   { get; set; }
        public double PrecioPorHora   { get; set; }
        public double TotalLinea   { get; set; }
        public string Descripcion   { get; set; }
        public string NombreCompleto { get; set; }

        public Factura() {
        
        }
    }
}
