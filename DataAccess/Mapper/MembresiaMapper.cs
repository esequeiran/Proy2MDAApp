using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Dao;
using Entities_POJO;

namespace DataAccess.Mapper
{
    public class MembresiaMapper : EntityMapper, ISqlStatements, IObjectMapper
    {
        private const string DB_COL_ID_MEMBRESIA = "ID_MEMBRESIA";
        private const string DB_COL_NOMBRE_MEMBRESIA = "NOMBRE_MEMBRESIA";
        private const string DB_COL_TIPO_MEMBRESIA = "TIPO_MEMBRESIA";
        private const string DB_COL_PRECIO = "PRECIO";
        private const string DB_COL_VIGENCIA_MESES = "VIGENCIA_MESES";
        private const string DB_COL_ID_ESTADO = "ID_ESTADO";
        private const string DB_COL_NOMBRE_ESTADO = "NOMBRE_ESTADO";
        private const string DB_COL_FEE_REAGENDAR = "FEE_REAGENDAR";
        private const string DB_COL_FEE_CANCELAR = "FEE_CANCELAR";
        private const string DB_COL_FEE_SERVICIO = "FEE_SERVICIO";
        private const string DB_COL_CEDULA_EMPRESA = "CEDULA_EMPRESA";
        private const string DB_COL_NOMBRE_EMPRESA = "NOMBRE_EMPRESA";
        private const string DB_COL_FECHA_CONTRATACION = "FECHA_CONTRATACION";

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var membresia = new Membresia
            {
                IdMembresia = GetIntValue(row, DB_COL_ID_MEMBRESIA),
                NombreMembresia = GetStringValue(row, DB_COL_NOMBRE_MEMBRESIA),
                TipoMembresia = GetStringValue(row, DB_COL_TIPO_MEMBRESIA),
                Precio = GetDoubleValue(row, DB_COL_PRECIO),
                VigenciaMeses = GetIntValue(row, DB_COL_VIGENCIA_MESES),
                Estado = GetStringValue(row, DB_COL_NOMBRE_ESTADO),
                FeeReagendar = GetDoubleValue(row, DB_COL_FEE_REAGENDAR),
                FeeCancelar = GetDoubleValue(row, DB_COL_FEE_CANCELAR),
                FeeServicio = GetDoubleValue(row, DB_COL_FEE_SERVICIO),
                NombreEmpresa = GetStringValue(row, DB_COL_NOMBRE_EMPRESA),
                FechaContratacionS = GetStringValue(row, DB_COL_FECHA_CONTRATACION)

            };

            return membresia;
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
            var operation = new SqlOperation { ProcedureName = "CRE_MEMBRESIA_PR" };
            var membresia = (Membresia)entity;
            operation.AddVarcharParam(DB_COL_NOMBRE_MEMBRESIA, membresia.NombreMembresia);
            operation.AddVarcharParam(DB_COL_TIPO_MEMBRESIA, membresia.TipoMembresia);
            operation.AddDoubleParam(DB_COL_PRECIO, membresia.Precio);
            operation.AddIntParam(DB_COL_VIGENCIA_MESES, membresia.VigenciaMeses);
            operation.AddDoubleParam(DB_COL_FEE_REAGENDAR, membresia.FeeReagendar);
            operation.AddDoubleParam(DB_COL_FEE_CANCELAR, membresia.FeeCancelar);
            operation.AddDoubleParam(DB_COL_FEE_SERVICIO, membresia.FeeServicio);
            operation.AddVarcharParam(DB_COL_CEDULA_EMPRESA, membresia.CedulaEmpresa); 
            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_MEMBRESIA_PR"};
            var membresia = (Membresia)entity;
            operation.AddIntParam(DB_COL_ID_MEMBRESIA, membresia.IdMembresia);
            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_MEMBRESIA_PR" };
            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_MEMBRESIA_PR" };
            var membrecia = (Membresia)entity;
            operation.AddIntParam(DB_COL_ID_MEMBRESIA, membrecia.IdMembresia);
            operation.AddVarcharParam(DB_COL_NOMBRE_MEMBRESIA, membrecia.NombreMembresia);
            operation.AddVarcharParam(DB_COL_TIPO_MEMBRESIA, membrecia.TipoMembresia);
            operation.AddDoubleParam(DB_COL_PRECIO, membrecia.Precio);
            operation.AddIntParam(DB_COL_VIGENCIA_MESES, membrecia.VigenciaMeses);
            operation.AddDoubleParam(DB_COL_FEE_REAGENDAR, membrecia.FeeReagendar);
            operation.AddDoubleParam(DB_COL_FEE_CANCELAR, membrecia.FeeCancelar);
            operation.AddDoubleParam(DB_COL_FEE_SERVICIO, membrecia.FeeServicio);   
            return operation;
        }

        public SqlOperation GetRetriveAllStatementByEmpresa(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_MEMBRESIA_EMPRESA_PR" };
            var membresia = (Membresia) entity;
            operation.AddVarcharParam(DB_COL_CEDULA_EMPRESA, membresia.CedulaEmpresa);
            return operation;
        }

        public SqlOperation GetUpdateMembresiaStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_ADQUIRIR_MEMBRESIA_PR" };
            var membresia = (Membresia)entity;
            operation.AddIntParam(DB_COL_ID_MEMBRESIA, membresia.IdMembresia);
            operation.AddDateTimeParam(DB_COL_FECHA_CONTRATACION, DateTime.Now);
            return operation;
        }

    }
}
