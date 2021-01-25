function vAsignarTrabajadores() {
	this.tblTrabajadoresId = 'tblTrabajadoresDisponibles';
	this.tblTrabajadoresA = 'tblTrabajadoresAsignados';
	var idEmpresa = sessionStorage.getItem('IdEmpresa');
	var idSolicitud = sessionStorage.getItem('IdSolicitudAsignarTrabajador');
	this.service = 'TrabajadoresDisponibles?idEmpresa=' + idEmpresa;
	//this.serviceUpd = 'Trabajador';
	this.asignar = 'AsignarTrabajador';
	this.eliminar = 'http://localhost:61079/api/Eliminar';
	this.asignados = 'TrabajadoresAsignados?idSolicitud='+ idSolicitud;
	this.ctrlActions = new ControlActions();
	this.columns = "Cedula,Nombre,Apellido1,Apellido2,FecNacimiento,Genero,Correo,IdEmpresa";

	this.RetrieveAll = function () {
		this.ctrlActions.FillTable(this.service, this.tblTrabajadoresId, false);
	}

	this.ReloadTable = function () {
		this.ctrlActions.FillTable(this.asignados, this.tblTrabajadoresA, true);
	}

	this.RetrieveAsignados = function () {
		this.ctrlActions.FillTable(this.asignados, this.tblTrabajadoresA, false);
	}







	this.ActivarBoton = function () {

		$('#btnAsignar').prop("disabled", false);
		$('#btnAsignar').removeAttr('disable');
	}

	this.EliminarBoton = function () {

		$('#btnEliminar').prop("disabled", false);
		$('#btnEliminar').removeAttr('disable');
	}

	this.Asignar = function () {
		var dataInfo = $('#tblTrabajadoresDisponibles').DataTable().row('.selected').data();
		var trabajador = {};
		trabajador.Cedula = dataInfo.Cedula;
		trabajador.IdSolicitud = idSolicitud;

		var asignado = false;

		$('#tblTrabajadoresAsignados tr.odd, #tblTrabajadoresAsignados tr.even').each(function (indice, elemento) {
			if ($(elemento.children[0]).text() == trabajador.Cedula) {
				asignado = true
			}
		});

		if (asignado == false) {
			this.ctrlActions.PostToAPI(this.asignar, trabajador, function (success) {

				if (success) {
					var vasignarTrabajadores = new vAsignarTrabajadores();
					vasignarTrabajadores.ReloadTable();
				}
			});
		} else {
			var ctrlActions = new ControlActions();
			ctrlActions.ShowMessage('E', 'El trabajador ya ha sido asignado');

		}
	}

	this.Eliminar = function () {
		var dataInfo = $('#tblTrabajadoresAsignados').DataTable().row('.selected').data();
		var trabajador = {};
		trabajador.Cedula = dataInfo.Cedula;
		trabajador.IdSolicitud = idSolicitud;

		$.delete(this.eliminar, trabajador, function (success) {
			if (success) {
				var vasignarTrabajadores = new vAsignarTrabajadores();
				vasignarTrabajadores.ReloadTable();
				var ctrlActions = new ControlActions();
				ctrlActions.ShowMessage('I', response.Message);
				ctrlActions.PostToApiParametrosBitacora('Eliminar', service);

			}
		});



	}



	$.delete = function (url, data, callback) {
		if ($.isFunction(data)) {
			type = type || callback,
				callback = data,
				data = {}
		}
		return $.ajax({
			url: url,
			type: 'DELETE',
			success: callback,
			data: JSON.stringify(data),
			origin: 'http://localhost:61079',
			contentType: 'application/json'
		});
	}

	this.GetCedula = async function (id) {
		var result = await this.GetDataByCedula(id);
		sessionStorage.setItem('IdEmpresa', result.Data.Oferente.CedulaJuridica);
	}
	this.GetDataByCedula = function (cedula) {
		return $.ajax({
			url: 'http://localhost:61079/api/Oferente?idUsuario=' + cedula,
			type: 'GET',
			contentType: 'application/json'
		});
	}



}





//ON DOCUMENT READY
$(document).ready(function () {



	var vasignarTrabajadores = new vAsignarTrabajadores();
	var id = sessionStorage.getItem('IdUsuario');
	vasignarTrabajadores.GetCedula(id);
	vasignarTrabajadores.RetrieveAll();
	vasignarTrabajadores.RetrieveAsignados();
	$('#btnAsignar').prop("disabled", true);
	$('#btnAsignar').attr('disable');
	$('#btnEliminar').prop("disabled", true);
	$('#btnEliminar').attr('disable');


});

