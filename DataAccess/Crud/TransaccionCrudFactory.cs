using DataAccess.Dao;
using DataAccess.Mapper;
using Entities_POJO;
using System;
using System.Collections.Generic;

namespace DataAccess.Crud
{
    public class TransaccionCrudFactory:CrudFactory
    {
        TransaccionMapper mapper;

        public TransaccionCrudFactory() {
            mapper = new TransaccionMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity) {
            throw new NotImplementedException();
        }

        public override T Retrieve<T>(BaseEntity entity) {
            throw new NotImplementedException();
        }

        public List<T> RetrieveIngresos<T>(BaseEntity entity) {
            var lstTransaccion = new List<T>();

            var transaccion = (Transaccion)entity;

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllIngresosStatement(transaccion));

            var dic = new Dictionary<string , object>();
            if (lstResult.Count > 0) 
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstTransaccion.Add((T)Convert.ChangeType(c , typeof(T)));
                }
            }
            return lstTransaccion;
        }

        public List<T> RetriveAllTransactions<T>(BaseEntity entity) {
            var lstTransaccion = new List<T>();

            var transaccion = (Transaccion)entity;

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllTransactionsStatement(transaccion));

            var dic = new Dictionary<string , object>();
            if (lstResult.Count > 0) {
                var objs = mapper.BuildObjectsTransactions(lstResult);
                foreach (var c in objs) {
                    lstTransaccion.Add((T)Convert.ChangeType(c , typeof(T)));
                }
            }
            return lstTransaccion;
        }      

        public List<T> RetriveIngresosOferente<T>(BaseEntity entity) {
            var lstTransaccion = new List<T>();

            var transaccion = (Transaccion)entity;

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetIngresosOferenteStatement(transaccion));

            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstTransaccion.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }
            return lstTransaccion;
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

