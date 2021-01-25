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
    public class MembresiaManager : BaseManager
    {
        private MembresiaCrudFactory crudMembresia;
        public MembresiaManager()
        {
            crudMembresia = new MembresiaCrudFactory();
        }

        public void Create(Membresia membresiaObj)
        {
            try
            {
                crudMembresia.Create(membresiaObj);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);

            }
        }

        public List<Membresia> RetrieveAll()
        {
            return crudMembresia.RetrieveAll<Membresia>();
        }

        public List<Membresia> RetriveAllByEmpresa(Membresia membresiaObj)
        {
            var list = new List<Membresia>();
            try
            {
                list = crudMembresia.RetriveAllStatementByEmpresa<Membresia>(membresiaObj);
                if (list.Count == 0 || list == null)
                {
                    throw new BussinessException(12);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
            return list;
        }

        public List<Membresia> RetriveAllByEmpresaSinExcepcion(Membresia membresiaObj)
        {
            var list = new List<Membresia>();
            try
            {
                list = crudMembresia.RetriveAllStatementByEmpresa<Membresia>(membresiaObj);
                
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
            return list;
        }

        public void Update(Membresia membresiaObj)
        {
            try
            {

                if (membresiaObj.Estado == "No Adquirida")
                {
                    crudMembresia.Update(membresiaObj);
                }
                else
                {
                    throw new BussinessException(3);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }


        public void Delete(Membresia membresiaObj)
        {
            try
            {
                if (membresiaObj.Estado == "No Adquirida")
                {
                    crudMembresia.Delete(membresiaObj);
                }
                else
                {
                    throw new BussinessException(4);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public void AdquirirMembresia(Membresia membresia)
        {
            try
            {
                crudMembresia.CompraMembresia(membresia);

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }
    }
}
