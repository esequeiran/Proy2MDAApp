using DataAccess.Dao;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class TerminosCondicionesMapper : EntityMapper, IObjectMapper, ISqlStatements
    {
        private const string DB_TERMINOS_CONDICIONES = "TERMINOS_CONDICIONES";
        private const string DB_DESCRIPCION = "DESCRIPCION_PARAMETRO";


        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var terminos = new TerminosCondiciones
            {
                Terminos = GetStringValue(row, DB_TERMINOS_CONDICIONES),
                Descripcion = GetStringValue(row, DB_DESCRIPCION)
            };

            return terminos;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var especialidad = BuildObject(row);
                lstResults.Add(especialidad);
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
            var operation = new SqlOperation { ProcedureName = "RET_ALL_TERMINOS_CONDICIONES_PR" };
            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_TERMINOS_CONDICIONES_PR" };

            var c = (TerminosCondiciones)entity;
            operation.AddVarcharParam(DB_TERMINOS_CONDICIONES, c.Terminos);
            return operation;
        }
    }
}
