var paypalKey = 'Ae4cyZyBw0oihOj_Zi0fPjTdLGNaOmP3qqUgfC6juFiJuQx2gVxgocCA5jG3NmSs4KvUcqrhQ1yK7JbL-vkbUd7xbTXxsZ8aM0puFK3q1qJGu';
var paypalSecret = 'EDIubp2LOh3E66MN9PIBmOPOo1j801GT4ioATphd6fZmytGcRzyj9sxrpAYzcUTFTwFaNvhfl73s9H8O';


//Recargar Membresia
paypal.Button.render({
    // Configuración de los keys de prueba y de producción de Paypal
    ///Monedero:
    /*AT_m482P2VklVtlYy_pblzKwHlc5snc0vvZ2r0JS1sVvMWlzYlP-vkbUd7xbTXxsZ8aM0puFK3q1qJGu*/
    //EEYRJHap7oJDyrf3CVbsZ8Z5AUpl_bAXPoXNb_pea8I3sfZdcE9XeyKR06_MTqEtAapus2PZwBh_mu9H
    //App
    //Ae4cyZyBw0oihOj_Zi0fPjTdLGNaOmP3qqUgfC6juFiJuQx2gVxgocCA5jG3NmSs4KvUcqrhQ1yK7JbL
    //EDIubp2LOh3E66MN9PIBmOPOo1j801GT4ioATphd6fZmytGcRzyj9sxrpAYzcUTFTwFaNvhfl73s9H8O
    env: 'sandbox',
    client: {
        sandbox: paypalKey,
        production: paypalSecret
    },
    // Customización del botón mostrado
    locale: 'en_US',
    style: {
        size: 'small',
        color: 'gold',
        shape: 'pill',
    },
    // Habilitar la posibilidad del pago instantaneo (esto es opcional)
    commit: true,

    // Configuración del pago
    payment: function (data, actions) {
        console.log(data);
        console.log(actions);
        return actions.payment.create({
            transactions: [{
                amount: {
                    total: $('#txtMontoRecarga')[0].value,
                    currency: 'USD'
                }
            }]
        });
    },
    // Ejecutar el pago
    onAuthorize: function (data, actions) {
        console.log(data);
        console.log(actions);
        return actions.payment.execute().then(function () {
            var monederoData = {};
            this.ctrlActions = new ControlActions();
            ctrlActions.PutToAPI('RecargarMonedero?cedula=' + sessionStorage.getItem('IdUsuario') + '&monto=' + $('#txtMontoRecarga')[0].value, monederoData);

            $('#RecargaM').modal('show');
            $('#Recar').text('Su el dinero ha sido depositado en su monedero!');
            $('#recargaH').css('display', 'none');


            $('#RecargaM').on('hidden.bs.modal', function () {
                location.reload(true);
            });
        });
    }
}, "#btn-paypal");


