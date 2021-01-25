using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Dao;
using Entities_POJO;

namespace DataAccess.Mapper
{
    public class MonederoMapper : EntityMapper, ISqlStatements, IObjectMapper
    {
        private const string DB_COL_CEDULA_USUARIO = "CEDULA_USUARIO";
        private const string DB_COL_MONTO = "MONTO";
        private const string DB_COL_FECHA = "FECHA";


        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            throw new NotImplementedException();
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRecargaMonederoStatement(string cedula, double monto)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_RECARGAR_MONEDERO_PR" };
            operation.AddNVarcharParam(DB_COL_CEDULA_USUARIO, cedula);
            operation.AddDoubleParam(DB_COL_MONTO, monto);
            operation.AddDateTimeParam(DB_COL_FECHA, DateTime.Now);
      
            return operation;
        }       
        public SqlOperation GetRetiroMonederoStatement(string cedula, double monto)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_RETIRO_MONEDERO_PR" };
            operation.AddNVarcharParam(DB_COL_CEDULA_USUARIO, cedula);
            operation.AddDoubleParam(DB_COL_MONTO, monto);
            operation.AddDateTimeParam(DB_COL_FECHA, DateTime.Now);
      
            return operation;
        }               
        public SqlOperation GetSaldoStatement(string cedula)
        {
            var operation = new SqlOperation { ProcedureName = "RET_SALDO_PR" };
            operation.AddNVarcharParam(DB_COL_CEDULA_USUARIO, cedula);

            return operation;
        }       


        public SqlOperation GetRetriveAllStatement()
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
