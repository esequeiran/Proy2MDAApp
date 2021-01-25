using DataAccess.Dao;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class SolicitudDeTrabajoMapper:EntityMapper, ISqlStatements, IObjectMapper
    {
        private const string DB_COL_ID_SOLICITUD = "ID_SOLICITUD";
        private const string DB_COL_FECHA_CREACION = "FECHA_CREACION";
        private const string DB_COL_DESCRIPCION_NECESIDAD = "DESCRIPCION_NECESIDAD";
        private const string DB_COL_EXPLICACION_TRABAJO = "EXPLICACION_TRABAJO";
        private const string DB_COL_TELEFONO_CONTACTO = "TELEFONO_CONTACTO";
        private const string DB_COL_NOMBRE_CONTACTO = "NOMBRE_CONTACTO";
        private const string DB_COL_PRESUPUESTO = "PRESUPUESTO";
        private const string DB_COL_CEDULA_CLIENTE = "CEDULA_CLIENTE";
        private const string DB_COL_ID_ESTADO = "ID_ESTADO";
        private const string DB_COL_NOMBRE_ESTADO = "NOMBRE_ESTADO";
        private const string DB_COL_CODIGO_QR = "CODIGO_QR";
        private const string DB_COL_FECHA_EVENTO = "FECHA_EVENTO";
        private const string DB_COL_ID_LOCALIZACION = "ID_LOCALIZACION";
        private const string DB_COL_VALORACION_ESTRELLAS = "VALORACION_ESTRELLAS";
        private const string DB_COL_COMENTARIO_TRABAJO = "COMENTARIO_TRABAJO";
        private const string DB_COL_ID_EMPRESA = "ID_EMPRESA";
        private const string DB_COL_ID_OFERENTE = "ID_OFERENTE";
        //localizacion
        private const string DB_COL_PROVINCIA = "PROVINCIA";
        private const string DB_COL_CANTON = "CANTON";
        private const string DB_COL_DISTRITO = "DISTRITO";
        private const string DB_COL_LATITUD = "LATITUD";
        private const string DB_COL_LONGITUD = "LONGITUD";
        private const string DB_COL_OTRAS_SENNAS = "OTRAS_SENNAS";
        private const string DB_COL_ID_USUARIO = "ID_USUARIO";
        private const string DB_COL_ID_NOMBRE_LOCALIZACION = "NOMBRE_LOCALIZACION";
        //tipoTrabajo
        private const string DB_COL_ID_TIPO_TRABAJO = "ID_TIPO_TRABAJO";
        private const string DB_COL_FECHA_EVENTO_S = "FECHA_EVENTO_S";
        private const string DB_COL_NOMBRE_CLIENTE = "NOMBRE_CLIENTE";
        private const string DB_COL_CANTIDAD_OFERTAS = "CANTIDAD_OFERTAS";
        private const string DB_COL_NOMBRE_EMPRESA = "NOMBRE_EMPRESA";
        private const string DB_COL_CORREO_EMPRESA = "CORREO_EMPRESA";
        private const string DB_COL_COSTO_MONETARIO = "COSTO_MONETARIO";
        private const string DB_COL_CORREO_CLIENTE = "CORREO_CLIENTE";
        private const string DB_COL_TIPOS_TRABAJO_S = "TIPOS_TRABAJO_S";
        private const string DB_COL_FOTOS = "FOTOS";
        private const string DB_COL_PRESUPUESTO_S = "PRESUPUESTO_S";

        private const string DB_COL_ID_OFERTA = "ID_OFERTA";
        private const string DB_COL_NUM_RESULTADO = "NUM_RESULTADO";

        private const string DB_COL_ID_TRABAJADOR = "ID_TRABAJADOR";
        private const string DB_COL_NOMBRE_TRABAJADOR = "NOMBRE_TRABAJADOR";
        private const string DB_COL_COMENTARIO = "COMENTARIO";
        private const string DB_COL_EMPRESA_TIPO_CEDULA = "EMPRESA_TIPO_CEDULA";
        private const string DB_COL_NOMBRE_COMPLETO = "NOMBRE_COMPLETO";

        
        public BaseEntity BuildObjectLocalizacion(Dictionary<string , object> row) {
            var localizacion = new Localizacion {
                IdLocalizacion = GetIntValue(row , DB_COL_ID_LOCALIZACION) ,
                Provincia = GetStringValue(row , DB_COL_PROVINCIA) ,
                Canton = GetStringValue(row , DB_COL_CANTON) ,
                Distrito = GetStringValue(row , DB_COL_DISTRITO) ,
                Latitud = GetStringValue(row , DB_COL_LATITUD) ,
                Longitud = GetStringValue(row , DB_COL_LONGITUD) ,
                OtrasSennas = GetStringValue(row , DB_COL_OTRAS_SENNAS) ,
                IdUsuario = GetStringValue(row , DB_COL_ID_USUARIO) ,
                Nombre = GetStringValue(row , DB_COL_ID_NOMBRE_LOCALIZACION)
            };
            return localizacion;
        }

        public BaseEntity BuildObjectResultadoEscaneo(Dictionary<string, object> row)
        {
            var solicitud = new SolicitudDeTrabajo
            {
                NumResultado = GetIntValue(row, DB_COL_NUM_RESULTADO),
                NombreEmpresa = GetStringValue(row,DB_COL_NOMBRE_EMPRESA)               
            };
            return solicitud;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            throw new NotImplementedException();
        }

        public BaseEntity BuildObjectOrdenTrabajo(Dictionary<string, object> row)
        { 
            var orden = new OrdenDeTrabajo
            {
                NombreCliente = GetStringValue(row, DB_COL_NOMBRE_CLIENTE),
                CorreoCliente = GetStringValue(row,DB_COL_CORREO_CLIENTE),
                FechaEventoS = GetStringValue(row, DB_COL_FECHA_EVENTO_S),
                DescripcionNecesidad = GetStringValue(row, DB_COL_DESCRIPCION_NECESIDAD),
                ExplicacionTrabajo = GetStringValue(row, DB_COL_EXPLICACION_TRABAJO),
                CodigoQr = GetStringValue(row, DB_COL_CODIGO_QR),
                Provincia = GetStringValue(row, DB_COL_PROVINCIA),
                Canton = GetStringValue(row, DB_COL_CANTON),
                Distrito = GetStringValue(row,DB_COL_DISTRITO),
                OtrasSennas = GetStringValue(row, DB_COL_OTRAS_SENNAS),
                NombreEmpresa = GetStringValue(row, DB_COL_NOMBRE_EMPRESA),
                CorreoEmpresa = GetStringValue(row, DB_COL_CORREO_EMPRESA),
                CostoMonetario = GetStringValue(row,DB_COL_COSTO_MONETARIO)
            };

            return orden;
        }
        public List<BaseEntity> BuildObjectsOrdenTrabajo(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var solicitud = BuildObjectOrdenTrabajo(row);
                lstResults.Add(solicitud);
            }

            return lstResults;
        }


        public BaseEntity BuildObjectSolicitudRecienCreada(Dictionary<string, object> row)
        {
            var solicitud = new SolicitudDeTrabajo
            {
                IdSolicitud = GetIntValue(row, DB_COL_ID_SOLICITUD)
            };
            return solicitud;
        }

        public BaseEntity BuildObjectSolicitudIngresadaPorIdParaOferente(Dictionary<string, object> row)
        {
            var solicitud = new SolicitudDeTrabajo
            {
                NombreCliente = GetStringValue(row, DB_COL_NOMBRE_CLIENTE),
                FechaEventoS = GetStringValue(row, DB_COL_FECHA_EVENTO_S),
                DescripcionNecesidad = GetStringValue(row, DB_COL_DESCRIPCION_NECESIDAD),
                ExplicacionTrabajo = GetStringValue(row, DB_COL_EXPLICACION_TRABAJO),
                TiposTrabajoS = GetStringValue(row, DB_COL_TIPOS_TRABAJO_S),
                Fotos = GetStringValue(row, DB_COL_FOTOS),
                NombreContacto = GetStringValue(row, DB_COL_NOMBRE_CONTACTO),
                TelefonoContacto = GetStringValue(row, DB_COL_TELEFONO_CONTACTO),
                PresupuestoS = GetStringValue(row, DB_COL_PRESUPUESTO_S),
                Provincia = GetStringValue(row, DB_COL_PROVINCIA),
                Canton = GetStringValue(row, DB_COL_CANTON),
                Distrito = GetStringValue(row, DB_COL_DISTRITO),
                OtrasSennas = GetStringValue(row, DB_COL_OTRAS_SENNAS),
                Latitud = GetStringValue(row, DB_COL_LATITUD),
                Longitud = GetStringValue(row, DB_COL_LONGITUD)
            };
            return solicitud;
        }




        public List<BaseEntity> BuildObjects(List<Dictionary<string , object>> lstRows) {
            throw new NotImplementedException();
        }

        public List<BaseEntity> BuildObjectsSolIngresadasOferente(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var solicitud = BuildObjectSolIngresadas(row);
                lstResults.Add(solicitud);
            }

            return lstResults;
        }


        public List<BaseEntity> BuildObjectsSolIngresadasParaClienteParaAceptarOferta(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var solicitud = BuildObjectSolIngresadasParaClienteParaAceptar(row);
                lstResults.Add(solicitud);
            }

            return lstResults;
        }

        public BaseEntity BuildObjectSolIngresadasParaClienteParaAceptar(Dictionary<string, object> row)
        {
            var solicitud = new SolicitudDeTrabajo
            {
                IdSolicitud = GetIntValue(row, DB_COL_ID_SOLICITUD),               
                ExplicacionTrabajo = GetStringValue(row, DB_COL_EXPLICACION_TRABAJO),
                Presupuesto = GetDoubleValue(row, DB_COL_PRESUPUESTO),
                NombreEstado = GetStringValue(row, DB_COL_NOMBRE_ESTADO),
                FechaEventoS = GetStringValue(row, DB_COL_FECHA_EVENTO_S),
                CantidadOfertas = GetIntValue(row,DB_COL_CANTIDAD_OFERTAS)
            };
            return solicitud;
        }

        public BaseEntity BuildObjectSolIngresadas(Dictionary<string, object> row)
        {
            var solicitud = new SolicitudDeTrabajo
            {
                IdSolicitud = GetIntValue(row, DB_COL_ID_SOLICITUD),
                NombreCliente = GetStringValue(row, DB_COL_NOMBRE_CLIENTE),
                ExplicacionTrabajo = GetStringValue(row, DB_COL_EXPLICACION_TRABAJO),
                Presupuesto = GetDoubleValue(row, DB_COL_PRESUPUESTO),
                FechaEventoS = GetStringValue(row, DB_COL_FECHA_EVENTO_S)                
            };
            return solicitud;
        }

        public SolicitudDeTrabajo BuildObjectSolPendienteEvaluacion(Dictionary<string, object> row)
        {
            var solicitud = new SolicitudDeTrabajo
            {
                IdSolicitud = GetIntValue(row, DB_COL_ID_SOLICITUD),               
                ExplicacionTrabajo = GetStringValue(row, DB_COL_EXPLICACION_TRABAJO),
                NombreEmpresa = GetStringValue(row, DB_COL_NOMBRE_EMPRESA),
                NombreEstado = GetStringValue(row, DB_COL_NOMBRE_ESTADO), 
                EmpresaTipoCedula = GetStringValue(row, DB_COL_EMPRESA_TIPO_CEDULA)
            };

            var valTraba = new ValoracionTrabajador
            {
                IdTrabajador = GetStringValue(row, DB_COL_ID_TRABAJADOR),
                NombreTrabajador = GetStringValue(row, DB_COL_NOMBRE_TRABAJADOR)
            };
            var listaT = new List<ValoracionTrabajador>();
            listaT.Add(valTraba);
            solicitud.ValoracionDeTrabajadores = listaT;

            return solicitud;
        }


        public List<SolicitudDeTrabajo> BuildObjectsSolPendientesEvaluacion(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<SolicitudDeTrabajo>();

            foreach (var row in lstRows)
            {
                var solicitud = BuildObjectSolPendienteEvaluacion(row);
                lstResults.Add(solicitud);
            }

            return lstResults;
        }


        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_SOLICITUD_DE_TRABAJO_PR" };

            var solicitudT = (SolicitudDeTrabajo)entity;
            operation.AddNVarcharParam(DB_COL_DESCRIPCION_NECESIDAD , solicitudT.DescripcionNecesidad);
            operation.AddNVarcharParam(DB_COL_EXPLICACION_TRABAJO , solicitudT.ExplicacionTrabajo);
            operation.AddNVarcharParam(DB_COL_TELEFONO_CONTACTO , solicitudT.TelefonoContacto);
            operation.AddNVarcharParam(DB_COL_NOMBRE_CONTACTO , solicitudT.NombreContacto);
            operation.AddDoubleParam(DB_COL_PRESUPUESTO , solicitudT.Presupuesto);
            operation.AddNVarcharParam(DB_COL_CEDULA_CLIENTE , solicitudT.CedulaCliente);
            operation.AddDateTimeParam(DB_COL_FECHA_EVENTO , solicitudT.FechaEvento);
            operation.AddIntParam(DB_COL_ID_LOCALIZACION , solicitudT.IdLocalizacion);
            return operation;
        }

        public SqlOperation GetCreateStatementTipoTrabajoSolicitud(BaseEntity entity , int idSolicitud) {
            var operation = new SqlOperation { ProcedureName = "CRE_TIPO_TRABAJO_POR_SOLICITUD_TRABAJO_PR" };

            var tipoTra = (TipoDeTrabajo)entity;
            operation.AddIntParam(DB_COL_ID_SOLICITUD , idSolicitud);
            operation.AddIntParam(DB_COL_ID_TIPO_TRABAJO , tipoTra.Id_TipoTrabajo);
            return operation;
        }
        
        public SqlOperation GetCreateStatementEvaluacionTrabajo(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_VALORACION_TRABAJO_SOLICTUD_PR" };

            var solicitud = (SolicitudDeTrabajo)entity;
            operation.AddIntParam(DB_COL_ID_SOLICITUD, solicitud.IdSolicitud);
            operation.AddIntParam(DB_COL_VALORACION_ESTRELLAS, solicitud.ValoracionEstrellas);
            operation.AddNVarcharParam(DB_COL_COMENTARIO, solicitud.ComentarioTrabajo);
            return operation;
        }

        public SqlOperation GetCreateStatementEvaluacionTrabajador(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_VALORACION_TRABAJADOR_SOLICITUD_PR" };

            var solicitud = (ValoracionTrabajador)entity;
            operation.AddIntParam(DB_COL_ID_SOLICITUD, solicitud.IdSolicitud);
            operation.AddNVarcharParam(DB_COL_ID_TRABAJADOR, solicitud.IdTrabajador);
            operation.AddIntParam(DB_COL_VALORACION_ESTRELLAS, solicitud.ValoracionEstrellasTrabajador);
            operation.AddNVarcharParam(DB_COL_COMENTARIO, solicitud.ComentarioTrabajador);
            return operation;
        }

        public SqlOperation GetUpdateStatementSolicitudAndCreateOrdenTrabajo(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_SOLICITUD_TRABAJO_APROBADA_GENERAR_ORDEN_PR" };
            var oferta = (OfertaASolicitudDeTrabajo)entity;
            operation.AddIntParam(DB_COL_ID_OFERTA, oferta.IdOferta);
            operation.AddIntParam(DB_COL_ID_SOLICITUD, oferta.IdSolicitud);    
            return operation;
        }


        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetriveAllStatementPorOferenteIngresadas(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_SOLICITUD_TRABAJO_PARA_OFERENTES_PR" };
            var ofe = (Usuario)entity;
            operation.AddNVarcharParam(DB_COL_ID_USUARIO, ofe.Cedula);
            return operation;
        }

        public SqlOperation GetRetriveAllStatementPorClienteParaAceptarOferta(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_SOLICITUDES_POR_CLIENTE" };
            var sol = (SolicitudDeTrabajo)entity;
            operation.AddNVarcharParam(DB_COL_CEDULA_CLIENTE, sol.CedulaCliente);
            return operation;
        } 
        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetriveLocalizacionRecienCreadaStatement(BaseEntity entity) {
            var operation = new SqlOperation { ProcedureName = "RET_LOCALIZACION_POR_USUARIO_PARA_SOLICITUD_TRABAJO_PR" };
            var solicitudT = (SolicitudDeTrabajo)entity;
            operation.AddNVarcharParam(DB_COL_CEDULA_CLIENTE, solicitudT.CedulaCliente);
            return operation;
        }

        public SqlOperation GetEscaneoStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_SOLICITUD_ESCANEO_CODIGO_QR_PR" };
            var solicitudT = (SolicitudDeTrabajo)entity;
            operation.AddNVarcharParam(DB_COL_CEDULA_CLIENTE, solicitudT.CedulaCliente);
            operation.AddNVarcharParam(DB_COL_CODIGO_QR, solicitudT.CodigoQR);    
            return operation;
        }

        public SqlOperation GetRetriveSolicitudRecienCreadaStatement(BaseEntity entity) {
            var operation = new SqlOperation { ProcedureName = "RET_ID_SOLICITUD_CLIENTE_RECIEN_CREADA_PR" };
            var solicitudT = (SolicitudDeTrabajo)entity;
            operation.AddNVarcharParam(DB_COL_CEDULA_CLIENTE, solicitudT.CedulaCliente);
            return operation;
        }

        public SqlOperation GetRetriveSolicitudIngresadaPorIdParaOferente(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_SOLICITUD_TRABAJO_DETALLE_PARA_OFERENTE_PR" };
            var solicitudT = (SolicitudDeTrabajo)entity;
            operation.AddIntParam(DB_COL_ID_SOLICITUD, solicitudT.IdSolicitud);
            return operation;
        }

        public SqlOperation GetRetrieveSolicitudesPendientesEvaluacion(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_SOLICITUDES_PENDIENTES_VALORACION_PR" };
            var solicitudT = (SolicitudDeTrabajo)entity;
            operation.AddNVarcharParam(DB_COL_CEDULA_CLIENTE, solicitudT.CedulaCliente);
            return operation;
        }


        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }


        //Solicitudes pendientes para oferente
        public SqlOperation GetRetriveAllStatementPorOferentePendientes(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_SOLICITUD_TRABAJO_PENDIENTES_PARA_OFERENTES_PR" };
            var ofe = (Usuario)entity;
            operation.AddNVarcharParam(DB_COL_ID_USUARIO, ofe.Cedula);
            return operation;
        }
             

        public SqlOperation GetRetriveSolicitudIngresadaPorIdParaOferentePendiente(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_SOLICITUD_TRABAJO_PENDIENTE_DETALLE_PARA_OFERENTE_PR" };
            var solicitudT = (SolicitudDeTrabajo)entity;
            operation.AddIntParam(DB_COL_ID_SOLICITUD, solicitudT.IdSolicitud);
            return operation;
        }

        




        public SqlOperation GetRetriveAllTrabajosPendienteHorasStatement(BaseEntity entity) {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_TRABAJOS_PENDIENTES_HORAS" };
            var solicitud = (SolicitudDeTrabajo)entity;
            operation.AddNVarcharParam(DB_COL_ID_OFERENTE , solicitud.Id_Empresa);
            return operation;
        }

        public List<BaseEntity> BuildObjectTrabajosPendientesHoras(List<Dictionary<string , object>> lstRows) {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows) {
                var soliticitud = BuildObjectTrabajosPendientesHoras(row);
                lstResults.Add(soliticitud);
            }

            return lstResults;
        }

        public BaseEntity BuildObjectTrabajosPendientesHoras(Dictionary<string , object> row) {
            var soliticitud = new SolicitudDeTrabajo {
                IdSolicitud = GetIntValue(row, DB_COL_ID_SOLICITUD),
                NombreCompletoCliente = GetStringValue(row, DB_COL_NOMBRE_COMPLETO),
                FechaEvento = GetDateValue(row, DB_COL_FECHA_EVENTO),
                DescripcionNecesidad = GetStringValue(row, DB_COL_DESCRIPCION_NECESIDAD)
            };
            return soliticitud;
        }

        public SqlOperation GetRetriveAllStatement() {
            throw new NotImplementedException();
        }
    }
}
