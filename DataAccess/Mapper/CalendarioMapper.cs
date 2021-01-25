using DataAccess.Dao;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class CalendarioMapper : EntityMapper, ISqlStatements, IObjectMapper
    {
        private const string DB_COL_FECHA = "ID_FECHA";
        private const string DB_COL_DESCRIPCION = "DESCRIPCION";

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var calendario = new Calendario
            {
                Fecha = GetStringValue (row, DB_COL_FECHA),
                Descripcion = GetStringValue(row, DB_COL_DESCRIPCION)
            };

            return calendario;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var membresia = BuildObject(row);
                lstResults.Add(membresia);
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
            var operation = new SqlOperation { ProcedureName = "RET_ALL_CALENDARIO_PR" };
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
