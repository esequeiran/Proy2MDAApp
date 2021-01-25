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
    public class TipoTrabajoPorEmpresaCrudFactory : CrudFactory
    {
        TipoTrabajoPorEmpresaMapper mapper;

        public TipoTrabajoPorEmpresaCrudFactory() : base()
        {
            mapper = new TipoTrabajoPorEmpresaMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var TipoTrabajoPorEmpresa = (TipoTrabajoPorEmpresa)entity;
            var sqlOperation = mapper.GetCreateStatement(TipoTrabajoPorEmpresa);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override void Delete(BaseEntity entity)
        {
            var TipoTrabajoPorEmpres = (TipoTrabajoPorEmpresa)entity;
            dao.ExecuteProcedure(mapper.GetDeleteStatement(TipoTrabajoPorEmpres));
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
            var lstTipoTrabajoPorEmpreses = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstTipoTrabajoPorEmpreses.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }
            return lstTipoTrabajoPorEmpreses;
        }

        //Fixed
        public List<T> RetrieveAll2<T>(BaseEntity entity)
        {
            var lstTipoTrabajoPorEmpreses = new List<T>();
            var a = mapper.GetRetriveStatement(entity);

            var lstResult = dao.ExecuteQueryProcedure(a);
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstTipoTrabajoPorEmpreses.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }
            return lstTipoTrabajoPorEmpreses;
        }

        public override void Update(BaseEntity entity)
        {
            var TipoTrabajoPorEmpres = (TipoTrabajoPorEmpresa)entity;
            dao.ExecuteProcedure(mapper.GetUpdateStatement(TipoTrabajoPorEmpres));
        }

    }
}
