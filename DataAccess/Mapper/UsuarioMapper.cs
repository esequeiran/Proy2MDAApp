using DataAccess.Dao;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class UsuarioMapper : EntityMapper, ISqlStatements, IObjectMapper
    {
        //NOMBRES DEBEN COINCIDIR CON LA BASE DE DATOS
        private const string DB_ID_USUARIO = "ID_USUARIO";
        private const string DB_COL_TIPO_CEDULA = "TIPO_CEDULA";
        private const string DB_COL_NOMBRE = "NOMBRE";
        private const string DB_COL_APELLIDO_UNO = "APELLIDO_UNO";
        private const string DB_COL_APELLIDO_DOS = "APELLIDO_DOS";
        private const string DB_COL_CORREO = "CORREO";
        private const string DB_COL_FECHA_NACIMIENTO = "FECHA_NACIMIENTO";
        private const string DB_COL_PAIS_NACIMIENTO = "PAIS_NACIMIENTO";
        private const string DB_COL_GENERO = "GENERO";
        private const string DB_COL_TELEFONO = "TELEFONO";
        private const string DB_COL_NOMBRE_ROL = "NOMBRE_ROL";
        private const string DB_COL_ID_ESTADO = "ID_ESTADO";

        //
        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var usuario = new Usuario
            {

                Cedula = GetStringValue(row, DB_ID_USUARIO),
                TipoCedula = GetStringValue(row, DB_COL_TIPO_CEDULA),
                Nombre = GetStringValue(row, DB_COL_NOMBRE),
                Apellido1 = GetStringValue(row, DB_COL_APELLIDO_UNO),
                Apellido2 = GetStringValue(row, DB_COL_APELLIDO_DOS),
                Correo = GetStringValue(row, DB_COL_CORREO),
                FecNacimiento = GetDateValue(row, DB_COL_FECHA_NACIMIENTO),
                PaisNacimiento = GetStringValue(row, DB_COL_PAIS_NACIMIENTO),
                Genero = GetStringValue(row, DB_COL_GENERO),

                Id_estado = GetIntValue(row, DB_COL_ID_ESTADO),
                Nombre_Rol = GetStringValue(row, DB_COL_NOMBRE_ROL)

            };

            return usuario;
        }


        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var especialidad = BuildObject(row);
                lstResults.Add(especialidad);
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
            var operation = new SqlOperation { ProcedureName = "RET_ALL_USUARIOS_PR" };
            return operation;
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
