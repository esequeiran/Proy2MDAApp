using DataAccess.Crud;
using Entities_POJO;
using Exceptions;
using System;
using System.Collections.Generic;

namespace CoreAPI
{
    public class ClienteManager:BaseManager
    {
        private ClienteCrudFactory crudCliente;

        public ClienteManager() {
            crudCliente = new ClienteCrudFactory();
        }

        public void Create(Cliente cliente) {
            var edad = 2020 - cliente.FechaNacimiento.Year;

            var lstUsuarios = RetrieveById(cliente);

            if (lstUsuarios != null) {
                throw new BussinessException(13);
            } else {
                if (edad >= 18) {
                    crudCliente.Create(cliente);
                } else {
                    throw new BussinessException(1);
                }
            }
        }

        public List<Cliente> RetrieveAll() {
            return crudCliente.RetrieveAll<Cliente>();
        }

        public Cliente RetrieveById(Cliente cliente) {
            return crudCliente.Retrieve<Cliente>(cliente);
        }

        public void Update(Cliente cliente) {
            crudCliente.Update(cliente);
        }

        public void Delete() {
            throw new NotImplementedException();
        }
    }
}
