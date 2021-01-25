using DataAccess.Dao;
using DataAccess.Mapper;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Crud
{

    public class TipoDeTrabajoCrudFactory : CrudFactory
    {
        TipoDeTrabajoMapper mapper;

        public TipoDeTrabajoCrudFactory()
        {
            mapper = new TipoDeTrabajoMapper();
            dao = SqlDao.GetInstance();
        }


        public override void Create(BaseEntity entity)
        {
            var tiposDeTrabajo = (TipoDeTrabajo)entity;
            var sqlOperation = mapper.GetCreateStatement(tiposDeTrabajo);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override void Delete(BaseEntity entity)
        {
            var tiposDeTrabajo = (TipoDeTrabajo)entity;
            dao.ExecuteProcedure(mapper.GetDeleteStatement(tiposDeTrabajo));
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
            var lstTiposDeTrabajo = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstTiposDeTrabajo.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }
            return lstTiposDeTrabajo;
        }

        public override void Update(BaseEntity entity)
        {
            var tiposDeTrabajo = (TipoDeTrabajo)entity;
            dao.ExecuteProcedure(mapper.GetUpdateStatement(tiposDeTrabajo));
        }

    }
}
