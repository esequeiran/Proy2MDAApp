function vRegistrarMembresia() {

    this.tblMembresiasId = 'tblMembresias';
    this.service = 'Membresia';
    this.ctrlActions = new ControlActions();
    this.serviceEnviar = 'EnviarMembresias';
    this.columns = "IdMembresia,NombreMembresia,TipoMembresia,Precio,VigenciaMeses,Estado,FeeReagendar,FeeCancelar,FeeServicio,NombreEmpresa,FechaContratacion";
    this.contador = 1;
    this.cedulaEmpresa = sessionStorage.getItem('Cedula');
    this.serviceMembresiasSinExcepcion = 'MembresiaEmpresaSinExcepcion';

    this.RetrieveAll = function () {      
        var cedulaEmpresa = sessionStorage.getItem('Cedula');
        var data = { CedulaEmpresa: cedulaEmpresa };
        var stringParametro = this.ctrlActions.GetParametersString(data);
        this.ctrlActions.FillTableCambiosEvelyn(this.serviceMembresiasSinExcepcion + stringParametro, this.tblMembresiasId, false);
    }

    this.ReloadTable = function () {
        var cedulaEmpresa = sessionStorage.getItem('Cedula');
        var data = { CedulaEmpresa: cedulaEmpresa };
        var stringParametro = this.ctrlActions.GetParametersString(data);
        this.ctrlActions.FillTableCambiosEvelyn(this.serviceMembresiasSinExcepcion + stringParametro, this.tblMembresiasId, true);
    }

   
 
    this.Create = function () {
        var membresiasData = {};
        var validar = this.ctrlActions.ValidateDataForm('frmCrear');
        if (validar) {
            membresiasData = this.ctrlActions.GetDataForm('frmCrear');
            //Hace el post al create
            this.ctrlActions.PostToAPI(this.service, membresiasData);
            //Refresca la tabla
            $('#txtNombreMembresia').val('');
            $('#txtTipoMembresia').val('');
            $('#txtPrecio').val('');
            $('#txtVigenciaMeses').val('');
            $('#txtFeeReagendar').val('');
            $('#txtFeeCancelar').val('');
            $('#txtFeeServicio').val('');
        }
        this.ReloadTable();        
     }

    this.Enviar = function () {        
        var data = { CedulaEmpresa: this.cedulaEmpresa };
        var stringParametro = this.ctrlActions.GetParametersString(data);
        this.ctrlActions.GetToApiByUrlMembrecia(this.service, stringParametro);
    }

    this.EjecutarEnvioCorreo = function () {
        $('#modalEnviarMembrecias').modal('hide');
        if (sessionStorage.getItem('Cedula')) {
            var cedulaEmpresa = sessionStorage.getItem('Cedula');
            var data = { CedulaEmpresa: cedulaEmpresa };
            var stringParametro = this.ctrlActions.GetParametersString(data);
            this.ctrlActions.PostToApiParametros(this.serviceEnviar, stringParametro);
        } else {
            this.ctrlActions.ShowMessage('E', "No se puede enviar correo con membrecías sin indicar el oferente.");
        }

    }

    //Añadir símbolo dolar
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



    $("input[data-type='percent']").on({
        keyup: function () {
            formatPercent($(this));
        },
        blur: function () {
            formatPercent($(this), "blur");
        }
    });




    function formatNumberPorcentaje(n) {
        // format number 1000000 to 1,234,567
        return n.replace(/\D/g, "").replace(/\B(?=(\d{3})+(?!\d))/g, ",")
    }


    function formatPercent(input, blur) {
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
            left_side = formatNumberPorcentaje(left_side);

            // validate right side
            right_side = formatNumberPorcentaje(right_side);

            // On blur make sure 2 numbers after decimal
            if (blur === "blur") {
                right_side += "00";
            }

            // Limit decimal to only 2 digits
            right_side = right_side.substring(0, 2);

            // join number by .
            input_val = "%" + left_side + "." + right_side;

        } else {
            // no decimal entered
            // add commas to number
            // remove all non-digits
            input_val = formatNumberPorcentaje(input_val);
            input_val = "%" + input_val;

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






}

//ON DOCUMENT READY
$(document).ready(function () {
    var vregistrarMembresia = new vRegistrarMembresia();
    //$("#txtFecha").attr('disabled', 'disabled');
    vregistrarMembresia.RetrieveAll();
    if ($('#btnEnviar').length > 0) {
        $('#txtCedulaEmpresa').val(sessionStorage.getItem('Cedula'));
        $('#txtCedulaEmpresa').attr('disabled', 'disabled');
        //vregistrarMembresia.RetrieveAll();
        $("table thead:nth-child(0n+2)").addClass("d-none");
    }

});