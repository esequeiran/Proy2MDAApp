using DataAccess.Dao;
using DataAccess.Mapper;
using Entities_POJO;
using System;
using System.Collections.Generic;

namespace DataAccess.Crud
{
    public class FacturaCrudFactory : CrudFactory
    {
        FacturaMapper mapper;

        public FacturaCrudFactory() {
            mapper = new FacturaMapper();
            dao = SqlDao.GetInstance();
        }
        //encabezado
        public override T Retrieve<T>(BaseEntity entity) {
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveEncabezadoStatement(entity));
            var dic = new Dictionary<string , object>();
            if (lstResult.Count > 0) {
                dic = lstResult[0];
                var objs = mapper.BuildObjectsEncabezado(dic);
                return (T)Convert.ChangeType(objs , typeof(T));
            }
            return default(T);
        }

        //cuerpo
        public List<T> RetrieveAllFacDetalle<T>(BaseEntity entity) {
            var lstDetalle = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveCuerpoFacStatement(entity));
            var dic = new Dictionary<string , object>();
            if (lstResult.Count > 0) {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs) {
                    lstDetalle.Add((T)Convert.ChangeType(c , typeof(T)));
                }
            }

            return lstDetalle;
        }

        public override void Create(BaseEntity entity) {
            throw new NotImplementedException();
        }

        public override List<T> RetrieveAll<T>() {
            throw new NotImplementedException();
        }

        public override void Update(BaseEntity entity) {
            throw new NotImplementedException();
        }

        public List<T> RetrieveAllByUser<T>(BaseEntity entity) {
            throw new NotImplementedException();
        }

        public override void Delete(BaseEntity entity) {
            throw new NotImplementedException();
        }
    }
}
