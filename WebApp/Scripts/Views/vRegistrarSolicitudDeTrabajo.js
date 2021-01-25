var CLOUDINARY_URL = 'https://api.cloudinary.com/v1_1/dc8lacq7g/upload';
var CLOUDINARY_UPLOAD_PRESET = 'u86aylh2';

var archivoF1 = document.getElementById('F1');
var archivoF2 = document.getElementById('F2');
var archivoF3 = document.getElementById('F3');

var datosArchivoF1 = {};
var datosArchivoF2 = {};
var datosArchivoF3 = {};



if (archivoF1) {
    archivoF1.addEventListener('change', function (event) {
        var file = event.target.files[0];
        var formData = new FormData();
        formData.append('file', file);
        formData.append('upload_preset', CLOUDINARY_UPLOAD_PRESET);
        console.log(file);
        $.ajax({
            url: CLOUDINARY_URL,
            type: 'POST',
            data: formData,
            contentType: false,
            processData: false,
            success: function (res) {
                console.log(res);
                datosArchivoF1 = res;
                $("#foto1").text(res.original_filename);
            }
        })
    })
}


if (archivoF2) {
    archivoF2.addEventListener('change', function (event) {
        var file = event.target.files[0];
        var formData = new FormData();
        formData.append('file', file);
        formData.append('upload_preset', CLOUDINARY_UPLOAD_PRESET);
        console.log(file);
        $.ajax({
            url: CLOUDINARY_URL,
            type: 'POST',
            data: formData,
            contentType: false,
            processData: false,
            success: function (res) {
                console.log(res);
                datosArchivoF2 = res;
                $("#foto2").text(res.original_filename);
            }
        })
    })
}


if (archivoF3) {
    archivoF3.addEventListener('change', function (event) {
        var file = event.target.files[0];
        var formData = new FormData();
        formData.append('file', file);
        formData.append('upload_preset', CLOUDINARY_UPLOAD_PRESET);
        console.log(file);
        $.ajax({
            url: CLOUDINARY_URL,
            type: 'POST',
            data: formData,
            contentType: false,
            processData: false,
            success: function (res) {
                console.log(res);
                datosArchivoF3 = res;
                $("#foto3").text(res.original_filename);
            }
        })
    })
}

