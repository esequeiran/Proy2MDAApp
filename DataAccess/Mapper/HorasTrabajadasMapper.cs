using DataAccess.Dao;
using Entities_POJO;
using System;
using System.Collections.Generic;

namespace DataAccess.Mapper
{
    public class HorasTrabajadasMapper:EntityMapper, IObjectMapper, ISqlStatements
    {
        private const string DB_COL_ID_SOLICITUD = "ID_SOLICITUD";
        private const string DB_COL_ID_TIPO_TRABAJO = "ID_TIPO_TRABAJO";
        private const string DB_COL_NOMBRE_TIPO_TRABAJO = "NOMBRE_TIPO_TRABAJO";
        private const string DB_COL_HORAS_TRABAJADAS = "HORAS_TRABAJADAS";
        private const string DB_COL_PRESUPUESTO = "PRESUPUESTO";

        private const string DB_COL_ID_NOTIFICACION = "ID";
        private const string DB_COL_MENSAJE = "MENSAJE";
        private const string DB_COL_ID_CLIENTE = "ID_CLIENTE";
        private const string DB_COL_DESCRIPCION = "DESCRIPCION";

        public SqlOperation GetCreateStatement(BaseEntity entity) {
            var operation = new SqlOperation { ProcedureName = "CRE_HORAS_TRABAJADAS_PR" };

            var t = (SolicitudDeTrabajo)entity;

            operation.AddIntParam(DB_COL_ID_SOLICITUD, t.IdSolicitud);
            operation.AddIntParam(DB_COL_ID_TIPO_TRABAJO , t.TipoTrabajo);
            operation.AddDoubleParam(DB_COL_HORAS_TRABAJADAS , t.HorasTrabajadas);
            operation.AddNVarcharParam(DB_COL_DESCRIPCION , t.Descripcion);

            return operation;
        }

        public SqlOperation GetCreateNotificacionStatement(BaseEntity entity) {
            var operation = new SqlOperation { ProcedureName = "CRE_NOTIFICACION_PR" };

            var n = (Notificacion)entity;

            operation.AddIntParam(DB_COL_ID_SOLICITUD , n.IdSolicitud);
            operation.AddNVarcharParam(DB_COL_MENSAJE , n.Mensaje);

            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity) {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_TIPOS_TRABAJO_POR_SOLICITUD_PR" };

            var tp = (SolicitudDeTrabajo)entity;
            operation.AddIntParam(DB_COL_ID_SOLICITUD , tp.IdSolicitud);

            return operation;
        }

        public SqlOperation GetRetrivePresupuestoStatement(BaseEntity entity) {
            var operation = new SqlOperation { ProcedureName = "RET_VERIFICAR_PRESUPUESTO_SOLICITUD_PR" };

            var tp = (SolicitudDeTrabajo)entity;
            operation.AddIntParam(DB_COL_ID_SOLICITUD , tp.IdSolicitud);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement(BaseEntity entity) {
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
                var trabajo = BuildObject(row);
                lstResults.Add(trabajo);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string , object> row) {
            var tipoDeTrabajo = new TipoDeTrabajo {
                Id_TipoTrabajo = GetIntValue(row , DB_COL_ID_TIPO_TRABAJO) ,
                Nombre_TipoTrabajo = GetStringValue(row , DB_COL_NOMBRE_TIPO_TRABAJO) ,
                HorasTrabajadas = GetIntValue(row , DB_COL_HORAS_TRABAJADAS) 
            };
            return tipoDeTrabajo;
        }

        public List<BaseEntity> BuildObjectsSolicitud(List<Dictionary<string , object>> lstRows) {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows) {
                var solicitud = BuildObjectsSolicitud(row);
                lstResults.Add(solicitud);
            }
            return lstResults;
        }

        public BaseEntity BuildObjectsSolicitud(Dictionary<string , object> row) {
            var tp = new SolicitudDeTrabajo {
                Presupuesto = GetDoubleValue(row , DB_COL_PRESUPUESTO)
            };
            return tp;
        }

        public List<BaseEntity> BuildObjectTipoTrabajo(List<Dictionary<string , object>> lstRows) {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows) {
                var tipoTrabajo = BuildObjectTipoTrabajo(row);
                lstResults.Add(tipoTrabajo);
            }
            return lstResults;
        }

        public BaseEntity BuildObjectTipoTrabajo(Dictionary<string , object> row) {
            var tp = new TipoDeTrabajo {
                Id_TipoTrabajo = GetIntValue(row , DB_COL_ID_TIPO_TRABAJO) ,
                Nombre_TipoTrabajo = GetStringValue(row , DB_COL_NOMBRE_TIPO_TRABAJO),
                HorasTrabajadas = GetDoubleValue(row, DB_COL_HORAS_TRABAJADAS)
            };
            return tp;
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



