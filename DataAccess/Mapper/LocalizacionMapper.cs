using DataAccess.Dao;
using Entities_POJO;
using System;
using System.Collections.Generic;

namespace DataAccess.Mapper
{
    public class LocalizacionMapper : EntityMapper, IObjectMapper, ISqlStatements
    {
        private const string DB_COL_ID_LOCALIZACION = "ID_LOCALIZACION";
        private const string DB_COL_PROVINCIA = "PROVINCIA";
        private const string DB_COL_CANTON = "CANTON";
        private const string DB_COL_DISTRITO = "DISTRITO";
        private const string DB_COL_LATITUD = "LATITUD";
        private const string DB_COL_LONGITUD = "LONGITUD";
        private const string DB_COL_OTRAS_SENNAS = "OTRAS_SENNAS";
        private const string DB_COL_ID_USUARIO = "ID_USUARIO";
        private const string DB_COL_ID_NOMBRE_LOCALIZACION = "NOMBRE_LOCALIZACION";

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_LOCALIZACION_PR" };

            var l = (Localizacion)entity;
            operation.AddVarcharParam(DB_COL_PROVINCIA, l.Provincia);
            operation.AddVarcharParam(DB_COL_CANTON, l.Canton);
            operation.AddVarcharParam(DB_COL_DISTRITO, l.Distrito);
            operation.AddVarcharParam(DB_COL_LATITUD, l.Latitud);
            operation.AddVarcharParam(DB_COL_LONGITUD, l.Longitud);
            operation.AddVarcharParam(DB_COL_OTRAS_SENNAS, l.OtrasSennas);
            operation.AddVarcharParam(DB_COL_ID_USUARIO, l.IdUsuario);
            operation.AddVarcharParam(DB_COL_ID_NOMBRE_LOCALIZACION, l.Nombre);

            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_LOCALIZACION_POR_USUARIO_PR" };

            var l = (Localizacion)entity;
            operation.AddVarcharParam(DB_COL_ID_USUARIO, l.IdUsuario);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_LOCALIZACION_PR" };
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_LOCALIZACION_PR" };

            var l = (Localizacion)entity;
            operation.AddIntParam(DB_COL_ID_LOCALIZACION, l.IdLocalizacion);
            operation.AddVarcharParam(DB_COL_PROVINCIA, l.Provincia);
            operation.AddVarcharParam(DB_COL_CANTON, l.Canton);
            operation.AddVarcharParam(DB_COL_DISTRITO, l.Distrito);
            operation.AddVarcharParam(DB_COL_LATITUD, l.Latitud);
            operation.AddVarcharParam(DB_COL_LONGITUD, l.Longitud);
            operation.AddVarcharParam(DB_COL_OTRAS_SENNAS, l.OtrasSennas);
            operation.AddVarcharParam(DB_COL_ID_NOMBRE_LOCALIZACION, l.Nombre);

            return operation;
        }
        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_LOCALIZACION_PR" };

            var l = (Localizacion)entity;
            operation.AddIntParam(DB_COL_ID_LOCALIZACION, l.IdLocalizacion);
            return operation;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var localizacion = BuildObject(row);
                lstResults.Add(localizacion);
            }
            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var localizacion = new Localizacion
            {
                IdLocalizacion = GetIntValue(row, DB_COL_ID_LOCALIZACION),
                Provincia = GetStringValue(row, DB_COL_PROVINCIA),
                Canton = GetStringValue(row, DB_COL_CANTON),
                Distrito = GetStringValue(row, DB_COL_DISTRITO),
                Latitud = GetStringValue(row, DB_COL_LATITUD),
                Longitud = GetStringValue(row, DB_COL_LONGITUD),
                OtrasSennas = GetStringValue(row, DB_COL_OTRAS_SENNAS),
                IdUsuario = GetStringValue(row, DB_COL_ID_USUARIO),
                Nombre = GetStringValue(row, DB_COL_ID_NOMBRE_LOCALIZACION)
            };
            return localizacion;
        }

        SqlOperation ISqlStatements.GetCreateStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        SqlOperation ISqlStatements.GetRetriveStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        SqlOperation ISqlStatements.GetRetriveAllStatement()
        {
            throw new NotImplementedException();
        }

        SqlOperation ISqlStatements.GetUpdateStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        SqlOperation ISqlStatements.GetDeleteStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}