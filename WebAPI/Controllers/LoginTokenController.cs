using CoreAPI;
using Entities_POJO;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [EnableCorsAttribute(origins: "*", headers: "*", methods: "*")]
    public class LoginTokenController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();
        // GET: api/LoginToken
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/LoginToken/5
        public IHttpActionResult Get(string Correo, string Contrasenna)
        {
            try
            {
                apiResp = new ApiResponse();
                var mng = new LoginTokenManager();
                var token = new LoginToken
                {
                    Correo = Correo,
                    Contrasenna = Contrasenna
                };
                apiResp.Data = mng.RetrieveById(token);

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }

        [Route("api/ModificarContrasenna")]
        public IHttpActionResult Post(string IdUsuario, string ContrasennaActual, string Contrasenna)
        {
            try
            {
                apiResp = new ApiResponse();
                var mng = new LoginTokenManager();
                var token = new LoginToken
                {
                    IdUsuario = IdUsuario,
                    ContrasennaActual = ContrasennaActual,
                    Contrasenna = Contrasenna

                };
                mng.RetrieveByIdContrasennaActual(token);
                apiResp.Message = "Proceso de modificación de contraseña exitoso";
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }

        [Route("api/RecuperarContrasenna")]
        public IHttpActionResult PostRecuperar(string Cedula)
        {
            try
            {
                apiResp = new ApiResponse();
                var mng = new DatosCorreoSmsManager();
                var dato = new DatosAuxiliaresSmsCorreo
                {
                    Cedula = Cedula
                };
                mng.RetrieveCorreoSMSRecuperarContrasenna(dato);
                apiResp.Message = "Correo enviado correctamente.";
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }

        }

        // POST: api/LoginToken
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/LoginToken/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/LoginToken/5
        public void Delete(int id)
        {
        }
    }
}
