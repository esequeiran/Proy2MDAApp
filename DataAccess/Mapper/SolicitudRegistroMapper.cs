using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Dao;
using Entities_POJO;

namespace DataAccess.Mapper
{
    public class SolicitudRegistroMapper : EntityMapper, ISqlStatements, IObjectMapper
    {

        //Oferente
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
        //Localizacion
        private const string DB_COL_NOMBRE_LOCALIZACION = "NOMBRE_LOCALIZACION";
        private const string DB_COL_ID_USUARIO_L = "ID_USUARIO";
        private const string DB_COL_LATITUD = "LATITUD";
        private const string DB_COL_LONGITUD = "LONGITUD";
        private const string DB_COL_PROVINCIA = "PROVINCIA";
        private const string DB_COL_CANTON = "CANTON";
        private const string DB_COL_DISTRITO = "DISTRITO";
        private const string DB_COL_OTRAS_SENNAS = "OTRAS_SENNAS";
        private const string DB_COL_ID_ESTADO_L = "ID_ESTADO";
        //Documento
        private const string DB_COL_NOMBRE_DOCUMENTO = "NOMBRE_DOCUMENTO";
        private const string DB_COL_ID_DOCUMENTO = "ID_DOCUMENTO";
        private const string DB_COL_EXTENSION = "EXTENSION";
        private const string DB_COL_ID_USUARIO_D = "ID_USUARIO";
        private const string DB_COL_ID_ESTADO_D = "ID_ESTADO";
        private const string DB_COL_TIPO_DOCUMENTO = "TIPO_DOCUMENTO";



        public BaseEntity BuildObject(List<Dictionary<string, object>> rows)
        {
            var solicitudRegistro = new SolicitudRegistro();
            solicitudRegistro.Documentos = new List<Documento>();
            var row = rows.ElementAt(0);



            var ofe = new Oferente
            {
                Nombre = GetStringValue(row, DB_COL_NOMBRE),
                Apellido1 = GetStringValue(row, DB_COL_APELLIDO_UNO),
                Apellido2 = GetStringValue(row, DB_COL_APELLIDO_DOS),
                Cedula = GetStringValue(row, DB_COL_ID_USUARIO),
                TipoCedula = GetStringValue(row, DB_COL_TIPO_CEDULA),
                Genero = GetStringValue(row, DB_COL_GENERO),
                Correo = GetStringValue(row, DB_COL_CORREO),
                Telefono = GetStringValue(row, DB_COL_TELEFONO),
                PaisNacimiento = GetStringValue(row, DB_COL_PAIS_NACIMIENTO),
                FecNacimiento = GetDateOferenteValue(row, DB_COL_FEC_NACIMIENTO),
                NombreComercial = GetStringValue(row, DB_COL_NOMBRE_COMERCIAL),
                RazonSocial = GetStringValue(row, DB_COL_RAZON_SOCIAL),
                CedulaJuridica = GetStringValue(row, DB_COL_CEDULA_JURIDICA),
                Descripcion = GetStringValue(row, DB_COL_DESCRIPCION),
                TipoCedulaComercial = GetStringValue(row, DB_COL_TIPO_CEDULA_COMERCIAL),
                FecCreacion = GetDateOferenteValue(row, DB_COL_FEC_CREACION)

            };

            var loc = new Localizacion
            {
                Nombre = GetStringValue(row, DB_COL_NOMBRE_LOCALIZACION),
                Latitud = GetStringValue(row, DB_COL_LATITUD),
                Longitud = GetStringValue(row, DB_COL_LONGITUD),
                Provincia = GetStringValue(row, DB_COL_PROVINCIA),
                Canton = GetStringValue(row, DB_COL_CANTON),
                Distrito = GetStringValue(row, DB_COL_DISTRITO),
                OtrasSennas = GetStringValue(row, DB_COL_OTRAS_SENNAS)
            };

            foreach (var rowDoc in rows)
            {

                var doc = new Documento
                {
                    NombreDocumento = GetStringValue(rowDoc, DB_COL_NOMBRE_DOCUMENTO),
                    IdDocumento = GetStringValue(rowDoc, DB_COL_ID_DOCUMENTO),
                    Extension = GetStringValue(rowDoc, DB_COL_EXTENSION),
                    TipoDocumento = GetStringValue(rowDoc, DB_COL_TIPO_DOCUMENTO)
                };

                solicitudRegistro.Documentos.Add(doc);

            }

            solicitudRegistro.Oferente = ofe;
            solicitudRegistro.Localizacion = loc;


            return solicitudRegistro;

        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            throw new NotImplementedException();
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
        public SqlOperation GetRetriveStatement(string idUsuario)
        {
            var operation = new SqlOperation { ProcedureName = "RET_INFORMACION_OFERENTE_PR" };
            operation.AddVarcharParam(DB_COL_ID_USUARIO, idUsuario);
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }



    }

}
