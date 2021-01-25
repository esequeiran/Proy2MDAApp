using DataAccess.Crud;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI
{
    public class ListManager : BaseManager
    {
        //VERSION NUEVA
        public EspecialidadCrudFactory crudEspecialidad;
        public TipoDeTrabajoCrudFactory crudTipoTrabajo;
        public LocalizacionCrudFactory crudLocalizacion;

        public ListManager()
        {
            crudEspecialidad = new EspecialidadCrudFactory();
            crudTipoTrabajo = new TipoDeTrabajoCrudFactory();
            crudLocalizacion = new LocalizacionCrudFactory();

        }

        public List<OptionList> RetrieveAll()
        {
            List<Especialidad> listEspecialidad = new List<Especialidad>();

            List<OptionList> dicListOptions = new List<OptionList>();
            try
            {
                listEspecialidad = crudEspecialidad.RetrieveAll<Especialidad>();
            }
            catch (Exception e)
            {


            }

            //var lst = new
            //List<OptionList>();

            if (listEspecialidad.Count > 0)
            {
                //var objs = mapper.BuildObjects(listEspecialidad);
                foreach (var c in listEspecialidad)
                {
                    if(c.Nombre_Estado.Equals("Activo"))
                    {
                        var option = new OptionList
                        {
                            ListId = c.Id_Number,
                            Value = c.Id_Number,
                            Description = c.Nombre_Especialidad
                        };
                        //cambios para mostrar unicamente las especialidades activas o en id_estado = 5

                        dicListOptions.Add(option);

                    }
                  
                    
                    
                }
            }
            return dicListOptions;
        }

        public List<OptionList> RetrieveAllTipoTrabajo()
        {
            List<TipoDeTrabajo> listTipoT = new List<TipoDeTrabajo>();

            List<OptionList> dicListOptions = new List<OptionList>();
            try
            {
                listTipoT = crudTipoTrabajo.RetrieveAll<TipoDeTrabajo>();
            }
            catch (Exception e)
            {


            }

            //var lst = new
            //List<OptionList>();

            if (listTipoT.Count > 0)
            {
                //var objs = mapper.BuildObjects(listEspecialidad);
                foreach (var t in listTipoT)
                {
                    if (t.Nombre_Estado.Equals("Activo"))
                    {
                        var option = new OptionList
                        {
                            ListId = t.Id_TipoTrabajo.ToString(),
                            Value = t.Id_TipoTrabajo.ToString(),
                            Description = t.Nombre_TipoTrabajo
                        };
                        //cambios para mostrar unicamente las especialidades activas o en id_estado = 5

                        dicListOptions.Add(option);

                    }



                }
            }
            return dicListOptions;
        }


        public List<OptionList> RetrieveAllLocalizacionesCliente(BaseEntity entity)
        {
            List<Localizacion> listLoca = new List<Localizacion>();

            List<OptionList> dicListOptions = new List<OptionList>();
            try
            {
                listLoca = crudLocalizacion.RetrieveAllByUser<Localizacion>(entity);
            }
            catch (Exception e)
            {


            }

            //var lst = new
            //List<OptionList>();

            if (listLoca.Count > 0)
            {
                //var objs = mapper.BuildObjects(listEspecialidad);
                foreach (var l in listLoca)
                {                    
                        var option = new OptionList
                        {
                            ListId = l.IdLocalizacion.ToString(),
                            Value = l.IdLocalizacion.ToString(),
                            Description = l.Nombre
                        };             

                        dicListOptions.Add(option);
                }
            }
            return dicListOptions;
        }

        /*
        //Ejemplo del profe
        public List<OptionList> RetrieveById(OptionList option)
        {

            try
            {
                if (dicListOptions.ContainsKey(option.ListId))
                {
                    return dicListOptions[option.ListId];
                }
                else
                {
                    //    //BUSCA EN OTRO MANAGER
                    if (option.ListId.Equals("LST_CUSTOMER"))
                    {
                        var crudCustomer = new CustomerCrudFactory();
                        var lst = crudCustomer.RetrieveAll<Customer>();

                        var lstResult = new List<OptionList>();

                        foreach (var c in lst)
                        {
                            var newOption = new OptionList { ListId = option.ListId, Value = c.Id, Description = c.Name + " " + c.LastName };
                            lstResult.Add(newOption);
                        }
                        return lstResult;

                    }
                    //    //retrieve de monedas
                    //    //foreach creo los list option, con cada pojo de moneda

                }

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return new List<OptionList>(); ;
        }
        */


    }
}
