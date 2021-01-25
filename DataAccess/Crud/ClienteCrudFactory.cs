using DataAccess.Dao;
using DataAccess.Mapper;
using Entities_POJO;
using System;
using System.Collections.Generic;

namespace DataAccess.Crud
{
    public class ClienteCrudFactory: CrudFactory
    {
        ClienteMapper mapper;

        public ClienteCrudFactory() {
            mapper = new ClienteMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity) {
            var cliente = (Cliente)entity;
            var sqlOperation = mapper.GetCreateStatement(cliente);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override T Retrieve<T>(BaseEntity entity) {
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveStatement(entity));
            var dic = new Dictionary<string , object>();
            if (lstResult.Count > 0) {
                dic = lstResult[0];
                var objs = mapper.BuildObject(dic);
                return (T)Convert.ChangeType(objs , typeof(T));
            }
            return default(T);
        }

        public override List<T> RetrieveAll<T>() {
            var lstCliente = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
            var dic = new Dictionary<string , object>();
            if (lstResult.Count > 0) {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs) {
                    lstCliente.Add((T)Convert.ChangeType(c , typeof(T)));
                }
            }
            return lstCliente;
        }

        public override void Update(BaseEntity entity) {
            var cliente = (Cliente)entity;
            dao.ExecuteProcedure(mapper.GetUpdateStatement(cliente));
        }

        public override void Delete(BaseEntity entity) {
            throw new NotImplementedException();
        }
    }
}
