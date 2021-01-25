using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class OfertaASolicitudDeTrabajo : BaseEntity
    {
        public int IdOferta { get; set; }

        public int IdSolicitud { get; set; }

        public int IdEmpresa { get; set; }

        public string NombreEmpresa  { get; set; }

        public string IdUsuario { get; set; }

        public double PresupuestoOferta { get; set; }

        public string Fecha { get; set; }

        public int IdEstado { get; set; }

        public string NombreEstado { get; set; }

        public List<TipoDeTrabajo> TiposDeTrabajo { get; set; }

      




        public OfertaASolicitudDeTrabajo() { 
        
        }
    }
}
