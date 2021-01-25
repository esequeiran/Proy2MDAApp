'use strict';
function vModificarContrasenna() {
    this.service = 'ModificarContrasenna';
    this.ctrlActions = new ControlActions();


    this.ModificarContrasenna = function () {

        var validar = this.ctrlActions.ValidateDataForm('frmModificarContrasenna');

        if (validar) {            
            //RegExp("^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#\$%\^&\*])(?=.{8,})")
            var regexMayuscula = new RegExp("^(?=.*[A-Z])");
            var regexMinuscula = new RegExp("^(?=.*[a-z])");
            var regexNumero = new RegExp("^(?=.*[0-9])");
            var regexCaracterEspecial = new RegExp("^(?=.*[!@#\$%\^&\*])");
            

            if ($('#txtContrasenna').val().length == 8) {

                if (regexMinuscula.test($('#txtContrasenna').val())) {

                    if (regexMayuscula.test($('#txtContrasenna').val())) {

                        if (regexNumero.test($('#txtContrasenna').val())) {

                            if (regexCaracterEspecial.test($('#txtContrasenna').val())) {                             

                                var regexCoincideActualNueva = RegExp($('#txtContrasennaActual').val());

                                if (($('#txtContrasenna').val()).match(regexCoincideActualNueva) == null) {

                                    var regexCoincide = RegExp($('#txtContrasenna').val());

                                    if (($('#txtConfirmarContrasenna').val()).match(regexCoincide) != null) {                                    

                                        var modificarContrasennaData = {
                                            IdUsuario: sessionStorage.getItem('IdUsuario'),
                                            ContrasennaActual: $('#txtContrasennaActual').val(),
                                            Contrasenna: $('#txtContrasenna').val()
                                        };

                                        $('#txtContrasenna').removeClass('is-invalid');
                                        $('#txtConfirmarContrasenna').removeClass('is-invalid');
                                        $('#txtContrasennaActual').removeClass('is-invalid');
                                        
                                        $('#txtContrasennaActual').addClass('is-valid');
                                        $('#txtContrasenna').addClass('is-valid');
                                        $('#txtConfirmarContrasenna').addClass('is-valid');
                                        $('.sPw').removeClass('invalid-feedback');

                                        var string = this.ctrlActions.GetParametersString(modificarContrasennaData);
                                        this.ctrlActions.PostToApiParametrosModificarContrasenna(this.service, string);

                                    } else {
                                        $('#txtConfirmarContrasenna').addClass('is-invalid');                                  
                                        this.ctrlActions.ShowMessage('E', 'La confirmación de contraseña y la contraseña deben coincidir');
                                    }
                                } else {
                                    $('#txtContrasenna').addClass('is-invalid');
                                    this.ctrlActions.ShowMessage('E', 'La nueva contraseña y la contraseña actual deben ser diferentes');
                                }

                            } else {
                                $('#txtContrasenna').addClass('is-invalid');
                                this.ctrlActions.ShowMessage('E', 'La contraseña debe incluir un caracter especial');
                            }

                        } else {
                            $('#txtContrasenna').addClass('is-invalid');
                            this.ctrlActions.ShowMessage('E', 'La contraseña debe incluir un número');
                        }
                    } else {
                        $('#txtContrasenna').addClass('is-invalid');
                        this.ctrlActions.ShowMessage('E', 'La contraseña debe incluir una mayúscula');
                    }

                } else {
                    $('#txtContrasenna').addClass('is-invalid');
                    this.ctrlActions.ShowMessage('E', 'La contraseña debe incluir una minúscula');
                }

            } else {
                $('#txtContrasenna').addClass('is-invalid');
                this.ctrlActions.ShowMessage('E', 'La contraseña debe ser de 8 caracteres');            
            }

        } else {
            $('.sPw').addClass('invalid-feedback');

        }
        $('#txtConfirmarContrasenna').val('');
        $('#txtConfirmarContrasenna').removeClass('is-valid');
        $('#txtContrasenna').val('');
        $('#txtContrasenna').removeClass('is-valid');
        $('#txtContrasennaActual').val('');
        $('#txtContrasennaActual').removeClass('is-valid');

    }

}

//ON DOCUMENT READY
$(document).ready(function () {
    var vModificarC = new vModificarContrasenna();

});