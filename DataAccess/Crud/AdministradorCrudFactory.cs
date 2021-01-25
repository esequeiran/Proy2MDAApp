using DataAccess.Dao;
using DataAccess.Mapper;
using Entities_POJO;
using System;
using System.Collections.Generic;

namespace DataAccess.Crud
{
    public class AdministradorCrudFactory : CrudFactory
    {
        AdministradorMapper mapper;

        public AdministradorCrudFactory()
        {
            mapper = new AdministradorMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var administrador = (Administrador)entity;
            var sqlOperation = mapper.GetCreateStatement(administrador);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override T Retrieve<T>(BaseEntity entity)
        {
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = mapper.BuildObject(dic);
                return (T)Convert.ChangeType(objs, typeof(T));
            }
            return default(T);
        }

        public override List<T> RetrieveAll<T>()
        {
            var lstAdministrador = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstAdministrador.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }
            return lstAdministrador;
        }

        public override void Update(BaseEntity entity)
        {
            var administrador = (Administrador)entity;
            dao.ExecuteProcedure(mapper.GetUpdateStatement(administrador));
        }

        public override void Delete(BaseEntity entity)
        {
            var administrador = (Administrador)entity;
            dao.ExecuteProcedure(mapper.GetDeleteStatement(administrador));
        }

    }
}