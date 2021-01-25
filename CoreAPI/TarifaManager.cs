using DataAccess.Crud;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI
{
    public class TarifaManager : BaseManager
    {
        private TarifaCrudFactory crudTarifa;
        public TarifaManager()
        {
            crudTarifa = new TarifaCrudFactory();
        }

        public List<Tarifa> RetrieveAll()
        {
            return crudTarifa.RetrieveAll<Tarifa>();
        }
        public void Update(Tarifa ptarifa)
        {
            crudTarifa.Update(ptarifa);
        }
    }
}
