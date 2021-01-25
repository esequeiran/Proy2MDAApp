using DataAccess.Dao;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class TipoDeTrabajoMapper : EntityMapper, ISqlStatements, IObjectMapper
    {
        //VERSION NUEVA
        private const string DB_COL_ID_TIPODETRABAJO = "ID_TIPO_TRABAJO";
        private const string DB_COL_NOMBRE_TIPO_TRABAJO = "NOMBRE_TIPO_TRABAJO";
        private const string DB_COL_ID_ESPECIALIDAD = "ID_ESPECIALIDAD";
        private const string DB_ESTADO = "NOMBRE_ESTADO";
        private const string DB_ID_NUMBER = "ID_NUMBER";
        private const string DB_COL_NOMBRE_ESPECIALIDAD = "NOMBRE_ESPECIALIDAD";

        //private const string DB_COL_NOMBRE_ESPECIALIDAD = "NOMBRE_ESPECIALIDAD";

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var tiposDeTrabajo = new TipoDeTrabajo
            {
                Id_TipoTrabajo = GetIntValue(row, DB_COL_ID_TIPODETRABAJO),
                Nombre_TipoTrabajo = GetStringValue(row, DB_COL_NOMBRE_TIPO_TRABAJO),
                Nombre_Especialidad = GetStringValue(row, DB_COL_NOMBRE_ESPECIALIDAD),
                Nombre_Estado = GetStringValue(row,DB_ESTADO)
            };

            return tiposDeTrabajo;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var tiposDeTrabajo = BuildObject(row);
                lstResults.Add(tiposDeTrabajo);
            }

            return lstResults;
        }


        //create
        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_TIPO_DE_TRABAJO_PR" };
            //'@P_NOMBRE_TIPO_TRABAJO
            var c = (TipoDeTrabajo)entity;
            operation.AddVarcharParam(DB_COL_NOMBRE_TIPO_TRABAJO, c.Nombre_TipoTrabajo);
            operation.AddVarcharParam(DB_ID_NUMBER, c.Id_Number);
            //operation.AddIntParam(DB_ESTADO, c.Id_Estado);
            return operation;
        }

        //delete
        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_TIPOS_DE_TRABAJO_PR" };

            var c = (TipoDeTrabajo)entity;
            operation.AddIntParam(DB_COL_ID_TIPODETRABAJO, c.Id_TipoTrabajo);
            //operation.AddIntParam(DB_COL_ID_ESPECIALIDAD, c.Id_Especialidad);
            //operation.AddIntParam(DB_ESTADO, c.Id_Estado);

            return operation;
        }
        //GET
        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_TIPOS_DE_TRABAJO_PR" };
            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
        //UPDATE
        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_TIPOS_DE_TRABAJO_PR" };

            var c = (TipoDeTrabajo)entity;
            operation.AddVarcharParam(DB_COL_NOMBRE_TIPO_TRABAJO, c.Nombre_TipoTrabajo);
            //operation.AddIntParam(DB_COL_ID_ESPECIALIDAD, c.Id_Especialidad);
            //operation.AddIntParam(DB_ESTADO, c.Id_Estado);
            operation.AddIntParam(DB_COL_ID_TIPODETRABAJO, c.Id_TipoTrabajo);

            return operation;
        }

        // IObjectMapper


    }
}
