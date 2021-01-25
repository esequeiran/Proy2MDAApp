using DataAccess.Crud;
using Entities_POJO;
using Exceptions;
using System;

namespace CoreAPI
{
    public class DatosCorreoSmsManager : BaseManager
    {

        private DatosCorreoSmsCrudFactory crudCorreoSMS;
        public DatosCorreoSmsManager()
        {
            crudCorreoSMS = new DatosCorreoSmsCrudFactory();
        }

        public void RetrieveSmsEmpresa(DatosAuxiliaresSmsCorreo dato)
        {
            try
            {
                var infoSms = crudCorreoSMS.RetriveStatementCodigoVerificacionSms<DatosAuxiliaresSmsCorreo>(dato);
                infoSms.MensajeSMS = "Su código de verificación de Aureosoft-MDA es: " + infoSms.CodigoVerificacion + ".";
                var gestorSms = new EnviarSmsManager();
                gestorSms.ejecutarEnvioSMS(infoSms);

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(new BussinessException(0));

            }
        }

        public void RetrieveSmsRecuperarContrasenna(DatosAuxiliaresSmsCorreo dato)
        {
            try
            {

                dato.MensajeSMS = "Su código de verificación de Aureosoft-MDA es: " + dato.CodigoVerificacion + ".";
                var gestorSms = new EnviarSmsManager();
                gestorSms.ejecutarEnvioSMS(dato);

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(new BussinessException(0));

            }
        }

        public void RetrieveCorreoEnlaceVerificacion(DatosAuxiliaresSmsCorreo dato)
        {
            //REVISAR PARA ENVÍO DE CÓDIGO DE VERIFICACIÓN
            try
            {
                var infoCorreo = crudCorreoSMS.RetrieveCorreoEmpresa<DatosAuxiliaresSmsCorreo>(dato);
                var gestorCorreos = new EnviarCorreoManager();
                var correoEstructura = new CorreoEstructura
                {
                    correoDestinatario = infoCorreo.Correo,
                    nombreDestinatario = infoCorreo.NombreUsuario,
                    Asunto = "MDA plataforma, verificación de registro",
                    ContenidoTextoPlano = "Comuníquese a la plataforma MDA",
                    PlantillaContenidoHtml =
                    "<!DOCTYPE html>" +
                    "<html LANG=" + "ES" + ">" +
                        "<head>" +
                            "<link href=" + "https://fonts.googleapis.com/css?family=Roboto" + " rel=" + "stylesheet" + ">" +
                            "<style>" +
                                "h1{" +
                                    "display: inline-block;" +
                                    "font-size: 40px;" +
                                    "text-align: left;" +
                                    "margin-left: 50px;" +
                                    "color: #375a7f;" +
                                    "}" +
                                    "h2{" +
                                        "text-align: center;" +
                                        "font-size: 30px;" +
                                        "margin-bottom: 50px;" +
                                        "color: #375a7f;" +
                                        "}" +
                                        ".wrapper{" +
                                            "background : #81ecec;" +
                                            "font-family: 'Roboto', sans-serif;" +
                                            "}" +
                                            ".container{" +
                                                "display: block;" +
                                                "margin: 0 auto;" +
                                                "background: #fff;" +
                                                "width: 80%;" +
                                                "text-align: center;" +
                                                "padding: 10px;" +
                                                "}" +
                                                ".pdfContainer{" +
                                                    "display: block;" +
                                                    "margin: 0 auto;" +
                                                    "background: #fff;" +
                                                    "width: 100%;" +
                                                    "text-align: center;" +
                                                    "padding: 10px;" +
                                                    "height: 80%;" +
                                                    "}" +
                                                    ".btnContainer{" +
                                                        "display: block;" +
                                                        "margin: 0 auto;" +
                                                        "background: #fff;" +
                                                        "width: 100%;" +
                                                        "text-align: center;" +
                                                        "padding: 10px;" +
                                                        "height: 5%;" +
                                                        "}" +
                                                        "a{" +
                                                            "text-align: right;" +
                                                            "text-decoration: none;" +
                                                            "padding: 10px;" +
                                                            "background: #f9aa33;" +
                                                            "color: #344955;" +
                                                            "font-size: 22px;" +
                                                            "display: inline-block;" +
                                                            "margin-left: 10px;" +
                                                            "}" +

                                                            " a:hover{" +
                                                                "background: #ffbe76;" +
                                                                "cursor: pointer;" +
                                                                "transition: all 300ms ease;" +
                                                                "}" +
                                                            "p{" +
                                                                "font-size: 22px;" +
                                                                "color: #344955;" +
                                                                "text-align: left;" +
                                                                " }" +
                                                                " span{" +
                                                                    "  color: #344955;" +
                                                                    "  }" +
                                                                    "  iframe{" +
                                                                        "   display: block;" +
                                                                        "    width : 40%;" +
                                                                        "    height :80%;" +
                                                                        " }" +
                                                                        " </style>" +
                                                               " </head>" +
                                                               " <body>" +
                        " <div class=" + "container" + ">" +
                            " <h1>Confirmación de registro</h1>" +
                            "<h2><i>Estimado(a) usuario " + infoCorreo.NombreUsuario + "</i></h2>" +
                            " <p>Reciba un cordial saludo. Su solicitud de registro a la plataforma MDA ha sido aprobada.</p>" +
                              " <p>Utilice el código de verifiación que se le envió por mensaje SMS.</p>" +
                            " <p>Por favor dirigirse al siguiente link para continuar con el proceso de verificación y creación de contraseña.</p>" +
                            "  <div class=" + "pdfContainer" + ">" +

                                            " </div>" +
                                " <div class=" + "btnContainer" + ">" +
                                    " <a href='" + "http://localhost:61102/Home/vComprarMembresia?Cedula=" + dato.CedulaEmpresa + "'</a>http://localhost:61102/Home/vComprarMembresia?Cedula=" + dato.CedulaEmpresa +
                                    " </div>   " +

                                " </div>      " +
                                    " </body> " +
                                    " </html> ",
                };

                gestorCorreos.ejecutarCorreo(correoEstructura);
                RetrieveSmsEmpresa(dato);
            }
            catch (Exception ex)
            {

                ExceptionManager.GetInstance().Process(new BussinessException(0));
            }
        }

