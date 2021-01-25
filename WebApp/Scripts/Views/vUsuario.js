'use strict';

let clUsuario;

// Cambia el idioma de los textos del datatable a español: 
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


let mostrarMensaje = (tipo, mensaje, actualizaTabla = 0) => {
    if (0 === 'E'.localeCompare(tipo)) {
        //Error
        $('#alert_container').removeClass("alert-success")
        $('#alert_container').addClass("alert-danger");
    } else if (0 === 'I'.localeCompare(tipo)) {
        //Información
        $('#alert_container').removeClass("alert-danger")
        $('#alert_container').addClass("alert-success");
    }
    $('#alert_message').text(mensaje);
    $('#alert_container').show('fast');
    $('#alert_container').focus();
    setTimeout(() => { document.body.scrollTop = 0; document.documentElement.scrollTop = 0; }, 1600);

    if (actualizaTabla === 1) {
        // clUsuario.llenarTabla();
        setTimeout(() => { window.location.href = 'http://localhost:61102/Home/vUsuario' }, 1);

    }
};

//Función global que abre el modal:
let fnMostrarModalCambio = (nombreApellido, correo, estadoActual, nombreEstadoActual, strEstadosEncode) => {
    const strEstados = decodeURIComponent(strEstadosEncode);
    const objEstados = JSON.parse(strEstados);

    Swal.fire({
        title: 'Cambiar el estado de:',
        html: nombreApellido,
        input: 'select',
        inputPlaceholder: nombreEstadoActual,
        /* inputAttributes: {
             '': ''
         },*/
        inputOptions: objEstados,
        inputValue: estadoActual,
        allowOutsideClick: false,
        allowEscapeKey: false,
        allowEnterKey: false,
        showCancelButton: true,
        showCloseButton: false,
        focusConfirm: false,
        focusCancel: true,
        confirmButtonText: '<i class="far fa-save"></i> Guardar',
        cancelButtonText: 'Cancelar',
        customClass: {
            //title: 'h5',
            //  closeButton: 'close',
            input: 'form-control',
            confirmButton: 'btn btn-primary',
            cancelButton: 'btn btn-secondary'
        },
        showLoaderOnConfirm: true,
        preConfirm: async (nuevoEstado) => {
            Swal.showLoading();
            let num = ('string' === typeof nuevoEstado) ? parseInt(nuevoEstado, 10) : nuevoEstado;
            if (num === 13) {
                const { value: valorDias } = await Swal.fire({
                    html: 'Seleccione la cantidad de días que va a <br><b>suspender</b> a <b>' + nombreApellido + '</b>',
                    input: 'range',
                    inputValue: 1,
                    icon: 'question',
                    inputAttributes: {
                        min: 1,
                        max: 366,
                        step: 1
                    },
                    showCancelButton: true,
                    inputValidator: (value) => {
                        if (!value) {
                            return 'Seleccione algún valor!'
                        }
                    }
                });

                if (valorDias) {
                    num = valorDias;
                } else {
                    num = -1;
                }
            } else if (num === estadoActual) {
                //Seleccionó el mismo que ya tiene
                num = -1;
            } else {
                num = 0;
            }

            if (num < 0) {
                //Se sale del swal:
                return false;
            } else {
                $.ajax({
                    method: 'GET',
                    url: `http://localhost:61079/api/EstadosUsuario/${correo}/${nuevoEstado}/${num}`,
                    dataType: 'json',//El tipo de datos que espera del servidor.
                    cache: false,
                    contentType: "application/json; charset=utf-8",
                    //contentType: "application/x-www-form-urlencoded; charset=UTF-8",
                    enctype: 'application/x-www-form-urlencoded',
                    async: true,
                    crossDomain: true,
                    beforeSend: xmlHttpRequest => {
                        xmlHttpRequest.withCredentials = false;
                    }
                }).done(resultado => {
                    let msg = 'El estado se ha modificado con éxito';
                    if (resultado.Message) {
                        msg = resultado.Message;
                    }
                    mostrarMensaje('I', msg, 1);

                    setTimeout(() => { document.body.scrollTop = 0; document.documentElement.scrollTop = 0; }, 1600);

                    return false;
                }).fail((request, textStatus, errorThrown) => {
                    let msg = 'Ocurrió un error al actualizar el estado';
                    if (request.responseText) {
                        msg = request.responseText;
                    }
                    mostrarMensaje('E', msg);
                    return false;
                });
            }
        },
        allowOutsideClick: () => !Swal.isLoading()
    }).then((result) => { });
};

class Usuario {
    constructor() {
        this.ENDPOINT_USUARIOS = 'UsuarioController'; //service
        this.URI_USUARIOS = 'http://localhost:61079/api/UsuarioController';
        this.URI_ESTADOS = 'http://localhost:61079/api/EstadosUsuario';
        this.URI_ESTADOS_CAMBIO = 'http://localhost:61079/api/EstadosUsuarioCambio';
        this.tblId = '#tblUsuario';
    }

