using System;
using System.Collections.Generic;
using DataAccess.Dao;
using Entities_POJO;

namespace DataAccess.Mapper
{
    public class OferenteMapper : EntityMapper, ISqlStatements, IObjectMapper
    {
        private const string DB_COL_NOMBRE = "NOMBRE";
        private const string DB_COL_APELLIDO_UNO = "APELLIDO_UNO";
        private const string DB_COL_APELLIDO_DOS = "APELLIDO_DOS";
        private const string DB_COL_ID_USUARIO = "ID_USUARIO";
        private const string DB_COL_TIPO_CEDULA = "TIPO_CEDULA";
        private const string DB_COL_GENERO = "GENERO";
        private const string DB_COL_CORREO = "CORREO";
        private const string DB_COL_TELEFONO = "TELEFONO";
        private const string DB_COL_PAIS_NACIMIENTO = "PAIS_NACIMIENTO";
        private const string DB_COL_FEC_NACIMIENTO = "FEC_NACIMIENTO";
        private const string DB_COL_CODIGO_VERIFICACION = "CODIGO_VERIFICACION";
        private const string DB_COL_CONTRASENNA = "CONTRASENNA";
        private const string DB_COL_ID_ESTADO = "ID_ESTADO";

        private const string DB_COL_NOMBRE_COMERCIAL = "NOMBRE_COMERCIAL";
        private const string DB_COL_RAZON_SOCIAL = "RAZON_SOCIAL";
        private const string DB_COL_CEDULA_JURIDICA = "CEDULA_JURIDICA";
        private const string DB_COL_DESCRIPCION = "DESCRIPCION";
        private const string DB_COL_TIPO_CEDULA_COMERCIAL = "TIPO_CEDULA_COMERCIAL";
        private const string DB_COL_ID_ROL = "ID_ROL";
        private const string DB_COL_FEC_CREACION = "FEC_CREACION";
        private const string DB_COL_MONTO = "MONTO";


        public BaseEntity BuildObject(Dictionary<string, object> row)
        {

            var ofe = new Oferente
            {
                Nombre = GetStringValue(row, DB_COL_NOMBRE),
                Cedula = GetStringValue(row, DB_COL_ID_USUARIO),
                Correo = GetStringValue(row, DB_COL_CORREO),
                Telefono = GetStringValue(row, DB_COL_TELEFONO),
                NombreComercial = GetStringValue(row, DB_COL_NOMBRE_COMERCIAL),
                TipoCedulaComercial = GetStringValue(row, DB_COL_TIPO_CEDULA_COMERCIAL)
            };

            return ofe;

        }


        public BaseEntity BuildObjectIngresos(Dictionary<string , object> row) {

            var ofe = new Oferente {
                Nombre = GetStringValue(row , DB_COL_NOMBRE) ,
                Cedula = GetStringValue(row , DB_COL_ID_USUARIO) ,
                Correo = GetStringValue(row , DB_COL_CORREO) ,
                Telefono = GetStringValue(row , DB_COL_TELEFONO) ,
                NombreComercial = GetStringValue(row , DB_COL_NOMBRE_COMERCIAL) ,
                TipoCedulaComercial = GetStringValue(row , DB_COL_TIPO_CEDULA_COMERCIAL) ,
                TotalIngresosGenerados = GetDoubleValue(row , DB_COL_MONTO)
            };

            return ofe;

        }



        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var oferente = BuildObject(row);
                lstResults.Add(oferente);
            }

            return lstResults;
        }

        public List<BaseEntity> BuildObjectsIngresos(List<Dictionary<string , object>> lstRows) {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows) {
                var oferente = BuildObjectIngresos(row);
                lstResults.Add(oferente);
            }

            return lstResults;
        }

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_OFERENTE_PR" };
            var id = 3;
            var c = (Oferente)entity;
            if (c.TipoCedulaComercial.Equals("Fisico"))
            {
                 id = 2;
            }
          
            operation.AddNVarcharParam(DB_COL_NOMBRE, c.Nombre);
            operation.AddNVarcharParam(DB_COL_APELLIDO_UNO, c.Apellido1);
            operation.AddNVarcharParam(DB_COL_APELLIDO_DOS, c.Apellido2);
            operation.AddNVarcharParam(DB_COL_ID_USUARIO, c.Cedula);
            operation.AddNVarcharParam(DB_COL_TIPO_CEDULA, c.TipoCedula);
            operation.AddNVarcharParam(DB_COL_GENERO, c.Genero);
            operation.AddNVarcharParam(DB_COL_CORREO, c.Correo);
            operation.AddNVarcharParam(DB_COL_TELEFONO, c.Telefono);
            operation.AddNVarcharParam(DB_COL_PAIS_NACIMIENTO, c.PaisNacimiento);
            operation.AddDateTimeParam(DB_COL_FEC_NACIMIENTO, c.FecNacimiento);
            operation.AddIntParam(DB_COL_ID_ESTADO, 1);

            operation.AddNVarcharParam(DB_COL_NOMBRE_COMERCIAL, c.NombreComercial);
            operation.AddNVarcharParam(DB_COL_RAZON_SOCIAL, c.RazonSocial);
            operation.AddNVarcharParam(DB_COL_CEDULA_JURIDICA, c.CedulaJuridica);
            operation.AddNVarcharParam(DB_COL_DESCRIPCION, c.Descripcion);
            operation.AddNVarcharParam(DB_COL_TIPO_CEDULA_COMERCIAL, c.TipoCedulaComercial);
            operation.AddIntParam(DB_COL_ID_ROL, id);
            operation.AddDateTimeParam(DB_COL_FEC_CREACION, c.FecCreacion);


            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_OFERENTES_PR" };
            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_OFERENTE_PR" };

            var c = (Oferente)entity;

            operation.AddIntParam(DB_COL_ID_ESTADO, c.IdEstado);
            operation.AddVarcharParam(DB_COL_ID_USUARIO, c.Cedula);

            return operation;
        }       
        public SqlOperation GetModificarOferente(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_INFORMACION_OFERENTE_PR" };

            var c = (Oferente)entity;

            operation.AddVarcharParam(DB_COL_ID_USUARIO, c.Cedula);
            operation.AddVarcharParam(DB_COL_NOMBRE, c.Nombre);
            operation.AddVarcharParam(DB_COL_APELLIDO_UNO, c.Apellido1);
            operation.AddVarcharParam(DB_COL_APELLIDO_DOS, c.Apellido2);
            operation.AddVarcharParam(DB_COL_TELEFONO, c.Telefono); 
            operation.AddVarcharParam(DB_COL_DESCRIPCION, c.Descripcion); 

            return operation;
        }      
        public SqlOperation GetVerificacion(string cedula,string codigoVerificacion)
        {

            var operation = new SqlOperation { ProcedureName = "RET_VERIFICACION_PR" };

            operation.AddNVarcharParam(DB_COL_ID_USUARIO , cedula);
            operation.AddNVarcharParam(DB_COL_CODIGO_VERIFICACION, codigoVerificacion);

            return operation;
        }

        public SqlOperation GetCrearContrasenna(string cedula, string contrasenna)
        {

            var operation = new SqlOperation { ProcedureName = "CRE_CONTRASENNA_PR" };

            operation.AddNVarcharParam(DB_COL_ID_USUARIO, cedula);
            operation.AddNVarcharParam(DB_COL_CONTRASENNA, contrasenna);

            return operation;
        }

        public SqlOperation GetRetriveMasIngresosTopTenStatement() {
            var operation = new SqlOperation { ProcedureName = "RET_OFERENTES_MAS_INGRESOS_PR" };
            
            return operation;
        }
    }
}
