using DataAccess.Crud;
using Entities_POJO;
using Exceptions;
using System;

namespace CoreAPI
{
    public class IvaManager
    {
        private IvaCrudFactory crudIva;

        public IvaManager()
        {
            crudIva = new IvaCrudFactory();
        }

        public Iva Retrieve()
        {
            Iva i = null;
            try
            {
                i = crudIva.Retrieve();
                if (i == null)
                {
                    throw new BussinessException(12);
                }
                else
                {
                    return crudIva.Retrieve();
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
            return i;
        }

        public void Update(Iva iva)
        {
            try
            {
                crudIva.Update(iva);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }
    }
}