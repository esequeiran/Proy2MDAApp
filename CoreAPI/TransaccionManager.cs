using DataAccess.Crud;
using Entities_POJO;
using System.Collections.Generic;
namespace CoreAPI
{
    public class TransaccionManager:BaseManager
    {
        private TransaccionCrudFactory crudTransaccion;

        public TransaccionManager() {
            crudTransaccion = new TransaccionCrudFactory();
        }

        public List<Transaccion> RetrieveAllIngresosApp(Transaccion transaccion) { 
            return crudTransaccion.RetrieveIngresos<Transaccion>(transaccion);
        }

        public List<Transaccion> RetrieveAllTransactions(Transaccion transaccion) {
            return crudTransaccion.RetriveAllTransactions<Transaccion>(transaccion);
        }

        public List<Transaccion> RetrieveAllIngresosOferente(Transaccion transaccion)
        {
            return crudTransaccion.RetriveIngresosOferente<Transaccion>(transaccion);
        }
    }
}
