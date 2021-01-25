using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Trabajador : BaseEntity
    {
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Cedula { get; set; }
        public DateTime FecNacimiento { get; set; }
        public string IdEmpresa { get; set; }
        public string Genero { get; set; }
        public string Correo { get; set; }
        public string UserEnteredCaptchaCode { get; set; }
        public string CaptchaId { get; set; }
        public string IdEstado { get; set; }
        public int IdSolicitud { get; set; }

        public Trabajador()
        {

        }

        public Trabajador(string nombre, string apellido1,string apellido2,string cedula,DateTime fecNacimiento,string idEmpresa,string genero,string correo,
            string userEnteredCaptchaCode, string captchaId,string idEstado)
        {
            Nombre = nombre;
            Apellido1 = apellido1;
            Apellido2 = apellido2;
            Cedula = cedula;
            FecNacimiento = fecNacimiento;
            IdEmpresa = idEmpresa;
            Genero = genero;
            Correo = correo;
            UserEnteredCaptchaCode = userEnteredCaptchaCode;
            CaptchaId = captchaId;
            IdEstado = idEstado;
        }


        public Trabajador(string cedula,int idSolicitud)
        {
            Cedula = cedula;
            IdSolicitud = idSolicitud;

        }


    }
}

