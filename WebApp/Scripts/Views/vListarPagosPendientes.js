class vListarPagosPendientes {
    constructor() {
        this.service = 'Notificaciones?IdCliente=' + sessionStorage.getItem('IdUsuario');
        this.ctrlActions = new ControlActions();

        this.tabla = document.getElementById('tblPagosPendientes');

        this.getNotificaciones();

        $("#btnCerrar").hide();
        $("#x").hide();
    }

    getNotificaciones() {
        this.ctrlActions.GetToApi(this.service, (response) => {
            this.notificaciones = response.Data;
            this.llenarTabla();
        });
    }

    llenarTabla() {
        for (let i = 0; i < this.notificaciones.length; i++) {
            const notificacion = this.notificaciones[i];
            this.crearColumna(notificacion, (i + 1));
        }
        this.cargarDataTable();
    }

    crearColumna(notificacion, index) {
        this.solicitud = notificacion.IdSolicitud;
        const tableRef = this.tabla.getElementsByTagName('tbody')[0];
        const row = tableRef.insertRow();

        const msj = row.insertCell(0);
        const vermas = row.insertCell(1);

        msj.innerHTML = notificacion.Mensaje;

        const span = document.createElement('span');
        span.classList.add('text-muted');
        span.innerHTML = 'Ver factura';
        const i = document.createElement('i');
        i.classList.add('fas', 'fa-file-invoice', 'pl-2', 'text-primary', 'btn');
        i.style.fontSize = '20px';

        vermas.appendChild(span);
        vermas.appendChild(i);
        
        vermas.addEventListener('click', () => {
            this.mostrarModal(notificacion);
 
        });
    }

    mostrarModal(notificacion) {
        this.getEncabezadoFactura(notificacion);
        $('#fac').modal();
    }

    getEncabezadoFactura(notificacion) {
        const servicio = 'Factura?idSolicitud=' + notificacion.IdSolicitud;
        this.ctrlActions.GetToApi(servicio, (response) => {
            this.llenarEncabezado(response.Data, notificacion.IdSolicitud);
        });
    }

    llenarEncabezado(factura, idSolicitud) {
        const idFactura = document.getElementById('numFactura');
        const fecha = document.getElementById('Fecha');
        const nombreCliente = document.getElementById('nombreCompleto');

        idFactura.innerHTML = factura.IdFactura;
        fecha.innerHTML = factura.FechaEvento.substring(0, 10);
        nombreCliente.innerHTML = factura.NombreCompleto;
        this.numeroOrden = factura.IdFactura;
        this.getCuerpoFactura(idSolicitud, factura);
    }

    getCuerpoFactura(idSolicitud, factura) {
        this.ctrlActions.GetToApi('Detalle?idSolicitud=' + idSolicitud, (response) => {
            const cuerpoFactura = response.Data;
            this.llenarFacturaDetalle(cuerpoFactura, factura);
        });
    }

    llenarFacturaDetalle(cuerpoFactura, factura) {
        const body = document.getElementById('detalleFac');
        let i = 1;

        body.innerHTML = "";

        if ('object' === typeof cuerpoFactura)
        {
            cuerpoFactura.forEach(obj => {
                const tr = document.createElement('tr');
                let td = '';
                td += '<td>' + i + '</td>';
                td += '<td>' + obj.Descripcion + '</td>';
                td += '<td>' + obj.CantHoras + " horas"+'</td>';
                td += '<td>' + "$ "+obj.PrecioPorHora + '</td>';
                td += '<td>' + "$ " +obj.TotalLinea + '</td>';
                tr.innerHTML = td;
                body.appendChild(tr);
                i++;
            });
        }
        
        this.llenarTotales(factura);
    }

    llenarTotales(factura) {
        const subtotal = document.getElementById('subtotal');
        const iva = document.getElementById('equivalenteIva');
        const total = document.getElementById('total');
        const porcentajeIva = document.getElementById('porcentajeIva');

        const porcentaje = (parseInt(factura.Iva) / 100);
        const cobroIva = porcentaje * factura.Subtotal;

        subtotal.innerHTML = "$ " +factura.Subtotal;
        iva.innerHTML = "$ " + cobroIva;
        total.innerHTML = "$ " + factura.Total;
        porcentajeIva.innerHTML = "(" + factura.Iva + "%)"

        
        this.cargarBoton(factura.Total);
    }

    cargarBoton(precio) {
        const x = document.getElementById('btn1');
        x.innerHTML = "";
        paypal.Button.render({
            env: 'sandbox',
            client: {
                sandbox: 'Ae4cyZyBw0oihOj_Zi0fPjTdLGNaOmP3qqUgfC6juFiJuQx2gVxgocCA5jG3NmSs4KvUcqrhQ1yK7JbL',
                production: 'EDIubp2LOh3E66MN9PIBmOPOo1j801GT4ioATphd6fZmytGcRzyj9sxrpAYzcUTFTwFaNvhfl73s9H8O'
            },
            locale: 'es_US',
            style: {
                size: 'medium',
                color: 'gold',
                shape: 'pill',
            },
            commit: true,
            payment: function (data, actions) {
                return actions.payment.create({
                    transactions: [{
                        amount: {
                            total: precio,
                            currency: 'USD'
                        }
                    }]
                });
            },
            onAuthorize: function (data, actions) {
                return actions.payment.execute().then(function () {
                    $("#fac").modal('hide');
                    $("#ready").modal();
                    
                });
            }
        }, "#btn1");
    }

    crearObjetoPago() {
        const notificacion = {
            "IdSolicitud": this.solicitud
        }

        this.registrarPago(notificacion);
    }

    registrarPago(notificacion) {
        
        this.ctrlActions.PostToAPI('PagoSolicitud', notificacion, () => {
            this.descargarPDF(() => {
                this.recargar();
            });
            
        });
        
    }

    descargarPDF(callback) {
        const num = this.numeroOrden;
        var element = document.getElementById('invoice');
        var opt = {
            margin: 1,
            filename: 'Factura(' + num + ').pdf',
            image: { type: 'jpeg', quality: 0.98 },
            html2canvas: { scale: 2 },
            jsPDF: { unit: 'in', format: 'letter', orientation: 'portrait' }
        };

        // New Promise-based usage:
        html2pdf().set(opt).from(element).save();

        callback();
    }

    recargar() {
        this.tabla.innerHTML = "";
        this.getNotificaciones();
        $("#ready").modal('hide');
    }

    crearEventos() {
        const btn = document.getElementById('pago');
        btn.addEventListener('click', () => { this.crearObjetoPago() });
       // btn.addEventListener('click', () => { this.descargarPDF() });
    }

    cargarDataTable(seDescarga = false) {

        //Creamos una instancia de la clase, en el contexto actual:
        const selft = '#tblPagosPendientes';

        let numeroColumna = 0;
        $(selft + ' tr#trbusqueda th').each(function () {
            const classID = 'busquedaCelda' + selft.replace('#', '');
            let title = $(this).text() || '';
            if (numeroColumna === 0 && $(this).hasClass("descartar-celda") === false) {
                $(this).html('<input type="text" id="' + numeroColumna + '" class="' + classID + ' form-control text-center mx-0 my-0 pt-0 py-1" style="min-width: 80px; font: inherit; font-size: 13px; font-family: \'Font Awesome 5 Free\'; position: inherit; left: 0; bottom: 0;" placeholder="&#xf002; ' + title.trim() + '" />');

            } else {
                $(this).html('');
            }
            ++numeroColumna;
        });

        $(selft + ' thead#theadBusqueda').removeClass('d-none');

        let tableObj = $(selft).DataTable({
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
            "order": [[0, "asc"]],
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
        $('input.busquedaCelda' + selft.replace('#', '')).on('keyup change clear', function () {
            //console.log('Buscando: ' + this.value);
            let getNumeroColumna = $(this).attr("id");
            tableObj.column(getNumeroColumna).search(this.value).draw();
        });

        $(selft + ' tbody').on('click', 'tr', function () {
            let rowx = $(this);
            if (rowx.hasClass('control') || rowx.hasClass('select-checkbox')) {
                return;
            }
            $(selft + ' tbody tr.selected').removeClass('selected');
            rowx.addClass('selected');
        });

    }
    
}

document.addEventListener("DOMContentLoaded", function (event) {
    const controller = new vListarPagosPendientes();
    controller.crearEventos();
});