    getAjax(url) {
        return $.ajax({
            method: 'GET',
            url: url,
            dataType: 'json',//El tipo de datos que espera del servidor.
            cache: false,
            contentType: "application/json; charset=utf-8",
            //contentType: "application/x-www-form-urlencoded; charset=UTF-8",
            enctype: 'application/x-www-form-urlencoded',
            async: true,
            crossDomain: true,
            beforeSend: xmlHttpRequest => {
                xmlHttpRequest.withCredentials = false;
            }
        });
    }

    getListaEstados(callBack) {
        //Creamos una instancia de la clase, en el contexto actual:
        const selft = this;

        const yaExiste = sessionStorage.getItem('lstEstadosUsr');
        if (null === yaExiste || 'undefined' == typeof yaExiste) {
            selft.getAjax(selft.URI_ESTADOS).done(resultado => {
                if (resultado.Data) {
                    if ('object' == typeof resultado.Data) {
                        let strEstadosTemp = '';
                        resultado.Data.forEach(obj => {
                            if (0 < strEstadosTemp.length) strEstadosTemp += ',';
                            strEstadosTemp += '"' + obj.Id + '":"' + obj.Valor + '"';
                        });
                        strEstadosTemp = '{' + strEstadosTemp + '}';
                        sessionStorage.setItem("lstEstadosUsr", strEstadosTemp);
                        callBack(strEstadosTemp);
                    } else {
                        callBack('{}');
                    }
                } else {
                    callBack('{}');
                }
            }).fail((request, textStatus, errorThrown) => {
                if (request.responseText) {
                    mostrarMensaje('E', request.responseText);
                } else {
                    mostrarMensaje('E', 'Ocurrió un error al obtener los estados');
                }
                callBack('{}');
            });
        } else {
            callBack(yaExiste);
        }
    }
    getListaEstadosCambio(callBack) {
        //Creamos una instancia de la clase, en el contexto actual:
        const selft = this;

        const yaExiste = sessionStorage.getItem('lstEstadosUsr2');
        if (null === yaExiste || 'undefined' == typeof yaExiste) {
            selft.getAjax(selft.URI_ESTADOS_CAMBIO).done(resultado => {
                if (resultado.Data) {
                    if ('object' == typeof resultado.Data) {
                        let strEstadosTemp = '';
                        resultado.Data.forEach(obj => {
                            if (0 < strEstadosTemp.length) strEstadosTemp += ',';
                            strEstadosTemp += '"' + obj.Id + '":"' + obj.Valor + '"';
                        });
                        strEstadosTemp = '{' + strEstadosTemp + '}';
                        sessionStorage.setItem("lstEstadosUsr2", strEstadosTemp);
                        callBack(strEstadosTemp);
                    } else {
                        callBack('{}');
                    }
                } else {
                    callBack('{}');
                }
            }).fail((request, textStatus, errorThrown) => {
                if (request.responseText) {
                    mostrarMensaje('E', request.responseText);
                } else {
                    mostrarMensaje('E', 'Ocurrió un error al obtener los estados');
                }
                callBack('{}');
            });
        } else {
            callBack(yaExiste);
        }
    }

    getNombreEstado(elID, callBack) {
        //Creamos una instancia de la clase, en el contexto actual:
        const selft = this;
        const has = Object.prototype.hasOwnProperty;

        let objEstados = JSON.parse(selft.strEstados);
        let encontrado = 0;

        let keyEstados;
        for (keyEstados in objEstados) {
            if (!has.call(objEstados, keyEstados)) continue;
            const value = objEstados[keyEstados];
            const num = ('string' === typeof keyEstados) ? parseInt(keyEstados, 10) : keyEstados;
            if (num === elID) {
                callBack(value);
                encontrado = 1;
                break;
            }
        }

        if (encontrado === 0) callBack('');
    }

