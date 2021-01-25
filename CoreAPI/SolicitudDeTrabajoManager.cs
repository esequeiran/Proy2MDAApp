using DataAccess.Crud;
using Entities_POJO;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI
{
    public class SolicitudDeTrabajoManager:BaseManager
    {
        private SolicitudDeTrabajoCrudFactory crudSolicitudATrabajo;
        private LocalizacionManager localizacionMng;
        private DocumentoManager documentoMng;


        public SolicitudDeTrabajoManager() {
            crudSolicitudATrabajo = new SolicitudDeTrabajoCrudFactory();
            localizacionMng = new LocalizacionManager();
            documentoMng = new DocumentoManager();
        }
        public void Create(SolicitudDeTrabajo solicitudT) {

            try {

                crudSolicitudATrabajo.Create(solicitudT);

                solicitudT.IdSolicitud = crudSolicitudATrabajo.RetrieveSolicitudRecienCreada<SolicitudDeTrabajo>(solicitudT).IdSolicitud;

                //agregar cada documento(foto) de la solicitud de trabajo
                foreach (Documento tipoD in solicitudT.ListaDocumentos) {
                    tipoD.IdSolicitud = solicitudT.IdSolicitud;
                    documentoMng.AgregarFotosPreviasSolicitud(tipoD);
                }
                //agregar cada tipo de trabajo correspondientee a la solicitud
                foreach (TipoDeTrabajo tipoT in solicitudT.TiposDeTrabajo) {
                    crudSolicitudATrabajo.CreateTipoTrabajoPorSolicitud(tipoT , solicitudT.IdSolicitud);
                }


            } catch (Exception ex) {
                ExceptionManager.GetInstance().Process(ex);
            }

        }


        public string escaneoSolicitudTrabajo(SolicitudDeTrabajo solicitudT) {
            var resultado = "";

            try {
                var numResult = crudSolicitudATrabajo.UpdateEscanearCodigoQR<SolicitudDeTrabajo>(solicitudT);

                switch (numResult.NumResultado) {
                    case 19:
                        throw new BussinessException(19);
                    case 50:
                        resultado = "La orden de trabajo con la empresa " + numResult.NombreEmpresa + " se da por iniciada.";
                        break;
                    case 51:
                        resultado = "La orden de trabajo con la empresa " + numResult.NombreEmpresa + " se da por finalizada y quedaría a la espera del pago.";
                        break;
                }
            } catch (Exception ex) {
                ExceptionManager.GetInstance().Process(ex);
            }
            return resultado;
        }

        public void EvaluacionTrabajo(SolicitudDeTrabajo solicitudT) {

            try {
                //evaluación del trabajo
                crudSolicitudATrabajo.CreateEvaluacionTrabajo(solicitudT);

                //agregar cada documento(foto) del trabajo realizado
                foreach (Documento tipoD in solicitudT.ListaDocumentos) {
                    tipoD.IdSolicitud = solicitudT.IdSolicitud;
                    documentoMng.AgregarFotosFinalesSolicitud(tipoD);
                }
                //agregar evaluación a cada trabajador
                if (solicitudT.EmpresaTipoCedula.Equals("Juridico")) {
                    foreach (ValoracionTrabajador trabajador in solicitudT.ValoracionDeTrabajadores) {
                        trabajador.IdSolicitud = solicitudT.IdSolicitud;
                        crudSolicitudATrabajo.CreateEvaluacionTrabajador(trabajador);
                    }
                }

            } catch (Exception ex) {
                ExceptionManager.GetInstance().Process(ex);
            }

        }

        public List<SolicitudDeTrabajo> RetriveAllSolicitudesIngresadasParaOferente(Usuario usuario) {
            var list = new List<SolicitudDeTrabajo>();
            try {
                list = crudSolicitudATrabajo.RetrieveSolicitudesIngresadaParaOferente<SolicitudDeTrabajo>(usuario);

            } catch (Exception ex) {
                ExceptionManager.GetInstance().Process(ex);
            }
            return list;
        }


        public List<SolicitudDeTrabajo> RetrieveSolicitudesPendientesEvaluacion(SolicitudDeTrabajo sol) {
            var list = new List<SolicitudDeTrabajo>();
            try {
                list = crudSolicitudATrabajo.RetrieveSolicitudesPendientesEvaluacion<SolicitudDeTrabajo>(sol);
            } catch (Exception ex) {
                ExceptionManager.GetInstance().Process(ex);
            }
            return list;
        }


        public List<SolicitudDeTrabajo> RetriveAllSolicitudesIngresadasParaClienteParaAceptar(SolicitudDeTrabajo solicitud) {
            var list = new List<SolicitudDeTrabajo>();
            try {
                list = crudSolicitudATrabajo.RetrieveSolicitudesIngresadaParaClienteParaAceptarOferta<SolicitudDeTrabajo>(solicitud);

            } catch (Exception ex) {
                ExceptionManager.GetInstance().Process(ex);
            }
            return list;
        }

        public SolicitudDeTrabajo RetrieveSolicitudIngresadaDetalleParaOferente(SolicitudDeTrabajo solConId) {

            var sol = new SolicitudDeTrabajo();
            try {
                sol = crudSolicitudATrabajo.RetrieveSolicitudIngresadaPorIdParaOferente<SolicitudDeTrabajo>(solConId);

                if (sol == null) {
                    throw new BussinessException(0);
                }

            } catch (Exception ex) {
                ExceptionManager.GetInstance().Process(ex);

            }

            return sol;

        }

        public void UpdateCreateOfertaTrabajo(OfertaASolicitudDeTrabajo oferta) {

            try {

                var ordenT = crudSolicitudATrabajo.RetrieveOrdenTrabajo<OrdenDeTrabajo>(oferta);
                if (ordenT != null) {
                    var mngCorreo = new DatosCorreoSmsManager();

                    mngCorreo.RetrieveCorreoOrdenTrabajo(ordenT);
                } else {
                    throw new BussinessException(0);
                }



            } catch (Exception ex) {
                ExceptionManager.GetInstance().Process(ex);
            }

        }


        public List<SolicitudDeTrabajo> RetriveAllSolicitudesPendientesParaOferente(Usuario usuario) {
            var list = new List<SolicitudDeTrabajo>();
            try {
                list = crudSolicitudATrabajo.RetrieveSolicitudesPendientesParaOferente<SolicitudDeTrabajo>(usuario);

            } catch (Exception ex) {
                ExceptionManager.GetInstance().Process(ex);
            }
            return list;
        }

        public SolicitudDeTrabajo RetrieveSolicitudPendienteDetalleParaOferente(SolicitudDeTrabajo solConId) {

            var sol = new SolicitudDeTrabajo();
            try {
                sol = crudSolicitudATrabajo.RetrieveSolicitudPendientePorIdParaOferente<SolicitudDeTrabajo>(solConId);

                if (sol == null) {
                    throw new BussinessException(0);
                }

            } catch (Exception ex) {
                ExceptionManager.GetInstance().Process(ex);

            }

            return sol;

        }


        public List<SolicitudDeTrabajo> RetrieveAllHoras(SolicitudDeTrabajo solicitud) {
            return crudSolicitudATrabajo.RetrieveAllTrabajosPendientesHoras<SolicitudDeTrabajo>(solicitud);
        }

    }
}
