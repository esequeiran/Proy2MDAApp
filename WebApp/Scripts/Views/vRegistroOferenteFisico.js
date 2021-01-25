function vRegistroOferenteFisico() {

	this.tblOFisicoId = 'tblOFisico';
	this.service = 'OferenteFisico';
	this.ctrlActions = new ControlActions();
	this.columns = "Nombre,Apellido1,Apellido2,Cedula,TipoCedula,Genero,Correo,Telefono,PaisNacimiento,FecNacimiento,NombreComercial,RazonSocial,CedulaJuridica,FecCreacion,Descripcion";

	this.RetrieveAll = function () {
		this.ctrlActions.FillTable(this.service, this.tblOFisicoId, false);
	}

	this.ReloadTable = function () {
		this.ctrlActions.FillTable(this.service, this.tblOFisicoId, true);
	}

	this.Create = function () {
		var oFisicoData = {};
		oFisicoData = this.ctrlActions.GetDataForm('frmEdition');
		//Hace el post al create
		this.ctrlActions.PostToAPI(this.service, oFisicoData);
		//Refresca la tabla
		this.ReloadTable();
	}

	this.Update = function () {

		var oFisicoData = {};
		oFisicoData = this.ctrlActions.GetDataForm('frmEdition');
		//Hace el post al create
		this.ctrlActions.PutToAPI(this.service, oFisicoData);
		//Refresca la tabla
		this.ReloadTable();

	}

	this.Delete = function () {

		var oFisicoData = {};
		oFisicoData = this.ctrlActions.GetDataForm('frmEdition');
		//Hace el post al create
		this.ctrlActions.DeleteToAPI(this.service, oFisicoData);
		//Refresca la tabla
		this.ReloadTable();

	}

	this.BindFields = function (data) {
		this.ctrlActions.BindFields('frmEdition', data);
	}
}

//ON DOCUMENT READY
$(document).ready(function () {

	var vregistroOferenteFisico = new vRegistroOferenteFisico();
	vregistroOferenteFisico.RetrieveAll();

});

