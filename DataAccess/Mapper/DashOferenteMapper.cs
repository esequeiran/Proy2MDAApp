using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Dao;
using Entities_POJO;

namespace DataAccess.Mapper
{
    public class DashOferenteMapper : EntityMapper, ISqlStatements, IObjectMapper
    {
        private const string DB_COL_ID_EMPRESA = "ID_EMPRESA";
        private const string DB_COL_ID_SOLICITUD = "ID_SOLICITUD";
        private const string DB_COL_ID_ESTADO = "ID_ESTADO";
        private const string DB_COL_FECHA_EVENTO = "FECHA_EVENTO";
        private const string DB_COL_ID_USUARIO = "ID_USUARIO";
        private const string DB_COL_NOMBRE = "NOMBRE";

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var trabajos = new DashOferente
            {
                IdSolicitud = GetIntValue(row, DB_COL_ID_SOLICITUD),
                FechaEvento = GetDateValue(row, DB_COL_FECHA_EVENTO),
                IdEstado = GetStringValue(row, DB_COL_ID_ESTADO),

            };

            return trabajos;
        }  
        public BaseEntity BuildObjectTrabajador(Dictionary<string, object> row)
        {
            var trabajos = new Trabajador
            {
                Cedula = GetStringValue(row, DB_COL_ID_USUARIO),
                Nombre = GetStringValue(row, DB_COL_NOMBRE)
              

            };

            return trabajos;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var trabajador = BuildObject(row);
                lstResults.Add(trabajador);
            }

            return lstResults;
        }        
        public List<BaseEntity> BuildObjectsTrabajadores(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var trabajador = BuildObjectTrabajador(row);
                lstResults.Add(trabajador);
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
            throw new NotImplementedException();
        }

        public SqlOperation GetRetriveAllTrabajos(string idEmpresa)
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_TRABAJOS_OFERENTE_PR" };
            operation.AddNVarcharParam(DB_COL_ID_EMPRESA, idEmpresa);
            return operation;
        }    
        public SqlOperation GetRetriveAllTrabajadores(string idEmpresa)
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_TRABAJADORES_OFERENTE_PR" };
            operation.AddNVarcharParam(DB_COL_ID_EMPRESA, idEmpresa);
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