function vRegistrarSolicitudDeTrabajo() {

    this.service = 'SolicitudDeTrabajo';
    this.ctrlActions = new ControlActions();
    this.cedulaCliente = sessionStorage.getItem('IdUsuario');   
    this.datosArchivos = [];

    this.sltLocalizaciones = document.getElementById('sltLocalizaciones');

    this.getLocalizaciones = function () {
        this.ctrlActions.GetToApi("List/Localizaciones?identificacion=" + this.cedulaCliente, (response) => {
            console.log(response);
            
            var localizacionesRegistradas = response;
            console.log(localizacionesRegistradas);
            this.sltLocalizaciones.options.add(new Option("--Seleccione una opción--", "default0"));
            for (const loca of localizacionesRegistradas) {
                this.sltLocalizaciones.options.add(new Option(loca.Description, loca.Value));
            }
          
        });
    }

    this.Create = function () {
        var solicitudData = {};
        var validar = this.validarCampos();
        if (validar) {
   
            solicitudData = this.GetDataForm();
            console.log(solicitudData);
            this.ctrlActions.PostToAPI(this.service, solicitudData);
            $('#txtNombreContacto').val('');
            $('#txtTelefono').val('');
            $('#txtPresupuesto').val('');
            $('#txtFecEvento').val('');
            $('#F1').val(null);
            $('#F2').val(null);
            $('#F3').val(null);
            $('#foto1').text('Seleccionar archivo');
            $('#foto2').text('Seleccionar archivo');
            $('#foto3').text('Seleccionar archivo');
            $('#selTiposTrabajo').val('');
            $('#sltLocalizaciones').val('');
            $('#txtADescripcionNecesidad').val('');
            $('#txtAExplicacionTrabajo').val('');
           
        }
    }

    this.validarCampos = function () {
        var valido = true;
        var formId = "frmCrearSolicitud";

        $("#alert_container").hide();

        $('#' + formId + ' *').filter(':input').each(function (input) {
            $(this).removeClass('is-invalid');

            if ($(this).attr("type") === 'number' && this.value < 0) {
                $(this).addClass('is-invalid');
                valido = false;
            }
            if ($(this).attr("IsRequired") === "required" && this.value === "") {
                $(this).addClass('is-invalid');
                valido = false;
            }

            if (this.value === "" && $(this).attr("data-type") != "currency") {
                $(this).addClass('is-invalid');
                valido = false;
            }
        });


        $('#' + formId + ' *').filter(function () {
            return $(this).is('select') === true;
        }).each(function (select) {
            if ($(this).val() == "default0" || $(this).val() == "") {
                $(this).addClass('is-invalid');
                valido = false;
            }
        });

        $('#' + formId + ' *').filter(function () {
            return $(this).is('textarea') === true;
        }).each(function (textarea) {
            if ($(this).val() == "") {
                $(this).addClass('is-invalid');
                valido = false;
            }
        });
        $('#frmCrearSolicitud input[required]').each(function () {
            if (this.value === "") {
                valido = false;
            }
        });
        if (!valido) {
            this.ctrlActions.ShowMessage('E', "Las fotos son requeridas.");
        }
        return valido;
    }

    this.GetDataForm = function () {
        var data = {};
        var arregloTipotrabajo = [];       
        var formId = "frmCrearSolicitud";

        $('#' + formId + ' *').filter(':input').each(function (input) {
            var columndataname = $(this).attr("columnDataName");
            data[columndataname] = this.value;
        });

        $('#' + formId + ' *').filter(':input[data-type="currency"]').each(function (input) {
            var columndataname = $(this).attr("columnDataName");
            var valPrevio = this.value.replace("$", "");
            var valNuevo = valPrevio.replace(",", "");
            data[columndataname] = valNuevo;
        });

        $('#' + formId + ' *').filter(function () {
            return $(this).is('select') === true;
        }).each(function (select) {
            if ($(this).attr('id') == "sltLocalizaciones") {
                var columndataname = $(this).attr("columnDataName");
                data[columndataname] = $(this).val();
            }          
            if ($(this).attr('id') == "selTiposTrabajo") {
                arregloTipotrabajo = $(this).val();
            }
        });

        $('#' + formId + ' *').filter(function () {
            return $(this).is('textarea') === true;
        }).each(function (textarea) {
            var columndataname = $(this).attr("columnDataName");
            data[columndataname] = $(this).val();
        });



        var arregloObjetosTT = [];

        arregloTipotrabajo.forEach(myFunction);  
       

        function myFunction(value) {
            console.log(value);
            var objData = {};
            objData = { Id_TipoTrabajo: value };                 
            console.log(objData);
            arregloObjetosTT.push(objData);          
        }

        data['TiposDeTrabajo'] = arregloObjetosTT;
        console.log(data['TiposDeTrabajo']);

        data['ListaDocumentos'] = this.getFotosInfo();
        console.log(data['ListaDocumentos']);

        data['CedulaCliente'] = this.cedulaCliente;
        return data;

    }

    this.getFotosInfo = function () {
        var dataDocumentos = [];
        var fot1 = {
            IdDocumento: datosArchivoF1.url,
            NombreDocumento: datosArchivoF1.original_filename,
            Extension: datosArchivoF1.format          
        }
        dataDocumentos.push(fot1);

        var fot2 = {
            IdDocumento: datosArchivoF2.url,
            NombreDocumento: datosArchivoF2.original_filename,
            Extension: datosArchivoF2.format 
        }
        dataDocumentos.push(fot2);
        var fot3 = {
            IdDocumento: datosArchivoF3.url,
            NombreDocumento: datosArchivoF3.original_filename,
            Extension: datosArchivoF3.format   
        }
        dataDocumentos.push(fot3);
        console.log(dataDocumentos);

        return dataDocumentos;
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





    //nuevo
    

    this.validateForm = function () {
        var esValido = true;
        var listaCampos = ['#txtNombreContacto', '#txtTelefono', '#txtFecEvento', '#selTiposTrabajo', '#sltLocalizaciones',
            '#txtADescripcionNecesidad','#txtAExplicacionTrabajo'];

        listaCampos.forEach(function (campo) {
            if ($(campo)[0].validity.valid === false) {
                esValido = false;
                $(campo).addClass('is-invalid');
                $(campo + '_val').removeClass('text-muted');
                $(campo + '_val').addClass('invalid-feedback');
            } else {
                if ($(campo)[0].value === '') {
                    esValido = false;
                    $(campo).addClass('is-invalid');
                    $(campo + '_val').removeClass('text-muted');
                    $(campo + '_val').removeClass('d-none');
                    $(campo + '_val').addClass('invalid-feedback');
                } else {
                    $(campo).removeClass('is-invalid');
                    $(campo).addClass('is-valid');
                    $(campo + '_val').removeClass('text-muted');
                    $(campo + '_val').removeClass('invalid-feedback');
                    $(campo + '_val').addClass('d-none');
                }
            }
        });


        if (esValido) {
            $('#btnCrear').prop("disabled", false);
            $('#btnCrear').removeAttr('disable');
        } else {
            $('#btnCrear').prop("disabled", true);
            $('#btnCrear').attr('disable');
        }
    }
   

 

}



//ON DOCUMENT READY
$(document).ready(function () {
    var vregistroSolTrabajo = new vRegistrarSolicitudDeTrabajo();
    var today = new Date();
    var dd = today.getDate();
    var mm = today.getMonth() + 1; //January is 0!
    var yyyy = today.getFullYear();
    if (dd < 10) {
        dd = '0' + dd
    }
    if (mm < 10) {
        mm = '0' + mm
    }
    today = yyyy + '-' + mm + '-' + dd;
    document.getElementById("txtFecEvento").setAttribute("min", today);
    vregistroSolTrabajo.getLocalizaciones();

    //nuevo
    document.addEventListener('keyup', () => { vregistroSolTrabajo.validateForm() });
    $('#btnCrear').attr('disabled', 'disabled');
});
