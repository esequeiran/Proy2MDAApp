'use strict';
function vRegistrarContrasenna() {
    this.service = 'RegistrarContrasenna';
    this.ctrlActions = new ControlActions();

    this.AceptarRegistroContrasenna = function () {
        window.location.href = 'http://localhost:61102';
    }
    this.GuardarContrasenna = function () { 
        var validar = this.ctrlActions.ValidateDataForm('frmRegistrarContrasenna');
        //valida campos vacios
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

                                $('#txtContrasenna').addClass('is-valid');
                                var regexCoincide = RegExp($('#txtContrasenna').val());

                                if (($('#txtConfirmarContrasenna').val()).match(regexCoincide) != null) {

                                    $('#txtConfirmarContrasenna').addClass('is-valid');
                        
                                    var url_string = window.location.href;
                                    var url = new URL(url_string);
                                    var cedulaUrl = url.searchParams.get('Cedula');
                                    console.log(cedulaUrl);

                                    $('#txtContrasenna').removeClass('is-valid');
                                    $('#txtConfirmarContrasenna').removeClass('is-valid');                               
                                    $('#txtContrasenna').addClass('is-valid');
                                    $('#txtConfirmarContrasenna').addClass('is-valid');

                                    if (cedulaUrl != null) {
                                        var registrarContrasennaData = this.ctrlActions.GetDataForm('frmRegistrarContrasenna');
                                        for (var dato in registrarContrasennaData) {
                                            if (dato.match('Contrasenna')) {
                                                var data = {
                                                    Cedula: cedulaUrl,
                                                    Contrasenna: registrarContrasennaData[dato]
                                                }
                                            }
                                        }
                                        $('#txtContrasenna').removeClass('is-invalid');
                                        $('#txtConfirmarContrasenna').removeClass('is-invalid');

                                        $('#txtContrasenna').addClass('is-valid');
                                        $('#txtConfirmarContrasenna').addClass('is-valid');
                                        $('.sPw').removeClass('invalid-feedback');

                                        var string = this.ctrlActions.GetParametersString(data);
                                        this.ctrlActions.PostToApiParametrosRegistrarContrasenna(this.service, string);

                                        
                                     
                                    } else {
                                        $('#parrafoDialogRegistrarContrasenna').html('No existe usuario asociado para registrar contraseña');
                                        $('#btnCerrar').hide();
                                        $('#modalRegistrarContrasenna').show();
                                    }
                                  
                                
                                   

                                } else {
                                    $('#txtContrasenna').addClass('is-invalid');
                                    this.ctrlActions.ShowMessage('E', 'La contraseña nueva y la de confirmación deben coincidir');
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
    }


}

//ON DOCUMENT READY
$(document).ready(function () {
    var vRegistrarC = new vRegistrarContrasenna();

});