function vListarSolicitudesTrabajoPendientesAprobadasParaOferente() {

    this.tblMembresiasId = 'tblSolicitudTrabajo';
    this.service = 'SolicitudesPendientesParaOferente';
    this.cedulaOferente = sessionStorage.getItem('IdUsuario');   
    this.serviceDetalle = 'SolicitudPendienteDetalleParaOferente?idSolDetalles=';

    this.ctrlActions = new ControlActions();
    this.columns = "NombreCliente,ExplicacionTrabajo,Presupuesto,FechaEventoS";

    mapboxgl.accessToken = 'pk.eyJ1IjoiYXVyZW9zb2Z0IiwiYSI6ImNrOHI4MG9oeDAydngzbW14d2pyemJxZngifQ.7Oe29pjYO56R3BJJ3vyjpw';
    this.map = new mapboxgl.Map({
        container: 'map',
        style: 'mapbox://styles/mapbox/streets-v11',
        center: [-84.0918343, 9.9254828], zoom: 12
    });
    this.map.addControl(new mapboxgl.NavigationControl());


    this.RetrieveAll = function () {
        this.ctrlActions.FillTableCambiosEvelyn(this.service + "?idOferente=" + this.cedulaOferente, this.tblMembresiasId, false);
    }

    this.ReloadTable = function () {
        this.ctrlActions.FillTableCambiosEvelyn(this.service + "?idOferente", this.tblMembresiasId, true);
    }

    this.AgregarTrabajadores = function () { 
        var idSol = $('#txtIdSolicitud').val();
        console.log(idSol);
        sessionStorage.removeItem('IdSolicitudAsignarTrabajador');
        sessionStorage.setItem('IdSolicitudAsignarTrabajador', idSol);
        window.location.href = "vAsignarTrabajadores";

    }


    this.BindFields = function (data) {
        
        if (sessionStorage.getItem('Idroles') == 3) {
            $('#btnAgregar').removeAttr('disabled');
        }
       
        $('#txtPresupuestoOferta').val('');

        this.ctrlActions.BindFields('frmInfoSolicitud', data);
        $('#txtPresupuestoOferta').attr('data-type', 'currency');

        $('input[data-type="currency"]').each(function (input) {
            formatCurrency($(this));
        });

        $('input[data-type="percent"]').each(function (input) {
            formatPercent($(this));
        });

        var valPresupuesto = $('#txtPresupuesto').val();

        if (valPresupuesto == '$0') {
            $('#txtPresupuestoOferta').removeAttr('placeholder');
            $('#txtPresupuestoOferta').attr('disabled', 'disabled');
            $('#txtPresupuestoOferta').attr('data-type', '');
            $('#txtPresupuestoOferta').val('');
            $('#txtPresupuestoOferta').removeAttr('IsRequired');

        }
        else {
            $('#txtPresupuestoOferta').attr('placeholder', "Ingrese un presupuesto");
            $('#txtPresupuestoOferta').removeAttr('disabled');
            $('#txtPresupuestoOferta').attr("IsRequired", "required");


        }


        this.GetSolicitudById(data['IdSolicitud']);
      
    }

    //aquí
    this.GetSolicitudById = function (idSolDetalles) {
        this.ctrlActions.GetToApi(this.serviceDetalle + idSolDetalles, (response) => {
            console.log(response.Data);
            this.llenarCampos(response.Data);
        });
    }

    this.llenarCampos = function (infoDetalleSolicitud) {
        //Info detallada solicitud
        $('.rowOcultar').show();
        $('#infoTotalSolicitud').show();
        console.log(infoDetalleSolicitud);
        $('#hNombreCliente').text("Cliente: " + infoDetalleSolicitud.NombreCliente);

        $('#liFechaCreacion').text("Fecha del trabajo: " + infoDetalleSolicitud.FechaEventoS);
        $('#liDescripcionNecesidad').text("Descripción de necesidad: " + infoDetalleSolicitud.DescripcionNecesidad);
        $('#liExplicacionTrabajo').text("Explicación del trabajo: " + infoDetalleSolicitud.ExplicacionTrabajo);
        $('#liTiposTrabajoS').text("Tipos de trabajo requeridos: " + infoDetalleSolicitud.TiposTrabajoS);
        $('#liNombreContacto').text("Nombre del contacto: " + infoDetalleSolicitud.NombreContacto);
        $('#liTelefonoContacto').text("Teléfono: " + infoDetalleSolicitud.TelefonoContacto);
        $('#liPresupuestoS').text("Presupuesto: " + infoDetalleSolicitud.PresupuestoS);
        $('#liProvincia').text("Provincia: " + infoDetalleSolicitud.Provincia);
        $('#liCanton').text("Cantón: " + infoDetalleSolicitud.Canton);
        $('#liDistrito').text("Distrito: " + infoDetalleSolicitud.Distrito);
        $('#liOtrasSennas').text("Otras señas: " + infoDetalleSolicitud.OtrasSennas);
        this.map.setCenter([infoDetalleSolicitud.Longitud, infoDetalleSolicitud.Latitud]);
        this.map.setZoom(18);


        var arregloFotos = [];
        arregloFotos = infoDetalleSolicitud.Fotos.split(',');
        var contador = 1;
        arregloFotos.forEach(agregarFotos);
        function agregarFotos(foto) {
            var node = document.createElement("img");
            node.setAttribute('src', foto);
            node.setAttribute('style', 'max-height: 300px; max-width:300px; margin: auto; display: block;');
            node.setAttribute('alt', 'foto');
            if (contador == 1) {
                document.getElementById("divFoto1").appendChild(node);
            } else if (contador == 2) {
                document.getElementById("divFoto2").appendChild(node);
            } else if (contador == 3) {
                document.getElementById("divFoto3").appendChild(node);
            }
            contador++;
        };

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

    var vlistarSolictiudes = new vListarSolicitudesTrabajoPendientesAprobadasParaOferente();
    vlistarSolictiudes.RetrieveAll();

    if (sessionStorage.getItem('Idroles') == 2) {
        $('#divBotonAgregarTrabajadores').hide();
      
    }
    $('#btnAgregar').attr('disabled', 'disabled');
    $('#divId').hide();
    $('#infoTotalSolicitud').hide();   
    $('.rowOcultar').hide();
});