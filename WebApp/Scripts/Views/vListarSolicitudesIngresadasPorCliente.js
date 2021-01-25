function redirigirVer2() {
    
    var table = $('#tblSolicitudTrabajoIngresadas').DataTable();

    $('#tblSolicitudTrabajoIngresadas tbody').on('click', 'tr', function () {
        var data = table.row(this).data();
        window.location.href = "vAceptarOfertaPorCliente?IdSolVer=" + data.IdSolicitud;
    });

}

function vListarSolicitudesIngresadasPorCliente() {
    
   
    this.tblSol = 'tblSolicitudTrabajoIngresadas';
    this.service = 'SolicitudDeTrabajo';
    this.cedulaCliente = sessionStorage.getItem('IdUsuario');   

    this.ctrlActions = new ControlActions();
    this.columns = "ExplicacionTrabajo,Presupuesto,NombreEstado,FechaEventoS,CantidadOfertas";

    this.RetrieveAll = function () {
        this.ctrlActions.FillTableCambiosEvelyn(this.service + "?idCliente=" + this.cedulaCliente, this.tblSol, false);
    }

    this.ReloadTable = function () {
        this.ctrlActions.FillTableCambiosEvelyn(this.service + "?idCliente=" + this.cedulaCliente, this.tblSol, true);
    }

    this.BindFields = function(data) {
        console.log(data.CantidadOfertas);
        id = data.IdSolicitud;
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


}

//ON DOCUMENT READY
$(document).ready(function () {

    var vlistarSolictiudes = new vListarSolicitudesIngresadasPorCliente();
    vlistarSolictiudes.RetrieveAll();


    //var table = $('#tblSolicitudTrabajoIngresadas').DataTable();

    //$('#tblSolicitudTrabajoIngresadas tbody tr').on('click', 'td', function () {
    //    var data = table.row(this).data();
    //    console.log(data);
    //    alert();
    //    //vlistarSolictiudes.BindFieldsOferta(data);
    //});

    //$("#tblSolicitudTrabajoIngresadas tbody").find("div").click(function () {
    //    var data = table.row(this).data();
    //    alert(data);
    //});
});