        public void RetrieveCorreoEmpresa(DatosAuxiliaresSmsCorreo dato)
        {
            try
            {
                var infoCorreo = crudCorreoSMS.RetrieveCorreoEmpresa<DatosAuxiliaresSmsCorreo>(dato);
                var gestorCorreos = new EnviarCorreoManager();
                var correoEstructura = new CorreoEstructura
                {
                    correoDestinatario = infoCorreo.Correo,
                    nombreDestinatario = infoCorreo.NombreEmpresa,
                    Asunto = "MDA plataforma, solicitud de registro",
                    ContenidoTextoPlano = "Comuníquese a la plataforma MDA",
                    PlantillaContenidoHtml =
                    "<!DOCTYPE html>" +
                    "<html LANG=" + "ES" + ">" +
                        "<head>" +
                            "<link href=" + "https://fonts.googleapis.com/css?family=Roboto" + " rel=" + "stylesheet" + ">" +
                            "<style>" +
                                "h1{" +
                                    "display: inline-block;" +
                                    "font-size: 40px;" +
                                    "text-align: left;" +
                                    "margin-left: 50px;" +
                                    "color: #f9aa33;" +
                                    "}" +
                                    "h2{" +
                                        "text-align: center;" +
                                        "font-size: 30px;" +
                                        "margin-bottom: 50px;" +
                                        "color: #232f34;" +
                                        "}" +
                                        ".wrapper{" +
                                            "background : #81ecec;" +
                                            "font-family: 'Roboto', sans-serif;" +
                                            "}" +
                                            ".container{" +
                                                "display: block;" +
                                                "margin: 0 auto;" +
                                                "background: #fff;" +
                                                "width: 80%;" +
                                                "text-align: center;" +
                                                "padding: 10px;" +
                                                "}" +
                                                ".pdfContainer{" +
                                                    "display: block;" +
                                                    "margin: 0 auto;" +
                                                    "background: #fff;" +
                                                    "width: 100%;" +
                                                    "text-align: center;" +
                                                    "padding: 10px;" +
                                                    "height: 80%;" +
                                                    "}" +
                                                    ".btnContainer{" +
                                                        "display: block;" +
                                                        "margin: 0 auto;" +
                                                        "background: #fff;" +
                                                        "width: 100%;" +
                                                        "text-align: center;" +
                                                        "padding: 10px;" +
                                                        "height: 5%;" +
                                                        "}" +
                                                        "a{" +
                                                            "text-align: right;" +
                                                            "text-decoration: none;" +
                                                            "padding: 10px;" +
                                                            "background: #f9aa33;" +
                                                            "color: #344955;" +
                                                            "font-size: 22px;" +
                                                            "display: inline-block;" +
                                                            "margin-left: 10px;" +
                                                            "}" +

                                                            " a:hover{" +
                                                                "background: #ffbe76;" +
                                                                "cursor: pointer;" +
                                                                "transition: all 300ms ease;" +
                                                                "}" +
                                                            "p{" +
                                                                "font-size: 22px;" +
                                                                "color: #344955;" +
                                                                "text-align: left;" +
                                                                " }" +
                                                                " span{" +
                                                                    "  color: #344955;" +
                                                                    "  }" +
                                                                    "  iframe{" +
                                                                        "   display: block;" +
                                                                        "    width : 40%;" +
                                                                        "    height :80%;" +
                                                                        " }" +
                                                                        " </style>" +
                                                               " </head>" +
                                                               " <body>" +
                        " <div class=" + "container" + ">" +
                            " <h1>Solicitud de registro</h1>" +
                            "<h2><i>Estimado(a) empresa " + infoCorreo.NombreEmpresa + "</i></h2>" +
                            " <p>Reciba un cordial saludo. Su solicitud de registro a la plataforma MDA ha sido aprobada.</p>" +
                            " <p>Por favor dirigirse al siguiente link para continuar con el proceso de compra de membresía.</p>" +
                            "  <div class=" + "pdfContainer" + ">" +

                                            " </div>" +
                                " <div class=" + "btnContainer" + ">" +
                                    " <a href='" + "http://localhost:61102/Home/vComprarMembresia?Cedula=" + dato.CedulaEmpresa + "'</a>http://localhost:61102/Home/vComprarMembresia?Cedula=" + dato.CedulaEmpresa +
                                    " </div>   " +

                                " </div>      " +
                                    " </body> " +
                                    " </html> ",
                };

                gestorCorreos.ejecutarCorreo(correoEstructura);
                //RetrieveSmsEmpresa(dato);
            }
            catch (Exception ex)
            {

                ExceptionManager.GetInstance().Process(new BussinessException(0));
            }
        }

