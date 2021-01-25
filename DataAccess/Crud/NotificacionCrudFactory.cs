using DataAccess.Dao;
using DataAccess.Mapper;
using Entities_POJO;
using System;
using System.Collections.Generic;

namespace DataAccess.Crud
{
    public class NotificacionCrudFactory: CrudFactory
    {
        NotificacionMapper mapper;

        public NotificacionCrudFactory() {
            mapper = new NotificacionMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity) {
            throw new NotImplementedException();
        }

        public override T Retrieve<T>(BaseEntity entity) {
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveStatement(entity));
            var dic = new Dictionary<string , object>();
            if (lstResult.Count > 0) {
                dic = lstResult[0];
                var objs = mapper.BuildObjectCantHoras(dic);
                return (T)Convert.ChangeType(objs , typeof(T));
            }
            return default(T);
        }

        public override List<T> RetrieveAll<T>() {
            throw new NotImplementedException();
        }

        public override void Update(BaseEntity entity) {
            var notificacion = (Notificacion)entity;
            dao.ExecuteProcedure(mapper.GetUpdateStatement(notificacion));
        }

        public List<T> RetrieveAllByUser<T>(BaseEntity entity) {
            var lstLocalizacion = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllNotificacionesStatement(entity));
            var dic = new Dictionary<string , object>();
            if (lstResult.Count > 0) {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs) {
                    lstLocalizacion.Add((T)Convert.ChangeType(c , typeof(T)));
                }
            }

            return lstLocalizacion;
        }

        public void UpdatePagoSolicitud(BaseEntity entity) {
            var notificacion = (Notificacion)entity;
            dao.ExecuteProcedure(mapper.GetRegistrarPagoSolicitudStatement(notificacion));
        }

        public override void Delete(BaseEntity entity) {
            throw new NotImplementedException();
        }
    }
}
