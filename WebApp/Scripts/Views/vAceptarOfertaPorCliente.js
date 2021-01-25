function redirigirVer2() {

    var table = $('#tblSolicitudTrabajoIngresadas').DataTable();

    $('#tblSolicitudTrabajoIngresadas tbody').on('click', 'tr', function () {
        var data = table.row(this).data();
        window.location.href = "vListarLocalizaciones?IdSolVer=" + data.IdSolicitud;
    });

}

function vAceptarOfertaPorCliente() {

    //this.btn = document.getElementById('aceptarOfertaBtnModal');
    //btn.addEventListener('click', () => { this.redireccionar() });
    this.tblOfertas = 'tblOfertas';
    this.service = 'OfertaASolicitudDeTrabajo';
    this.serviceAceptar = 'AceptarOfertaASolicitud';
    var url_string = window.location.href;
    var url = new URL(url_string);    
    this.idSol = url.searchParams.get('IdSolVer');

    this.ctrlActions = new ControlActions();
    this.columns = "NombreEmpresa,PresupuestoOferta,Fecha";

    this.RetrieveAll = function () {
        this.ctrlActions.FillTableCambiosEvelyn(this.service + "?idSolicitudOferta=" + this.idSol, this.tblOfertas, false);
    }

    this.ReloadTable = function () {
        this.ctrlActions.FillTableCambiosEvelyn(this.service + "?idSolicitudOferta=" + this.idSol, this.tblOfertas, true);
    }

    this.AceptarOferta = function () {
        var idOfertaAcepta = $('#txtIdOferta').val();
        var oferta = {};
        oferta["IdOferta"] = idOfertaAcepta;
        oferta["IdSolicitud"] = this.idSol;
        console.log(oferta);
        this.PostToAPIOferta(oferta);       

    }


    this.PostToAPIOferta = function (data, callback = undefined) {
        var jqxhr = $.post("http://localhost:61079/api/" + this.serviceAceptar, data, function (response) {
            var ctrlActions2 = new ControlActions();
            ctrlActions2.ShowMessage('I', response.Message);
            if (sessionStorage.getItem('IdUsuario')) {
                ctrlActions2.PostToApiParametrosBitacora('Registrar', this.service);
            }
            if (callback != undefined) {
                callback(true);
            }
            $("#ready").modal();
            $('#btnCerrar').hide();

        })
            .fail(function (response) {
                var data = response.responseJSON;
                var ctrlActions3 = new ControlActions();
                ctrlActions3.ShowMessage('E', data.ExceptionMessage);
                console.log(data);
                if (callback != undefined) {
                    callback(false);
                }
            })
    };


    this.redireccionar = function() {
        window.location.href = 'vIndexInterno';
    }



    this.BindFields = function (data) {
        $('#btnAceptar').removeClass('disabled', 'disabled');
        $('#txtIdOferta').val(data.IdOferta);
        var id = $('#txtIdOferta').val();
        console.log(id);
        $('#infoTotalOferta').show();
        $('#hNombreEmpresa').text("Empresa: "+data.NombreEmpresa);
        console.log(data.PresupuestoOferta);
      
        $('#liFechaCreacion').text("Fecha de creación: " + data.Fecha);

        if (data.PresupuestoOferta == 0) {
            $('#liPresupuesto').text("Presupuesto: no aplica");
        

            data.TiposDeTrabajo.forEach(agregarTipos);

            function agregarTipos(tt) {
                var node = document.createElement("LI");
                var textnode = document.createTextNode(tt.Nombre_TipoTrabajo + " $" + tt.Costo_Por_Hora +"/hra");
                node.appendChild(textnode);
                node.setAttribute("class","list-group-item");
                document.getElementById("ulList").appendChild(node);
            }
        } else {
            $('#liPresupuesto').text("Presupuesto: $" +data.PresupuestoOferta);
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
    var vlistarOfertas = new vAceptarOfertaPorCliente();
    vlistarOfertas.RetrieveAll();
    $('#infoTotalOferta').hide();
    $('#divId').hide();
    $('#btnAceptar').addClass('disabled', 'disabled');
});


