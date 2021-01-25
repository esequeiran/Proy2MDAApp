using System;
namespace Entities_POJO
{
    public class EstadosUsuario : BaseEntity
    {
        public int Id { get; set; }
        public string Valor { get; set; }
        public int diasSuspendido { get; set; }
        public EstadosUsuario() { }
        public EstadosUsuario(string[] infoArray)
        {
            if (infoArray != null && infoArray.Length >= 3)
            {
                var id = 0;
                if (Int32.TryParse(infoArray[0], out id))
                    Id = id;
                else
                    throw new Exception("id must be a number");

                Valor = infoArray[1];

                var dSusp = 0;
                if (Int32.TryParse(infoArray[2], out dSusp))
                    diasSuspendido = dSusp;
                else
                    throw new Exception("diasSuspendido must be a number");

            }
            else
            {
                throw new Exception("All values are require[Id,Valor,diasSuspendido]");
            }

        }
    }
}
