using CoreAPI;
using System.Web.Http;
using System.Web.Http.Cors;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [EnableCorsAttribute(origins: "*" , headers: "*" , methods: "*")]
    public class OferenteTopTenController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();

        [Route("api/TopTen")]
        public IHttpActionResult Get() {
            apiResp = new ApiResponse();
            var mng = new OferenteManager();
            apiResp.Data = mng.RetrieveAllTopTenMasIngresos();
            return Ok(apiResp);
        }
    }
}
