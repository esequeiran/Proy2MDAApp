using DataAccess.Dao;
using DataAccess.Mapper;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Crud
{
    public class OfertaASolicitudCrudFactory : CrudFactory
    {
        OfertaASolicitudDeTrabajoMapper mapper;
        public OfertaASolicitudCrudFactory() {

            mapper = new OfertaASolicitudDeTrabajoMapper();
            dao = SqlDao.GetInstance();
        }
        public override void Create(BaseEntity entity)
        {
            var oferta = (OfertaASolicitudDeTrabajo)entity;
            var sqlOperation = mapper.GetCreateStatement(oferta);
            dao.ExecuteProcedure(sqlOperation);
        }

        public int CreateRetorno(BaseEntity entity)
        {

            var oferta = (OfertaASolicitudDeTrabajo)entity;
            var sqlOperation = mapper.GetCreateStatement(oferta);

            var resultado = dao.ExecuteQueryProcedure(sqlOperation);
            if (resultado.Count > 0)
            {
                return 18;
            }

            return 0;

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

        public List<OfertaASolicitudDeTrabajo> RetrieveAllOfertasParaSolicitudParaCliente<T>(BaseEntity entity)
        {

            var lstOf = new List<OfertaASolicitudDeTrabajo>();
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllOfertasPorSolicitudParaCliente(entity));
            var dicAuxiliar = new Dictionary<int, OfertaASolicitudDeTrabajo>();

            var dic = new Dictionary<string, object>();

            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjectsOfertasASolicitudCliente(lstResult);

                foreach (OfertaASolicitudDeTrabajo c in objs)
                {

                    if (dicAuxiliar.ContainsKey(c.IdOferta))
                    {
                        dicAuxiliar[c.IdOferta].TiposDeTrabajo.Add(c.TiposDeTrabajo[0]);
                    }
                    else {
                        dicAuxiliar.Add(c.IdOferta, c);
                    }                  

                }

            }

            lstOf = dicAuxiliar.Values.ToList();

            return lstOf;
        }
      
           
        

        
        public override void Update(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
