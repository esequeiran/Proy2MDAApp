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
    //VERSION NUEVA
    public class EspecialidadCrudFactory : CrudFactory
    {
        EspecialidadMapper mapper;

        public EspecialidadCrudFactory() : base()
        {
            mapper = new EspecialidadMapper();
            dao = SqlDao.GetInstance();
        }


        public override void Create(BaseEntity entity)
        {
            var especialidad = (Especialidad)entity;
            var sqlOperation = mapper.GetCreateStatement(especialidad);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override void Delete(BaseEntity entity)
        {
            var especialidad = (Especialidad)entity;
            dao.ExecuteProcedure(mapper.GetDeleteStatement(especialidad));
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
            var lstEspecialidades = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstEspecialidades.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }
            return lstEspecialidades;
        }

        public override void Update(BaseEntity entity)
        {
            var especialidad = (Especialidad)entity;
            dao.ExecuteProcedure(mapper.GetUpdateStatement(especialidad));
        }

    }

}
