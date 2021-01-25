using DataAccess.Dao;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class AppMessagesMapper : EntityMapper, ISqlStatements, IObjectMapper
    {
        private const string DB_COL_ID_EXCEPCION = "ID_EXCEPCION";
        private const string DB_COL_MENSAJE_EXCEPCION = "MENSAJE_EXCEPCION";
        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var appM = new ApplicationMessage
            {
                Id = GetIntValue(row, DB_COL_ID_EXCEPCION),
                Message = GetStringValue(row, DB_COL_MENSAJE_EXCEPCION),
            };
            return appM;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var appM = BuildObject(row);
                lstResults.Add(appM);
            }

            return lstResults;
        }

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_EXCEPCIONES_PR" };
            return operation;
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
