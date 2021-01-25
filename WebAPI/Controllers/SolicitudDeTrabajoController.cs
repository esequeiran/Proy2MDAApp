using CoreAPI;
using Entities_POJO;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SolicitudDeTrabajoController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();
        // GET: api/SolicitudDeTrabajo

        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/SolicitudDeTrabajo/5
        public string Get(int id)
        {
            return "value";
        }

        public IHttpActionResult GetSolPorIdParaOferente(int idSolDetalles)
        {
            try
            {
                apiResp = new ApiResponse();
                var mng = new SolicitudDeTrabajoManager();
                var solicitud = new SolicitudDeTrabajo
                {
                    IdSolicitud = idSolDetalles
                };
                apiResp.Data = mng.RetrieveSolicitudIngresadaDetalleParaOferente(solicitud);

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }

        [Route ("api/SolicitudPendienteDetalleParaOferente")]
        public IHttpActionResult GetSolPorIdParaOferentePendiente(int idSolDetalles)
        {
            try
            {
                apiResp = new ApiResponse();
                var mng = new SolicitudDeTrabajoManager();
                var solicitud = new SolicitudDeTrabajo
                {
                    IdSolicitud = idSolDetalles
                };
                apiResp.Data = mng.RetrieveSolicitudPendienteDetalleParaOferente(solicitud);

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }
        [Route("api/SolicitudesPendientesParaOferente")]
        public IHttpActionResult GetPendientesParaOferente(string idOferente)
        {
            try
            {
                apiResp = new ApiResponse();
                var mng = new SolicitudDeTrabajoManager();
                var usuario = new Usuario
                {
                    Cedula = idOferente
                };
                apiResp.Data = mng.RetriveAllSolicitudesPendientesParaOferente(usuario);

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }


        public IHttpActionResult GetIngresadasParaCliente(string idCliente)
        {
            try
            {
                apiResp = new ApiResponse();
                var mng = new SolicitudDeTrabajoManager();
                var solicitud = new SolicitudDeTrabajo
                {
                    CedulaCliente = idCliente
                };
                apiResp.Data = mng.RetriveAllSolicitudesIngresadasParaClienteParaAceptar(solicitud);

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }

        [Route("api/SolicitudesPendientesEvaluacion")]
        public IHttpActionResult GetPendientesEvaluacion(string idCliente)
        {
            try
            {
                apiResp = new ApiResponse();
                var mng = new SolicitudDeTrabajoManager();
                var solicitud = new SolicitudDeTrabajo
                {
                    CedulaCliente = idCliente
                };
                apiResp.Data = mng.RetrieveSolicitudesPendientesEvaluacion(solicitud);

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }

        public IHttpActionResult GetIngresadasParaOferente(string idOferente)
        {
            try
            {
                apiResp = new ApiResponse();
                var mng = new SolicitudDeTrabajoManager();
                var usuario = new Usuario
                {
                    Cedula = idOferente
                };
                apiResp.Data = mng.RetriveAllSolicitudesIngresadasParaOferente(usuario);

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }

        // POST: api/SolicitudDeTrabajo
        public IHttpActionResult Post(SolicitudDeTrabajo solicitudTrabajo)
        {

            try
            {
                var mng = new SolicitudDeTrabajoManager();
                mng.Create(solicitudTrabajo);
                apiResp = new ApiResponse();
                apiResp.Message = "Registro de solicitud de trabajo correcto";
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }


       
        [Route("api/CalificarSolicitudDeTrabajo")]
        public IHttpActionResult PostCalificacion(SolicitudDeTrabajo solicitudTrabajo)
        {
            try
            {
                var mng = new SolicitudDeTrabajoManager();
                mng.EvaluacionTrabajo(solicitudTrabajo);
                apiResp = new ApiResponse();
                apiResp.Message = "Registro de evaluación de trabajo correcto";
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }


        [Route ("api/EscanearCodigoSolicitud")]
        public IHttpActionResult PostEscanearCodigo(SolicitudDeTrabajo solicitudTrabajo)
        {

            try
            {
                var mng = new SolicitudDeTrabajoManager();              
                apiResp = new ApiResponse();
                apiResp.Message =  mng.escaneoSolicitudTrabajo(solicitudTrabajo);
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }

        // PUT: api/SolicitudDeTrabajo/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/SolicitudDeTrabajo/5
        public void Delete(int id)
        {
        }

        //[HttpGet]
        [Route("api/SolicitudHora")] //TRAE TODAS
        public IHttpActionResult GetNotificaciones(string  idEmpresa) {
            var solicitud = new SolicitudDeTrabajo { Id_Empresa = idEmpresa };
            apiResp = new ApiResponse();
            var mng = new SolicitudDeTrabajoManager();

            apiResp.Data = mng.RetrieveAllHoras(solicitud);

            return Ok(apiResp);
        }
    }
}
