'use strict';

const tblMembresiaId = 'tblMembresias';
//const UrlApiService = 'http://localhost:61079/api/Membresia';
const UrlApiServiceMembresiasSinExcepcion = 'http://localhost:61079/api/MembresiaEmpresaSinExcepcion';
const UrlApiServiceCancelarMembresia = 'http://localhost:61079/api/CancelarMembresia';

let cedulaEmpresa = null;

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
        // cc.llenarTabla();
        //setTimeout(() => { window.location.href = 'vListarMembresiasOferente' }, 1);
        RetrieveAll();
    }
};

let cancelarMembresiaOferente = (pIdmembresia, pNombreMembresia) => {
    if (pIdmembresia) {
        Swal.fire({
            title: 'Confirmación',
            text: "Desea cancelar la membresía " + pNombreMembresia + "?",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonText: 'Si',
            cancelButtonText: 'No'
        }).then((result) => {
            if (result.value) {
                getAjax(UrlApiServiceCancelarMembresia + '/' + pIdmembresia + '?AspxAutoDetectCookieSupport=1')
                    .done(resultado => {
                        if (resultado.Message) {
                            mostrarMensaje('I', resultado.Message, 1);
                        } else {
                            mostrarMensaje('I', 'La membresía se ha cancelado con éxito', 1);
                        }
                    }).fail((request, textStatus, errorThrown) => {
                        if (request.responseText) {
                            mostrarMensaje('E', request.responseText);
                        } else {
                            mostrarMensaje('E', 'Ocurrió un error al llenar la tabla');
                        }
                    });
            }
        });
    }
};

let cargarDataTable = (seDescarga = false) => {

    let numeroColumna = 0;
    $('#' + tblMembresiaId + ' tr#trbusqueda th').each(function () {
        const classID = 'busquedaCelda' + tblMembresiaId.replace('#', '');
        let title = $(this).text() || '';
        if ($(this).hasClass("descartar-celda") === false) {
            $(this).html('<input type="text" id="' + numeroColumna + '" class="' + classID + ' form-control text-center mx-0 my-0 pt-0 py-1" style="min-width: 80px; font: inherit; font-size: 13px; font-family: \'Font Awesome 5 Free\'; position: inherit; left: 0; bottom: 0;" placeholder="&#xf002; ' + title.trim() + '" />');
        }
        ++numeroColumna;
    });

    $('#' + tblMembresiaId + ' thead#theadBusqueda').removeClass('d-none');

    let tableObj = $('#' + tblMembresiaId).DataTable({
        "serverSide": false,
        "processing": false,
        "deferRender": true,
        "bDestroy": true,
        "paging": true,
        "pagingType": "full_numbers",
        "ordering": true,
        "iDisplayLength": 3,
        "aLengthMenu": [[3, 5, 10, 25, 50, 100, -1], [3, 5, 10, 25, 50, 100, "Todos los"]],
        "bFilter": true,
        "searching": true,
        "jQueryUI": false,
        "bSort": true,
        "scrollX": true,
        "scrollCollapse": true,
        "order": [[1, "asc"]],
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
    $('input.busquedaCelda' + tblMembresiaId.replace('#', '')).on('keyup change clear', function () {
        //console.log('Buscando: ' + this.value);
        let getNumeroColumna = $(this).attr("id");
        tableObj.column(getNumeroColumna).search(this.value).draw();
    });

    $('#' + tblMembresiaId + ' tbody').on('click', 'tr', function () {
        let rowx = $(this);
        if (rowx.hasClass('control') || rowx.hasClass('select-checkbox')) {
            return;
        }
        $('#' + tblMembresiaId + ' tbody tr.selected').removeClass('selected');
        rowx.addClass('selected');

    });

};

let getAjax = url => {
    return $.ajax({
        method: 'GET',
        url: url,
        timeout: 0,
        dataType: 'json',//El tipo de datos que espera del servidor.
        cache: false,
        contentType: "application/json; charset=utf-8",
        //contentType: "application/x-www-form-urlencoded; charset=UTF-8",
        enctype: 'application/x-www-form-urlencoded',
        async: true,
        crossDomain: true,
        beforeSend: xmlHttpRequest => {
            xmlHttpRequest.withCredentials = true;
            xmlHttpRequest.setRequestHeader('Cookie', 'AspxAutoDetectCookieSupport=1');
        }
    });
};

let RetrieveAll = () => {

    if ($.fn.DataTable.isDataTable('#' + tblMembresiaId)) {
        $('#' + tblMembresiaId).DataTable().clear().destroy();
    }

    $('#' + tblMembresiaId + ' > tbody').html('');
    getAjax(UrlApiServiceMembresiasSinExcepcion + '?CedulaEmpresa=' + cedulaEmpresa + '&AspxAutoDetectCookieSupport=1').done(resultado => {
        if (resultado.Data) {
            if ('object' == typeof resultado.Data) {
                resultado.Data.forEach(obj => {
                    const tdMolde = '<td class="text-center">';
                    let cells = '';
                    cells += tdMolde + obj.NombreEmpresa + '</td>';
                    cells += tdMolde + obj.NombreMembresia + '</td>';
                    cells += tdMolde + obj.TipoMembresia + '</td>';
                    cells += tdMolde + obj.Precio + '</td>';
                    cells += tdMolde + obj.VigenciaMeses + '</td>';
                    cells += tdMolde + obj.FeeReagendar + '</td>';
                    cells += tdMolde + obj.FeeCancelar + '</td>';
                    cells += tdMolde + obj.FeeServicio + '</td>';
                    cells += tdMolde + obj.FechaContratacionS + '</td>';
                    //cells += tdMolde + obj.Id_Estado + ' - ' + obj.Estado + '</td>';
                    cells += tdMolde + obj.Estado + '</td>';
                    cells += tdMolde + '<button onclick="cancelarMembresiaOferente(\'' + obj.IdMembresia + '\',\'' + obj.NombreMembresia + '\');return false;" class="btn btn-link btn-sm text-danger">' + '<i class="fas fa-minus-circle fa-2x"></i></button>' + '</td>';

                    //Agrega la fila al tbody de la tabla:
                    $('#' + tblMembresiaId + ' > tbody').append('<tr>' + cells + '</tr>');
                });

                //Cada vez que se rellene la tabla, vuelve a cargar el datatable:
                cargarDataTable(false);
            }
        }
    }).fail((request, textStatus, errorThrown) => {
        if (request.responseText) {
            mostrarMensaje('E', request.responseText);
        } else {
            mostrarMensaje('E', 'Ocurrió un error al llenar la tabla');
        }
    });
};

window.onload = () => {
    cedulaEmpresa = sessionStorage.getItem('IdUsuario');

    if (null !== cedulaEmpresa) {
        RetrieveAll();
    }
};
