using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class SolicitudDeTrabajo : BaseEntity
    {
        public int IdSolicitud { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string DescripcionNecesidad { get; set; }
        public string ExplicacionTrabajo { get; set; }
        public string TelefonoContacto { get; set; }
        public string NombreContacto { get; set; }
        public double Presupuesto { get; set; }
        public string CedulaCliente { get; set; }
        public int IdEstado { get; set; }
        public string NombreEstado { get; set; }
        public string CodigoQR { get; set; }
        public DateTime FechaEvento { get; set; }
        public int IdLocalizacion { get; set; }
        public Boolean IdLocalizacionPresente { get; set; } 
        public Localizacion Localizacion { get; set; }
        public int ValoracionEstrellas { get; set; }
        public string ComentarioTrabajo { get; set; }
        public string Id_Empresa { get; set; }
        public List<Documento>  ListaDocumentos { get; set; }
        public List<TipoDeTrabajo> TiposDeTrabajo { get; set; }
        public string FechaEventoS { get; set; }
        public string NombreCliente { get; set; }
        public int CantidadOfertas { get; set; }
        public string TiposTrabajoS { get; set; }
        public string Fotos { get; set; }
        public string PresupuestoS { get; set; }

        public string Provincia { get; set; }

        public string Canton { get; set; }

        public string Distrito { get; set; }

        public string OtrasSennas { get; set; }

        public string Latitud { get; set; }

        public string Longitud { get; set; }

        public int NumResultado { get; set; }

        public string NombreEmpresa { get; set; }

        public string IdTrabajador { get; set; }

        public string NombreTrabajador { get; set; }

        public string EmpresaTipoCedula { get; set; }
        public List<ValoracionTrabajador> ValoracionDeTrabajadores { get; set; }


        public string NombreCompletoCliente { get; set; }
        public string Descripcion { get; set; }
        public double HorasTrabajadas { get; set; }
        public int TipoTrabajo { get; set; }


        public SolicitudDeTrabajo()
        {

        }
    }
}
