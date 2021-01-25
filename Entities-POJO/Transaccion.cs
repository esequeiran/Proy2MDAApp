using System;


namespace Entities_POJO
{
    public class Transaccion:BaseEntity
    {
        public int IdTransaccion { get; set; }
        public string Fecha { get; set; }
        public double Monto { get; set; }
        public string Concepto { get; set; }
        public string TipoMovimiento { get; set; }
        public string IdUsuario { get; set; } 

        public Transaccion() {

        }
    }
}
