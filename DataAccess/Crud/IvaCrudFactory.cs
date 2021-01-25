using DataAccess.Dao;
using DataAccess.Mapper;
using Entities_POJO;
using System;
using System.Collections.Generic;

namespace DataAccess.Crud
{
    public class IvaCrudFactory : CrudFactory
    {
        IvaMapper mapper;

        public IvaCrudFactory()
        {
            mapper = new IvaMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public Iva Retrieve()
        {
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = mapper.BuildObject(dic);
                return (Iva)Convert.ChangeType(objs, typeof(Iva));
            }
            return default(Iva);
        }

        public override T Retrieve<T>(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public override List<T> RetrieveAll<T>()
        {
            throw new NotImplementedException();
        }

        public override void Update(BaseEntity entity)
        {
            var iva = (Iva)entity;
            dao.ExecuteProcedure(mapper.GetUpdateStatement(iva));
        }

        public override void Delete(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}