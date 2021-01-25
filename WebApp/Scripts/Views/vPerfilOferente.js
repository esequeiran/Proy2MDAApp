function vPerfilOferente() {
	this.service = 'ModificarPerfilOferente';
	this.ctrlActions = new ControlActions();


	this.AceptarCambios = function () {
		var aceptarData = {};
		aceptarData.Cedula = $('#txtCedula')[0].value;
		aceptarData.Nombre = $('#txtNombre')[0].value;
		aceptarData.Apellido1 = $('#txtApellido1')[0].value;
		aceptarData.Apellido2 = $('#txtApellido2')[0].value;
		aceptarData.Telefono = $('#txtTelefono')[0].value;
		aceptarData.Descripcion = $('#txtDescripcion')[0].value;
		this.ctrlActions.PutToAPI(this.service, aceptarData);

	}

	this.BindFieldsOferente = async function (data) {
		var result = await this.GetDataByCedula(data);
		if (result.Data.Oferente.TipoCedulaComercial == 'Fisico') {
			$('#tituloU').css('display', 'block');
			$('#RegistrarTrabajadores').css('display', 'none');
			$('#ListarTrabajadores').css('display', 'none');
		}
		if (result.Data.Oferente.TipoCedulaComercial == 'Juridico') {
			$('#tituloR').css('display', 'block');

		}

		var fecC = new Date(result.Data.Oferente.FecCreacion);
		var fecN = new Date(result.Data.Oferente.FecNacimiento);
		var nombreL = result.Data.Localizacion.Nombre;
		var nombreO = result.Data.Oferente.Nombre;

		var newData = $.extend({}, result.Data.Oferente, result.Data.Localizacion);
		newData.FecCreacion = fecC.getMonth() + '/' + fecC.getDate() + '/' + fecC.getFullYear();
		newData.FecNacimiento = fecN.getMonth() + '/' + fecN.getDate() + '/' + fecN.getFullYear();
		newData.NombreLocalizacion = nombreL;
		newData.Nombre = nombreO;

		newData.IdDocumento1 = result.Data.Documentos[0].IdDocumento;
		newData.IdDocumento2 = result.Data.Documentos[1].IdDocumento;

		

		this.ctrlActions.BindFields('frmOferente', newData);
		sessionStorage.setItem('IdEmpresa', $('#txtCedulaJuridica').val());
	}

	this.GetDataByCedula = function (cedula) {
		return $.ajax({
			url: 'http://localhost:61079/api/Oferente?idUsuario=' + cedula,
			type: 'GET',
			contentType: 'application/json'
		});
	}

	this.validateForm = function () {
		var esValido = true;
		var listaCampos = ["#txtNombre", "#txtApellido1","#txtApellido2","#txtTelefono", '#txtDescripcion'];		
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
					$(campo).removeClass('is-invalid');
					$(campo).addClass('is-valid');
					$(campo + '_val').removeClass('text-muted');
					$(campo + '_val').removeClass('invalid-feedback');
					$(campo + '_val').addClass('d-none');
				}
			}
		});

		
		if (esValido) {
			$('#btnGuardarCambios').prop("disabled", false);
			$('#btnGuardarCambios').removeAttr('disable');
		} else {
			$('#btnGuardarCambios').prop("disabled", true);
			$('#btnGuardarCambios').attr('disable');
		}
	}
}
//ON DOCUMENT READY
$(document).ready(function () {
	var id = sessionStorage.getItem('IdUsuario');
	var vperfilOferente = new vPerfilOferente();
	vperfilOferente.BindFieldsOferente(id);

	document.addEventListener('keyup', () => { vperfilOferente.validateForm() });

});