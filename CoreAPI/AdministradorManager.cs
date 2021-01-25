using DataAccess.Crud;
using Entities_POJO;
using Exceptions;
using System.Collections.Generic;

namespace CoreAPI
{
    public class AdministradorManager : BaseManager
    {
        private AdministradorCrudFactory crudAdministrador;

        public AdministradorManager()
        {
            crudAdministrador = new AdministradorCrudFactory();
        }

        public void Create(Administrador administrador)
        {
            var edad = 2020 -administrador.FechaNacimiento.Year;

            var lstUsuarios = RetrieveById(administrador);

            if (lstUsuarios != null) {
                throw new BussinessException(13);
            } else {
                if (edad >= 18) {
                    crudAdministrador.Create(administrador);
                } else {
                    throw new BussinessException(17);
                }
            }
        }

        public List<Administrador> RetrieveAll()
        {
            return crudAdministrador.RetrieveAll<Administrador>();
        }

        public Administrador RetrieveById(Administrador administrador)
        {
            return crudAdministrador.Retrieve<Administrador>(administrador);
        }

        public void Update(Administrador administrador)
        {
            crudAdministrador.Update(administrador);
        }

        public void Delete(Administrador administrador)
        {
            crudAdministrador.Delete(administrador);
        }
    }
}