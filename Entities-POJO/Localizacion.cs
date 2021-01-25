using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Localizacion : BaseEntity
    {
        public int IdLocalizacion { get; set; }
        public string Provincia { get; set; }
        public string Canton { get; set; }
        public string Distrito { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public string OtrasSennas { get; set; }
        public string IdUsuario { get; set; }
        public string Nombre { get; set; }

        public Localizacion()
        {
        }

        public Localizacion(string[] infoArray)
        {
            if (infoArray != null && infoArray.Length >= 8)
            {
                Provincia = infoArray[0];
                Canton = infoArray[1];
                Distrito = infoArray[2];
                Latitud = infoArray[3];
                Longitud = infoArray[4];
                OtrasSennas = infoArray[5];
                IdUsuario = infoArray[6];
                Nombre = infoArray[7];
            }
            else
            {
                throw new Exception("Todos los datos son necesarios");
            }
        }
    }
}