using System;

namespace Entities_POJO
{
    public class Administrador : BaseEntity
    {
        public string Identificacion
        {
            get; set;
        }
        public string TipoIdentificacion
        {
            get; set;
        }
        public string Nombre
        {
            get; set;
        }
        public string ApellidoUno
        {
            get; set;
        }
        public string ApellidoDos
        {
            get; set;
        }
        public string Correo
        {
            get; set;
        }
        public string Contrasenna
        {
            get; set;
        }
        public DateTime FechaNacimiento
        {
            get; set;
        }
        public string PaisNacimiento
        {
            get; set;
        }
        public string Genero
        {
            get; set;
        }
        public string Telefono
        {
            get; set;
        }
        public int IdEstado
        {
            get; set;
        }
         public string CodigoVerificacion{ get; set; }

        public Administrador()
        {
        }

        public Administrador(string[] infoArray)
        {
            if (infoArray != null && infoArray.Length >= 11)
            {
                Identificacion = infoArray[0];
                TipoIdentificacion = infoArray[1];
                Nombre = infoArray[2];
                ApellidoUno = infoArray[3];
                ApellidoDos = infoArray[4];
                Correo = infoArray[5];
                Contrasenna = infoArray[6];

                var fecha = DateTime.Now;
                if (DateTime.TryParse(infoArray[7], out fecha))
                    FechaNacimiento = fecha;

                PaisNacimiento = infoArray[8];
                Genero = infoArray[9];
                Telefono = infoArray[10];

                IdEstado = 5;
            }
            else
            {
                throw new Exception("Todos los datos son necesarios");
            }
        }
    }
}