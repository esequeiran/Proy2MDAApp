using DataAccess.Dao;
using DataAccess.Mapper;
using Entities_POJO;
using System;
using System.Collections.Generic;

namespace DataAccess.Crud
{
    public class HorasTrabajadasCrudFactory : CrudFactory
    {
        HorasTrabajadasMapper mapper;

        public HorasTrabajadasCrudFactory() {
            mapper = new HorasTrabajadasMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity) {
            var solicitud = (SolicitudDeTrabajo)entity;
            var sqlOperation = mapper.GetCreateStatement(solicitud);
            dao.ExecuteProcedure(sqlOperation);
        }

        public void CreateNotificacion(BaseEntity entity) {
            var notificacion = (Notificacion)entity;
            var sqlOperation = mapper.GetCreateNotificacionStatement(notificacion);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override T Retrieve<T>(BaseEntity entity) {
            throw new NotImplementedException();
        }

        public List<TipoDeTrabajo> RetrieveTiposTrabajo<T>(BaseEntity entity) {

            var lstTiposTrabajo = new List<TipoDeTrabajo>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveStatement(entity));
            var dic = new Dictionary<string , object>();
            if (lstResult.Count > 0) 
            {
                var objs = mapper.BuildObjectTipoTrabajo(lstResult);
                foreach (var t in objs) {
                    lstTiposTrabajo.Add((TipoDeTrabajo)Convert.ChangeType(t , typeof(TipoDeTrabajo)));
                }
                return lstTiposTrabajo;
            }
            return lstTiposTrabajo;
        }

        public SolicitudDeTrabajo RetrievePresupuestoSolicitud<T>(BaseEntity entity) {

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetrivePresupuestoStatement(entity));
            var dic = new Dictionary<string , object>();
            if (lstResult.Count > 0) {
                dic = lstResult[0];
                var objs = mapper.BuildObjectsSolicitud(dic);
                return (SolicitudDeTrabajo)Convert.ChangeType(objs , typeof(SolicitudDeTrabajo));
            }
            return default(SolicitudDeTrabajo);
        }

        public override List<T> RetrieveAll<T>() {
            throw new NotImplementedException();
        }

        public override void Update(BaseEntity entity) {
            throw new NotImplementedException();
        }

        public override void Delete(BaseEntity entity) {
            throw new NotImplementedException();
        }

        
    }
}
