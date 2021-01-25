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
    public class DashOferenteCrudFactory : CrudFactory
    {
        DashOferenteMapper mapper;
        public DashOferenteCrudFactory() : base()
        {
            mapper = new DashOferenteMapper();
            dao = SqlDao.GetInstance();
        }
        public List<T> RetrieveTrabajos<T>(string idEmpresa)
        {
            var lstOferente = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllTrabajos(idEmpresa));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstOferente.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }
            return lstOferente;
        }
        public List<T> RetrieveTrabajadores<T>(string idEmpresa)
        {
            var lstOferente = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllTrabajadores(idEmpresa));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjectsTrabajadores(lstResult);
                foreach (var c in objs)
                {
                    lstOferente.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }
            return lstOferente;
        }
        public override void Create(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public override void Delete(BaseEntity entity)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
