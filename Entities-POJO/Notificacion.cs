

namespace Entities_POJO
{
    public class Notificacion:BaseEntity
    {
        public int Id { get; set; }
        public int IdSolicitud { get; set; }
        public string Mensaje  { get; set; }
        public string Estado { get; set; }
        public string IdCliente { get; set; }
        public int CantNotificaciones { get; set; } 

        public Notificacion() {
        }
    }
}
