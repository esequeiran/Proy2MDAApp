function vRegistroOferenteJuridico() {

	this.tblOJuridicoId = 'tblOJuridico';
	this.service = 'OferenteJuridico';
	this.ctrlActions = new ControlActions();
	this.columns = "Nombre,Apellido1,Apellido2,Cedula,TipoCedula,Genero,Correo,Telefono,PaisNacimiento,FecNacimiento,NombreComercial,RazonSocial,CedulaJuridica,FecCreacion,Descripcion";

	this.RetrieveAll = function () {
		this.ctrlActions.FillTable(this.service, this.tblOJuridicoId, false);
	}

	this.ReloadTable = function () {
		this.ctrlActions.FillTable(this.service, this.tblOJuridicoId, true);
	}

	this.Create = function () {
		var oJuridicoData = {};
		oJuridicoData = this.ctrlActions.GetDataForm('frmEdition');
		//Hace el post al create
		this.ctrlActions.PostToAPI(this.service, oJuridicoData);
		//Refresca la tabla
		this.ReloadTable();
	}

	this.Update = function () {

		var oJuridicoData = {};
		oJuridicoData = this.ctrlActions.GetDataForm('frmEdition');
		//Hace el post al create
		this.ctrlActions.PutToAPI(this.service, oJuridicoData);
		//Refresca la tabla
		this.ReloadTable();

	}

	this.Delete = function () {

		var oJuridicoData = {};
		oJuridicoData = this.ctrlActions.GetDataForm('frmEdition');
		//Hace el post al create
		this.ctrlActions.DeleteToAPI(this.service, oJuridicoData);
		//Refresca la tabla
		this.ReloadTable();

	}

	this.BindFields = function (data) {
		this.ctrlActions.BindFields('frmEdition', data);
	}
}

//ON DOCUMENT READY
$(document).ready(function () {

	var vregistroOferenteJuridico = new vRegistroOferenteJuridico();
	vregistroOferenteJuridico.RetrieveAll();

});

