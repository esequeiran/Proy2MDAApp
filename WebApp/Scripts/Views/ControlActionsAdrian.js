//'use strict';

const existeJqueryA = window.jQuery;

if (existeJqueryA && 'undefined' !== typeof $.fn.dataTable) {
    $.extend(true, $.fn.dataTable.defaults, {
        "language": {
            "decimal": ",",
            "thousands": ".",
            "info": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
            "infoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
            "infoPostFix": "",
            "infoFiltered": "(filtrado de un total de _MAX_ registros)",
            "loadingRecords": "Cargando...",
            "lengthMenu": "Mostrar _MENU_ registros",
            "paginate": {
                "first": "Primero",
                "last": "Último",
                "next": "Siguiente",
                "previous": "Anterior"
            },
            "processing": "Procesando...",
            "search": "Buscar:",
            "searchPlaceholder": "Término de búsqueda",
            "zeroRecords": "No se encontraron resultados",
            "emptyTable": "Ningún dato disponible en esta tabla",
            "aria": {
                "sortAscending": ": Activar para ordenar la columna de manera ascendente",
                "sortDescending": ": Activar para ordenar la columna de manera descendente"
            },
            //only works for built-in buttons, not for custom buttons
            "buttons": {
                "create": "Nuevo",
                "edit": "Cambiar",
                "remove": "Borrar",
                "copy": "Copiar",
                "csv": "CSV",
                "excel": "Excel",
                "pdf": "PDF",
                "print": "Imprimir",
                "colvis": "Visibilidad columnas",
                "collection": "Colección",
                "upload": "Seleccione fichero...."
            },
            "select": {
                "rows": {
                    _: '%d filas seleccionadas',
                    0: 'clic fila para seleccionar',
                    1: 'una fila seleccionada'
                }
            }
        }
    });
}

