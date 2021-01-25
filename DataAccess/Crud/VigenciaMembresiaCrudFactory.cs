using DataAccess.Dao;
using DataAccess.Mapper;
using Entities_POJO;
using System;
using System.Collections.Generic;

namespace DataAccess.Crud
{
    public class VigenciaMembresiaCrudFactory : CrudFactory
    {

        private VigenciaMembresiaMapper mapper;

        public VigenciaMembresiaCrudFactory()
        {
            mapper = new VigenciaMembresiaMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            dao.ExecuteProcedure(mapper.GetCreateStatement(entity));
        }
        public override void Update(BaseEntity entity)
        {
            dao.ExecuteProcedure(mapper.GetUpdateStatement(entity));
        }

        public override void Delete(BaseEntity entity)
        {
            dao.ExecuteProcedure(mapper.GetDeleteStatement(entity));
        }
        public override T Retrieve<T>(BaseEntity entity)
        {
            var sqlOperation = mapper.GetRetriveStatement(entity);
            var lstResult = dao.ExecuteQueryProcedure(sqlOperation);
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
            var res = new List<T>();
            var sqlOperation = mapper.GetRetriveAllStatement();
            var lstResult = dao.ExecuteQueryProcedure(sqlOperation);
            if (lstResult.Count > 0)
            {
                var objs = BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    res.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }
            return res;
        }

        /// <summary>
        /// Lista todos los id y nombre de membresías que pertenecen a idUsuario.
        /// Ejecuta: RET_ALL_ID_MEMBRESIA_PR
        /// </summary>
        public List<T> RetrieveAll<T>(string idUsuario)
        {
            var res = new List<T>();
            var sqlOperation = mapper.GetRetriveAllStatement(idUsuario);
            var lstResult = dao.ExecuteQueryProcedure(sqlOperation);
            if (lstResult.Count > 0)
            {
                var objs = BuildIdsMembresia(lstResult);
                foreach (var c in objs)
                {
                    res.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }
            return res;
        }
        private List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var obj = mapper.BuildObject(row);
                lstResults.Add(obj);
            }

            return lstResults;
        }
        private List<BaseEntity> BuildIdsMembresia(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var obj = mapper.BuildObjectIdsMembresia(row);
                lstResults.Add(obj);
            }

            return lstResults;
        }
    }
}
