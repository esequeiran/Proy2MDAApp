using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Usuario : BaseEntity
    {
        public string Cedula { get; set; }
        public string TipoCedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Correo { get; set; }
        public DateTime? FecNacimiento { get; set; }
        public string PaisNacimiento { get; set; }
        public string Genero { get; set; }
        public string Telefono { get; set; }
        public string Nombre_Rol { get; set; }
        public int Id_estado { get; set; }

        public Usuario()
        {

        }
    }



}
