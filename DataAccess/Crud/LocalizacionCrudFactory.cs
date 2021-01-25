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
    public class LocalizacionCrudFactory : CrudFactory
    {
        LocalizacionMapper mapper;

        public LocalizacionCrudFactory()
        {
            mapper = new LocalizacionMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var localizacion = (Localizacion)entity;
            var sqlOperation = mapper.GetCreateStatement(localizacion);
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
            var lstLocalizacion = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstLocalizacion.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstLocalizacion;
        }

        public override void Update(BaseEntity entity)
        {
            var localizacion = (Localizacion)entity;
            dao.ExecuteProcedure(mapper.GetUpdateStatement(localizacion));
        }

        public override void Delete(BaseEntity entity)
        {
            var localizacion = (Localizacion)entity;
            dao.ExecuteProcedure(mapper.GetDeleteStatement(localizacion));
        }

        public List<T> RetrieveAllByUser<T>(BaseEntity entity)
        {
            var lstLocalizacion = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstLocalizacion.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstLocalizacion;
        }
    }
}