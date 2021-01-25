'use strict';

let membresiasOferente = (pCedula) => {
	if (pCedula) {
		//window.location.href = 'vListarMembresiasOferente?Cedula=' + pCedula;
	}
	window.location.href = 'vListarMembresiasOferente';
};

function vVerPerfilOferente() {
	this.ctrlActions = new ControlActions();

	this.BindFieldsOferente = async function (data) {
		const result = await this.GetDataByCedula(data);

		//Se valida que result.Data sea un object (Si no encontró la cédula: result.Data es null o 'undefined')
		if (null !== result.Data && 'object' === typeof result.Data) {

			//Se valida que los datos existan
			const oferenteData = (null !== result.Data.Oferente && 'object' === typeof result.Data.Oferente) ? result.Data.Oferente : {};

			if (0 < oferenteData.length) {

				if (oferenteData.TipoCedulaComercial == 'Fisico') {
					$('#tituloU').css('display', 'block');
				}
				if (oferenteData.TipoCedulaComercial == 'Juridico') {
					$('#tituloR').css('display', 'block');
				}

				var fecC = new Date(oferenteData.FecCreacion);
				var fecN = new Date(oferenteData.FecNacimiento);
				var nombreL = result.Data.Localizacion.Nombre;
				var nombreO = oferenteData.Nombre;

				$('#titlePerfil').text(nombreO);

				var newData = $.extend({}, oferenteData, result.Data.Localizacion);
				newData.FecCreacion = fecC.getMonth() + '/' + fecC.getDate() + '/' + fecC.getFullYear();
				newData.FecNacimiento = fecN.getMonth() + '/' + fecN.getDate() + '/' + fecN.getFullYear();
				newData.NombreLocalizacion = nombreL;
				newData.Nombre = nombreO;

				newData.IdDocumento1 = result.Data.Documentos[0].IdDocumento;
				newData.IdDocumento2 = result.Data.Documentos[1].IdDocumento;

				this.ctrlActions.BindFields('frmOferente', newData);
			}
		} else {
			console.log('result: ', result);
		}
	}

	this.GetDataByCedula = function (cedula) {
		return $.ajax({
			url: 'http://localhost:61079/api/Oferente?idUsuario=' + cedula,
			type: 'GET',
			contentType: 'application/json'
		});
	}

	//this.validateForm = function () {
	//	var esValido = true;
	//	var listaCampos = ["#txtNombre", "#txtApellido1", "#txtApellido2", "#txtTelefono", '#txtDescripcion'];
	//	listaCampos.forEach(function (campo) {
	//		if ($(campo)[0].validity.valid === false) {
	//			esValido = false;
	//			$(campo).addClass('is-invalid');
	//			$(campo + '_val').removeClass('text-muted');
	//			$(campo + '_val').addClass('invalid-feedback');
	//		} else {
	//			if ($(campo)[0].value === '') {
	//				esValido = false;
	//				$(campo).addClass('is-invalid');
	//				$(campo + '_val').removeClass('text-muted');
	//				$(campo + '_val').removeClass('d-none');
	//				$(campo + '_val').addClass('invalid-feedback');
	//			} else {
	//				$(campo).removeClass('is-invalid');
	//				$(campo).addClass('is-valid');
	//				$(campo + '_val').removeClass('text-muted');
	//				$(campo + '_val').removeClass('invalid-feedback');
	//				$(campo + '_val').addClass('d-none');
	//			}
	//		}
	//	});


	//	if (esValido) {
	//		$('#btnGuardarCambios').prop("disabled", false);
	//		$('#btnGuardarCambios').removeAttr('disable');
	//	} else {
	//		$('#btnGuardarCambios').prop("disabled", true);
	//		$('#btnGuardarCambios').attr('disable');
	//	}
	//}
}
//ON DOCUMENT READY
$(document).ready(function () {
	const url = document.URL;
	const cedula = url.split('=');

	//Si no envían los parámetros cedula[1] queda 'undefined'.
	if ('undefined' !== typeof cedula[1]) {
		const id = cedula[1];
		let vperfilOferente = new vVerPerfilOferente();
		vperfilOferente.BindFieldsOferente(id);

		document.addEventListener('keyup', () => { vperfilOferente.validateForm() });
	} else {
		console.log('No enviaron la cédula por parámetros');
	}
});