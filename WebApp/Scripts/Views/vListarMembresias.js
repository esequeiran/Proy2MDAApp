function vListarMembresias() {

    this.tblMembresiasId = 'tblMembresias';
    this.service = 'Membresia';
    this.ctrlActions = new ControlActions();
    this.columns = "IdMembresia,NombreMembresia,TipoMembresia,Precio,VigenciaMeses,Estado,FeeReagendar,FeeCancelar,FeeServicio,NombreEmpresa,FechaContratacion";

    this.RetrieveAll = function () {
        this.ctrlActions.FillTableCambiosEvelyn(this.service, this.tblMembresiasId, false);
    }

    this.ReloadTable = function () {
        this.ctrlActions.FillTableCambiosEvelyn(this.service, this.tblMembresiasId, true);
    }

    this.Create = function () {
        var membresiasData = {};
        membresiasData = this.ctrlActions.GetDataForm('frmCreate');
        //Hace el post al create
        this.ctrlActions.PostToAPI(this.service, membresiasData);
        //Refresca la tabla
        this.ReloadTable();
    }

    this.Update = function () {
        var membresiasData = {};
        membresiasData = this.ctrlActions.GetDataForm('frmEdicion');
        //Hace el post al create   
        var validar = this.ctrlActions.ValidateDataForm('frmEdicion');
        if (validar) {
            membresiasData = this.ctrlActions.GetDataForm('frmEdicion');
            //Hace el post al create
            this.ctrlActions.PutToAPI(this.service, membresiasData);
            //Refresca la tabla
            $('#txtNombreMembresia').val('');
            $('#txtTipoMembresia').val('');
            $('#txtPrecio').val('');
            $('#txtVigenciaMeses').val('');
            $('#txtFeeReagendar').val('');
            $('#txtFeeCancelar').val('');
            $('#txtFeeServicio').val('');
            $('#txtCedulaEmpresa').val('');
            $("#txtFechaContratacion").val('');
            $("#txtIdMembresia").val('');
            $("#txtNombreEmpresa").val('');
            $("#txtEstado").val('');
            this.ReloadTable();

        }

    }
    this.Delete = function () {
        $("#parrafoModalEliminarMembresia").html('¿Desea eliminar el registro?');
    }

    this.ConfirmarEliminar = function () {
        var membresiasData = {};
        membresiasData = this.ctrlActions.GetDataForm('frmEdicion');

        membresiasData = this.ctrlActions.GetDataForm('frmEdicion');
        //Hace el post al create
        this.ctrlActions.DeleteToAPI(this.service, membresiasData);
        //Refresca la tabla
        $('#txtNombreMembresia').val('');
        $('#txtTipoMembresia').val('');
        $('#txtPrecio').val('');
        $('#txtVigenciaMeses').val('');
        $('#txtFeeReagendar').val('');
        $('#txtFeeCancelar').val('');
        $('#txtFeeServicio').val('');
        $('#txtCedulaEmpresa').val('');
        $("#txtFechaContratacion").val('');
        $("#txtIdMembresia").val('');
        $("#txtNombreEmpresa").val('');
        $("#txtEstado").val('');
        this.ReloadTable();
        $("#modalEliminarMembresia").modal('hide');


    }

    //this.ParamUrl = function(){
    //    let get_param = (param) => {
    //        let url_string = window.location.href;
    //        let url = new URL(url_string);
    //        let id = url.searchParams.get(param);//Toma el parámetro id_inmueble del url y retorna el valor
    //        return id;
    //    };
    //    let _id = get_param('Cedula');
    //    console.log(_id)
    //}

    this.BindFields = function (data) {
        this.ctrlActions.BindFields('frmEdicion', data);

        $('input[data-type="currency"]').each(function (input) {
            formatCurrency($(this));
        });

        $('input[data-type="percent"]').each(function (input) {
            formatPercent($(this));
        });
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

    //Añadir símbolo %
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
            right_side = right_side.substring(0, 3);

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

    var vlistarMembresias = new vListarMembresias();
    vlistarMembresias.RetrieveAll();
    //$('thead tr th:first-child').hide();
    $('#divId').hide();
    $("#txtIdMembresia").attr('disabled', 'disabled');
    $("#txtNombreEmpresa").attr('disabled', 'disabled');
    $("#txtFechaContratacion").attr('disabled', 'disabled');
    $("#txtEstado").attr('disabled', 'disabled');
    //$("#txtFecha").attr('disabled', 'disabled');

});