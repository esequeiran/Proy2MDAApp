using DataAccess.Crud;
using Entities_POJO;
using Exceptions;
using System;
using System.Collections.Generic;

namespace CoreAPI
{
    public class LoginTokenManager : BaseManager
    {

        private LoginTokenCrudFactory crudLoginToken;
        public LoginTokenManager()
        {
            crudLoginToken = new LoginTokenCrudFactory();
        }

        public LoginToken RetrieveById(LoginToken pCredenciales)
        {
            var token = new LoginToken();
            try
            {
                token = crudLoginToken.RetrieveExisteCorreo<LoginToken>(pCredenciales);

                if (token == null)
                {
                    throw new BussinessException(7);
                }
                else
                {
                    token = crudLoginToken.RetrieveValidarIntentoContrasenna<LoginToken>(pCredenciales);
                    if (token.NumeroResultado == 1)
                    {
                        token = crudLoginToken.Retrieve<LoginToken>(pCredenciales);
                        if (token == null)
                        {
                            token = crudLoginToken.UpadateIntentoContrasenna<LoginToken>(pCredenciales);
                            if (token.NumeroResultado == 1)
                            {
                                throw new BussinessException(7);
                            }
                            else
                            {
                                throw new BussinessException(token.NumeroResultado);
                            }
                        }

                        //Valida la vigencia de las membresías de los oferentes:

                        var esOferente = false;
                        foreach (KeyValuePair<int, string> kvp in token.DiccionarioRoles)
                        {
                            /*
                                ID_ROL	NOMBRE_ROL
                                   2	Oferente Físico
                                   3	Oferente Jurídico
                            */
                            if (2 == kvp.Key || 3 == kvp.Key)
                            {
                                esOferente = true;
                                break;
                            }
                        }

                        if (esOferente)
                        {
                            var tieneMembresiaVigente = VigenciaMembresiaManager.TieneMembresiaVigente(token.IdUsuario);
                        }

                    }
                    else
                    {
                        throw new BussinessException(token.NumeroResultado);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
            return token;

        }

        public LoginToken RetrieveByIdContrasennaActual(LoginToken pCredenciales)
        {
            var token = new LoginToken();
            try
            {
                token = crudLoginToken.RetrieveContrasennaActual<LoginToken>(pCredenciales);
                if (token == null)
                {
                    throw new BussinessException(14);
                }
                else
                {
                    //devolver fila con contraseña nueva actualizada ver crud
                    token = crudLoginToken.RetrieveModificarContrasenna<LoginToken>(pCredenciales);
                    if (token == null)
                    {
                        throw new BussinessException(15);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
            return token;

        }

    }
}
