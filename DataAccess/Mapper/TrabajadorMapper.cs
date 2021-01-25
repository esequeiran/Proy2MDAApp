using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Dao;
using Entities_POJO;

namespace DataAccess.Mapper
{
    public class TrabajadorMapper : EntityMapper, ISqlStatements, IObjectMapper
    {

        private const string DB_COL_NOMBRE = "NOMBRE";
        private const string DB_COL_APELLIDO_UNO = "APELLIDO_UNO";
        private const string DB_COL_APELLIDO_DOS = "APELLIDO_DOS";
        private const string DB_COL_ID_USUARIO = "ID_USUARIO";
        private const string DB_COL_GENERO = "GENERO";
        private const string DB_COL_CORREO = "CORREO";
        private const string DB_COL_FEC_NACIMIENTO = "FEC_NACIMIENTO";
        private const string DB_COL_ID_ESTADO = "ID_ESTADO";
        private const string DB_COL_ID_EMPRESA = "ID_EMPRESA";
        private const string DB_COL_ID_SOLICITUD = "ID_SOLICITUD";



        public BaseEntity BuildObject(Dictionary<string, object> row)
        {

            var trabajador = new Trabajador
            {
                Nombre = GetStringValue(row, DB_COL_NOMBRE),
                Apellido1 = GetStringValue(row, DB_COL_APELLIDO_UNO),
                Apellido2 = GetStringValue(row, DB_COL_APELLIDO_DOS),
                Cedula = GetStringValue(row, DB_COL_ID_USUARIO),
                Correo = GetStringValue(row, DB_COL_CORREO),
                Genero = GetStringValue(row, DB_COL_GENERO),
                FecNacimiento = GetDateValue(row, DB_COL_FEC_NACIMIENTO),
                IdEmpresa = GetStringValue(row, DB_COL_ID_EMPRESA),
                IdEstado = GetStringValue(row, DB_COL_ID_ESTADO)

            };

            return trabajador;

        }
        public BaseEntity BuildObjectDisponible(Dictionary<string, object> row)
        {

            var trabajador = new Trabajador
            {
                Nombre = GetStringValue(row, DB_COL_NOMBRE),
                Apellido1 = GetStringValue(row, DB_COL_APELLIDO_UNO),
                Apellido2 = GetStringValue(row, DB_COL_APELLIDO_DOS),
                Cedula = GetStringValue(row, DB_COL_ID_USUARIO),
                Correo = GetStringValue(row, DB_COL_CORREO),
                Genero = GetStringValue(row, DB_COL_GENERO),
                FecNacimiento = GetDateValue(row, DB_COL_FEC_NACIMIENTO),
                IdEmpresa = GetStringValue(row, DB_COL_ID_EMPRESA)
            };

            return trabajador;

        }






        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var trabajador = BuildObject(row);
                lstResults.Add(trabajador);
            }

            return lstResults;
        }
        public List<BaseEntity> BuildObjectsDisponibles(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var trabajador = BuildObjectDisponible(row);
                lstResults.Add(trabajador);
            }

            return lstResults;
        }



        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_TRABAJADOR_PR" };
            var c = (Trabajador)entity;

            operation.AddNVarcharParam(DB_COL_NOMBRE, c.Nombre);
            operation.AddNVarcharParam(DB_COL_APELLIDO_UNO, c.Apellido1);
            operation.AddNVarcharParam(DB_COL_APELLIDO_DOS, c.Apellido2);
            operation.AddNVarcharParam(DB_COL_ID_USUARIO, c.Cedula);
            operation.AddNVarcharParam(DB_COL_GENERO, c.Genero);
            operation.AddNVarcharParam(DB_COL_CORREO, c.Correo);
            operation.AddDateTimeParam(DB_COL_FEC_NACIMIENTO, c.FecNacimiento);
            operation.AddIntParam(DB_COL_ID_ESTADO, 5);
            operation.AddNVarcharParam(DB_COL_ID_EMPRESA, c.IdEmpresa);



            return operation;
        }
        public SqlOperation GetAsignarTrabajadorStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_ASIGNAR_TRABAJADOR_PR" };
            var c = (Trabajador)entity;

            operation.AddNVarcharParam(DB_COL_ID_USUARIO, c.Cedula);
            operation.AddIntParam(DB_COL_ID_SOLICITUD, c.IdSolicitud);

            return operation;
        }
        public SqlOperation GetEliminarTrabajadorStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_ELIMINAR_TRABAJADOR_PR" };
            var c = (Trabajador)entity;

            operation.AddNVarcharParam(DB_COL_ID_USUARIO, c.Cedula);
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
        public SqlOperation GetRetriveAllTrabajadores(string idEmpresa)
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_TRABAJADORES_PR" };
            operation.AddNVarcharParam(DB_COL_ID_EMPRESA, idEmpresa);
            return operation;
        }
        public SqlOperation GetRetriveAllTrabajadoresDisponibles(string idEmpresa)
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_TRABAJADORES_DISPONIBLES_PR" };
            operation.AddNVarcharParam(DB_COL_ID_EMPRESA, idEmpresa);
            return operation;
        }
        public SqlOperation GetRetriveAllTrabajadoresAsignados(string idSolicitud)
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_TRABAJADORES_ASIGNADOS_PR" };
            operation.AddNVarcharParam(DB_COL_ID_SOLICITUD, idSolicitud);
            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_TRABAJADOR_PR" };

            var c = (Trabajador)entity;


            operation.AddVarcharParam(DB_COL_ID_USUARIO, c.Cedula);
            operation.AddVarcharParam(DB_COL_NOMBRE, c.Nombre);
            operation.AddVarcharParam(DB_COL_APELLIDO_UNO, c.Apellido1);
            operation.AddVarcharParam(DB_COL_APELLIDO_DOS, c.Apellido2);
            operation.AddVarcharParam(DB_COL_CORREO, c.Correo);

            return operation;
        }
        public SqlOperation GetCambioEstadoStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_ESTADO_TRABAJADOR_PR" };

            var c = (Trabajador)entity;
            if (c.IdEstado == "Suspender")
            {
                operation.AddIntParam(DB_COL_ID_ESTADO, 13);

            }
            if (c.IdEstado == "Activar")
            {
                operation.AddIntParam(DB_COL_ID_ESTADO, 5);

            }
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
            //operation.AddVarcharParam(DB_COL_TELEFONO, c.Telefono);
            //operation.AddVarcharParam(DB_COL_DESCRIPCION, c.Descripcion);

            return operation;
        }
        public SqlOperation GetVerificacion(string cedula, string codigoVerificacion)
        {

            var operation = new SqlOperation { ProcedureName = "RET_VERIFICACION_PR" };

            operation.AddNVarcharParam(DB_COL_ID_USUARIO, cedula);
            //operation.AddNVarcharParam(DB_COL_CODIGO_VERIFICACION, codigoVerificacion);

            return operation;
        }

        public SqlOperation GetCrearContrasenna(string cedula, string contrasenna)
        {

            var operation = new SqlOperation { ProcedureName = "CRE_CONTRASENNA_PR" };

            operation.AddNVarcharParam(DB_COL_ID_USUARIO, cedula);
            //operation.AddNVarcharParam(DB_COL_CONTRASENNA, contrasenna);

            return operation;
        }

        public SqlOperation GetRetriveMasIngresosTopTenStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_OFERENTES_MAS_INGRESOS_PR" };

            return operation;
        }





    }
}
