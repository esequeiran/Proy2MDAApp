using DataAccess.Dao;
using Entities_POJO;
using System;
using System.Collections.Generic;

namespace DataAccess.Mapper
{
    public class CancelarMembresiaMapper : EntityMapper, ISqlStatements, IObjectMapper
    {
        private const string DB_COL_ID_MEMBRESIA = "ID_MEMBRESIA";

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_CANCELAR_MEMBRESIA_PR" };
            var c = (CancelarMembresia)entity;
            operation.AddIntParam(DB_COL_ID_MEMBRESIA, c.Id);
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
        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var obj = BuildObject(row);
                lstResults.Add(obj);
            }

            return lstResults;
        }
        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var obj = new CancelarMembresia
            {
                Id = GetIntValue(row, DB_COL_ID_MEMBRESIA)
            };
            return obj;
        }
    }
}
