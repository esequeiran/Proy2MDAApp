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
    [EnableCorsAttribute(origins: "*", headers: "*", methods: "*")]
    public class MembresiaController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();
        // GET: api/Membresia
        public IHttpActionResult Get()
        {
            apiResp = new ApiResponse();
            var mng = new MembresiaManager();
            apiResp.Data = mng.RetrieveAll();
            return Ok(apiResp);
        }

        public IHttpActionResult Get(string CedulaEmpresa)
        {
            try
            {
                apiResp = new ApiResponse();
                var mng = new MembresiaManager();
                var membresia = new Membresia
                {
                    CedulaEmpresa = CedulaEmpresa
                };
                apiResp.Data = mng.RetriveAllByEmpresa(membresia);

                //correoMng.ejecutarCorreo();
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }

        }

        [Route("api/MembresiaEmpresaSinExcepcion")]
        public IHttpActionResult GetPorEmpresaSinExcepcion(string CedulaEmpresa)
        {
            try
            {
                apiResp = new ApiResponse();
                var mng = new MembresiaManager();
                var membresia = new Membresia
                {
                    CedulaEmpresa = CedulaEmpresa
                };
                apiResp.Data = mng.RetriveAllByEmpresaSinExcepcion(membresia);

                //correoMng.ejecutarCorreo();
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }

        }


        [Route("api/EnviarMembresias")]
        public IHttpActionResult PostEnviarCorreo(string CedulaEmpresa)
        {
            try
            {
                apiResp = new ApiResponse();
                var mng = new DatosCorreoSmsManager();
                var dato = new DatosAuxiliaresSmsCorreo
                {
                    CedulaEmpresa = CedulaEmpresa
                };
                mng.RetrieveCorreoEmpresa(dato);
                apiResp.Message = "Correo enviado correctamente.";
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }

        }



        // GET: api/Membresia/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Membresia
        public IHttpActionResult Post(Membresia objMembresia)
        {
            try
            {
                var mng = new MembresiaManager();
                mng.Create(objMembresia);
                apiResp = new ApiResponse();
                apiResp.Message = "Registro de membresía correcto";
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }

        }

        // PUT: api/Membresia/5
        public IHttpActionResult Put(Membresia objMembresia)
        {
            try
            {
                var mng = new MembresiaManager();
                mng.Update(objMembresia);
                apiResp = new ApiResponse();
                apiResp.Message = "Registro de membresía correcto";
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }

        }

        // DELETE: api/Membresia/5
        public IHttpActionResult Delete(Membresia objMembresia)
        {
            try
            {
                var mng = new MembresiaManager();
                mng.Delete(objMembresia);
                apiResp = new ApiResponse();
                apiResp.Message = "Proceso de eliminación correcto";
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }
    }
}
