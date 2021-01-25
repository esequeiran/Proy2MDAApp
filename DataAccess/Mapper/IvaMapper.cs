using DataAccess.Dao;
using Entities_POJO;
using System;
using System.Collections.Generic;

namespace DataAccess.Mapper
{
    public class IvaMapper : EntityMapper, IObjectMapper, ISqlStatements
    {
        private const string DB_COL_ID_IVA = "ID_PARAMETRO";
        private const string DB_COL_PORCENTAJE_IVA = "PORCENTAJE_IVA";

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetriveStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_IVA_PR" };
            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_IVA_PR" };

            var i = (Iva)entity;
            operation.AddDoubleParam(DB_COL_PORCENTAJE_IVA, i.PorcentajeIVA);

            return operation;
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
                var iva = BuildObject(row);
                lstResults.Add(iva);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var iva = new Iva
            {
                Id = GetIntValue(row, DB_COL_ID_IVA),
                PorcentajeIVA = GetDoubleValue(row, DB_COL_PORCENTAJE_IVA)
            };
            return iva;
        }

        SqlOperation ISqlStatements.GetCreateStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        SqlOperation ISqlStatements.GetRetriveStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        SqlOperation ISqlStatements.GetRetriveAllStatement()
        {
            throw new NotImplementedException();
        }

        SqlOperation ISqlStatements.GetUpdateStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        SqlOperation ISqlStatements.GetDeleteStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}