function ControlActionsAdrian() {

    this.URL_API = "http://localhost:61079/api/";

    this.GetUrlApiService = function (service) {
        return this.URL_API + service;
    }

    this.GetTableColumsDataName = function (tableId) {
        var val = $('#' + tableId).attr("ColumnsDataName");
        return val;

    }



    this.FillTable = function (service, tableId, refresh, isDownloadable) {

        let seRefresca = ('undefined' !== typeof refresh && refresh === true) ? true : false;

		/*if (seRefresca === true) {
			$('#' + tableId).dataTable().fnDestroy();
		}*/

        if (seRefresca === false) {

            let columns = this.GetTableColumsDataName(tableId).split(',');
            let arrayColumnsData = [];

            $.each(columns, function (index, value) {
                var obj = {};
                obj.data = value;
                //obj.title = value;
                obj.name = value;
                obj.sortable = true;
                obj.searchable = true;

                arrayColumnsData.push(obj);
            });

            let seDescarga = ('undefined' !== typeof isDownloadable && isDownloadable === true) ? true : false;

            //Construye los input para búsqueda en cada columna:
            let numeroColumna = 0;
            $('#' + tableId + ' tr#trbusqueda th').each(function () {
                if (numeroColumna == 0) {

                    let title = $(this).text() || '';
                    $(this).html('<input type="text" id="' + numeroColumna + '" class="busquedaCelda form-control text-center mx-0 my-0 pt-0 py-1" style="font: inherit; font-size: 13px; font-family: \'Font Awesome 5 Free\'; position: inherit; left: 0; bottom: 0;" placeholder="&#xf002; ' + title.trim() + '" />');
                    
                }
                if (numeroColumna == 1) {
                    var select = $('<select id="' + numeroColumna + '" class="form-control select2" style="width: 100%;" data-placeholder="Filtrar por t&eacute;cnico"><option value="" selected="selected" disabled="disabled"><span style="color:#999999;">Filtrar por t&eacute;cnico</span></option><option value="">Sin filtro</option></select>');
                    $(this).html(select);
                }
                ++numeroColumna;
            });
           
            let tableObj = $('#' + tableId).DataTable({
                "serverSide": false,
                "processing": true,
                "bDestroy": true,
                "deferRender": true,
                "ajax": {
                    "url": this.GetUrlApiService(service),
                    "contentType": 'application/json',
                    "dataSrc": 'Data',
                    "type": 'GET',
                    "draw": 1,
                    "crossDomain": true,
                    "async": true,
                    "headers": {
                        'Content-Type': 'application/json',
                        //'Authorization': 'Bearer ' + userToken,
                        'Access-Control-Allow-Origin': '*'
                    },
                    "error": function (xhr, error, thrown) {
                        let ctrlActions = new ControlActionsAdrian();
                        const data = xhr.responseJSON;
                        if ('undefined' == typeof data) {
                            ctrlActions.ShowMessage('E', 'Ocurrió un error al cargar la tabla');
                        } else {
                            ctrlActions.ShowMessage('E', data.ExceptionMessage);
                        }
                    }
                },
                "columns": arrayColumnsData,
                "paging": true,
                "pagingType": "full_numbers",
                "ordering": true,
                "iDisplayLength": 5,
                "aLengthMenu": [[5, 10, 25, 50, 100, -1], [5, 10, 25, 50, 100, "Todos los"]],
                "bFilter": true,
                "searching": true,
                "jQueryUI": false,
                "bSort": true,
                "scrollX": true,
                "scrollCollapse": true,
                "order": [[0, "desc"]],
                "buttons": []

                , initComplete: function () {
                   
                    this.api().columns([1]).every(function () {
                        var column = this;
                   

                        column.data().unique().sort().each(function (d, j) {
                         
                            $('#' + tableId + '_wrapper tr#trbusqueda th > select').append('<option value="' + d + '">' + d + '</option>')
                        });
                    });
                }

                       
            //LOGICA AVANZADA DE JEI NO TOCAR!!


            });

            if (seDescarga) {
                const nombreArchivoDescarga = 'Archivo';
                new $.fn.dataTable.Buttons(tableObj, {
                    buttons: [{
                        extend: 'excelHtml5',
                        className: 'btn-outline-primary btn-sm',
                        text: '<i class="fa fa-download" aria-hidden="true"></i>&nbsp;Descargar',
                        title: nombreArchivoDescarga,
                        exportOptions: {
                            columns: ':visible'
                        }
                    }]
                });
                tableObj.buttons(0, null).container().appendTo(
                    tableObj.table().container()
                );
            }

            //Agregar la funcionalidad a los input de búsqueda:
            $('#' + tableId + '_wrapper tr#trbusqueda input.busquedaCelda').on('keyup change clear', function () {
                //console.log('Buscando: ' + this.value);
                let getNumeroColumna = $(this).attr("id");
                tableObj.column(getNumeroColumna).search(this.value).draw();
            });
           
            $('#' + tableId + '_wrapper tr#trbusqueda th > select').on('change', function () {
                let getNumeroColumna = $(this).attr("id");
                var val = $.fn.dataTable.util.escapeRegex($(this).val());
                tableObj.column(getNumeroColumna).search(val ? '^' + val + '$' : '', true, false).draw();
            });
           
        } else {
            console.log('Se recargará la tabla');
            //RECARGA LA TABLA
            $('#' + tableId).DataTable().ajax.reload(null, true).draw();
        }
    }


    //ESTA SECCION ES UNICAMENTE PARA TIPOS DE TRABAJO, MUESTRA EL FILTRO , ACTIVO E INACTIVO EN LA COLUMNA ESTADO
    this.FillTableTipoTrabajo = function (service, tableId, refresh, isDownloadable) {

        let seRefresca = ('undefined' !== typeof refresh && refresh === true) ? true : false;

		/*if (seRefresca === true) {
			$('#' + tableId).dataTable().fnDestroy();
		}*/

        if (seRefresca === false) {

            let columns = this.GetTableColumsDataName(tableId).split(',');
            let arrayColumnsData = [];

            $.each(columns, function (index, value) {
                var obj = {};
                obj.data = value;
                //obj.title = value;
                obj.name = value;
                obj.sortable = true;
                obj.searchable = true;

                arrayColumnsData.push(obj);
            });

            let seDescarga = ('undefined' !== typeof isDownloadable && isDownloadable === true) ? true : false;

            //Construye los input para búsqueda en cada columna:
            //AQUI SE ESPECIFICA DONDE CAE EL FILTRO O SEA EN CUAL COLUMNA, TRATAR CAMBIANDO LOS VALORES PARA POSICIONAR EL FILTRO DROPDOW 
            //original 0
            let numeroColumna = 0;

            $('#' + tableId + ' tr#trbusqueda th').each(function () {
                //original 0
                if (numeroColumna <2) {

                    let title = $(this).text() || '';
                    $(this).html('<input type="text" id="' + numeroColumna + '" class="busquedaCelda form-control text-center mx-0 my-0 pt-0 py-1" style="font: inherit; font-size: 13px; font-family: \'Font Awesome 5 Free\'; position: inherit; left: 0; bottom: 0;" placeholder="&#xf002; ' + title.trim() + '" />');

                }
                //original 1
                //EN ESTE IF EL NUMERO 2 CORRESPONDE A LA POSICION DONDE SE ENCUENTRA EL ESTADO
                if (numeroColumna == 2) {
                    var select = $('<select id="' + numeroColumna + '" class="form-control select2" style="width: 100%;" data-placeholder="Filtrar por t&eacute;cnico"><option value="" selected="selected" disabled="disabled"><span style="color:#999999;">Filtrar por t&eacute;cnico</span></option><option value="">Sin filtro</option></select>');
                    $(this).html(select);
                }
                ++numeroColumna;
            });

            let tableObj = $('#' + tableId).DataTable({
                "serverSide": false,
                "processing": true,
                "bDestroy": true,
                "deferRender": true,
                "ajax": {
                    "url": this.GetUrlApiService(service),
                    "contentType": 'application/json',
                    "dataSrc": 'Data',
                    "type": 'GET',
                    "draw": 1,
                    "crossDomain": true,
                    "async": true,
                    "headers": {
                        'Content-Type': 'application/json',
                        //'Authorization': 'Bearer ' + userToken,
                        'Access-Control-Allow-Origin': '*'
                    },
                    "error": function (xhr, error, thrown) {
                        let ctrlActions = new ControlActionsAdrian();
                        const data = xhr.responseJSON;
                        if ('undefined' == typeof data) {
                            ctrlActions.ShowMessage('E', 'Ocurrió un error al cargar la tabla');
                        } else {
                            ctrlActions.ShowMessage('E', data.ExceptionMessage);
                        }
                    }
                },
                "columns": arrayColumnsData,
                "paging": true,
                "pagingType": "full_numbers",
                "ordering": true,
                "iDisplayLength": 5,
                "aLengthMenu": [[5, 10, 25, 50, 100, -1], [5, 10, 25, 50, 100, "Todos los"]],
                "bFilter": true,
                "searching": true,
                "jQueryUI": false,
                "bSort": true,
                "scrollX": true,
                "scrollCollapse": true,
                "order": [[0, "desc"]],
                "buttons": []

                , initComplete: function () {

                    this.api().columns([2]).every(function () {
                        var column = this;


                        column.data().unique().sort().each(function (d, j) {

                            $('#' + tableId + '_wrapper tr#trbusqueda th > select').append('<option value="' + d + '">' + d + '</option>')
                        });
                    });
                }




            });

            if (seDescarga) {
                const nombreArchivoDescarga = 'Archivo';
                new $.fn.dataTable.Buttons(tableObj, {
                    buttons: [{
                        extend: 'excelHtml5',
                        className: 'btn-outline-primary btn-sm',
                        text: '<i class="fa fa-download" aria-hidden="true"></i>&nbsp;Descargar',
                        title: nombreArchivoDescarga,
                        exportOptions: {
                            columns: ':visible'
                        }
                    }]
                });
                tableObj.buttons(0, null).container().appendTo(
                    tableObj.table().container()
                );
            }

            //Agregar la funcionalidad a los input de búsqueda:
            $('#' + tableId + '_wrapper tr#trbusqueda input.busquedaCelda').on('keyup change clear', function () {
                //console.log('Buscando: ' + this.value);
                let getNumeroColumna = $(this).attr("id");
                tableObj.column(getNumeroColumna).search(this.value).draw();
            });

            $('#' + tableId + '_wrapper tr#trbusqueda th > select').on('change', function () {
                let getNumeroColumna = $(this).attr("id");
                var val = $.fn.dataTable.util.escapeRegex($(this).val());
                tableObj.column(getNumeroColumna).search(val ? '^' + val + '$' : '', true, false).draw();
            });

        } else {
            console.log('Se recargará la tabla');
            //RECARGA LA TABLA
            $('#' + tableId).DataTable().ajax.reload(null, true).draw();
        }
    }

    this.GetSelectedRow = function () {
        var data = sessionStorage.getItem(tableId + '_selected');

        return data;
    };

    this.BindFields = function (formId, data) {
        console.log(data);
        $('#' + formId + ' *').filter(':input').each(function (input) {
            var columnDataName = $(this).attr("ColumnDataName");
            this.value = data[columnDataName];
        });
        ////Para el anchor en solicitud de registro
        $('#' + formId).find('a').each(function (input) {
            var columnDataName = $(this).attr("id");
            $(this).attr("href", data[columnDataName]);
        });
    }

    this.GetDataForm = function (formId) {
        var data = {};

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

        $('#' + formId + ' *').filter(':input[type=radio]:checked').each(function (input) {
            var columndataname = $(this).attr("columnDataName");
            data[columndataname] = this.value;
        });

        $('#' + formId + ' *').filter(function () {
            return $(this).is('img') === true;
        }).each(function (img) {
            var columndataname = $(this).attr("columnDataName");
            data[columndataname] = $(this).attr("src");
        })
        $('#' + formId + ' *').filter(function () {
            return $(this).is('select') === true;
        }).each(function (select) {

            var columndataname = $(this).attr("columnDataName");
            console.log(columndataname);
            data[columndataname] = $(this).val();

        })

        return data;

    }


    this.ValidateDataForm = function (formId) {
        $("#alert_container").hide();
        var valido = true;
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
        });


        $('#' + formId + ' *').filter(function () {
            return $(this).is('select') === true;
        }).each(function (select) {
            if ($(this).val() == "seleccioné una opción") {
                $(this).addClass('is-invalid');
                valido = false;
            }
        })

        var ctrlActions = new ControlActionsAdrian();
        if (!valido) {
            ctrlActions.ShowMessage('E', "Revise los campos en requeridos.");
        }

        return valido;

    }
    this.ShowMessage = function (type, message) {
        if (type == 'E') {
            $("#alert_container").removeClass("alert-success")
            $("#alert_container").addClass("alert-danger");
        } else if (type == 'I') {
            $("#alert_container").removeClass("alert-danger")
            $("#alert_container").addClass("alert-success");
        }
        $("#alert_message").text(message);
        $("#alert_container").show();
    };

    this.PostToAPI = function (service, data, callback = undefined) {
        var jqxhr = $.post(this.GetUrlApiService(service), data, function (response) {
            var ctrlActions = new ControlActionsAdrian();
            ctrlActions.ShowMessage('I', response.Message);
            if (sessionStorage.getItem('IdUsuario')) {
                ctrlActions.PostToApiParametrosBitacora('Registrar', service);
            }
            if (callback != undefined) {
                callback(true);
            }
        })
            .fail(function (response) {
                var data = response.responseJSON;
                var ctrlActions = new ControlActionsAdrian();
                ctrlActions.ShowMessage('E', data.ExceptionMessage);
                console.log(data);
                if (callback != undefined) {
                    callback(false);
                }
            })
    };

    this.PutToAPI = function (service, data) {
        var jqxhr = $.put(this.GetUrlApiService(service), data, function (response) {
            var ctrlActions = new ControlActionsAdrian();
            ctrlActions.ShowMessage('I', response.Message);
            ctrlActions.PostToApiParametrosBitacora('Modificar', service);
        })
            .fail(function (response) {
                var data = response.responseJSON;
                var ctrlActions = new ControlActionsAdrian();
                ctrlActions.ShowMessage('E', data.ExceptionMessage);
                console.log(data);
            })
    };

    this.DeleteToAPI = function (service, data) {
        var jqxhr = $.delete(this.GetUrlApiService(service), data, function (response) {
            var ctrlActions = new ControlActionsAdrian();
            ctrlActions.ShowMessage('I', response.Message);
            ctrlActions.PostToApiParametrosBitacora('Eliminar', service);
        })
            .fail(function (response) {
                var data = response.responseJSON;
                var ctrlActions = new ControlActionsAdrian();
                ctrlActions.ShowMessage('E', data.ExceptionMessage);
                console.log(data);
            })
    };

    this.GetToApi = function (service, callbackFunction) {
        var jqxhr = $.get(this.GetUrlApiService(service), function (response) {
            console.log("Response " + response);
            callbackFunction(response);
        });
    }


    this.GetToApiMembresias = function (service, callbackFunction) {
        var jqxhr = $.get(this.GetUrlApiService(service), function (response) {
            console.log("Response " + response);
            callbackFunction(response);
        })
            .fail(function (response) {
                var data = response.responseJSON;
                var ctrlActions = new ControlActionsAdrian();
                ctrlActions.ShowMessage('E', data.ExceptionMessage);
                console.log(data);
            })
    }

  
    this.PostToApiParametros = function (service, parametros) {
        var jqxhr = $.post(this.GetUrlApiService(service) + parametros, function (response) {
            console.log("Response " + response);
            var ctrlActions = new ControlActionsAdrian();
            ctrlActions.ShowMessage('I', response.Message);
            if (sessionStorage.getItem('Cedula')) {
                sessionStorage.removeItem('Cedula');

            }
            window.location.href = "vIndexInterno";
        })
            .fail(function (response) {
                var data = response.responseJSON;
                var ctrlActions = new ControlActionsAdrian();
                ctrlActions.ShowMessage('E', data.ExceptionMessage);
            });
    }


    this.PostToApiParametrosBitacora = function (accion, service) {
        var stringP = this.GetParametersString({
            CedulaUsuario: sessionStorage.getItem('IdUsuario'),
            DescripcionAccion: accion + ' ' + service
        });
        var jqxhr = $.post(this.GetUrlApiService('Bitacora') + stringP, function (response) {
            console.log(response.Message);
        })
            .fail(function (response) {
                var data = response.responseJSON;
                console.log(data.ExceptionMessage);
            });
    }


    this.GetToApiParametrosLogin = function (service, parametros) {
        var jqxhr = $.get(this.GetUrlApiService(service) + parametros, function (response) {
            console.log("Response " + response);
            var token = response.Data;
            sessionStorage.setItem("IdUsuario", token.IdUsuario)
            sessionStorage.setItem("Nombre", token.Nombre)
            var obj = token.DiccionarioRoles;
            var arrayIdRol = $.map(obj, function (value, index) {
                return [index];
            });
            sessionStorage.setItem("Idroles", arrayIdRol)
            var arrayNombreRol = $.map(obj, function (value, index) {
                return [value];
            });
            sessionStorage.setItem("Nombreroles", arrayNombreRol);
            sessionStorage.setItem("IdEstado", token.IdEstado);
            window.location.href = "vIndexInterno";
        })
            .fail(function (response) {
                var data = response.responseJSON;
                var ctrlActions = new ControlActionsAdrian();
                ctrlActions.ShowMessage('E', data.ExceptionMessage);
            });
    }

    this.GetToApiByUrlMembrecia = function (service, data) {
        var jqxhr = $.get(this.GetUrlApiService(service) + data, function (response) {
            var data = response.Data;
            var tamanno = data.length;
            if (tamanno > 0) {
                var nombreEmpresa = data[0].NombreEmpresa;
                $('#parrafoDialogEnviarCorreo').html("La empresa " + nombreEmpresa + " cuenta con " + tamanno
                    + " membrecías. ¿Desea enviar el correo con la cartelera de membrecías a dicha empresa?");
                console.log($('#parrafoDialogEnviarCorreo').text());
            }
        })
            .fail(function (response) {
                $('#btnEnvioCorreo').hide();
                $('#parrafoDialogEnviarCorreo').html("La empresa cuenta con 0 membrecías. No se puede enviar el correo. Intente registrar membrecías.");
                console.log($('#parrafoDialogEnviarCorreo').text());
                var data = response.responseJSON;
                var ctrlActions = new ControlActionsAdrian();
                ctrlActions.ShowMessage('E', data.ExceptionMessage);
                console.log(data);
            })
    }

    this.GetParametersString = function (data) {
        var parametersString = '?';

        for (var para in data) {
            parametersString = parametersString + para + "=";
            parametersString = parametersString + data[para] + "&";
        }
        parametersString = parametersString.substring(0, parametersString.length - 1);
        return parametersString;

    }


    this.GetToApiParametrosRecuperarContrasenna = function (service, parametros) {
        var jqxhr = $.post(this.GetUrlApiService(service) + parametros, function (response) {

            $('#parrafoDialogo').html("Se ha enviado un código SMS a su teléfono y un correo"
                + " con el link para ingresar código de verificación y creación de nueva contraseña.");
            $('#btnConfirmar').show();
            $('#btnCerrar').hide();

        })
            .fail(function (response) {
                var data = response.responseJSON;
                var ctrlActions = new ControlActionsAdrian();
                $('#parrafoDialogo').html(data.ExceptionMessage);
                $('#btnConfirmar').hide();

            });
    }

    this.PostToApiParametrosModificarContrasenna = function (service, parametros) {
        var jqxhr = $.post(this.GetUrlApiService(service) + parametros, function (response) {
            console.log("Response " + response);
            var ctrlActions = new ControlActionsAdrian();
            ctrlActions.ShowMessage('I', response.Message);
        })
            .fail(function (response) {
                var data = response.responseJSON;
                var ctrlActions = new ControlActionsAdrian();
                ctrlActions.ShowMessage('E', data.ExceptionMessage);
            });
    }

    this.PostToApiParametrosRegistrarContrasenna = function (service, parametros) {
        var jqxhr = $.post(this.GetUrlApiService(service) + parametros, function (response) {
            console.log("Response " + response);
            var ctrlActions = new ControlActionsAdrian();
            ctrlActions.ShowMessage('I', response);
            $('#parrafoDialogRegistrarContrasenna').html('Registro correcto de contraseña');
            $('#modalRegistrarContrasenna').show();
            $('#btnCerrar').hide();
        })
            .fail(function (response) {
                var data = response.responseJSON;
                var ctrlActions = new ControlActionsAdrian();
                ctrlActions.ShowMessage('E', data.ExceptionMessage);
            });
    }

    this.PutPaymentApi = function (service, data, callbackFunction) {
        debugger
        var jqxhr = $.put(this.GetUrlApiService(service), data, function (response) {
            var ctrlActions = new ControlActionsAdrian();
            ctrlActions.ShowMessage('I', response.Message);
            callbackFunction(response.Data);
        })
    };





}

//Custom jquery actions
$.put = function (url, data, callback) {
    if ($.isFunction(data)) {
        type = type || callback,
            callback = data,
            data = {}
    }
    return $.ajax({
        url: url,
        type: 'PUT',
        success: callback,
        data: JSON.stringify(data),
        origin: 'http://localhost:61079',
        contentType: 'application/json'
    });
}

$.delete = function (url, data, callback) {
    if ($.isFunction(data)) {
        type = type || callback,
            callback = data,
            data = {}
    }
    return $.ajax({
        url: url,
        type: 'DELETE',
        success: callback,
        data: JSON.stringify(data),
        origin: 'http://localhost:61079',
        contentType: 'application/json'
    });




}


