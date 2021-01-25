

function vRegistrarEvaluacionSolicitudTrabajo() {

    this.cedulaCliente = sessionStorage.getItem('IdUsuario');
    this.datosArchivos = [];

    this.tblSol = 'tblSolicitudesPendientesEvaluacion';
    this.service = 'SolicitudesPendientesEvaluacion';

    this.serviceEvaluacion = 'CalificarSolicitudDeTrabajo';

    this.ctrlActions = new ControlActions();

    this.columns = "ExplicacionTrabajo,NombreEmpresa,NombreEstado";

    this.RetrieveAll = function () {
        this.ctrlActions.FillTableCambiosEvelyn(this.service + "?idCliente=" + this.cedulaCliente, this.tblSol, false);
    }

    this.ReloadTable = function () {
        this.ctrlActions.FillTableCambiosEvelyn(this.service + "?idCliente=" + this.cedulaCliente, this.tblSol, true);
    }

    this.BindFields = function (data) {

        var todosFormularios = document.getElementsByClassName("formDinamico");
        if (todosFormularios.length > 0) {
            $(".formDinamico").remove();
        }

        //var arregloTrabajadores = [];

        //for (i = 0; i < todosFormularios.length; i++) {
        //    var objValoracionTrabajador = this.GetDataFormParaTrabajadores(todosFormularios[i].id);
        //    arregloTrabajadores.push(objValoracionTrabajador);
        //}    

        $('#idSolicitud').val(data.IdSolicitud);
        $('#h6NombreEmpresa').text(data.NombreEmpresa);
        $('#tipoCedulaEmpresa').val(data.EmpresaTipoCedula);
        console.log(data.EmpresaTipoCedula);

        
       

        if (data.EmpresaTipoCedula != 'Fisico') {
            $('#h6TipoDeOferente').text('Oferente jurídico');
            
            var arregloTrabajadores = data.ValoracionDeTrabajadores;

            arregloTrabajadores.forEach(trabaCrear);

            function trabaCrear(value) {
                console.log(value);
                $('<form id="form' + value.IdTrabajador + '" class="formDinamico" ><div class="row"><div class="col-md-6"><h6>Trabajador ' + value.NombreTrabajador
                    + '</h6><input id="idTrabajador' + value.IdTrabajador + '" type="text" columnDataName="Idtrabajador"><input id="valoracion' + value.IdTrabajador + '"  type="number" columnDataName="ValoracionEstrellasTrabajador" required><span id="start' + value.IdTrabajador + '"></span><br/><label for="txtComentarioTrabajo">Comentario</label>' +
                    '<textarea class="form-control" id="txtComentarioTrabajo" columnDataName="ComentarioTrabajador"' +
                    'aria-describedby="coMent" required rows="10" cols = "50" maxlength = "200" style = "resize:none" ></textarea >' +
                    +'<small id="coMent" class="form-text text-muted">Este dato es requerido</small></div></div></form>').appendTo($('#divFormulariosTrabajadores'));

                $('#idTrabajador' + value.IdTrabajador).hide();
                $('#idTrabajador' + value.IdTrabajador).val(value.IdTrabajador);
                console.log($('#idTrabajador' + value.IdTrabajador).val());
                $('#valoracion' + value.IdTrabajador).hide();
                $('#start' + value.IdTrabajador).starrr({
                    rating: 0,
                    change: function (e, valor) {
                        $('#valoracion' + value.IdTrabajador).val(valor);
                        console.log($('#valoracion' + value.IdTrabajador).val());
                    }
                });
            }
        } else {

            $('#h6TipoDeOferente').text('Oferente físico');
        }


    }

    this.Create = function () {
        var valoracionData = {};
        var formId = "frmCrearSolicitud";
        var validar = this.validarCampos(formId);

        var validarForm = true;

        var todosFormularios = document.getElementsByClassName("formDinamico");
        if (todosFormularios.length > 0) {
            validarForm = this.validarForms();
        } 
        
        if (validarForm && validar) {          
            valoracionData = this.GetDataForm();

            this.ctrlActions.PostToAPI(this.serviceEvaluacion, valoracionData, () => {
                $('#txtComentarioTrabajo').val('');
                $('#idSolicitud').val('');
                $('#idValoracionestellasTrabajo').val('');
                $('#F1').val(null);
                $('#F2').val(null);
                $('#F3').val(null);
                $('#foto1').text('Seleccionar archivo');
                $('#foto2').text('Seleccionar archivo');
                $('#foto3').text('Seleccionar archivo');
                var todosFormularios = document.getElementsByClassName("formDinamico");
                if (todosFormularios.length > 0) {
                    $(".formDinamico").remove();
                }
                this.ReloadTable();
                location.reload(true);
            });
           
           
        }
    }

    this.GetDataFormParaTrabajadores = function(formId){
        var data = {};
    
        $('#' + formId + ' *').filter(':input').each(function (input) {
            var columndataname = $(this).attr("columnDataName");
            data[columndataname] = this.value;
        });
                   

        $('#' + formId + ' *').filter(function () {
            return $(this).is('textarea') === true;
        }).each(function (textarea) {
            var columndataname = $(this).attr("columnDataName");
            data[columndataname] = $(this).val();
        });
                
        return data;

    }

    this.validarForms = function () {
        var valido = true;

        var todosFormularios = document.getElementsByClassName("formDinamico");

        for (i = 0; i < todosFormularios.length; i++) {
            var validarFor = this.validarCampos(todosFormularios[i].id);
            if (!validarFor) {
                valido = false;
            }
        }       
        return valido;
    }

    this.validarCampos = function (formId) {
        var valido = true;
        

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
            this.ctrlActions.ShowMessage('E', "Revise los campos en requeridos.");
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


        var todosFormularios = document.getElementsByClassName("formDinamico");
        if (todosFormularios.length > 0) { 

            var todosFormularios = document.getElementsByClassName("formDinamico");
            var arregloTrabajadores = [];
            for (i = 0; i < todosFormularios.length; i++) {
                var objValoracionTrabajador = this.GetDataFormParaTrabajadores(todosFormularios[i].id);
                arregloTrabajadores.push(objValoracionTrabajador);

            }
            data['ValoracionDeTrabajadores'] = arregloTrabajadores;

        }       


        data['ListaDocumentos'] = this.getFotosInfo();
        
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

}


//ON DOCUMENT READY
$(document).ready(function () {
    var vlistarSolictiudes = new vRegistrarEvaluacionSolicitudTrabajo();
    vlistarSolictiudes.RetrieveAll();
    $('#divId').hide();

    $('#Estrellas').starrr({
        rating: 0,
        change: function (e, valor) {
            $('#idValoracionestellasTrabajo').val(valor);
            
        }
    });

  
});
