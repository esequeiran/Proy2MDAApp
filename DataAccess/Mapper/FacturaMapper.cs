using DataAccess.Dao;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class FacturaMapper:EntityMapper, IObjectMapper, ISqlStatements
    {
        private const string DB_COL_ID_FACTURA = "ID_FACTURA";
        private const string DB_COL_FECHA = "FECHA";
        private const string DB_COL_SUBTOTAL = "SUBTOTAL";
        private const string DB_COL_FEE = "VALOR_FEE";
        private const string DB_COL_IVA = "VALOR_IVA";
        private const string DB_COL_TOTAL = "TOTAL";
        private const string DB_COL_NOMBRE_COMPLETO = "NOMBRE_COMPLETO";

        private const string DB_COL_ID_SOLICITUD = "ID_SOLICITUD";
        private const string DB_COL_ID_USUARIO = "ID_USUARIO";

        private const string DB_COL_CANT_HORAS = "CANTIDAD_HORAS";
        private const string DB_COL_TOTAL_LINEA = "TOTAL_LINEA";
        private const string DB_COL_PRECIO_POR_HORA = "PRECIO_POR_HORA";
        private const string DB_COL_DESCRIPCION = "DESCRIPCION";


        public SqlOperation GetRetriveEncabezadoStatement(BaseEntity entity) {
            var operation = new SqlOperation { ProcedureName = "RET_FACTURA_ENCABEZADO_SOLICITUD" };

            var a = (Factura)entity;
            operation.AddIntParam(DB_COL_ID_SOLICITUD , a.IdSolicitud);

            return operation;
        }

        public List<BaseEntity> BuildObjectsEncabezado(List<Dictionary<string , object>> lstRows) {
            var lstResults = new List<BaseEntity>();
            foreach (var row in lstRows) {
                var notificacion = BuildObjectsEncabezado(row);
                lstResults.Add(notificacion);
            }
            return lstResults;
        }

        public BaseEntity BuildObjectsEncabezado(Dictionary<string , object> row) {
            var notificacion = new Factura {
                IdFactura = GetIntValue(row , DB_COL_ID_FACTURA) ,
                FechaEvento = GetDateValue(row, DB_COL_FECHA),
                Subtotal = GetDoubleValue(row, DB_COL_SUBTOTAL), 
                Iva = GetDoubleValue(row , DB_COL_IVA) ,
                Total = GetDoubleValue(row , DB_COL_TOTAL) ,
                NombreCompleto = GetStringValue(row, DB_COL_NOMBRE_COMPLETO),
                IdCliente = GetStringValue(row, DB_COL_ID_USUARIO)
            };
            return notificacion;
        }
        public SqlOperation GetRetriveCuerpoFacStatement(BaseEntity entity) {
            var operation = new SqlOperation { ProcedureName = "RET_FACTURA_CUERPO_SOLICITUD" };

            var a = (Factura)entity;
            operation.AddIntParam(DB_COL_ID_SOLICITUD , a.IdSolicitud);

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
            var notificacion = new Factura {
                CantHoras  = GetDoubleValue(row , DB_COL_CANT_HORAS) ,
                PrecioPorHora = GetDoubleValue(row , DB_COL_PRECIO_POR_HORA) ,
                TotalLinea = GetDoubleValue(row , DB_COL_TOTAL_LINEA) ,
                Descripcion = GetStringValue(row, DB_COL_DESCRIPCION)
            };
            return notificacion;
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