        public void RetrieveCorreoSMSRecuperarContrasenna(DatosAuxiliaresSmsCorreo dato)
        {
            try
            {
                dato.CodigoVerificacion = generarCodigoVerificacionAlfanumerico();
                var informacion = crudCorreoSMS.RetriveStatementCodigoVerificacionSmsRecuperarContrasenna<DatosAuxiliaresSmsCorreo>(dato);
                if (informacion != null)
                {
                    RetrieveSmsRecuperarContrasenna(informacion);
                    var gestorCorreos = new EnviarCorreoManager();
                    var correoEstructura = new CorreoEstructura
                    {
                        correoDestinatario = informacion.Correo,
                        nombreDestinatario = informacion.NombreUsuario,
                        Asunto = "MDA plataforma, solicitud de recuperación",
                        ContenidoTextoPlano = "Comuníquese a la plataforma MDA",
                        PlantillaContenidoHtml =
                        "<!DOCTYPE html>" +
                        "<html LANG=" + "ES" + ">" +
                            "<head>" +
                                "<link href=" + "https://fonts.googleapis.com/css?family=Roboto" + " rel=" + "stylesheet" + ">" +
                                "<style>" +
                                    "h1{" +
                                        "display: inline-block;" +
                                        "font-size: 40px;" +
                                        "text-align: left;" +
                                        "margin-left: 50px;" +
                                        "color: #f9aa33;" +
                                        "}" +
                                        "h2{" +
                                            "text-align: center;" +
                                            "font-size: 30px;" +
                                            "margin-bottom: 50px;" +
                                            "color: #232f34;" +
                                            "}" +
                                            ".wrapper{" +
                                                "background : #81ecec;" +
                                                "font-family: 'Roboto', sans-serif;" +
                                                "}" +
                                                ".container{" +
                                                    "display: block;" +
                                                    "margin: 0 auto;" +
                                                    "background: #fff;" +
                                                    "width: 80%;" +
                                                    "text-align: center;" +
                                                    "padding: 10px;" +
                                                    "}" +
                                                    ".pdfContainer{" +
                                                        "display: block;" +
                                                        "margin: 0 auto;" +
                                                        "background: #fff;" +
                                                        "width: 100%;" +
                                                        "text-align: center;" +
                                                        "padding: 10px;" +
                                                        "height: 80%;" +
                                                        "}" +
                                                        ".btnContainer{" +
                                                            "display: block;" +
                                                            "margin: 0 auto;" +
                                                            "background: #fff;" +
                                                            "width: 100%;" +
                                                            "text-align: center;" +
                                                            "padding: 10px;" +
                                                            "height: 5%;" +
                                                            "}" +
                                                            "a{" +
                                                                "text-align: right;" +
                                                                "text-decoration: none;" +
                                                                "padding: 10px;" +
                                                                "background: #f9aa33;" +
                                                                "color: #344955;" +
                                                                "font-size: 22px;" +
                                                                "display: inline-block;" +
                                                                "margin-left: 10px;" +
                                                                "}" +

                                                                " a:hover{" +
                                                                    "background: #ffbe76;" +
                                                                    "cursor: pointer;" +
                                                                    "transition: all 300ms ease;" +
                                                                    "}" +
                                                                "p{" +
                                                                    "font-size: 22px;" +
                                                                    "color: #344955;" +
                                                                    "text-align: left;" +
                                                                    " }" +
                                                                    " span{" +
                                                                        "  color: #344955;" +
                                                                        "  }" +
                                                                        "  iframe{" +
                                                                            "   display: block;" +
                                                                            "    width : 40%;" +
                                                                            "    height :80%;" +
                                                                            " }" +
                                                                            " </style>" +
                                                                   " </head>" +
                                                                   " <body>" +
                            " <div class=" + "container" + ">" +
                                " <h1>Solicitud de recuperación de contraseña</h1>" +
                                "<h2><i>Estimado(a) usuario(a) " + informacion.NombreUsuario + "</i></h2>" +
                                " <p>Reciba un cordial saludo. Para continuar con el proceso de recuperación de contraseña " +
                                "por favor dirigirse al siguiente link y coloque el código de verificación que le llegó al celular por mensaje SMS.</p>" +
                                "  <div class=" + "pdfContainer" + ">" +

                                                " </div>" +
                                    " <div class=" + "btnContainer" + ">" +
                                        " <a href='" + "http://localhost:61102/Home/vVerificarCodigo?Cedula=" + dato.Cedula + "'</a>http://localhost:61102/Home/vVerificarCodigo?Cedula=" + dato.Cedula +
                                        " </div>   " +

                                    " </div>      " +
                                        " </body> " +
                                        " </html> ",
                    };

                    gestorCorreos.ejecutarCorreo(correoEstructura);
                }
                else
                {
                    throw new BussinessException(13);
                }


            }
            catch (Exception ex)
            {

                ExceptionManager.GetInstance().Process(ex);
            }
        }

