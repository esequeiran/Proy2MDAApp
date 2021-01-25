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
    public class TrabajadorCrudFactory:CrudFactory
    {
        TrabajadorMapper mapper;
        public TrabajadorCrudFactory() : base()
        {
            mapper = new TrabajadorMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
             
            var trabajador = (Trabajador)entity;
            var sqlOperation = mapper.GetCreateStatement(trabajador);
            dao.ExecuteProcedure(sqlOperation);
        }
        //public int RegistrarContrassena(string cedula, string contrasenna)
        //{

        //    var sqlOperation = mapper.GetCrearContrasenna(cedula, contrasenna);
        //    var respuesta = dao.ExecuteQueryProcedure(sqlOperation);

        //    if (respuesta.Count > 0)
        //    {
        //        return -1;
        //    }
        //    return 15;
        //}
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
            var lstOferente = new List<T>();

            //var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
            //var dic = new Dictionary<string, object>();
            //if (lstResult.Count > 0)
            //{
            //    var objs = mapper.BuildObjects(lstResult);
            //    foreach (var c in objs)
            //    {
            //        lstOferente.Add((T)Convert.ChangeType(c, typeof(T)));
            //    }
            //}
            return lstOferente;
        }     
        public List<T> RetrieveTrabajadores<T>(string idEmpresa)
        {
            var lstOferente = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllTrabajadores(idEmpresa));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstOferente.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }
            return lstOferente;
        }    
        public List<T> RetrieveTrabajadoresDisponibles<T>(string idEmpresa)
        {
            var lstOferente = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllTrabajadoresDisponibles(idEmpresa));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjectsDisponibles(lstResult);
                foreach (var c in objs)
                {
                    lstOferente.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }
            return lstOferente;
        }     
        public List<T> RetrieveTrabajadoresAsignados<T>(string idSolicitud)
        {
            var lstOferente = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllTrabajadoresAsignados(idSolicitud));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjectsDisponibles(lstResult);
                foreach (var c in objs)
                {
                    lstOferente.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }
            return lstOferente;
        }

        public override void Update(BaseEntity entity)
        {
            var trabajador = (Trabajador)entity;
            dao.ExecuteProcedure(mapper.GetUpdateStatement(trabajador));
        }
        
        public void CambioEstado(BaseEntity entity)
        {
            var trabajador = (Trabajador)entity;
            dao.ExecuteProcedure(mapper.GetCambioEstadoStatement(trabajador));
        }
        public void AsignarTrabajador(BaseEntity entity)
        {
            var trabajador = (Trabajador)entity;
            dao.ExecuteProcedure(mapper.GetAsignarTrabajadorStatement(trabajador));
            
        }      
        public void EliminarTrabajador(BaseEntity entity)
        {
            var trabajador = (Trabajador)entity;
            dao.ExecuteProcedure(mapper.GetEliminarTrabajadorStatement(trabajador));
            
        }






        //public List<T> RetrieveAllTopTenMasIngresos<T>()
        //{
        //    var lstOferente = new List<T>();

        //    var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveMasIngresosTopTenStatement());
        //    var dic = new Dictionary<string, object>();
        //    if (lstResult.Count > 0)
        //    {
        //        var objs = mapper.BuildObjectsIngresos(lstResult);
        //        foreach (var c in objs)
        //        {
        //            lstOferente.Add((T)Convert.ChangeType(c, typeof(T)));
        //        }
        //    }
        //    return lstOferente;
        //}
    }
}
