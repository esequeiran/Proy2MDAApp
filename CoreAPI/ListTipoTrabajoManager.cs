using DataAccess.Crud;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI
{
    public class ListTipoTrabajoManager : BaseManager
    {
        public TipoDeTrabajoCrudFactory crudTipoTrabajo;

        public ListTipoTrabajoManager()
        {
            crudTipoTrabajo = new TipoDeTrabajoCrudFactory();
        }

        public List<OptionList> RetrieveAll()
        {
            List<TipoDeTrabajo> listTipoTrabajo = new List<TipoDeTrabajo>();

            List<OptionList> dicListOptions = new List<OptionList>();
            try
            {
                listTipoTrabajo = crudTipoTrabajo.RetrieveAll<TipoDeTrabajo>();
            }
            catch (Exception e)
            {


            }

            //var lst = new
            //List<OptionList>();

            if (listTipoTrabajo.Count > 0)
            {
                //var objs = mapper.BuildObjects(listEspecialidad);
                foreach (var c in listTipoTrabajo)
                {
                    if (c.Nombre_Estado.Equals("Activo"))
                    {
                        var option = new OptionList
                        {
                            ListId = c.Id_Number,
                            Value = c.Id_TipoTrabajo.ToString(),
                            Description = c.Nombre_TipoTrabajo
                        };
                        //cambios para mostrar unicamente las especialidades activas o en id_estado = 5

                        dicListOptions.Add(option);
                    }
                }
            }
            return dicListOptions;
        }

    }
}
