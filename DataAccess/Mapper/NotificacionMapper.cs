using DataAccess.Dao;
using Entities_POJO;
using System;
using System.Collections.Generic;

namespace DataAccess.Mapper
{
    public class NotificacionMapper:EntityMapper, IObjectMapper, ISqlStatements
    {
        private const string DB_COL_ID= "ID";
        private const string DB_COL_ID_SOLICITUD= "ID_SOLICITUD";
        private const string DB_COL_MENSAJE = "MENSAJE";
        private const string DB_COL_ID_CLIENTE = "ID_USUARIO";
        private const string DB_COL_NUM_NOTIFICACIONES = "NUM_NOTIFICACIONES";


        public SqlOperation GetRetriveStatement(BaseEntity entity) {
            var operation = new SqlOperation { ProcedureName = "RET_NUM_NOTIFICACIONES_PAGO_CLIENTE" };

            var a = (Notificacion)entity;
            operation.AddVarcharParam(DB_COL_ID_CLIENTE , a.IdCliente);

            return operation;
        }
        public List<BaseEntity> BuildObjectsCantHoras(List<Dictionary<string , object>> lstRows) {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows) {
                var notificacion = BuildObjectCantHoras(row);
                lstResults.Add(notificacion);
            }

            return lstResults;
        }

        public BaseEntity BuildObjectCantHoras(Dictionary<string , object> row) {
            var notificacion = new Notificacion {
                CantNotificaciones = GetIntValue(row , DB_COL_NUM_NOTIFICACIONES) ,
            };
            return notificacion;
        }
        public SqlOperation GetRetriveAllNotificacionesStatement(BaseEntity entity) {
            var operation = new SqlOperation { ProcedureName = "RET_NOTIFICACIONES_PAGO_CLIENTE" };

            var a = (Notificacion)entity;
            operation.AddVarcharParam(DB_COL_ID_CLIENTE , a.IdCliente);

            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity) {
            var operation = new SqlOperation { ProcedureName = "UPD_NOTIFICACIONES_PAGO_CLIENTE" };

            var a = (Notificacion)entity;
            operation.AddIntParam(DB_COL_ID , a.Id);
            operation.AddNVarcharParam(DB_COL_ID_CLIENTE , a.IdCliente);

            return operation;
        }
        
        public List<BaseEntity> BuildObjects(List<Dictionary<string , object>> lstRows) {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows) {
                var notificacion = BuildObject(row);
                lstResults.Add(notificacion);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string , object> row) {
            var notificacion = new Notificacion {
                Id = GetIntValue(row , DB_COL_ID) ,
                IdSolicitud = GetIntValue(row , DB_COL_ID_SOLICITUD) ,
                Mensaje = GetStringValue(row , DB_COL_MENSAJE)
            };
            return notificacion;
        }

        public SqlOperation GetRegistrarPagoSolicitudStatement(BaseEntity entity) {
            var operation = new SqlOperation { ProcedureName = "PAGAR_SOLICITUD_TRABAJO" };

            var a = (Notificacion)entity;
            operation.AddIntParam(DB_COL_ID_SOLICITUD , a.IdSolicitud);

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
