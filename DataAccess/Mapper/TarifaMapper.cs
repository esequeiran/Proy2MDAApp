using DataAccess.Dao;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class TarifaMapper : EntityMapper, ISqlStatements, IObjectMapper
    {

        private const string DB_COL_ID_PARAMETRO = "ID_PARAMETRO";
        private const string DB_COL_DESCRIPCION_PARAMETRO = "DESCRIPCION_PARAMETRO";
        private const string DB_COL_PRECIO_POR_CANCELAR = "PRECIO_POR_CANCELAR";
  
        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var tarifa = new Tarifa
            {
                IdParametro = GetIntValue(row, DB_COL_ID_PARAMETRO),
                DescripcionParametro = GetStringValue(row, DB_COL_DESCRIPCION_PARAMETRO),
                PrecioPorCancelar = GetDoubleValue(row, DB_COL_PRECIO_POR_CANCELAR)
               
            };

            return tarifa;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var tarifaCancelar = BuildObject(row);
                lstResults.Add(tarifaCancelar);
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
            var operation = new SqlOperation { ProcedureName = "RET_ALL_TARIFA_PR" };
            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_TARIFA_PR" };
            var tarifa = (Tarifa)entity;
            operation.AddIntParam(DB_COL_ID_PARAMETRO, tarifa.IdParametro);
            operation.AddVarcharParam(DB_COL_DESCRIPCION_PARAMETRO, tarifa.DescripcionParametro);
            operation.AddDoubleParam(DB_COL_PRECIO_POR_CANCELAR, tarifa.PrecioPorCancelar);                      
            return operation;
        }
    }
}
