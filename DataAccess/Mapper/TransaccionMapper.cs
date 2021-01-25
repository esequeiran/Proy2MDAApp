using DataAccess.Dao;
using Entities_POJO;
using System;
using System.Collections.Generic;

namespace DataAccess.Mapper
{
    public class TransaccionMapper:EntityMapper, IObjectMapper, ISqlStatements
    {
        private const string DB_COL_ID_USUARIO = "ID_USUARIO";
        private const string DB_COL_ID_TRANSACCION = "ID_TRANSACCION_FINANCIERA";
        private const string DB_COL_FECHA = "FECHA";
        private const string DB_COL_MONTO = "MONTO";
        private const string DB_COL_CONCEPTO = "CONCEPTO";
        private const string DB_COL_TIPO_MOVIMIENTO = "TIPO_MOVIMIENTO";

        public SqlOperation GetCreateStatement(BaseEntity entity) {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity) {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_INGRESOS_PR" };

            var t = (Transaccion)entity;
            operation.AddVarcharParam(DB_COL_ID_USUARIO , t.IdUsuario);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement() {
            throw new NotImplementedException();
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity) {
            throw new NotImplementedException();
        }
        public SqlOperation GetDeleteStatement(BaseEntity entity) {
            throw new NotImplementedException();
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string , object>> lstRows) {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows) {
                var transaccion = BuildObject(row);
                lstResults.Add(transaccion);
            }
            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string , object> row) {
            var transaccion = new Transaccion {
                Fecha = GetStringValue(row , DB_COL_FECHA) ,
                Monto = GetDoubleValue(row , DB_COL_MONTO) 
            };
            return transaccion;
        }

        public SqlOperation GetRetriveAllIngresosStatement(BaseEntity entity) {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_INGRESOS_PR" };

            var t = (Transaccion)entity;
            operation.AddVarcharParam(DB_COL_ID_USUARIO , t.IdUsuario);

            return operation;
        }

        public SqlOperation GetRetriveAllTransactionsStatement(BaseEntity entity) {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_TRANSACCIONES_PR" };

            var t = (Transaccion)entity;
            operation.AddVarcharParam(DB_COL_ID_USUARIO , t.IdUsuario);

            return operation;
        }

        public List<BaseEntity> BuildObjectsTransactions(List<Dictionary<string , object>> lstRows) {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows) {
                var transaccion = BuildObjectT(row);
                lstResults.Add(transaccion);
            }
            return lstResults;
        }

        public BaseEntity BuildObjectT(Dictionary<string , object> row) {
            var transaccion = new Transaccion {
                Fecha = GetStringValue(row , DB_COL_FECHA) ,
                Monto = GetDoubleValue(row , DB_COL_MONTO),
                Concepto = GetStringValue(row, DB_COL_CONCEPTO),
                TipoMovimiento = GetStringValue (row, DB_COL_TIPO_MOVIMIENTO)
            };
            return transaccion;
        }
        public SqlOperation GetIngresosOferenteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_INGRESOS_OFERENTE_PR" };

            var t = (Transaccion)entity;
            operation.AddVarcharParam(DB_COL_ID_USUARIO, t.IdUsuario);

            return operation;
        }

        SqlOperation ISqlStatements.GetCreateStatement(BaseEntity entity) {
            throw new NotImplementedException();
        }

        SqlOperation ISqlStatements.GetRetriveStatement(BaseEntity entity) {
            throw new NotImplementedException();
        }

        SqlOperation ISqlStatements.GetRetriveAllStatement() {
            throw new NotImplementedException();
        }

        SqlOperation ISqlStatements.GetUpdateStatement(BaseEntity entity) {
            throw new NotImplementedException();
        }

        SqlOperation ISqlStatements.GetDeleteStatement(BaseEntity entity) {
            throw new NotImplementedException();
        }
    }
}
