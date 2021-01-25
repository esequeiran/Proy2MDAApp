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
    public class OfertaASolicitudDeTrabajoManager : BaseManager
    {

        OfertaASolicitudCrudFactory crudOfertaASolicitud;

        public OfertaASolicitudDeTrabajoManager() {

            crudOfertaASolicitud = new OfertaASolicitudCrudFactory();
        }

        public void Create(OfertaASolicitudDeTrabajo oferta)
        {
            try
            {
                var numResultado = crudOfertaASolicitud.CreateRetorno(oferta);
                if (numResultado == 18) {
                    throw new BussinessException(18);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);

            }
        }

        public List<OfertaASolicitudDeTrabajo> RetrieveOfertasPorSolicitudParaAceptar(OfertaASolicitudDeTrabajo oferta)
        {
            var lista = new List<OfertaASolicitudDeTrabajo>();
            try
            {
                lista = crudOfertaASolicitud.RetrieveAllOfertasParaSolicitudParaCliente<OfertaASolicitudDeTrabajo>(oferta);
                
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return lista;
        }


    }
}