        //Este método se llama después de comprar membresía para que continué con la verificación de sms y creación de contraseña
        public void RetrieveCorreoSMSPrimerAccesoPlataforma(DatosAuxiliaresSmsCorreo dato)
        {
            try
            {
                dato.CodigoVerificacion = generarCodigoVerificacionAlfanumerico();
                var informacion = crudCorreoSMS.RetriveStatementCodigoVerificacionSmsRecuperarContrasenna<DatosAuxiliaresSmsCorreo>(dato);
                if (informacion != null)
                {
                    RetrieveSmsRecuperarContrasenna(informacion);
                    var gestorCorreos = new EnviarCorreoManager();
                    var correoEstructura = new CorreoEstructura
                    {
                        correoDestinatario = informacion.Correo,
                        nombreDestinatario = informacion.NombreUsuario,
                        Asunto = "MDA plataforma, solicitud de registro de contraseña",
                        ContenidoTextoPlano = "Comuníquese a la plataforma MDA",
                        PlantillaContenidoHtml =
                        "<!DOCTYPE html>" +
                        "<html LANG=" + "ES" + ">" +
                            "<head>" +
                                "<link href=" + "https://fonts.googleapis.com/css?family=Roboto" + " rel=" + "stylesheet" + ">" +
                                "<style>" +
                                    "h1{" +
                                        "display: inline-block;" +
                                        "font-size: 40px;" +
                                        "text-align: left;" +
                                        "margin-left: 50px;" +
                                        "color: #f9aa33;" +
                                        "}" +
                                        "h2{" +
                                            "text-align: center;" +
                                            "font-size: 30px;" +
                                            "margin-bottom: 50px;" +
                                            "color: #232f34;" +
                                            "}" +
                                            ".wrapper{" +
                                                "background : #81ecec;" +
                                                "font-family: 'Roboto', sans-serif;" +
                                                "}" +
                                                ".container{" +
                                                    "display: block;" +
                                                    "margin: 0 auto;" +
                                                    "background: #fff;" +
                                                    "width: 80%;" +
                                                    "text-align: center;" +
                                                    "padding: 10px;" +
                                                    "}" +
                                                    ".pdfContainer{" +
                                                        "display: block;" +
                                                        "margin: 0 auto;" +
                                                        "background: #fff;" +
                                                        "width: 100%;" +
                                                        "text-align: center;" +
                                                        "padding: 10px;" +
                                                        "height: 80%;" +
                                                        "}" +
                                                        ".btnContainer{" +
                                                            "display: block;" +
                                                            "margin: 0 auto;" +
                                                            "background: #fff;" +
                                                            "width: 100%;" +
                                                            "text-align: center;" +
                                                            "padding: 10px;" +
                                                            "height: 5%;" +
                                                            "}" +
                                                            "a{" +
                                                                "text-align: right;" +
                                                                "text-decoration: none;" +
                                                                "padding: 10px;" +
                                                                "background: #f9aa33;" +
                                                                "color: #344955;" +
                                                                "font-size: 22px;" +
                                                                "display: inline-block;" +
                                                                "margin-left: 10px;" +
                                                                "}" +

                                                                " a:hover{" +
                                                                    "background: #ffbe76;" +
                                                                    "cursor: pointer;" +
                                                                    "transition: all 300ms ease;" +
                                                                    "}" +
                                                                "p{" +
                                                                    "font-size: 22px;" +
                                                                    "color: #344955;" +
                                                                    "text-align: left;" +
                                                                    " }" +
                                                                    " span{" +
                                                                        "  color: #344955;" +
                                                                        "  }" +
                                                                        "  iframe{" +
                                                                            "   display: block;" +
                                                                            "    width : 40%;" +
                                                                            "    height :80%;" +
                                                                            " }" +
                                                                            " </style>" +
                                                                   " </head>" +
                                                                   " <body>" +
                            " <div class=" + "container" + ">" +
                                " <h1>Solicitud de registro de contraseña</h1>" +
                                "<h2><i>Estimado(a) usuario(a) " + informacion.NombreUsuario + "</i></h2>" +
                                " <p>Reciba un cordial saludo. Para continuar con el proceso de registro de verificación de cuenta y de creación de contraseña " +
                                "por favor dirigirse al siguiente link y coloque el código de verificación que le llegó al celular por mensaje SMS.</p>" +
                                "  <div class=" + "pdfContainer" + ">" +

                                                " </div>" +
                                    " <div class=" + "btnContainer" + ">" +
                                        " <a href='" + "http://localhost:61102/Home/vVerificarCodigo?Cedula=" + dato.Cedula + "'</a>http://localhost:61102/Home/vVerificarCodigo?Cedula=" + dato.Cedula +
                                        " </div>   " +

                                    " </div>      " +
                                        " </body> " +
                                        " </html> ",
                    };

                    gestorCorreos.ejecutarCorreo(correoEstructura);
                }
                else
                {
                    throw new BussinessException(13);
                }


            }
            catch (Exception ex)
            {

                ExceptionManager.GetInstance().Process(ex);
            }
        }


