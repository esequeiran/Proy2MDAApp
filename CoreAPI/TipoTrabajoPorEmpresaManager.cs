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
    public class TipoTrabajoPorEmpresaManager
    {
        //VERSION NUEVA
        public TipoTrabajoPorEmpresaCrudFactory crudTipoTrabajoPorEmpresa;

        public TipoTrabajoPorEmpresaManager()
        {
            crudTipoTrabajoPorEmpresa = new TipoTrabajoPorEmpresaCrudFactory();
        }
        
        //-----------------------------------------------------------
        public void Create(TipoTrabajoPorEmpresa tipoTrabajoPorEmpresa)
        {

            crudTipoTrabajoPorEmpresa.Create(tipoTrabajoPorEmpresa);
        }

        public List<TipoTrabajoPorEmpresa> RetrieveAll()
        {
            return crudTipoTrabajoPorEmpresa.RetrieveAll<TipoTrabajoPorEmpresa>();
        }

        //Fixed
        public List<TipoTrabajoPorEmpresa> RetrieveAll2(TipoTrabajoPorEmpresa cedula)
        {                      
            try
            {
                return crudTipoTrabajoPorEmpresa.RetrieveAll2<TipoTrabajoPorEmpresa>(cedula);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
            
        }

        public TipoTrabajoPorEmpresa RetrieveById(TipoTrabajoPorEmpresa tipoTrabajoPorEmpresa)
        {
            TipoTrabajoPorEmpresa c = null;
            try
            {
                c = crudTipoTrabajoPorEmpresa.Retrieve<TipoTrabajoPorEmpresa>(tipoTrabajoPorEmpresa);
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

        public void Update(TipoTrabajoPorEmpresa tipoTrabajoPorEmpresa)
        {
            try
            {
                crudTipoTrabajoPorEmpresa.Update(tipoTrabajoPorEmpresa);
            }catch(Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
            
        }

        public void Delete(TipoTrabajoPorEmpresa tipoTrabajoPorEmpresa)
        {
            crudTipoTrabajoPorEmpresa.Delete(tipoTrabajoPorEmpresa);
        }
     
    }
}
