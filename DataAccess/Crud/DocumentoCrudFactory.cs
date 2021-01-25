using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Dao;
using DataAccess.Mapper;
using Entities_POJO;

namespace DataAccess.Crud
{
     public class DocumentoCrudFactory:CrudFactory
    {
        DocumentoMapper mapper;

        public DocumentoCrudFactory() : base()
        {
            mapper = new DocumentoMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {

            var docuemnto = (Documento)entity;
            var sqlOperation = mapper.GetCreateStatement(docuemnto);
            dao.ExecuteProcedure(sqlOperation);
        }

          public void CreateFotosPreviasSolicitud(BaseEntity entity)
        {
            var docuemnto = (Documento)entity;
            var sqlOperation = mapper.GetCreateStatementFotosPreviasSolicitud(docuemnto);
            dao.ExecuteProcedure(sqlOperation);
        }

        public void CreateFotosFinalesSolicitud(BaseEntity entity)
        {
            var docuemnto = (Documento)entity;
            var sqlOperation = mapper.GetCreateStatementFotosFinalesSolicitud(docuemnto);
            dao.ExecuteProcedure(sqlOperation);
        }


        public override void Delete(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public override T Retrieve<T>(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public override List<T> RetrieveAll<T>()
        {
            throw new NotImplementedException();
        }

        public override void Update(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

    }
}
