using CoreAPI;
using Entities_POJO;
using Exceptions;
using System;
using System.Web.Http;
using System.Web.Http.Cors;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [EnableCorsAttribute(origins: "*", headers: "*", methods: "*")]
    public class MembresiaPaypamentController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();

        [Route("api/AdquirirMembresia")]
        public IHttpActionResult Put(Membresia membresia)
        {
            try
            {
                //var mem = new Membresia() { IdMembresia = Int32.Parse(id) };
                var mng = new MembresiaManager();
                mng.AdquirirMembresia(membresia);
                var mngCorreoSms = new DatosCorreoSmsManager();
                var pdato = new DatosAuxiliaresSmsCorreo
                {
                    Cedula = membresia.CedulaEmpresa,
                };
                mngCorreoSms.RetrieveCorreoSMSPrimerAccesoPlataforma(pdato);
                apiResp = new ApiResponse();
                apiResp.Message = "Membresía adquirida correctamente.";
                return Ok(apiResp);

            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }

        }
    }
}