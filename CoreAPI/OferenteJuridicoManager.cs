using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Crud;
using Entities_POJO;
using Exceptions;

namespace CoreAPI
{
   public class OferenteJuridicoManager
    {
        private OferenteJuridicoCrudFactory crudJuridico;

        public OferenteJuridicoManager()
        {
            crudJuridico = new OferenteJuridicoCrudFactory();
        }

        public void Agregar(OferenteJuridico juridico)
        {
            try
            {
                //      var c = crudFisico.Retrieve<OferenteFisico>(fisico);

                //   if (c == fisico)
                /// {
                //Tipo cambio ya existe
                //  throw new BussinessException(3);
                // }

                crudJuridico.Create(juridico);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ExceptionManager.GetInstance().Process(ex);
            }
        }

    }
}
