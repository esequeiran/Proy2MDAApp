using DataAccess.Dao;
using Entities_POJO;
using System;
using System.Collections.Generic;

namespace DataAccess.Mapper
{
    public class EstadosUsuarioMapper : EntityMapper, ISqlStatements, IObjectMapper
    {
        private const string DB_COL_ID_ESTADO = "ID_ESTADO";
        private const string DB_COL_VALOR = "VALOR";
        private const string DB_COL_CORREO = "CORREO";
        private const string DB_COL_ID_NUEVO_ESTADO = "ID_NUEVO_ESTADO";
        private const string DB_COL_DIAS_SUSPENDIDO = "DIAS_SUSPENDIDO";

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_ESTADO_USUARIO_PR" };
            return operation;
        }
        public SqlOperation GetRetriveAllCambioStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_ESTADO_USUARIO_CAMBIO_PR" };
            return operation;
        }
        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_ESTADO_USUARIO_PR" };
            var c = (EstadosUsuario)entity;
            operation.AddNVarcharParam(DB_COL_CORREO, c.Valor);
            return operation;
        }
        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_ESTADO_USUARIO_PR" };
            var c = (EstadosUsuario)entity;
            operation.AddNVarcharParam(DB_COL_CORREO, c.Valor);
            operation.AddIntParam(DB_COL_ID_NUEVO_ESTADO, c.Id);
            operation.AddIntParam(DB_COL_DIAS_SUSPENDIDO, c.diasSuspendido);
            return operation;
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
            var obj = new EstadosUsuario
            {
                Id = GetIntValue(row, DB_COL_ID_ESTADO),
                Valor = GetStringValue(row, DB_COL_VALOR),
                diasSuspendido = 0
            };
            return obj;
        }
    }
}
