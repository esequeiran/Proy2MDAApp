using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        [Route("index")]
        [Route("~/")]
        public ActionResult Index()
        {
            return View("vLandingPage");
        }

        public ActionResult vVerificarCodigo()
        {
            return View();
        }   
        
        public ActionResult vAsignarTrabajadores()
        {
            return View();
        }
        public ActionResult vMonedero()
        {
            return View();
        } 
        public ActionResult vPerfilOferente()
        {
            return View();
        }
        public ActionResult vVerPerfilOferente()
        {
            string cedula = GetUrlParameter(Request, "Cedula");
            ViewBag.Cedula = string.Empty;
            if (!string.IsNullOrEmpty(cedula))
            {
                ViewBag.Cedula = cedula;
            }

            return View();
        }
        public ActionResult vRegistroOferente()
        {
            return View();
        }

        public ActionResult vRegistroTrabajador()
        {
            return View();
        }
        public ActionResult vBitacoraAcciones()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult vListarMembresias()
        {
            return View();
        }
        public ActionResult vRegistrarMembresia()
        {
            return View();
        }

        public ActionResult vAdministrarTarifas()
        {
            return View();
        }

        public ActionResult vLogin()
        {
            return View();
        }

        [HttpGet, ActionName("vLandingPage")]
        [Route("vLandingPage")]
        public ActionResult vLandingPage()
        {
            return View();
        }
        public ActionResult vRegistrarMembresiaYEnviarCorreo()
        {
            return View();
        }

        public ActionResult vEspecialidad()
        {
            return View();
        }

        public ActionResult vTipoTrabajo()
        {
            return View();
        }

        public ActionResult vUsuario()
        {
            return View();
        }
        public ActionResult vSolicitudRegistro()
        {
            return View();
        }

        public ActionResult vRegistrarContrasenna()
        {
            return View();
        }

        public ActionResult vRecuperarContrasenna()
        {
            return View();
        }

        public ActionResult vModificarContrasenna()
        {
            return View();
        }
        public ActionResult vIndexInterno()
        {
            return View();
        }

        public ActionResult vRegistrarAdministrador()
        {
            ViewBag.IdVista = 1;
            return View();
        }

        public ActionResult vRegistrarLocalizacion()
        {
            return View();
        }
        public ActionResult vListarLocalizaciones()
        {
            return View();
        }
        public ActionResult vListarTrabajadores()
        {
            return View();
        }

        public ActionResult vModificarAdministrador()
        {
            return View();
        }

        public ActionResult vConfigurarIVA()
        {
            ViewBag.IdVista = 1;
            return View();
        }

        public ActionResult vComprarMembresia()
        {
            return View();
        }

        public ActionResult vDashboardAdmin()
        {
            return View();
        }

        public ActionResult vDashboardOferente()
        {
            return View();
        }
        public ActionResult vTerminosCondiciones()
        {
            return View();
        }


        public ActionResult vRegistrarSolicitudDeTrabajo()
        {
            return View();
        }

        public ActionResult vListarMembresiasOferente()
        {
            string cedula = GetUrlParameter(Request, "Cedula");
            ViewBag.Cedula = string.Empty;
            if (!string.IsNullOrEmpty(cedula))
            {
                ViewBag.Cedula = cedula;
            }

            return View();
        }

        public ActionResult vElegirTipoRegistro() {
            return View();
        }

        public ActionResult vListarTransacciones() {
            return View();
        }

        public ActionResult vRegistrarCliente() {
            return View();
        }
        public ActionResult vModificarCliente() {
            return View();
        }
        public ActionResult vPerfilCliente() {
            return View();
        }
        private string GetUrlParameter(HttpRequestBase request, string parName)
        {
            string result = string.Empty;

            var urlParameters = HttpUtility.ParseQueryString(request.Url.Query);
            if (urlParameters.AllKeys.Contains(parName))
            {
                result = urlParameters.Get(parName);
            }

            return result;
        }

        public ActionResult vListarSolicitudesTrabajoIngresadasPorOferente(){
            return View();
        }

        public ActionResult vListarSolicitudesIngresadasPorCliente()
        {
            return View();
        }

        public ActionResult vAceptarOfertaPorCliente()
        {
            return View();
        }

        public ActionResult vEscanearCodigoQR()
        {
            return View();
        }

        public ActionResult vRegistrarEvaluacionSolicitudTrabajo()
        {
            return View();
        }


        public ActionResult vListarSolicitudesTrabajoPendientesAprobadasParaOferente()
        {
            return View();
        }

        

        public ActionResult vTipoTrabajoPorEmpresa()
        {
            return View();
        }

        public ActionResult vRegistrarHorasTrabajadas() {
            return View();
        }

        public ActionResult vListarPagosPendientes() {
            return View();
        }

        public ActionResult vListarSolicitudesPendienteHoras() {
            return View();
        }
    }
}
