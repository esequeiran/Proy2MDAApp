
function vTerminosCondiciones() {

	//VERSION NUEVA
	this.tblTerminosCondicionesId = 'tblTerminosCondiciones';
	this.service = 'TerminosCondiciones';//nombre igual en API
	this.ctrlActions = new ControlActions();
	this.columns = "Terminos,Id_Parametro,Descripcion";//cambiar a los nombre del otro lado iguales al pojo

	this.RetrieveAll = function () {
		//this.ctrlActions.FillTable(this.service, this.tblTerminosCondicionesId, false);
		this.ctrlActions.GetToApi(this.service, new vTerminosCondiciones().FillTextArea);
	}

	this.FillTextArea = function (data) {
		if (data)
			$("#txtTerminos").text(data.Data[0].Terminos);
	}
	   
	this.Update = function () {
		var terminosTexto = $("#txtTerminos").val();
		var terminosData = { "Id_Parametro": 0, "Terminos": terminosTexto, "Descripcion": ""};
		
		this.ctrlActions.PutToAPI(this.service, terminosData);
	
		window.location.reload(true);
	}
}

//ON DOCUMENT READY
$(document).ready(function () {

	var vTerminos = new vTerminosCondiciones();
	vTerminos.RetrieveAll();

	$('btnUpdate').on('click', function (e) {
		vTerminos.Update();
	});

});

