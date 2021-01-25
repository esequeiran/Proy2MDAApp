
function vEspecialidad() {

	//VERSION NUEVA
	this.tblEspecialidadId = 'tblEspecialidad';
	this.service = 'Especialidad';//nombre igual en API
	this.ctrlActions = new ControlActionsAdrian();
	
	this.columns = "Id_Number,Nombre_Especialidad,Nombre_Estado";//cambiar a los nombre del otro lado iguales al pojo
	
	this.RetrieveAll = function () {
		this.ctrlActions.FillTable(this.service, this.tblEspecialidadId, false);
	}

	this.ReloadTable = function () {
		this.ctrlActions.FillTable(this.service, this.tblEspecialidadId, true);
	}

	this.Create = function () {
		let self = this;
		var customerData = {};
		customerData = self.ctrlActions.GetDataForm('frmEdition');		

		//Hace el post al create
		self.ctrlActions.PostToAPI(self.service, customerData, function (isSuccess) {
			if ("boolean" == typeof isSuccess && true == isSuccess) {
				//window.location.reload(true);
				self.ReloadTable();			
				
				window.location.reload(true);
				// limpia el formulario				
			}	
		});
	}


	this.Update = function () {

		var customerData = {};
		customerData = this.ctrlActions.GetDataForm('frmEdition');
		//Hace el post al create
		this.ctrlActions.PutToAPI(this.service, customerData);
		//Refresca la tabla
		//this.ctrlActions.ShowMessage('E', "No se puede enviar correo con membrecías sin indicar el oferente.");
		
		window.location.reload(true);
		//this.ReloadTable();
		//alert("Especialidad Actualizada con exito");

	}

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
}

//nuevo
function checkInputs() {
	
	const especialidadValue = txtNombreEspecialidad.value.trim();
}

//ON DOCUMENT READY
$(document).ready(function () {

	var vespecialidad = new vEspecialidad();
	vespecialidad.RetrieveAll();
	$("#txtIdNumber").attr('disabled', 'disabled');

});

