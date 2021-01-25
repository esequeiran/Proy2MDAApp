using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Oferente : BaseEntity
    {
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Cedula { get; set; }
        public string TipoCedula { get; set; }
        public string Genero { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public int IdEstado{ get; set; }
        public string PaisNacimiento { get; set; }
        public string CodigoVerificacion{ get; set; }
        public DateTime FecNacimiento { get; set; }

        //Empresa

        public string NombreComercial { get; set; }
        public string RazonSocial { get; set; }
        public string CedulaJuridica { get; set; }
        public string Descripcion { get; set; }
        public string TipoCedulaComercial { get; set; }
        public DateTime FecCreacion { get; set; }
        public string UserEnteredCaptchaCode { get; set; }
        public string CaptchaId { get; set; }

        public double TotalIngresosGenerados { get; set; }

        public Oferente()
        {

        }

        public Oferente(string[] infoArray)
        {
            if (infoArray != null && infoArray.Length >= 18)
            {
                Nombre = infoArray[1];
                Apellido1 = infoArray[2];
                Apellido2 = infoArray[3];

                Cedula = infoArray[4];
                TipoCedula = infoArray[5];
                Genero = infoArray[6];
                Correo = infoArray[7];
                Telefono = infoArray[8];

                PaisNacimiento = infoArray[9];
                var fec = DateTime.Now;
                if (DateTime.TryParse(infoArray[10], out fec))
                    FecNacimiento = fec;


                NombreComercial = infoArray[11];
                RazonSocial = infoArray[12];
                CedulaJuridica = infoArray[13];
                Descripcion = infoArray[14];
                TipoCedulaComercial = infoArray[15];
                var fecCre = DateTime.Now;
                if (DateTime.TryParse(infoArray[16], out fecCre))
                    FecCreacion = fecCre;

                UserEnteredCaptchaCode = infoArray[17];
                CaptchaId = infoArray[18];

            }
            else
            {
                throw new Exception("Todos los valores son necesarios");
            }
        }
    }
}
