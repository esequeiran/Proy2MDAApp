using DataAccess.Dao;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class BitacoraMapper : EntityMapper, ISqlStatements, IObjectMapper
    {
  
        private const string DB_COL_ID_BITACORA = "ID_BITACORA";
        private const string DB_COL_CEDULA_USUARIO = "CEDULA_USUARIO";
        private const string DB_COL_NOMBRE = "NOMBRE";
        private const string DB_COL_DESCRIPCION_ACCION = "DESCRIPCION_ACCION";
        private const string DB_COL_FECHA = "FECHA";

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var bitacora = new Bitacora
            {
               IdBitacora = GetIntValue(row, DB_COL_ID_BITACORA),
               Nombre = GetStringValue(row, DB_COL_NOMBRE),
               DescripcionAccion = GetStringValue(row, DB_COL_DESCRIPCION_ACCION),
               Fecha = GetStringValue(row, DB_COL_FECHA)
            };

            return bitacora;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var bitacora = BuildObject(row);
                lstResults.Add(bitacora);
            }

            return lstResults;
        }

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_BITACORA_ACCIONES_PR" };
            var bitacora = (Bitacora)entity;
            operation.AddVarcharParam(DB_COL_CEDULA_USUARIO, bitacora.CedulaUsuario);
            operation.AddVarcharParam(DB_COL_DESCRIPCION_ACCION, bitacora.DescripcionAccion);
            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_BITACORA_ACCIONES_PR" };
            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }


        SqlOperation ISqlStatements.GetUpdateStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
