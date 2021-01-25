using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class OferenteFisico : BaseEntity
    {
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Cedula { get; set; }
        public string TipoCedula { get; set; }
        public string Genero { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string PaisNacimiento { get; set; }
        public DateTime FecNacimiento { get; set; }

        //Empresa

        public string NombreComercial { get; set; }
        public string RazonSocial { get; set; }
        public string CedulaJuridica { get; set; }
        public string Descripcion { get; set; }
        public DateTime FecCreacion { get; set; }

        //public string Curriculum { get; set; }
        //public string HojaDelincuencia { get; set; }
        //public string Especialidad { get; set; }
        //public string TipoTrabajo { get; set; }

        //public string Latitud { get; set; }
        //public string Longitud { get; set; }
        //public string Provincia { get; set; }
        //public string Canton { get; set; }
        //public string Distrito { get; set; }
        //public string OtrasSennas { get; set; }



        public OferenteFisico()
        {

        }

        public OferenteFisico(string[] infoArray)
        {
            if (infoArray != null && infoArray.Length >= 15)
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
                var fecCre = DateTime.Now;
                if (DateTime.TryParse(infoArray[15], out fecCre))
                    FecCreacion = fecCre;

                //Latitud = infoArray[9];
                //Longitud = infoArray[10];
                //Provincia = infoArray[11];
                //Canton = infoArray[12];
                //Distrito = infoArray[13];
                //OtrasSennas = infoArray[14];

                //Curriculum = infoArray[16];
                //HojaDelincuencia = infoArray[17];
                //Especialidad = infoArray[18];
                //TipoTrabajo = infoArray[19];


            }
            else
            {
                throw new Exception("Todos los valores son necesarios");
            }
        }


    }
}
