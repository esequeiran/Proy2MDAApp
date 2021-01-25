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
    //VERSION NUEVA
    public class TipoDeTrabajoManager : BaseManager
    {

        public TipoDeTrabajoCrudFactory crudTipoDeTrabajo;

        public TipoDeTrabajoManager()
        {
            crudTipoDeTrabajo = new TipoDeTrabajoCrudFactory();
        }

        //-----------------------------------------------------------
        public void Create(TipoDeTrabajo tipoDeTrabajo)
        {
            try
            {
                /*
                var Id_Especialidad = tipoDeTrabajo.Id_Especialidad;
                if (Id_Especialidad >= 1)
                {
                    
                }
                */
                crudTipoDeTrabajo.Create(tipoDeTrabajo);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public List<TipoDeTrabajo> RetrieveAll()
        {
            return crudTipoDeTrabajo.RetrieveAll<TipoDeTrabajo>();
        }

        public TipoDeTrabajo RetrieveById(TipoDeTrabajo tipoDeTrabajo)
        {
            TipoDeTrabajo c = null;
            try
            {
                c = crudTipoDeTrabajo.Retrieve<TipoDeTrabajo>(tipoDeTrabajo);
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

        public void Update(TipoDeTrabajo tipoDeTrabajo)
        {
            crudTipoDeTrabajo.Update(tipoDeTrabajo);
        }

        public void Delete(TipoDeTrabajo tipoDeTrabajo)
        {
            crudTipoDeTrabajo.Delete(tipoDeTrabajo);
        }

    }
}
