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
   public class OferenteFisicoManager
    {
        private OferenteFisicoCrudFactory crudFisico;

        public OferenteFisicoManager()
        {
            crudFisico = new OferenteFisicoCrudFactory();
        }

        public void Agregar(OferenteFisico fisico)
        {
            try
            {
                //      var c = crudFisico.Retrieve<OferenteFisico>(fisico);

                //   if (c == fisico)
                /// {
                //Tipo cambio ya existe
                //  throw new BussinessException(3);
                // }

                crudFisico.Create(fisico);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ExceptionManager.GetInstance().Process(ex);
            }
        }


    }
}
