using DataAccess.Crud;
using Entities_POJO;
using System;
using System.Collections.Generic;

namespace CoreAPI
{
    public class FacturaManager:BaseManager
    {
        private FacturaCrudFactory crudFac;

        public FacturaManager() {
            crudFac = new FacturaCrudFactory();
        }

        public List<Factura> RetrieveAllFacDetalle(Factura factura)
        {
            return crudFac.RetrieveAllFacDetalle<Factura>(factura);
        }

        public Factura RetrieveById(Factura factura) {
            return crudFac.Retrieve<Factura>(factura);
        }
    }
}
