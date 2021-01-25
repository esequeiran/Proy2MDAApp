using DataAccess.Dao;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class LoginTokenMapper : EntityMapper, ISqlStatements, IObjectMapper
    {
        private const string DB_COL_CORREO = "CORREO";
        private const string DB_COL_CONTRASENNA = "CONTRASENNA";
        private const string DB_COL_CONTRASENNA_ACTUAL = "CONTRASENNA_ACTUAL";
        private const string DB_COL_ID_USUARIO = "ID_USUARIO";
        private const string DB_COL_NOMBRE = "NOMBRE";
        private const string DB_COL_ID_ROL = "ID_ROL";
        private const string DB_COL_NOMBRE_ROL = "NOMBRE_ROL";
        private const string DB_COL_ID_ESTADO = "ID_ESTADO";
        private const string DB_COL_NUMERO_RESULTADO = "NUMERO_RESULTADO";
        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var logToken = new LoginToken
            {
                Correo = "",
                Contrasenna = "",
                IdUsuario = GetStringValue(row, DB_COL_ID_USUARIO),
                Nombre = GetStringValue(row, DB_COL_NOMBRE),
                DiccionarioRoles = new Dictionary<int, string>(),
                IdEstado = GetIntValue(row, DB_COL_ID_ESTADO)
            };
            logToken.DiccionarioRoles.Add(GetIntValue(row, DB_COL_ID_ROL),
           GetStringValue(row, DB_COL_NOMBRE_ROL));
            return logToken;
        }

        public BaseEntity BuildObjectExisteCorreo(Dictionary<string, object> row)
        {
            var logToken = new LoginToken
            {                
                IdUsuario = GetStringValue(row, DB_COL_ID_USUARIO),               
            };
 
            return logToken;
        }


        public BaseEntity BuildObjectValidarIntentoOActualizarIntento(Dictionary<string, object> row)
        {
            var logToken = new LoginToken
            {
                NumeroResultado = GetIntValue(row, DB_COL_NUMERO_RESULTADO)
            };

            return logToken;
        }

        public BaseEntity BuildObjectContrasennaActual(Dictionary<string, object> row)
        {
            var logToken = new LoginToken
            {
                IdUsuario = GetStringValue(row, DB_COL_ID_USUARIO),
            };

            return logToken;
        }

        public BaseEntity BuildObjectModificarContrasenna(Dictionary<string, object> row)
        {
            var logToken = new LoginToken
            {
                IdUsuario = GetStringValue(row, DB_COL_ID_USUARIO),
            };

            return logToken;
        }


        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var token = BuildObject(row);
                lstResults.Add(token);
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

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_USUARIO_LOGIN_PR" };
            var credenciales = (LoginToken)entity;
            operation.AddVarcharParam(DB_COL_CORREO, credenciales.Correo);
            operation.AddVarcharParam(DB_COL_CONTRASENNA, credenciales.Contrasenna);
            return operation;
        }

        public SqlOperation GetRetrieveExisteCorreoStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_EXISTE_CORREO_PR" };
            var credenciales = (LoginToken)entity;
            operation.AddVarcharParam(DB_COL_CORREO, credenciales.Correo);           
            return operation;
        }

        public SqlOperation GetRetrieveValidarIntentoContrasennaStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_VALIDAR_INTENTO_CONTRASENNA_PR" };
            var credenciales = (LoginToken)entity;
            operation.AddVarcharParam(DB_COL_CORREO, credenciales.Correo);
            return operation;
        }

        public SqlOperation GetUpdateIntentoContrasennaStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_ACTUALIZAR_INTENTO_CONTRASENNA_PR" };
            var credenciales = (LoginToken)entity;
            operation.AddVarcharParam(DB_COL_CORREO, credenciales.Correo);
            return operation;
        }


        public SqlOperation GetRetriveStatementContrasennaActual(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_USUARIO_CONTRASENNA_ACTUAL_PR" };
            var credenciales = (LoginToken)entity;
            operation.AddVarcharParam(DB_COL_ID_USUARIO, credenciales.IdUsuario);
            operation.AddVarcharParam(DB_COL_CONTRASENNA_ACTUAL, credenciales.ContrasennaActual);
            return operation;
        }

        public SqlOperation GetRetriveStatementUpdateContrasenna(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_USUARIO_CONTRASENNA_PR" };
            var credenciales = (LoginToken)entity;
            operation.AddVarcharParam(DB_COL_ID_USUARIO, credenciales.IdUsuario);
            operation.AddVarcharParam(DB_COL_CONTRASENNA, credenciales.Contrasenna);
            return operation;
        }
        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

    }
}
