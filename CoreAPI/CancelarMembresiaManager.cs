using DataAccess.Crud;
using Entities_POJO;
using Exceptions;
using System;

namespace CoreAPI
{
    public class CancelarMembresiaManager : BaseManager
    {
        private CancelarMembresiaCrudFactory crud;
        public CancelarMembresiaManager()
        {
            crud = new CancelarMembresiaCrudFactory();
        }

        public void CancelarMembresia(CancelarMembresia obj)
        {
            try
            {
                crud.Update(obj);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }
    }
}
