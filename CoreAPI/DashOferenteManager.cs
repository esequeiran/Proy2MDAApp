using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Crud;
using Entities_POJO;

namespace CoreAPI
{
    public class DashOferenteManager
    {
        private DashOferenteCrudFactory crudDashOferente;

        public DashOferenteManager()
        {
            crudDashOferente = new DashOferenteCrudFactory();
        }
        public List<DashOferente> RetrieveAllTrabajos(string idEmpresa)
        {
            return crudDashOferente.RetrieveTrabajos<DashOferente>(idEmpresa);
        }
        public List<Trabajador> RetrieveAllTrabajadores(string idEmpresa)
        {
            return crudDashOferente.RetrieveTrabajadores<Trabajador>(idEmpresa);
        }

    }
}
