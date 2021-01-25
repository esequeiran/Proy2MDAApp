
function vTipoTrabajoPorEmpresa() {

	//TIPOS DE TRABAJO POR EMPRESA
	this.tblTipoTrabajoPorEmpresaId = 'tblTipoTrabajoPorEmpresa';
	this.service = 'TipoTrabajoPorEmpresa';//nombre igual en API
	this.ctrlActions = new ControlActions();
	this.columns = "Id_TipoTrabajo,Nombre_TipoTrabajo,Costo_Por_Hora";//cambiar a los nombre del otro lado iguales al pojo	
	this.cedulaOferente = sessionStorage.getItem('IdUsuario');
	//PRUEBA

    //funcionando
    /*
	this.RetrieveAll = function () {
        this.ctrlActions.FillTable(this.service, this.tblTipoTrabajoPorEmpresaId, false);
        var tipoTrabajoPorEmpresaData = {};
        tipoTrabajoPorEmpresaData['Cedula_Usuario'] = this.cedulaOferente;
    }
    */

    this.RetrieveAll = function () {
        this.ctrlActions.FillTableJazmin(this.service + '?idUsuario=' + this.cedulaOferente, this.tblTipoTrabajoPorEmpresaId, false, false, true);       
    }


	this.ReloadTable = function () {
        this.ctrlActions.FillTableJazmin(this.service, this.tblTipoTrabajoPorEmpresaId, true,false, true);
	}

	this.Create = function () {
		var tipoTrabajoPorEmpresaData = {};
		tipoTrabajoPorEmpresaData = this.ctrlActions.GetDataForm('frmEdition');
		tipoTrabajoPorEmpresaData['Cedula_Usuario'] = this.cedulaOferente;
		
		//console.log("tipoTrabajoPorEmpresaData");

		//Hace el post al create
		this.ctrlActions.PostToAPI(this.service, tipoTrabajoPorEmpresaData);
		//Refresca la tabla
		window.location.reload(true);
	
	}


	this.Update = function () {

		var tipoTrabajoPorEmpresaData = {};
		tipoTrabajoPorEmpresaData = this.ctrlActions.GetDataForm('frmEdition');
		//Hace el post al create
		this.ctrlActions.PutToAPI(this.service, tipoTrabajoPorEmpresaData);
		//Refresca la tabla
		//this.ctrlActions.ShowMessage('E', "No se puede enviar correo con membrecías sin indicar el oferente.");

		window.location.reload(true);
		//this.ReloadTable();
		//alert("Especialidad Actualizada con exito");

	}

	this.ConfirmarEliminar = function () {
		var tipoTrabajoPorEmpresaData = {};
		tipoTrabajoPorEmpresaData = this.ctrlActions.GetDataForm('frmEdition');
		this.ctrlActions.DeleteToAPI(this.service, tipoTrabajoPorEmpresaData);
		window.location.reload(true);
	}

	this.Delete = function () {

		$("#ready").modal();
	}

	this.BindFields = function (data) {
		this.ctrlActions.BindFields('frmEdition', data);
	}	


    //Añadir símbolo dolar---------------------------------------------------------------------------------------------------
    $("input[data-type='currency']").on({
        keyup: function () {
            formatCurrency($(this));
        },
        blur: function () {
            formatCurrency($(this), "blur");
        }
    });

    function formatNumber(n) {
        // format number 1000000 to 1,234,567
        return n.replace(/\D/g, "").replace(/\B(?=(\d{3})+(?!\d))/g, ",")
    }

    function formatCurrency(input, blur) {
        // appends $ to value, validates decimal side
        // and puts cursor back in right position.

        // get input value
        var input_val = input.val();

        // don't validate empty input
        if (input_val === "") { return; }

        // original length
        var original_len = input_val.length;

        // initial caret position 
        var caret_pos = input.prop("selectionStart");

        // check for decimal
        if (input_val.indexOf(".") >= 0) {

            // get position of first decimal
            // this prevents multiple decimals from
            // being entered
            var decimal_pos = input_val.indexOf(".");

            // split number by decimal point
            var left_side = input_val.substring(0, decimal_pos);
            var right_side = input_val.substring(decimal_pos);

            // add commas to left side of number
            left_side = formatNumber(left_side);

            // validate right side
            right_side = formatNumber(right_side);

            // On blur make sure 2 numbers after decimal
            if (blur === "blur") {
                right_side += "00";
            }

            // Limit decimal to only 2 digits
            right_side = right_side.substring(0, 2);

            // join number by .
            input_val = "$" + left_side + "." + right_side;

        } else {
            // no decimal entered
            // add commas to number
            // remove all non-digits
            input_val = formatNumber(input_val);
            input_val = "$" + input_val;

            // final formatting
            if (blur === "blur") {
                input_val += ".00";
            }
        }

        // send updated string to input
        input.val(input_val);

        // put caret back in the right position
        var updated_len = input_val.length;
        caret_pos = updated_len - original_len + caret_pos;
        input[0].setSelectionRange(caret_pos, caret_pos);
    }
    //-----------------------------------------------------------------------------------------------------------------------
}

//ON DOCUMENT READY
$(document).ready(function () {

	var vtipoTrabajoPorEmpresa = new vTipoTrabajoPorEmpresa();
	vtipoTrabajoPorEmpresa.RetrieveAll();
	$("#txtIdNumber").attr('disabled', 'disabled');
	//$("#txtNombreTipoTrabajo").attr('disabled', 'disabled');
});



