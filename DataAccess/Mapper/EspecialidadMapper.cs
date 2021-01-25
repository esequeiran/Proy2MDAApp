using DataAccess.Dao;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    //VERSION NUEVA
    public class EspecialidadMapper : EntityMapper, ISqlStatements, IObjectMapper
    {
        private const string DB_COL_ID_ESPECIALIDAD = "ID_ESPECIALIDAD";
        private const string DB_COL_NOMBRE_ESPECIALIDAD = "NOMBRE_ESPECIALIDAD";
        private const string DB_ID_ESTADO = "NOMBRE_ESTADO";
        private const string DB_ID_NUMBER = "ID_NUMBER";

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var especialidad = new Especialidad
            {
                Id_Number = GetStringValue(row, DB_ID_NUMBER),
                Nombre_Especialidad = GetStringValue(row, DB_COL_NOMBRE_ESPECIALIDAD),
                Nombre_Estado = GetStringValue(row, DB_ID_ESTADO)

            };

            return especialidad;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var especialidad = BuildObject(row);
                lstResults.Add(especialidad);
            }

            return lstResults;
        }

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_ESPECIALIDAD_PR" };

            var c = (Especialidad)entity;

            operation.AddVarcharParam(DB_COL_NOMBRE_ESPECIALIDAD, c.Nombre_Especialidad);


            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_ESPECIALIDAD_PR" };

            var c = (Especialidad)entity;
            operation.AddVarcharParam(DB_ID_NUMBER, c.Id_Number);
            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_ESPECIALIDADES_PR" };
            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        //UPDATE
        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_ESPECIALIDAD_PR" };

            var c = (Especialidad)entity;

            operation.AddVarcharParam(DB_ID_NUMBER, c.Id_Number);
            operation.AddVarcharParam(DB_COL_NOMBRE_ESPECIALIDAD, c.Nombre_Especialidad);


            return operation;
        }
    }
}
