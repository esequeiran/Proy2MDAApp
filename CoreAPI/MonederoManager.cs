using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Crud;
using Exceptions;

namespace CoreAPI
{
    public class MonederoManager : BaseManager
    {

        private MonederoCrudFactory crudMonedero;

        public MonederoManager()
        {
            crudMonedero = new MonederoCrudFactory();
        }

        public void RecargarMonedero(string cedula, double monto)
        {
            try
            {
                crudMonedero.RecargarMonedero(cedula,monto);

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }
        public void RetiroMonedero(string cedula, double monto)
        {
            try
            {
                crudMonedero.RetiroMonedero(cedula,monto);

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public string RetriveSaldo(string cedula)
        {
            try
            {
               return crudMonedero.RetrieveSaldo(cedula);

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return ex.Message;
            }
            
        }




    }
}
