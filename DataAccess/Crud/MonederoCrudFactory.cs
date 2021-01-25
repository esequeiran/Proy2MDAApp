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
   public class MonederoCrudFactory : CrudFactory
    {
        MonederoMapper mapper;

        public MonederoCrudFactory()
        {
            mapper = new MonederoMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public override void Delete(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public void RecargarMonedero(string cedula,double monto)
        {
            dao.ExecuteProcedure(mapper.GetRecargaMonederoStatement(cedula,monto));
        }
        public void RetiroMonedero(string cedula,double monto)
        {
            dao.ExecuteProcedure(mapper.GetRetiroMonederoStatement(cedula,monto));
        }


        public string RetrieveSaldo(string cedula)
        {
            
            var sqlOperation = mapper.GetSaldoStatement(cedula);
            var lstResult = dao.ExecuteQueryProcedure(sqlOperation);
            Object saldo ;
            var s = lstResult[0].TryGetValue("SALDO_ACTUAL",out saldo);
            string saldoFinal = saldo.ToString();
            return saldoFinal;
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
