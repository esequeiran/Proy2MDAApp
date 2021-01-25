using Entities_POJO;
using DataAccess.Crud;
using System;
using System.Collections.Generic;
using Exceptions;

namespace CoreAPI
{
    public class LocalizacionManager
    {
        private LocalizacionCrudFactory crudLocalizacion;

        public LocalizacionManager()
        {
            crudLocalizacion = new LocalizacionCrudFactory();
        }

        public void Create(Localizacion localizacion)
        {
            crudLocalizacion.Create(localizacion);
        }

        public List<Localizacion> RetrieveAll(Localizacion localizacion)
        {
            return crudLocalizacion.RetrieveAllByUser<Localizacion>(localizacion);
        }

        public Localizacion RetrieveById(Localizacion localizacion)
        {
            Localizacion l = null;
            try
            {
                l = crudLocalizacion.Retrieve<Localizacion>(localizacion);
                if (l == null)
                {
                    throw new BussinessException(12);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return l;
        }

        public void Update(Localizacion localizacion)
        {
            crudLocalizacion.Update(localizacion);
        }

        public void Delete(Localizacion localizacion)
        {
            crudLocalizacion.Delete(localizacion);
        }
    }
}