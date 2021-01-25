using DataAccess.Dao;
using Entities_POJO;
using System;
using System.Collections.Generic;

namespace DataAccess.Mapper
{
    public class VigenciaMembresiaMapper : EntityMapper, ISqlStatements
    {
        private const string DB_COL_ESTA_VIGENTE = "ESTA_VIGENTE";
        private const string DB_COL_ID_MEMBRESIA = "ID_MEMBRESIA";
        private const string DB_COL_NOMBRE_MEMBRESIA = "NOMBRE_MEMBRESIA";
        private const string DB_COL_ID_USUARIO = "ID_USUARIO";
        private const string DB_COL_CORREO = "CORREO";
        private const string DB_COL_NOMBRE_COMPLETO = "NOMBRE_COMPLETO";

        public SqlOperation GetRetriveAllStatement(string idUsuario)
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_ID_MEMBRESIA_PR" };
            operation.AddNVarcharParam(DB_COL_ID_USUARIO, idUsuario);
            return operation;
        }
        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_MEMBRESIA_ESTA_VIGENTE_PR" };
            var c = (VigenciaMembresia)entity;
            operation.AddIntParam(DB_COL_ID_MEMBRESIA, c.Valor);
            return operation;
        }
        public SqlOperation GetRetriveAllStatement()
        {
            throw new NotImplementedException();
        }
        public SqlOperation GetUpdateStatement(BaseEntity entity)
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
        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var obj = new VigenciaMembresia
            {
                Valor = GetIntValue(row, DB_COL_ESTA_VIGENTE)
            };
            return obj;
        }
        public BaseEntity BuildObjectIdsMembresia(Dictionary<string, object> row)
        {
            var obj = new VigenciaMembresias
            {
                Id = GetIntValue(row, DB_COL_ID_MEMBRESIA),
                Valor = GetStringValue(row, DB_COL_NOMBRE_MEMBRESIA),
                Correo = GetStringValue(row, DB_COL_CORREO),
                NombreCompleto = GetStringValue(row, DB_COL_NOMBRE_COMPLETO)
            };
            return obj;
        }
    }
}
