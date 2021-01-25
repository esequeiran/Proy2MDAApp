using DataAccess.Crud;
using Entities_POJO;
using System.Collections.Generic;

namespace CoreAPI
{
    public class NotificacionManager:BaseManager
    {
        private NotificacionCrudFactory crudNotificacion;

        public NotificacionManager() {
            crudNotificacion = new NotificacionCrudFactory();
        }

        public List<Notificacion> RetrieveAll(Notificacion notificacion) {
            return crudNotificacion.RetrieveAllByUser<Notificacion>(notificacion);
        }

        public Notificacion RetrieveById(Notificacion notificacion) { //numero
            return crudNotificacion.Retrieve<Notificacion>(notificacion);
        }

        public void Update(Notificacion notificacion) {
            crudNotificacion.Update(notificacion);
        }

        public void UpdatePagoSolicitud(Notificacion notificacion) {
            crudNotificacion.UpdatePagoSolicitud(notificacion);
        }
    }
}