    cargarDataTable(seDescarga = false) {

        //Creamos una instancia de la clase, en el contexto actual:
        const selft = this;

        let numeroColumna = 1;
        $(selft.tblId + ' tr#trbusqueda th').each(function () {
            const classID = 'busquedaCelda' + selft.tblId.replace('#', '');
            let title = $(this).text() || '';
            if ($(this).hasClass("descartar-celda") === false) {
                $(this).html('<input type="text" id="' + numeroColumna + '" class="' + classID + ' form-control text-center mx-0 my-0 pt-0 py-1" style="min-width: 80px; font: inherit; font-size: 13px; font-family: \'Font Awesome 5 Free\'; position: inherit; left: 0; bottom: 0;" placeholder="&#xf002; ' + title.trim() + '" />');
                ++numeroColumna;
            }
        });

        $(selft.tblId + ' thead#theadBusqueda').removeClass('d-none');

        let tableObj = $(selft.tblId).DataTable({
            "serverSide": false,
            "processing": false,
            "deferRender": true,
            "bDestroy": true,
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
            "order": [[7, "desc"]],
            "buttons": []
        });
        if (true === seDescarga) {
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
        $('input.busquedaCelda' + selft.tblId.replace('#', '')).on('keyup change clear', function () {
            //console.log('Buscando: ' + this.value);
            let getNumeroColumna = $(this).attr("id");
            tableObj.column(getNumeroColumna).search(this.value).draw();
        });

        $(selft.tblId + ' tbody').on('click', 'tr', function () {
            let rowx = $(this);
            if (rowx.hasClass('control') || rowx.hasClass('select-checkbox')) {
                return;
            }
            $(selft.tblId + ' tbody tr.selected').removeClass('selected');
            rowx.addClass('selected');

        });

    }

    llenarTabla() {
        //Creamos una instancia de la clase, en el contexto actual:
        const selft = this;

        if ($.fn.DataTable.isDataTable(selft.tblId)) {
            $(selft.tblId).DataTable().clear().destroy();
        }

        selft.getListaEstados(lst => {
            selft.strEstados = lst;

            selft.getListaEstadosCambio(lstCambio => {
                selft.strEstadosCambio = lstCambio;


                $(selft.tblId + ' > tbody').html('');

                selft.getAjax(selft.URI_USUARIOS).done(resultado => {
                    if (resultado.Data) {
                        if ('object' == typeof resultado.Data) {
                            resultado.Data.forEach(obj => {

                                //Construye las celdas de la fila:
                                const tdMolde = '<td class="text-center">';
                                let cells = '';
                                cells += tdMolde + '<a title="Ver el perfil de: ' + obj.Nombre + ' ' + obj.Apellido1 + '" href="vVerPerfilOferente?Cedula=' + obj.Cedula + '" target="_blank"><i class="far fa-address-card fa-2x"></i></a></td>';
                                cells += tdMolde + obj.Nombre_Rol + '</td>';
                                cells += tdMolde + obj.Nombre + '</td>';
                                cells += tdMolde + obj.Apellido1 + '</td>';
                                cells += tdMolde + obj.Apellido2 + '</td>';
                                cells += tdMolde + obj.Cedula + '</td>';
                                cells += tdMolde + obj.TipoCedula + '</td>';
                                cells += tdMolde + obj.Correo + '</td>';

                                if (obj.FecNacimiento.length > 10) {
                                    cells += tdMolde + obj.FecNacimiento.substring(0, 10) + '</td>';
                                } else {
                                    cells += tdMolde + obj.FecNacimiento + '</td>';
                                }

                                cells += tdMolde + obj.PaisNacimiento + '</td>';
                                cells += tdMolde + obj.Genero + '</td>';

                                let nombreEstado = '';

                                selft.getNombreEstado(obj.Id_estado, (r) => {
                                    nombreEstado = r;
                                });

                                let strEstadosCambio = encodeURIComponent(selft.strEstadosCambio);

                                const nombreApellido = obj.Nombre + ' ' + obj.Apellido1 + ' (' + obj.Cedula + ')';

                                let tmp = tdMolde + '<div class="text-nowrap">' + nombreEstado;
                                tmp += '<div class="float-right">';
                                tmp += '<button onClick="fnMostrarModalCambio(\'' + nombreApellido + '\',\'' + obj.Correo + '\',' + obj.Id_estado + ',\'' + nombreEstado + '\',\'' + strEstadosCambio + '\');return false;" type="button" class="btn btn-link btn-sm" title="Cambiar el estado de ' + nombreApellido + '"><i class="far fa-edit"></i></button>';
                                tmp += '</div>';
                                tmp += '</div></td>';

                                cells += tmp;


                                //Agrega la fila al tbody de la tabla:
                                $(selft.tblId + ' > tbody').append('<tr>' + cells + '</tr>');

                            });


                            //Cada vez que se rellene la tabla, vuelve a cargar el datatable:
                            selft.cargarDataTable(false);



                        }
                    }

                }).fail((request, textStatus, errorThrown) => {
                    if (request.responseText) {
                        mostrarMensaje('E', request.responseText);
                    } else {
                        mostrarMensaje('E', 'Ocurrió un error al llenar la tabla');
                    }
                    return false;
                });
            });
        });
    }


}


window.onload = () => {
    sessionStorage.removeItem('lstEstadosUsr');
    sessionStorage.removeItem('lstEstadosUsr2');
    clUsuario = new Usuario();
    clUsuario.llenarTabla();

};

