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
    public class SolicitudDeTrabajoCrudFactory : CrudFactory
    {
        SolicitudDeTrabajoMapper mapper;

        public SolicitudDeTrabajoCrudFactory()
        {
            mapper = new SolicitudDeTrabajoMapper();
            dao = SqlDao.GetInstance();
        }
        public override void Create(BaseEntity entity)
        {
            var solicitudT = (SolicitudDeTrabajo)entity;
            var sqlOperation = mapper.GetCreateStatement(solicitudT);
            dao.ExecuteProcedure(sqlOperation);
        }

        public void CreateTipoTrabajoPorSolicitud(BaseEntity entity, int idSolicitud)
        {
            var tipoTrabajo = (TipoDeTrabajo)entity;
            var sqlOperation = mapper.GetCreateStatementTipoTrabajoSolicitud(tipoTrabajo, idSolicitud);
            dao.ExecuteProcedure(sqlOperation);
        }


        public void CreateEvaluacionTrabajo(BaseEntity entity)
        {
            var solicitud = (SolicitudDeTrabajo)entity;
            var sqlOperation = mapper.GetCreateStatementEvaluacionTrabajo(solicitud);
            dao.ExecuteProcedure(sqlOperation);
        }

        public void CreateEvaluacionTrabajador(BaseEntity entity)
        {
            var valTrabajador = (ValoracionTrabajador)entity;
            var sqlOperation = mapper.GetCreateStatementEvaluacionTrabajador(valTrabajador);
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

        public T RetrieveSolicitudRecienCreada<T>(BaseEntity entity)
        {
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveSolicitudRecienCreadaStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = mapper.BuildObjectSolicitudRecienCreada(dic);
                return (T)Convert.ChangeType(objs, typeof(T));
            }

            return default(T);
            
        }

        public T RetrieveSolicitudIngresadaPorIdParaOferente<T>(BaseEntity entity)
        {
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveSolicitudIngresadaPorIdParaOferente(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = mapper.BuildObjectSolicitudIngresadaPorIdParaOferente(dic);
                return (T)Convert.ChangeType(objs, typeof(T));
            }
            return default(T);
        }
        


        public T RetrieveOrdenTrabajo<T>(BaseEntity entity)
        {
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetUpdateStatementSolicitudAndCreateOrdenTrabajo(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = mapper.BuildObjectOrdenTrabajo(dic);
                return (T)Convert.ChangeType(objs, typeof(T));
            }

            return default(T);

        }

        public List<T> RetrieveSolicitudesIngresadaParaOferente<T>(BaseEntity entity)
        {
            var lstSol = new List<T>();
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatementPorOferenteIngresadas(entity));                 
                   
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjectsSolIngresadasOferente(lstResult);
                foreach (var c in objs)
                {
                    lstSol.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }
            return lstSol;

        }


        public List<SolicitudDeTrabajo> RetrieveSolicitudesPendientesEvaluacion<T>(BaseEntity entity)
        {
            var lstSol = new List<SolicitudDeTrabajo>();
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetrieveSolicitudesPendientesEvaluacion(entity));
            var dicAuxiliar = new Dictionary<int, SolicitudDeTrabajo>();
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjectsSolPendientesEvaluacion(lstResult);

                foreach (var c in objs)
                {

                    if (dicAuxiliar.ContainsKey(c.IdSolicitud))
                    {
                        dicAuxiliar[c.IdSolicitud].ValoracionDeTrabajadores.Add(c.ValoracionDeTrabajadores[0]);
                    }
                    else
                    {
                        dicAuxiliar.Add(c.IdSolicitud, c);
                    }

                   
                }
            }

            lstSol = dicAuxiliar.Values.ToList();

            return lstSol;            

        }


        public List<T> RetrieveSolicitudesIngresadaParaClienteParaAceptarOferta<T>(BaseEntity entity)
        {
            var lstSol = new List<T>();
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatementPorClienteParaAceptarOferta(entity));

            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjectsSolIngresadasParaClienteParaAceptarOferta(lstResult);
                foreach (var c in objs)
                {
                    lstSol.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }
            return lstSol;

        }



        public T RetrieveLocalizacionRecienCreada<T>(BaseEntity entity)
        {

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveLocalizacionRecienCreadaStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = mapper.BuildObjectLocalizacion(dic);
                return (T)Convert.ChangeType(objs, typeof(T));
            }

            return default(T);
        }


        public T UpdateEscanearCodigoQR<T>(BaseEntity entity)
        {

            var resultado = dao.ExecuteQueryProcedure(mapper.GetEscaneoStatement(entity));
            var dic = new Dictionary<string, object>();
            if (resultado.Count > 0)
            {
                dic = resultado[0];
                var objs = mapper.BuildObjectResultadoEscaneo(dic);
                return (T)Convert.ChangeType(objs, typeof(T));
            }

            return default(T);
        }


        public List<T> RetrieveSolicitudesPendientesParaOferente<T>(BaseEntity entity)
        {
            var lstSol = new List<T>();
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatementPorOferentePendientes(entity));

            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjectsSolIngresadasOferente(lstResult);
                foreach (var c in objs)
                {
                    lstSol.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }
            return lstSol;

        }

        public T RetrieveSolicitudPendientePorIdParaOferente<T>(BaseEntity entity)
        {
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveSolicitudIngresadaPorIdParaOferentePendiente(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = mapper.BuildObjectSolicitudIngresadaPorIdParaOferente(dic);
                return (T)Convert.ChangeType(objs, typeof(T));
            }
            return default(T);
        }

        public override List<T> RetrieveAll<T>()
        {
            throw new NotImplementedException();
        }
        
        public List<T> RetrieveAllTrabajosPendientesHoras<T>(BaseEntity entity)
        {
            var lstSolicitud = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllTrabajosPendienteHorasStatement(entity));
            var dic = new Dictionary<string , object>();
            if (lstResult.Count > 0) {
                var objs = mapper.BuildObjectTrabajosPendientesHoras(lstResult);
                foreach (var c in objs) {
                    lstSolicitud.Add((T)Convert.ChangeType(c , typeof(T)));
                }
            }
            return lstSolicitud;
        }

        public override void Update(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

    }
}
