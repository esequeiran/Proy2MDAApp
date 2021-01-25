using DataAccess.Dao;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class OfertaASolicitudDeTrabajoMapper : EntityMapper, ISqlStatements, IObjectMapper
    {

        private const string DB_COL_ID_OFERTA = "ID_OFERTA";
        private const string DB_COL_ID_SOLICITUD = "ID_SOLICITUD";
        private const string DB_COL_ID_EMPRESA = "ID_EMPRESA";
        private const string DB_COL_ID_USUARIO = "ID_USUARIO";
        private const string DB_COL_PRESUPUESTO = "PRESUPUESTO_OFERTA";
        private const string DB_COL_FECHA = "FECHA";
        private const string DB_COL_ID_ESTADO = "ID_ESTADO";
        private const string DB_COL_NOMBRE_ESTADO = "NOMBRE_ESTADO";
        private const string DB_COL_NOMBRE_EMPRESA = "NOMBRE_EMPRESA";
        private const string DB_COL_NOMBRE_TIPO_TRABAJO = "NOMBRE_TIPO_TRABAJO";
        private const string DB_COL_COSTO_POR_HORA = "COSTO_POR_HORA";
        private const string DB_COL_FECHA_CREACION = "FECHA_CREACION";

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var membresia = new Membresia
            {
                

            };

            return membresia;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var membresia = BuildObject(row);
                lstResults.Add(membresia);
            }

            return lstResults;
        }

        public BaseEntity BuildObjectOfertaASolictudCliente(Dictionary<string, object> row)
        {
            var oferta = new OfertaASolicitudDeTrabajo
            {
                IdOferta = GetIntValue(row, DB_COL_ID_OFERTA),
                NombreEmpresa = GetStringValue(row, DB_COL_NOMBRE_EMPRESA),
                PresupuestoOferta = GetDoubleValue(row, DB_COL_PRESUPUESTO),
                Fecha = GetStringValue(row,DB_COL_FECHA_CREACION)
            };

            var tt = new TipoDeTrabajo { 
                Nombre_TipoTrabajo = GetStringValue(row, DB_COL_NOMBRE_TIPO_TRABAJO),
                Costo_Por_Hora = GetDoubleValue(row, DB_COL_COSTO_POR_HORA)
            };
            oferta.TiposDeTrabajo = new List<TipoDeTrabajo>();
            oferta.TiposDeTrabajo.Add(tt);

            return oferta;
        }

        public List<BaseEntity> BuildObjectsOfertasASolicitudCliente(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var oferta = BuildObjectOfertaASolictudCliente(row);
                lstResults.Add(oferta);
            }

            return lstResults;
        }

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_OFERTA_A_SOLICITUD_PR" };
            var oferta = (OfertaASolicitudDeTrabajo)entity;
            operation.AddIntParam(DB_COL_ID_SOLICITUD, oferta.IdSolicitud);
            operation.AddVarcharParam(DB_COL_ID_USUARIO, oferta.IdUsuario);
            operation.AddDoubleParam(DB_COL_PRESUPUESTO, oferta.PresupuestoOferta);            
            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_MEMBRESIA_PR" };
            var membresia = (Membresia)entity;
           
            return operation;
        }

        public SqlOperation GetRetriveAllOfertasPorSolicitudParaCliente(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_OFERTAS_POR_SOLICITUD" };
            var of = (OfertaASolicitudDeTrabajo)entity;
            operation.AddIntParam(DB_COL_ID_SOLICITUD, of.IdSolicitud);
            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_MEMBRESIA_PR" };
            var membrecia = (Membresia)entity;
            
            return operation;
        }

        public SqlOperation GetRetriveAllStatementByEmpresa(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_MEMBRESIA_EMPRESA_PR" };
            var membresia = (Membresia)entity;
            
            return operation;
        }

        public SqlOperation GetUpdateMembresiaStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_ADQUIRIR_MEMBRESIA_PR" };
            var membresia = (Membresia)entity;
          
            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            throw new NotImplementedException();
        }
    }
}
