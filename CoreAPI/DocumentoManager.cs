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
    public class DocumentoManager
    {

        private DocumentoCrudFactory crudDocumento;

        public DocumentoManager()
        {
            crudDocumento = new DocumentoCrudFactory();
        }

        public void Agregar(Documento documento)
        {
            try
            {
                //      var c = crudFisico.Retrieve<OferenteFisico>(fisico);

                //   if (c == fisico)
                /// {
                //Tipo cambio ya existe
                //  throw new BussinessException(3);
                // }

                crudDocumento.Create(documento);

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public void AgregarFotosPreviasSolicitud(Documento documento)
        {
            try
            {
               

                crudDocumento.CreateFotosPreviasSolicitud(documento);

            }
            catch (Exception ex)
            {                
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public void AgregarFotosFinalesSolicitud(Documento documento)
        {
            try
            {
                crudDocumento.CreateFotosFinalesSolicitud(documento);

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }


    }
}
