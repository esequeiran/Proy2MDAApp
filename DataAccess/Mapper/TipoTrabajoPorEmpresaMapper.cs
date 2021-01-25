using DataAccess.Dao;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class TipoTrabajoPorEmpresaMapper : EntityMapper, ISqlStatements, IObjectMapper
    {
        private const string DB_COL_CEDULA_USUARIO = "CEDULA_USUARIO";
        private const string DB_COL_ID_TIPO_TRABAJO = "ID_TIPO_TRABAJO";
        private const string DB_COL_COSTO_POR_HORA = "COSTO_POR_HORA";
        private const string DB_COL_NOMBRE_TIPO_TRABAJO = "NOMBRE_TIPO_TRABAJO";


        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var tipoTrabajoPorEmpresa = new TipoTrabajoPorEmpresa
            {                
                Id_TipoTrabajo = GetIntValue(row, DB_COL_ID_TIPO_TRABAJO),                
                Nombre_TipoTrabajo = GetStringValue(row,DB_COL_NOMBRE_TIPO_TRABAJO),
                Costo_Por_Hora = GetDoubleValue(row,DB_COL_COSTO_POR_HORA)
            };

            return tipoTrabajoPorEmpresa; 
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var membresia = BuildObject(row);
                lstResults.Add(membresia);
            }

            return lstResults;
        }

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_TIPO_TRABAJO_POR_EMPRESA_PR" };

            var c = (TipoTrabajoPorEmpresa)entity;

            operation.AddVarcharParam(DB_COL_CEDULA_USUARIO, c.Cedula_Usuario);
            operation.AddIntParam(DB_COL_ID_TIPO_TRABAJO, c.Id_TipoTrabajo);
            operation.AddDoubleParam(DB_COL_COSTO_POR_HORA, c.Costo_Por_Hora);
            //operation.AddVarcharParam(DB_COL_NOMBRE_TIPO_TRABAJO, c.Nombre_TipoTrabajo);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)//DEL_TIPO_TRABAJO_POR_EMPRESA_PR
        {
            var operation = new SqlOperation { ProcedureName = "DEL_TIPO_TRABAJO_POR_EMPRESA_PR" };
            var c = (TipoTrabajoPorEmpresa)entity;
            
            operation.AddIntParam(DB_COL_ID_TIPO_TRABAJO, c.Id_TipoTrabajo);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            throw new NotImplementedException();
        }

        //Fixed
        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_TIPO_TRABAJO_POR_EMPRESA_PR" };
            var c = (TipoTrabajoPorEmpresa)entity;
            operation.AddNVarcharParam(DB_COL_CEDULA_USUARIO, c.Cedula_Usuario);
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_TIPO_TRABAJO_POR_EMPRESA_PR" };
            var c = (TipoTrabajoPorEmpresa)entity;

            operation.AddDoubleParam(DB_COL_COSTO_POR_HORA, c.Costo_Por_Hora);
            operation.AddIntParam(DB_COL_ID_TIPO_TRABAJO, c.Id_TipoTrabajo);

            return operation;
        }
    }
}
