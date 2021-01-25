using DataAccess.Crud;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI
{
    public class BitacoraManager : BaseManager
    {
        private BitacoraCrudFactory crudBitacora;

        public BitacoraManager()
        {
            crudBitacora = new BitacoraCrudFactory();
        }

        public void Create(Bitacora bitacora)
        {
            crudBitacora.Create(bitacora);
        }
        public List<Bitacora> RetrieveAll()
        {
            return crudBitacora.RetrieveAll<Bitacora>();
        }
    }
}
