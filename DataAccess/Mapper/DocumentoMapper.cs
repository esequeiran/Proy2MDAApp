using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Dao;
using Entities_POJO;

namespace DataAccess.Mapper
{
   public class DocumentoMapper : EntityMapper, ISqlStatements, IObjectMapper
    {

        private const string DB_COL_NOMBRE_DOCUMENTO = "NOMBRE_DOCUMENTO";
        private const string DB_COL_ID_DOCUMENTO = "ID_DOCUMENTO";
        private const string DB_COL_EXTENSION = "EXTENSION";
        private const string DB_COL_ID_USUARIO = "ID_USUARIO";
        private const string DB_COL_ID_ESTADO = "ID_ESTADO";
        private const string DB_COL_TIPO_DOCUMENTO = "TIPO_DOCUMENTO";
        private const string DB_COL_ID_SOLICITUD = "ID_SOLICITUD";
 

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
            var operation = new SqlOperation { ProcedureName = "CRE_DOCUMENTO_PR" };

            var c = (Documento)entity;
            operation.AddNVarcharParam(DB_COL_ID_DOCUMENTO, c.IdDocumento);
            operation.AddNVarcharParam(DB_COL_NOMBRE_DOCUMENTO, c.NombreDocumento);
            operation.AddNVarcharParam(DB_COL_EXTENSION, c.Extension);
            operation.AddNVarcharParam(DB_COL_ID_USUARIO, c.IdUsuario);
            operation.AddIntParam(DB_COL_ID_ESTADO, 5);
            operation.AddNVarcharParam(DB_COL_TIPO_DOCUMENTO, c.TipoDocumento);

            return operation;
        }

        public SqlOperation GetCreateStatementFotosPreviasSolicitud(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_DOCUMENTO_SOLICITUD_TRABAJO_PR" };

            var c = (Documento)entity;
            operation.AddNVarcharParam(DB_COL_ID_DOCUMENTO, c.IdDocumento);
            operation.AddNVarcharParam(DB_COL_NOMBRE_DOCUMENTO, c.NombreDocumento);
            operation.AddNVarcharParam(DB_COL_EXTENSION, c.Extension);          
            operation.AddIntParam(DB_COL_ID_SOLICITUD, c.IdSolicitud);

            return operation;
        }

        public SqlOperation GetCreateStatementFotosFinalesSolicitud(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_FOTOS_TRABAJO_DE_SOLICITUD_TRABAJO_PR" };

            var c = (Documento)entity;
            operation.AddNVarcharParam(DB_COL_ID_DOCUMENTO, c.IdDocumento);
            operation.AddNVarcharParam(DB_COL_NOMBRE_DOCUMENTO, c.NombreDocumento);
            operation.AddNVarcharParam(DB_COL_EXTENSION, c.Extension);
            operation.AddIntParam(DB_COL_ID_SOLICITUD, c.IdSolicitud);

            return operation;
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

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }



    }
}
