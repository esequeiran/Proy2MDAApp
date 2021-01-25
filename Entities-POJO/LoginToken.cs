using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class LoginToken : BaseEntity
    {
        public string Correo { get; set; }
        public string Contrasenna { get; set; }
        public string IdUsuario { get; set; }
        public string Nombre { get; set; }
        public Dictionary<int, string> DiccionarioRoles { get; set; }
        public int IdEstado { get; set; }
        public string ContrasennaActual { get; set; }
        public int NumeroResultado { get; set; }

        public LoginToken()
        {

        }

    }
}
