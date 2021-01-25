using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Dao;
using DataAccess.Mapper;
using Entities_POJO;

namespace DataAccess.Crud
{
    public class MembresiaCrudFactory : CrudFactory
    {
        MembresiaMapper mapper;

        public MembresiaCrudFactory()
        {
            mapper = new MembresiaMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var membresia = (Membresia)entity;
            var sqlOperation = mapper.GetCreateStatement(membresia);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override void Delete(BaseEntity entity)
        {
            var membresia = (Membresia)entity;
            var sqlOperation = mapper.GetDeleteStatement(membresia);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override T Retrieve<T>(BaseEntity entity)
        {
            throw new NotImplementedException();
        }



        public override List<T> RetrieveAll<T>()
        {
            var lstMembresias = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstMembresias.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }
            return lstMembresias;
        }

        public override void Update(BaseEntity entity)
        {
            var membrecia = (Membresia)entity;
            dao.ExecuteProcedure(mapper.GetUpdateStatement(membrecia));
        }

        public List<T> RetriveAllStatementByEmpresa<T>(BaseEntity baseEntity)
        {
            var lstMembresias = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatementByEmpresa(baseEntity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstMembresias.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }
            return lstMembresias;
        }

        public void CompraMembresia(Membresia membresia)
        {
            dao.ExecuteProcedure(mapper.GetUpdateMembresiaStatement(membresia));
        }

    }
}
