using DataAccess.Dao;
using Entities_POJO;
using System;
using System.Collections.Generic;

namespace DataAccess.Mapper
{
    public class AdministradorMapper : EntityMapper, IObjectMapper, ISqlStatements
    {
        private const string DB_COL_IDENTIFICACION = "ID_USUARIO";
        private const string DB_COL_TIPO_IDENTIFICACION = "TIPO_CEDULA";
        private const string DB_COL_NOMBRE = "NOMBRE";
        private const string DB_COL_APELLIDO_UNO = "APELLIDO_UNO";
        private const string DB_COL_APELLIDO_DOS = "APELLIDO_DOS";
        private const string DB_COL_CORREO = "CORREO";
        private const string DB_COL_CONTRASENNA = "CONTRASENNA";
        private const string DB_COL_FECHA_NACIMIENTO = "FECHA_NACIMIENTO";
        private const string DB_COL_PAIS_NACIMIENTO = "PAIS_NACIMIENTO";
        private const string DB_COL_GENERO = "GENERO";
        private const string DB_COL_TELEFONO = "TELEFONO";
        private const string DB_COL_ID_ESTADO = "ID_ESTADO";

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_ADMINISTRADOR_PR" };

            var a = (Administrador)entity;
            operation.AddVarcharParam(DB_COL_IDENTIFICACION, a.Identificacion);
            operation.AddVarcharParam(DB_COL_TIPO_IDENTIFICACION, a.TipoIdentificacion);
            operation.AddVarcharParam(DB_COL_NOMBRE, a.Nombre);
            operation.AddVarcharParam(DB_COL_APELLIDO_UNO, a.ApellidoUno);
            operation.AddVarcharParam(DB_COL_APELLIDO_DOS, a.ApellidoDos);
            operation.AddVarcharParam(DB_COL_CORREO, a.Correo);
            operation.AddDateTimeParam(DB_COL_FECHA_NACIMIENTO, a.FechaNacimiento);
            operation.AddVarcharParam(DB_COL_PAIS_NACIMIENTO, a.PaisNacimiento);
            operation.AddVarcharParam(DB_COL_GENERO, a.Genero);
            operation.AddVarcharParam(DB_COL_TELEFONO, a.Telefono);


            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_ADMINISTRADOR_PR" };

            var a = (Administrador)entity;
            operation.AddVarcharParam(DB_COL_IDENTIFICACION, a.Identificacion);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_ADMINISTRADOR_PR" };
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_ADMINISTRADOR_PR" };

            var a = (Administrador)entity;
            operation.AddVarcharParam(DB_COL_IDENTIFICACION, a.Identificacion);
            operation.AddVarcharParam(DB_COL_NOMBRE, a.Nombre);
            operation.AddVarcharParam(DB_COL_APELLIDO_UNO, a.ApellidoUno);
            operation.AddVarcharParam(DB_COL_APELLIDO_DOS, a.ApellidoDos);
            operation.AddVarcharParam(DB_COL_GENERO, a.Genero);
            operation.AddVarcharParam(DB_COL_TELEFONO, a.Telefono);

            return operation;
        }
        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_ADMINISTRADOR_PR" };

            var a = (Administrador)entity;
            operation.AddVarcharParam(DB_COL_IDENTIFICACION, a.Identificacion);
            return operation;
        }

        public SqlOperation GetIngresosStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_INGRESOS_PR" };

            var a = (Administrador)entity;
            operation.AddVarcharParam(DB_COL_IDENTIFICACION, a.Identificacion);
            return operation;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var admin = BuildObject(row);
                lstResults.Add(admin);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var administrador = new Administrador
            {
                Identificacion = GetStringValue(row, DB_COL_IDENTIFICACION),
                TipoIdentificacion = GetStringValue(row, DB_COL_TIPO_IDENTIFICACION),
                Nombre = GetStringValue(row, DB_COL_NOMBRE),
                ApellidoUno = GetStringValue(row, DB_COL_APELLIDO_UNO),
                ApellidoDos = GetStringValue(row, DB_COL_APELLIDO_DOS),
                Correo = GetStringValue(row, DB_COL_CORREO),
                Contrasenna = GetStringValue(row, DB_COL_CONTRASENNA),
                FechaNacimiento = GetDateValue(row, DB_COL_FECHA_NACIMIENTO),
                PaisNacimiento = GetStringValue(row, DB_COL_PAIS_NACIMIENTO),
                Genero = GetStringValue(row, DB_COL_GENERO),
                Telefono = GetStringValue(row, DB_COL_TELEFONO),
                IdEstado = GetIntValue(row, DB_COL_ID_ESTADO)
            };
            return administrador;
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