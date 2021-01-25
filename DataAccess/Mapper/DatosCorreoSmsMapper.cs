using DataAccess.Dao;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class DatosCorreoSmsMapper : EntityMapper, ISqlStatements, IObjectMapper
    {
        private const string DB_COL_CEDULA = "CEDULA";
        private const string DB_COL_ID_USUARIO = "ID_USUARIO";
        private const string DB_COL_CODIGO_VERIFICACION = "CODIGO_VERIFICACION";
        private const string DB_COL_CORREO = "CORREO";
        private const string DB_COL_TELEFONO = "TELEFONO";
        private const string DB_COL_NOMBRE_EMPRESA = "NOMBRE_EMPRESA";
        private const string DB_COL_NOMBRE_VISTA = "NOMBRE_VISTA";
        private const string DB_COL_NOMBRE = "NOMBRE";


        public BaseEntity BuildObjectCorreoEmpresa(Dictionary<string, object> row)
        {
            var dato = new DatosAuxiliaresSmsCorreo
            {

                NombreEmpresa = GetStringValue(row, DB_COL_NOMBRE_EMPRESA),
                Correo = GetStringValue(row, DB_COL_CORREO)
            };
            return dato;
        }

        public BaseEntity BuildObjectCorreoUsuario(Dictionary<string, object> row)
        {
            var dato = new DatosAuxiliaresSmsCorreo
            {
                CedulaEmpresa = GetStringValue(row, DB_COL_ID_USUARIO),
                NombreUsuario = GetStringValue(row, DB_COL_NOMBRE),
                Correo = GetStringValue(row, DB_COL_CORREO)
            };
            return dato;
        }

        public BaseEntity BuildObjectCodigoVerificacionSMSEmpresa(Dictionary<string, object> row)
        {
            var dato = new DatosAuxiliaresSmsCorreo
            {
                CedulaEmpresa = GetStringValue(row, DB_COL_ID_USUARIO),
                CodigoVerificacion = GetStringValue(row, DB_COL_CODIGO_VERIFICACION),
                Telefono = GetStringValue(row, DB_COL_TELEFONO)
            };
            return dato;
        }

        public BaseEntity BuildObjectCodigoSMSCorreoRecuperar(Dictionary<string, object> row)
        {
            var dato = new DatosAuxiliaresSmsCorreo
            {
                Cedula = GetStringValue(row, DB_COL_ID_USUARIO),
                CodigoVerificacion = GetStringValue(row, DB_COL_CODIGO_VERIFICACION),
                Telefono = GetStringValue(row, DB_COL_TELEFONO),
                Correo = GetStringValue(row, DB_COL_CORREO),
                NombreUsuario = GetStringValue(row, DB_COL_NOMBRE)
            };
            return dato;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            throw new NotImplementedException();
        }
        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
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

        public SqlOperation GetRetriveAllStatement()
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
        public SqlOperation GetRetriveStatementCorreoEmpresa(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_USUARIO_EMAIL_EMPRESA_PR" };

            var dato = (DatosAuxiliaresSmsCorreo)entity;
            operation.AddVarcharParam(DB_COL_CEDULA, dato.CedulaEmpresa);
            return operation;
        }

        public SqlOperation GetRetriveStatementUsuarioEMAIL(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_USUARIO_EMAIL_CODIGO_VERIFICACION_PR" };

            var dato = (DatosAuxiliaresSmsCorreo)entity;
            operation.AddVarcharParam(DB_COL_CEDULA, dato.CedulaEmpresa);
            return operation;
        }

        public SqlOperation GetRetriveStatementCodigoVerificacionSms(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_CODIGO_VERIFICACION_PR" };

            var dato = (DatosAuxiliaresSmsCorreo)entity;
            operation.AddVarcharParam(DB_COL_CEDULA, dato.CedulaEmpresa);
            return operation;
        }

        public SqlOperation GetRetriveStatementCodigoVerificacionSmsRecuperarContrasenna(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_CORREO_SMS_RECUPERAR_CONTRASENNA_PR" };

            var dato = (DatosAuxiliaresSmsCorreo)entity;
            operation.AddVarcharParam(DB_COL_CEDULA, dato.Cedula);
            operation.AddVarcharParam(DB_COL_CODIGO_VERIFICACION, dato.CodigoVerificacion);
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