        public void RetrieveCorreoOrdenTrabajo(OrdenDeTrabajo orden)
        {
            try
            {


                //var informacion = crudCorreoSMS.RetriveStatementCodigoVerificacionSmsRecuperarContrasenna<DatosAuxiliaresSmsCorreo>(dato);
                var stringImg = imgCodigoQr();
                var adjuntoQRCorreo = imgCodigoQr2(orden.CodigoQr);

                    var gestorCorreos = new EnviarCorreoManager();
                    var correoEstructuraCliente = new CorreoEstructura
                    {
                        correoDestinatario = orden.CorreoCliente,
                        nombreDestinatario = orden.NombreCliente,
                        Asunto = "MDA plataforma, orden de trabajo",
                        ContenidoTextoPlano = "Comuníquese a la plataforma MDA",
                        PlantillaContenidoHtml =
                        "<!DOCTYPE html>" +
                        "<html LANG=" + "ES" + ">" +
                            "<head>" +
                                "<link href=" + "https://fonts.googleapis.com/css?family=Roboto" + " rel=" + "stylesheet" + ">" +
                                "<style>" +
                                    "h1{" +
                                        "display: inline-block;" +
                                        "font-size: 40px;" +
                                        "text-align: left;" +
                                        "margin-left: 50px;" +
                                        "color: #f9aa33;" +
                                        "}" +
                                        "h2{" +
                                            "text-align: center;" +
                                            "font-size: 30px;" +
                                            "margin-bottom: 50px;" +
                                            "color: #232f34;" +
                                            "}" +
                                            ".wrapper{" +
                                                "background : #81ecec;" +
                                                "font-family: 'Roboto', sans-serif;" +
                                                "}" +
                                                ".container{" +
                                                    "display: block;" +
                                                    "margin: 0 auto;" +
                                                    "background: #fff;" +
                                                    "width: 80%;" +
                                                    "text-align: center;" +
                                                    "padding: 10px;" +
                                                    "}" +
                                                    ".pdfContainer{" +
                                                        "display: block;" +
                                                        "margin: 0 auto;" +
                                                        "background: #fff;" +
                                                        "width: 300px;" +
                                                        "text-align: center;" +
                                                        "padding: 10px;" +
                                                        "height: 300px;" +
                                                        "}" +
                                                        ".btnContainer{" +
                                                            "display: block;" +
                                                            "margin: 0 auto;" +
                                                            "background: #fff;" +
                                                            "width: 100%;" +
                                                            "text-align: center;" +
                                                            "padding: 10px;" +
                                                            "height: 5%;" +
                                                            "}" +
                                                            "a{" +
                                                                "text-align: right;" +
                                                                "text-decoration: none;" +
                                                                "padding: 10px;" +
                                                                "background: #f9aa33;" +
                                                                "color: #344955;" +
                                                                "font-size: 22px;" +
                                                                "display: inline-block;" +
                                                                "margin-left: 10px;" +
                                                                "}" +

                                                                " a:hover{" +
                                                                    "background: #ffbe76;" +
                                                                    "cursor: pointer;" +
                                                                    "transition: all 300ms ease;" +
                                                                    "}" +
                                                                "p{" +
                                                                    "font-size: 22px;" +
                                                                    "color: #344955;" +
                                                                    "text-align: left;" +
                                                                    " }" +
                                                                    " span{" +
                                                                        "  color: #344955;" +
                                                                        "  }" +
                                                                        "  iframe{" +
                                                                            "   display: block;" +
                                                                            "    width : 40%;" +
                                                                            "    height :80%;" +
                                                                            " }" +
                                                                        
                                                                            " </style>" +
                                     " </head>" +
                                     " <body>" +
                                        " <div class=" + "container" + ">" +
                                            " <h1>Orden de trabajo</h1>" +
                                            "<h2><i>Estimado(a) usuario(a) " + orden.NombreCliente + "</i></h2>" +
                                            " <p>Reciba un cordial saludo. Se ha generado una orden de trabajo a su nombre.</p>" +
                                               "<p>A continuación los detalles de la misma:</p>" +                               
                                            "<p>Nombre de la empresa: " + orden.NombreEmpresa + "</p>" +
                                            "<p>Fecha del trabajo: " + orden.FechaEventoS+ "</p>" +
                                            "<p>Descripción de la necesidad: " + orden.DescripcionNecesidad+ "</p>" +
                                            "<p>Explicación del trabajo: " + orden.ExplicacionTrabajo+ "</p>" +
                                            "<p>Costo monetario: " + orden.CostoMonetario+ "</p>" +                                            
                                             "<p>El día del trabajo la persona que se registró como contacto debe escanear el código QR " +
                                             "que el trabajador de la empresa le enseñe para confirmar el trabajo" +         
                                            "</p>" +                                                                                
                                        " </div>      " +                                    
                                        " </body> " +
                                        " </html> ",
                    };

                var correoEstructuraEmpresa = new CorreoEstructura
                {
                    correoDestinatario = orden.CorreoEmpresa,
                    nombreDestinatario = orden.NombreEmpresa,
                    Asunto = "MDA plataforma, orden de trabajo",
                    ContenidoTextoPlano = "Comuníquese a la plataforma MDA",
                    PlantillaContenidoHtml =
                 "<!DOCTYPE html>" +
                 "<html LANG=" + "ES" + ">" +
                     "<head>" +
                         "<link href=" + "https://fonts.googleapis.com/css?family=Roboto" + " rel=" + "stylesheet" + ">" +
                         "<style>" +
                             "h1{" +
                                 "display: inline-block;" +
                                 "font-size: 40px;" +
                                 "text-align: left;" +
                                 "margin-left: 50px;" +
                                 "color: #f9aa33;" +
                                 "}" +
                                 "h2{" +
                                     "text-align: center;" +
                                     "font-size: 30px;" +
                                     "margin-bottom: 50px;" +
                                     "color: #232f34;" +
                                     "}" +
                                     ".wrapper{" +
                                         "background : #81ecec;" +
                                         "font-family: 'Roboto', sans-serif;" +
                                         "}" +
                                         ".container{" +
                                             "display: block;" +
                                             "margin: 0 auto;" +
                                             "background: #fff;" +
                                             "width: 80%;" +
                                             "text-align: center;" +
                                             "padding: 10px;" +
                                             "}" +
                                             ".pdfContainer{" +
                                                 "display: block;" +
                                                 "margin: 0 auto;" +
                                                 "background: #fff;" +
                                                 "width: 300px;" +
                                                 "text-align: center;" +
                                                 "padding: 10px;" +
                                                 "height: 300px;" +
                                                 "}" +
                                                 ".btnContainer{" +
                                                     "display: block;" +
                                                     "margin: 0 auto;" +
                                                     "background: #fff;" +
                                                     "width: 100%;" +
                                                     "text-align: center;" +
                                                     "padding: 10px;" +
                                                     "height: 5%;" +
                                                     "}" +
                                                     "a{" +
                                                         "text-align: right;" +
                                                         "text-decoration: none;" +
                                                         "padding: 10px;" +
                                                         "background: #f9aa33;" +
                                                         "color: #344955;" +
                                                         "font-size: 22px;" +
                                                         "display: inline-block;" +
                                                         "margin-left: 10px;" +
                                                         "}" +

                                                         " a:hover{" +
                                                             "background: #ffbe76;" +
                                                             "cursor: pointer;" +
                                                             "transition: all 300ms ease;" +
                                                             "}" +
                                                         "p{" +
                                                             "font-size: 22px;" +
                                                             "color: #344955;" +
                                                             "text-align: left;" +
                                                             " }" +
                                                             " span{" +
                                                                 "  color: #344955;" +
                                                                 "  }" +
                                                                 "  iframe{" +
                                                                     "   display: block;" +
                                                                     "    width : 40%;" +
                                                                     "    height :80%;" +
                                                                     " }" +
                                                                     //".divQr{" +
                                                                     //"display: block;" +
                                                                     //"margin: 0 auto;" +
                                                                     //"background-image: url('" + stringImg + "');" +
                                                                     //"background-repeat: no-repeat;" +
                                                                     //"background-size: cover;" +
                                                                     //"width: 150px;" +
                                                                     //" height: 150px;" +
                                                                     //"}" +
                                                                     " </style>" +
                              " </head>" +
                              " <body>" +
                                 " <div class=" + "container" + ">" +
                                     " <h1>Orden de trabajo</h1>" +
                                     "<h2><i>Estimado(a) usuario(a) " + orden.NombreEmpresa + "</i></h2>" +
                                     " <p>Reciba un cordial saludo. Se ha generado una orden de trabajo para su empresa.</p>" +
                                     "<p>A continuación los detalles de la misma:</p>" +
                                     "<p>Nombre del cliente: " + orden.NombreCliente + "</p>" +
                                     "<p>Fecha del trabajo: " + orden.FechaEventoS + "</p>" +
                                     "<p>Descripción de la necesidad: " + orden.DescripcionNecesidad + "</p>" +
                                     "<p>Explicación del trabajo: " + orden.ExplicacionTrabajo + "</p>" +
                                     "<p>Costo monetario: " + orden.CostoMonetario + "</p>" +
                                     "<p>Localización: " + orden.Provincia + ", " + orden.Canton + ", " + orden.Distrito + "," +
                                     "Señas " + orden.OtrasSennas + "." + "</p>" +
                                     "<p>Recuerde que el trabajador encargado debe enseñar el código QR al cliente para confirmar el inicio del trabajo." + "</p>" +
                                     "<p>Se adjunta imagen del código QR." + "</p>" +
                                 " </div>      " +
                                 " </body> " +
                                 " </html> ",

                    AdjuntoQR = adjuntoQRCorreo
                };

                

                gestorCorreos.ejecutarCorreo(correoEstructuraCliente);

                gestorCorreos.ejecutarCorreoConAdjunto(correoEstructuraEmpresa);              


            }
            catch (Exception ex)
            {

                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public string imgCodigoQr() {

            GeneradorCodigoQrManager mngQR = new GeneradorCodigoQrManager();
            return mngQR.generarCodigoQr("hola");
        }

        public byte[] imgCodigoQr2(string claveQR)
        {

            GeneradorCodigoQrManager mngQR = new GeneradorCodigoQrManager();
            return mngQR.generarCodigoQr2(claveQR);
        }
        public string generarCodigoVerificacionAlfanumerico()
        {
            string codigoVerificacion = string.Empty;
            string[] letras = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "ñ", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z",
                                "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};
            Random aleatorio = new Random();

            for (int i = 0; i < 6; i++)
            {
                int letraAleatoria = aleatorio.Next(0, 100);
                int numeroAleatorio = aleatorio.Next(0, 9);

                if (letraAleatoria < letras.Length)
                {
                    codigoVerificacion += letras[letraAleatoria];
                }
                else
                {
                    codigoVerificacion += numeroAleatorio.ToString();
                }
            }
            return codigoVerificacion;
        }

    }
}
