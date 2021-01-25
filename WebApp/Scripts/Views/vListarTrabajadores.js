function vListarTrabajadores() {
	this.tblTrabajadoresId = 'tblTrabajadores';
	var id = sessionStorage.getItem('IdEmpresa');
	this.service = 'Trabajador?idEmpresa=' + id;//nombre igual en API
	this.serviceUpd = 'Trabajador';//nombre igual en API
	this.cambioEstado = 'CambioEstado';//nombre igual en API
	this.ctrlActions = new ControlActions();
	this.columns = "Cedula,Nombre,Apellido1,Apellido2,FecNacimiento,Genero,Correo,IdEstado,IdEmpresa";

	this.RetrieveAll = function () {
		this.ctrlActions.FillTable(this.service, this.tblTrabajadoresId, false);
	}

	this.ReloadTable = function () {
		this.ctrlActions.FillTable(this.service, this.tblTrabajadoresId, true);
	}

	this.Update = function () {

		var trabajadorData = {};
		trabajadorData = this.ctrlActions.GetDataForm('frmTrabajador');
		var data = {};
		data.Nombre = trabajadorData.Nombre;
		data.Apellido1 = trabajadorData.Apellido1;
		data.Apellido2 = trabajadorData.Apellido2;
		data.Correo = trabajadorData.Correo;
		data.Cedula = trabajadorData.Cedula;
		this.ctrlActions.PutToAPI(this.serviceUpd, data);

	}
	this.Activar = function () {

		var trabajadorData = {};
		trabajadorData = this.ctrlActions.GetDataForm('frmTrabajador');
		var data = {};
		data.Cedula = trabajadorData.Cedula;
			data.IdEstado = "Activar";

		this.ctrlActions.PutToAPI(this.cambioEstado, data);

	}

	this.Suspender = function () {

		var trabajadorData = {};
		trabajadorData = this.ctrlActions.GetDataForm('frmTrabajador');
		var data = {};
		data.Cedula = trabajadorData.Cedula;
		data.IdEstado = "Suspender";

		this.ctrlActions.PutToAPI(this.cambioEstado, data);

	}




	this.BindFields = function (data) {
		var d = data.FecNacimiento.toString();
		var sd = d.split('T');
		
		data.FecNacimiento = sd[0];
		//Revisar
		sessionStorage.setItem('Estado', data.IdEstado);

		this.ctrlActions.BindFields('frmTrabajador', data);

		if (sessionStorage.getItem('Estado') == "Activo") {
			$('#btnSuspender').prop("disabled", false);
			$('#btnSuspender').removeAttr('disable');
		}
		if (sessionStorage.getItem('Estado') == "Suspendido") {
			$('#btnActivar').prop("disabled", false);
			$('#btnActivar').removeAttr('disable');
		}
	}


	this.validateForm = function () {
		var esValido = true;
		var listaCampos = ["#txtNombre", "#txtApellido1", "#txtApellido2", "#txtCorreo", "#txtCedula"];
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
			$('#btnUpdate').prop("disabled", false);
			$('#btnUpdate').removeAttr('disable');
		} else {
			$('#btnUpdate').prop("disabled", true);
			$('#btnUpdate').attr('disable');
		}
	}
}

//ON DOCUMENT READY
$(document).ready(function () {

	var vlistarTrabajadores = new vListarTrabajadores();
	vlistarTrabajadores.RetrieveAll();
	document.addEventListener('keyup', () => { vlistarTrabajadores.validateForm() });
	sessionStorage.removeItem("Estado");
	$('#btnActivar').prop("disabled", true);
	$('#btnActivar').attr('disable');
	$('#btnSuspender').prop("disabled", true);
	$('#btnSuspender').attr('disable');

});

