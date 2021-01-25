'use strict';
function vRecuperarContrasenna() {

    this.service = 'RecuperarContrasenna';
    this.ctrlActions = new ControlActions();

    this.RecuperarContrasenna = function () {
        var recuperarData = {};
        var validar = this.ctrlActions.ValidateDataForm('frmRecuperarContrasenna');

        if (validar) {

            $('#divMsjInputCedula').hide();
            recuperarData = this.ctrlActions.GetDataForm('frmRecuperarContrasenna');
            console.log(recuperarData);
            var string = this.ctrlActions.GetParametersString(recuperarData);
            this.ctrlActions.GetToApiParametrosRecuperarContrasenna(this.service, string);
            $('#parrafoDialogo').text("Se la ha enviado un correo y un mensaje sms para el proceso de creación de contraseña.");

        } else {
            $('#divMsjInputCedula').text('Campo requerido');
            $('#divMsjInputCedula').show();
        }

    }

    this.Confirmar = function () {
    
        window.location.href = "vLandingPage";
    }

}

//ON DOCUMENT READY
$(document).ready(function () {
    var vRecuperarC = new vRecuperarContrasenna();
    $('#divMsjInputCedula').hide();

});