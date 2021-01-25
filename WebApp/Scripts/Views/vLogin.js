'use strict';
function vLogin() {
    this.service = 'LoginToken';
    this.ctrlActions = new ControlActions();

    this.InicioSesion = function () {
        var membresiasData = {};
        var validar = this.ctrlActions.ValidateDataForm('frmLogin');
        if (validar) {
            if ($('#txtContrasenna').val().length == 8) {
                $('#txtContrasenna').addClass('is-valid');
                $('#divMsjInputPW').hide();
                $('#divMsjInputCorreo').hide();
                membresiasData = this.ctrlActions.GetDataForm('frmLogin');
                var string = this.ctrlActions.GetParametersString(membresiasData);
                this.ctrlActions.GetToApiParametrosLogin(this.service, string);
            } else {
                $('#txtContrasenna').addClass('is-invalid');
                $('#divMsjInputPW').text('La contraseña debe ser de 8 caracteres');
                $('#divMsjInputPW').show();
            }
        } else {
            $('#divMsjInputPW').text('Campo requerido');
            $('#divMsjInputPW').show();
            $('#divMsjInputCorreo').text('Campo requerido');
            $('#divMsjInputCorreo').show();
        }
        $('#txtContrasenna').val('');
        $('#txtContrasenna').removeClass('is-valid');
    }

}

//ON DOCUMENT READY
$(document).ready(function () {
    var vloginD = new vLogin();
    $('#divMsjInputPW').hide();
    $('#divMsjInputCorreo').hide();
});