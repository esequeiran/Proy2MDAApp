using DataAccess.Crud;
using Entities_POJO;
using System.Collections.Generic;

namespace CoreAPI
{
    public class HorasTrabajadasManager : BaseManager
    {
        private HorasTrabajadasCrudFactory crudHoras;

        public HorasTrabajadasManager() {
            crudHoras = new HorasTrabajadasCrudFactory();
        }

        public void Create(SolicitudDeTrabajo solicitud) {
            crudHoras.Create(solicitud); 
        }

        public void CreateNotificacion(Notificacion notificacion) {
            crudHoras.CreateNotificacion(notificacion);
        }

        public List<TipoDeTrabajo> RetrieveAllTiposTrabajo(SolicitudDeTrabajo solicitudDeTrabajo) {
            return crudHoras.RetrieveTiposTrabajo<SolicitudDeTrabajo>(solicitudDeTrabajo);
        }

        public SolicitudDeTrabajo RetrievePresupuestoSolicitud(SolicitudDeTrabajo solicitudDeTrabajo) {
            return crudHoras.RetrievePresupuestoSolicitud<SolicitudDeTrabajo>(solicitudDeTrabajo);
        }
    }
}
