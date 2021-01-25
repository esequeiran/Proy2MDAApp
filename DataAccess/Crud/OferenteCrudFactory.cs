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
    public class OferenteCrudFactory : CrudFactory
    {

        OferenteMapper mapper;
        SolicitudRegistroMapper solicitudMapper;


        public OferenteCrudFactory() : base()
        {
            mapper = new OferenteMapper();
            solicitudMapper = new SolicitudRegistroMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {

            var oferente = (Oferente)entity;
            var sqlOperation = mapper.GetCreateStatement(oferente);
            dao.ExecuteProcedure(sqlOperation);
        }
        public int RegistrarContrassena(string cedula, string contrasenna)
        {

            var sqlOperation = mapper.GetCrearContrasenna(cedula, contrasenna);
            var respuesta = dao.ExecuteQueryProcedure(sqlOperation);

            if (respuesta.Count > 0)
            {
                return -1;
            }
            return 15;
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
            var lstOferente = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
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

        public override void Update(BaseEntity entity)
        {
            var oferente = (Oferente)entity;
            dao.ExecuteProcedure(mapper.GetUpdateStatement(oferente));
        }   
        
        public  void ModificarOferente(BaseEntity entity)
        {

            var oferente = (Oferente)entity;
            dao.ExecuteProcedure(mapper.GetModificarOferente(oferente));
        }


        public RespuestaCod VerificarCodigo(string cedula,string codigoVerificacion)
        {

            
            var sqlOperation = mapper.GetVerificacion(cedula,codigoVerificacion);
            var respuesta = dao.ExecuteQueryProcedure(sqlOperation);

            var respuestaCod = new RespuestaCod();


            respuestaCod.Resultado = respuesta.ElementAt(0).Values.ElementAt(0).Equals(1);
            return respuestaCod;

        }

        public SolicitudRegistro RetrieveSolicitud(string idUsuario)
        {
            var solicitud = new SolicitudRegistro();
            var sqlOperation = solicitudMapper.GetRetriveStatement(idUsuario);
            var lstResult = dao.ExecuteQueryProcedure(sqlOperation);

            if (lstResult.Count > 0)
            {

                solicitud = (SolicitudRegistro)solicitudMapper.BuildObject(lstResult);
            }

            return solicitud;
        }


        public  List<T> RetrieveAllTopTenMasIngresos<T>() {
            var lstOferente = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveMasIngresosTopTenStatement());
            var dic = new Dictionary<string , object>();
            if (lstResult.Count > 0) {
                var objs = mapper.BuildObjectsIngresos(lstResult);
                foreach (var c in objs) {
                    lstOferente.Add((T)Convert.ChangeType(c , typeof(T)));
                }
            }
            return lstOferente;
        }
    }
}
