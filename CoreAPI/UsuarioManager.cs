using DataAccess.Crud;
using Entities_POJO;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI
{
    public class UsuarioManager : BaseManager
    {
        public UsuarioCrudFactory crudUsuario;

        public UsuarioManager()
        {
            crudUsuario = new UsuarioCrudFactory();
        }

        //-----------------------------------------------------------
        public void Create(Usuario usuario)
        {
            crudUsuario.Create(usuario);
        }

        public List<Usuario> RetrieveAll()
        {
            return crudUsuario.RetrieveAll<Usuario>();
        }

        public Usuario RetrieveById(Usuario usuario)
        {
            Usuario c = null;
            try
            {
                c = crudUsuario.Retrieve<Usuario>(usuario);
                if (c == null)
                {
                    throw new BussinessException(4);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return c;
        }

        public void Update(Usuario usuario)
        {
            crudUsuario.Update(usuario);
        }

        public void Delete(Usuario usuario)
        {
            crudUsuario.Delete(usuario);
        }
    }
}
