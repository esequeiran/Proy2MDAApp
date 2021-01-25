function vCodigoVerificacion() {
    this.service = 'VerificarCodigo';
	this.ctrlActions = new ControlActions();

	this.validateForm = function () {
		var esValido = true;
		var listaCampos = ["#txtCodigo"];
		listaCampos.forEach(function (campo) {
				if ($(campo)[0].value === '') {
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
			
		});


		if (esValido) {
			$('#btnValidarCodigo').prop("disabled", false);
			$('#btnValidarCodigo').removeAttr('disable');
		} else {
			$('#btnValidarCodigo').prop("disabled", true);
			$('#btnValidarCodigo').attr('disable');
		}
	}


    this.ValidarCodigo = function () {


        if ($('#txtCodigo')[0].value != null) {
            var codigo = {};
            let url_string = window.location.href;
            let url = new URL(url_string);

            codigo.cedula = url.searchParams.get('Cedula');

            codigo.codigoVerificacion = $('#txtCodigo')[0].value;

            this.ctrlActions.GetToApi(this.service + '?cedula=' + codigo.cedula + '&codigoVerificacion=' + codigo.codigoVerificacion,
                function (response) {
                    if (response.Resultado == true) {
                        window.location.href = "vRegistrarContrasenna?Cedula=" + codigo.cedula;

                    } else {
                        let ctrlAction = new ControlActions();
                        ctrlAction.ShowMessage('E', "El código que ingreso es incorrecto.");

                    }

                });
        }

    };

}


//ON DOCUMENT READY
$(document).ready(function () {
	var vcodigoVerificacion = new vCodigoVerificacion();
	$('#btnValidarCodigo').prop("disabled", true);
	$('#btnValidarCodigo').attr('disable');
	document.addEventListener('keyup', () => { vcodigoVerificacion.validateForm() });

});