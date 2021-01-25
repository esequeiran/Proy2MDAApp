
function vTipoTrabajo() {

	this.tblTipoTrabajoId = 'tblTipoTrabajo';
	this.service = 'TipoDeTrabajo';//nombre igual en API
	this.ctrlActions = new ControlActionsAdrian();	
	this.columns = "Id_TipoTrabajo,Nombre_TipoTrabajo,Nombre_Especialidad";//cambiar a los nombre del otro lado iguales al pojo

	//Id_TipoTrabajo,Nombre_TipoTrabajo,Id_Estado,Id_Especialidad 
	
	this.RetrieveAll = function () {
		this.ctrlActions.FillTableTipoTrabajo(this.service, this.tblTipoTrabajoId, false);
	}

	this.ReloadTable = function () {
		this.ctrlActions.FillTableTipoTrabajo(this.service, this.tblTipoTrabajoId, true);
	}

	this.Create = function () {
		var tipoTrabajoData = {};
		tipoTrabajoData = this.ctrlActions.GetDataForm('frmEdition');

		//Hace el post al create
		this.ctrlActions.PostToAPI(this.service, tipoTrabajoData);
		//Refresca la tabla
		window.location.reload(true);
		//this.ReloadTable();
		//alert("TipoTrabajo registrado con exito");


	}

	this.Update = function () {

		var tipoTrabajoData = {};
		tipoTrabajoData = this.ctrlActions.GetDataForm('frmEdition');
		//Hace el post al create
		this.ctrlActions.PutToAPI(this.service, tipoTrabajoData);
		//Refresca la tabla
		window.location.reload(true);
		//this.ReloadTable();
		//alert("TipoTrabajo Actualizado con exito");

	}

	//nuevo 4/22/2020
	this.ConfirmarEliminar = function () {
		var customerData = {};
		customerData = this.ctrlActions.GetDataForm('frmEdition');
		this.ctrlActions.DeleteToAPI(this.service, customerData);
		window.location.reload(true);
	}


	this.Delete = function () {

		$("#ready").modal();
	}

	this.BindFields = function (data) {
		this.ctrlActions.BindFields('frmEdition', data);
	}

	//nuevo 4/22/2020	
}

//ON DOCUMENT READY
$(document).ready(function () {

	var vtipotrabajo = new vTipoTrabajo();
	vtipotrabajo.RetrieveAll();
	$("#txtidTipoTrabajo").attr('disabled', 'disabled');
	$("#txtIdEstado").attr('disabled', 'disabled');

});


//#################################################################################################################################################
//#################################################################################################################################################
//#################################################################################################################################################

/*
function vTipoTrabajo() {

	this.tblTipoTrabajoId = 'tblTipoTrabajo';
	this.service = 'TipoDeTrabajo';//nombre igual en API
	this.ctrlActions = new ControlActions();
	this.columns = "Id_TipoTrabajo,Nombre_TipoTrabajo,Nombre_Especialidad";//cambiar a los nombre del otro lado iguales al pojo


	//Id_TipoTrabajo,Nombre_TipoTrabajo,Id_Estado,Id_Especialidad 

	this.RetrieveAll = function () {
		this.ctrlActions.FillTable(this.service, this.tblTipoTrabajoId, false);
	}

	this.ReloadTable = function () {
		this.ctrlActions.FillTable(this.service, this.tblTipoTrabajoId, true);
	}

	this.Create = function () {
		var tipoTrabajoData = {};
		tipoTrabajoData = this.ctrlActions.GetDataForm('frmEdition');

		//Hace el post al create
		this.ctrlActions.PostToAPI(this.service, tipoTrabajoData);
		//Refresca la tabla
		window.location.reload(true);
		//this.ReloadTable();
		//alert("TipoTrabajo registrado con exito");


	}

	this.Update = function () {

		var tipoTrabajoData = {};
		tipoTrabajoData = this.ctrlActions.GetDataForm('frmEdition');
		//Hace el post al create
		this.ctrlActions.PutToAPI(this.service, tipoTrabajoData);
		//Refresca la tabla
		window.location.reload(true);
		//this.ReloadTable();
		//alert("TipoTrabajo Actualizado con exito");

	}

	this.Delete = function () {

		var tipoTrabajoData = {};
		tipoTrabajoData = this.ctrlActions.GetDataForm('frmEdition');


		//modal
		//DELETE ACTION
		$('.btn-primary').on('click', (e) => {


			//delete
			this.ctrlActions.DeleteToAPI(this.service, tipoTrabajoData);
			window.location.reload(true);
		})

		$("#ready").modal();

		//Hace el post al create
		//this.ctrlActions.DeleteToAPI(this.service, tipoTrabajoData);
		//Refresca la tabla
		//window.location.reload(true);
		//this.ReloadTable();
		//alert("TipoTrabajo Eliminado con exito");

	}

	this.BindFields = function (data) {
		this.ctrlActions.BindFields('frmEdition', data);
	}
}

//ON DOCUMENT READY
$(document).ready(function () {

	var vtipotrabajo = new vTipoTrabajo();
	vtipotrabajo.RetrieveAll();
	$("#txtidTipoTrabajo").attr('disabled', 'disabled');
	$("#txtIdEstado").attr('disabled', 'disabled');

});

*/