using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Dao;
using Entities_POJO;

namespace DataAccess.Mapper
{
   public class OferenteJuridicoMapper : EntityMapper, ISqlStatements, IObjectMapper
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
        private const string DB_COL_ID_ESTADO = "ID_ESTADO";

        private const string DB_COL_NOMBRE_COMERCIAL = "NOMBRE_COMERCIAL";
        private const string DB_COL_RAZON_SOCIAL = "RAZON_SOCIAL";
        private const string DB_COL_CEDULA_JURIDICA = "CEDULA_JURIDICA";
        private const string DB_COL_DESCRIPCION = "DESCRIPCION";
        private const string DB_COL_TIPO_CEDULA_COMERCIAL = "TIPO_CEDULA_COMERCIAL";
        private const string DB_COL_FEC_CREACION = "FEC_CREACION";


        //private const string DB_COL_LATITUD = "LATITUD";
        //private const string DB_COL_LONGITUD = "LONGITUD";
        //private const string DB_COL_PROVINCIA = "PROVINCIA";
        //private const string DB_COL_CANTON= "CANTON";
        //private const string DB_COL_DISTRITO = "DISTRITO";
        //private const string DB_COL_OTRAS_SENNAS = "OTRAS_SENNAS";

        //private const string DB_COL_CURRICULUM = "CURRICULUM";
        //private const string DB_COL_HOJA_DELINCUENCIA = "HOJA_DELINCUENCIA";
        //private const string DB_COL_REFERENCIAS = "REFERENCIAS";

        //private const string DB_COL_ESPECIALIDAD = "ESPECIALIDAD";
        //private const string DB_COL_TIPO_TRABAJO = "TIPO_TRABAJO";



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
            var operation = new SqlOperation { ProcedureName = "CRE_OFERENTE_JURIDICO_PR" };

            var c = (OferenteJuridico)entity;
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
            operation.AddNVarcharParam(DB_COL_TIPO_CEDULA_COMERCIAL, "Juridico");
            operation.AddDateTimeParam(DB_COL_FEC_CREACION, c.FecCreacion);

            //operation.AddNVarcharParam(DB_COL_LATITUD, c.Latitud);
            //operation.AddNVarcharParam(DB_COL_LONGITUD, c.Longitud);
            //operation.AddNVarcharParam(DB_COL_PROVINCIA, c.Longitud);
            //operation.AddNVarcharParam(DB_COL_CANTON, c.Longitud);
            //operation.AddNVarcharParam(DB_COL_DISTRITO, c.Longitud);
            //operation.AddNVarcharParam(DB_COL_OTRAS_SENNAS, c.OtrasSennas);

            //operation.AddNVarcharParam(DB_COL_CURRICULUM, c.Curriculum);
            //operation.AddNVarcharParam(DB_COL_HOJA_DELINCUENCIA, c.HojaDelincuencia);
            //operation.AddNVarcharParam(DB_COL_ESPECIALIDAD, c.Especialidad);
            //operation.AddNVarcharParam(DB_COL_TIPO_TRABAJO, c.TipoTrabajo);



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
