function vListarSolicitudesRegistro() {
	this.tblSolicitudId = 'tblSolicitudesRegistro';
	this.service = 'Oferente';
	this.serviceEnviar = 'EnviarCorreo';
	this.ctrlActions = new ControlActions();
	this.columns = "Cedula,Nombre,TipoCedulaComercial,Telefono,Correo,NombreComercial";

	this.RetrieveAll = function () {
		this.ctrlActions.FillTable(this.service, this.tblSolicitudId, false);
	}

	this.ReloadTable = function () {
		this.ctrlActions.FillTable(this.service, this.tblSolicitudId, true);
	}


	this.AceptarSolicitud = function () {
		var aceptarData = {};
		aceptarData.IdEstado = 12;
		aceptarData.Cedula = $('#txtCedula')[0].value;
		this.ctrlActions.PutToAPI(this.service, aceptarData);
		//Sesion Storage
		sessionStorage.setItem('Cedula', $('#txtCedulaJuridica')[0].value);
		window.location.pathname = "Home/vRegistrarMembresiaYEnviarCorreo";

	}
	this.RechazarSolicitud = function () {
		var rechazarData = {};
		var infoRechazo = {};
		rechazarData.IdEstado = 14;
		rechazarData.Cedula = $('#txtCedula')[0].value;

		this.ctrlActions.PutToAPI(this.service, rechazarData);
		//Enviar correo con rechazo de solicitud
		infoRechazo.Cedula = $('#txtCedula')[0].value;
		infoRechazo.correoDestinatario = $('#txtCorreo')[0].value;
		infoRechazo.Asunto = "Solicitud de Registro";
		infoRechazo.ContenidoTextoPlano = "Su solicitud de registro ha sido rechazada";
		infoRechazo.nombreDestinatario = $('#txtNombre')[0].value;
		infoRechazo.PlantillaContenidoHtml = "";
		this.ctrlActions.PostToAPI(this.serviceEnviar, infoRechazo);




	}


	this.CrearUsuario = function () {
		var camposValidos = true;
		$('#frmEdition input[required], textarea[required]').each(function () {
			if (this.value === "") {
				camposValidos = false;
			}
		})

		if (camposValidos === false) {

			$('#modalRegistrarOferente').modal('show')
			$('#errorRegistro').text('Los campos que tiene este simbolo:(*) deben ser llenados')

			return false;
		}

		var oferenteData = {};
		oferenteData = this.ctrlActions.GetDataForm('frmEdition');

		//CAPTCHA		
		var userEnteredCaptchaCode = captcha.getUserEnteredCaptchaCode();
		var captchaId = captcha.getCaptchaId();
		//CAPTCHA

		oferenteData.userEnteredCaptchaCode = userEnteredCaptchaCode;
		oferenteData.captchaId = captchaId;

		//Hace el post al create
		this.ctrlActions.PostToAPI(this.service, oferenteData, function (success) {
			if (success) {
				$('#RegistroUsuario').css('display', 'none');
				$('#RegistroLocalizacion').css('display', 'block');

				$('#modalRegistrarOfe').modal('show')
				$('#buenRegistro').text('Sus datos han sidos registrados!')
			} else {

				captcha.reloadImage();
				$('#modalRegistrarOferente').modal('show')
				$('#errorRegistro').text('Ha ocurrido un error')
				return false;

			}
		});

	}

	this.Update = function () {

		var oferenteData = {};
		oferenteData = this.ctrlActions.GetDataForm('frmEdition');
		//Hace el post al create
		this.ctrlActions.PutToAPI(this.service, oferenteData);
		//Refresca la tabla
		this.ReloadTable();

	}

	this.Delete = function () {

		var oferenteData = {};
		oferenteData = this.ctrlActions.GetDataForm('frmEdition');
		//Hace el post al create
		this.ctrlActions.DeleteToAPI(this.service, oferenteData);
		//Refresca la tabla
		this.ReloadTable();

	}

	this.BindFieldsOferente = async function (data) {
		var result = await this.GetDataByCedula(data.Cedula);
		

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

		this.ctrlActions.BindFields('frmInformacionSolicitud', newData);
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

	var vlistarSolicitudesRegistro = new vListarSolicitudesRegistro();
	vlistarSolicitudesRegistro.RetrieveAll();


});