function vMonedero() {

    this.MontoPago = function () {
        $('#btn-paypal').css('display', 'block');
        $('#btnRecargarMonedero').css('display', 'none');
        $('#txtMontoRecarga').css('display', 'none');
        $('label[for=txtMontoRecarga]').css('display', 'none');
        $('#valMonto').css('display', 'none');

    }


    this.validarRecarga = function () {
        var esValido = true;
        var listaCampos = ["#txtMontoRecarga"];
        listaCampos.forEach(function (campo) {
            if ($(campo)[0].validity.valid === false) {
                esValido = false;
                $(campo).addClass('is-invalid');
                $(campo + '_val').removeClass('text-muted');
                $(campo + '_val').addClass('invalid-feedback');
            } else {
                if ($(campo)[0].value === '') {
                    esValido = false;
                    $(campo).addClass('is-invalid');
                    $(campo + '_val').removeClass('text-muted');
                    $(campo + '_val').removeClass('d-none');
                    $(campo + '_val').addClass('invalid-feedback');
                } else {
                    if ($(campo)[0].value === '0') {
                        esValido = false;
                        $(campo).addClass('is-invalid');
                        $(campo + '_val').removeClass('text-muted');
                        $(campo + '_val').removeClass('d-none');
                        $(campo + '_val').addClass('invalid-feedback');
                    } else {

                        $(campo).removeClass('is-invalid');
                        $(campo).addClass('is-valid');
                        $(campo + '_val').removeClass('text-muted');
                        $(campo + '_val').removeClass('invalid-feedback');
                        $(campo + '_val').addClass('d-none');
                    }
                }
            }
        });
        if (esValido) {
            $('#btnRecargarMonedero').prop("disabled", false);
            $('#btnRecargarMonedero').removeAttr('disable');
        } else {
            $('#btnRecargarMonedero').prop("disabled", true);
            $('#btnRecargarMonedero').attr('disable');
        }
    }
    this.validarRetiro = function () {
        var esValido = true;
        var listaCampos = ["#txtMontoRetiro"];
        listaCampos.forEach(function (campo) {
            if ($(campo)[0].validity.valid === false) {
                esValido = false;
                $(campo).addClass('is-invalid');
                $(campo + '_val').removeClass('text-muted');
                $(campo + '_val').addClass('invalid-feedback');
            } else {
                if ($(campo)[0].value === '') {
                    esValido = false;
                    $(campo).addClass('is-invalid');
                    $(campo + '_val').removeClass('text-muted');
                    $(campo + '_val').removeClass('d-none');
                    $(campo + '_val').addClass('invalid-feedback');
                } else {
                    if ($(campo)[0].value === '0') {
                        esValido = false;
                        $(campo).addClass('is-invalid');
                        $(campo + '_val').removeClass('text-muted');
                        $(campo + '_val').removeClass('d-none');
                        $(campo + '_val').addClass('invalid-feedback');
                    } else {
                        $(campo).removeClass('is-invalid');
                        $(campo).addClass('is-valid');
                        $(campo + '_val').removeClass('text-muted');
                        $(campo + '_val').removeClass('invalid-feedback');
                        $(campo + '_val').addClass('d-none');
                    }
                }
            }
        });
        if (esValido) {
            $('#btnRetiroMonedero').prop("disabled", false);
            $('#btnRetiroMonedero').removeAttr('disable');
        } else {
            $('#btnRetiroMonedero').prop("disabled", true);
            $('#btnRetiroMonedero').attr('disable');
        }
    }

    this.RetiroMonedero = function () {
        var basicToken = btoa(paypalKey + ":" + paypalSecret)
        var tokenSettings = {
            "url": "https://api.sandbox.paypal.com/v1/oauth2/token",
            "method": "POST",
            "timeout": 0,
            "headers": {
                "Authorization": "Basic " + basicToken,
                "Content-Type": "application/x-www-form-urlencoded"
            },
            "data": {
                "grant_type": "client_credentials"
            }
        };

        $.ajax(tokenSettings).done(function (response) {

            var settings = {
                "url": "https://api.sandbox.paypal.com/v1/payments/payouts",
                "method": "POST",
                "timeout": 0,
                "headers": {
                    "Content-Type": ["application/json", "text/plain"],
                    "Authorization": "Bearer " + response.access_token
                },
                "data": JSON.stringify({
                    "sender_batch_header": {
                        "sender_batch_id": "Payouts_" + Date.now(),
                        "email_subject": "You have a payout!",
                        "email_message": "You have received a payout! Thanks for using our service!"
                    },
                    "items": [
                        {
                            "recipient_type": "EMAIL",
                            "amount": {
                                "value": $('#txtMontoRetiro')[0].value,
                                "currency": "USD"
                            },
                            "note": "Thanks for your patronage!",
                            "sender_item_id": "201403140001",
                            "receiver": sessionStorage.getItem('Correo'),
                            "alternate_notification_method": {
                                "phone": {
                                    "country_code": "91",
                                    "national_number": "9999988888"
                                }
                            },
                            "notification_language": "fr-FR"
                        }
                    ]
                })
            };

            $.ajax(settings).done(function (response) {
                var monederoData = {};
                this.ctrlActions = new ControlActions();
                this.ctrlActions.PutToAPI('RetiroMonedero?cedula=' + sessionStorage.getItem('IdUsuario') + '&monto=' + $('#txtMontoRetiro')[0].value, monederoData);

                $('#RetiroM').modal('show');
                $('#Reti').text('El retiro ha sido exitoso!');
                $('#retiroH').css('display', 'none');

                $('#RetiroM').on('hidden.bs.modal', function () {
                    location.reload(true);
                });
            });

        });
    }

    this.GetCorreo = async function () {
        var result = await this.GetDataByCedula(sessionStorage.getItem('IdUsuario'));
        sessionStorage.setItem("Correo", result.Data.Oferente.Correo)
    }

    this.GetDataByCedula = function (cedula) {
        return $.ajax({
            url: 'http://localhost:61079/api/Oferente?idUsuario=' + cedula,
            type: 'GET',
            contentType: 'application/json'
        });
    }


    this.GetSaldo = async function () {
        var result = await this.GetSaldoByCedula(sessionStorage.getItem('IdUsuario'));
        $('#txtMonedero')[0].value = '$' + result.Data;
    }

    this.GetSaldoByCedula = function (cedula) {
        return $.ajax({
            url: 'http://localhost:61079/api/Monedero?cedula=' + cedula,
            type: 'GET',
            contentType: 'application/json'
        });
    }




}





//ON DOCUMENT READY
$(document).ready(function () {

    var vmonedero = new vMonedero();
    document.addEventListener('keyup', () => { vmonedero.validarRetiro() });
    document.addEventListener('keyup', () => { vmonedero.validarRecarga() });
    $('#btnRetiroMonedero').prop("disabled", true);
    $('#btnRetiroMonedero').attr('disable');
    $('#btnRecargarMonedero').prop("disabled", true);
    $('#btnRecargarMonedero').attr('disable');
    vmonedero.GetCorreo();
    vmonedero.GetSaldo();

});