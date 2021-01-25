using DataAccess.Crud;
using Entities_POJO;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI
{
    public class TerminosCondicionesManager : BaseManager
    {
        public TerminosCondicionesCrudFactory crudTerminosCondiciones;

        public TerminosCondicionesManager()
        {
            crudTerminosCondiciones = new TerminosCondicionesCrudFactory();
        }

            public void Create(TerminosCondiciones terminos)
        {
            try
            {
                /*
                var Id_Especialidad = tipoDeTrabajo.Id_Especialidad;
                if (Id_Especialidad >= 1)
                {

                }
                */
                crudTerminosCondiciones.Create(terminos);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public List<TerminosCondiciones> RetrieveAll()
        {
            return crudTerminosCondiciones.RetrieveAll<TerminosCondiciones>();
        }

        public TerminosCondiciones RetrieveById(TerminosCondiciones terminos)
        {
            TerminosCondiciones c = null;
            try
            {
                c = crudTerminosCondiciones.Retrieve<TerminosCondiciones>(terminos);
                if (c == null)
                {
                    throw new BussinessException(4);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return c;
        }

        public void Update(TerminosCondiciones terminos)
        {
            crudTerminosCondiciones.Update(terminos);
        }

        public void Delete(TerminosCondiciones terminos)
        {
            crudTerminosCondiciones.Delete(terminos);
        }
    }

    
    
}
