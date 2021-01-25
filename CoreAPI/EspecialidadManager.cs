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
    public class EspecialidadManager : BaseManager
    {
        //VERSION NUEVA
        public EspecialidadCrudFactory crudEspecialidad;

        public EspecialidadManager()
        {
            crudEspecialidad = new EspecialidadCrudFactory();
        }

        //-----------------------------------------------------------
        public void Create(Especialidad especialidad)
        {

            crudEspecialidad.Create(especialidad);
        }

        public List<Especialidad> RetrieveAll()
        {
            return crudEspecialidad.RetrieveAll<Especialidad>();
        }

        public Especialidad RetrieveById(Especialidad especialidad)
        {
            Especialidad c = null;
            try
            {
                c = crudEspecialidad.Retrieve<Especialidad>(especialidad);
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

        public void Update(Especialidad especialidad)
        {
            try
            {
                crudEspecialidad.Update(especialidad);
            }
            catch(Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }     


        }

        public void Delete(Especialidad especialidad)
        {
            crudEspecialidad.Delete(especialidad);
        }

    }
}
