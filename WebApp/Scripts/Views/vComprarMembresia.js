class vComprarMembresia {
    constructor() {
        this.ctrlActions = new ControlActions();

        let url_string = window.location.href;
        let url = new URL(url_string);
        console.log(url);
       

        this.service = 'Membresia?CedulaEmpresa=' + url.searchParams.get('Cedula');
        this.tabla = document.getElementById('tblMembresia');
        this.pago = document.getElementById('pago');
        $('#btnCerrar').hide();

        this.disabledInputs();
        this.getMembresias();
        this.MembresiaActual;
        this.Cedula = url.searchParams.get('Cedula');
        $("table thead:nth-child(0n+2)").addClass("d-none");
    }


    getMembresias() {
        this.ctrlActions.GetToApi(this.service, (response) => {
            var membresiasRegistradas = response.Data;
            console.log(response);
            this.llenarTabla(membresiasRegistradas);
        });
    }

    cargarDataTable(seDescarga = false) {

        //Creamos una instancia de la clase, en el contexto actual:
        const selft = '#tblMembresia';

        let numeroColumna = 0;
        $(selft + ' tr#trbusqueda th').each(function () {
            const classID = 'busquedaCelda' + selft.replace('#', '');
            let title = $(this).text() || '';
            if ($(this).hasClass("descartar-celda") === false) {
                $(this).html('<input type="text" id="' + numeroColumna + '" class="' + classID + ' form-control text-center mx-0 my-0 pt-0 py-1" style="min-width: 80px; font: inherit; font-size: 13px; font-family: \'Font Awesome 5 Free\'; position: inherit; left: 0; bottom: 0;" placeholder="&#xf002; ' + title.trim() + '" />');
                ++numeroColumna;
            }
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

    llenarTabla(membresiasRegistradas) {
        for (let i = 0; i < membresiasRegistradas.length; i++) {
            const membresia = membresiasRegistradas[i];
            this.crearColumnas(membresia, (i + 1));
        }
        //this.cargarDataTable();
    }

    crearColumnas(membresia, index) {
        const tableRef = this.tabla.getElementsByTagName('tbody')[0];
        const row = tableRef.insertRow();
        const nombre = row.insertCell(0);
        const tipoMembresia = row.insertCell(1);
        const precio = row.insertCell(2);
        const vigencia = row.insertCell(3);

        nombre.innerHTML = membresia.NombreMembresia;
        tipoMembresia.innerHTML = membresia.TipoMembresia;
        precio.innerHTML = "$ " + membresia.Precio;

        if (membresia.VigenciaMeses === 1) {
            vigencia.innerHTML = membresia.VigenciaMeses + " mes";
        } else {
            vigencia.innerHTML = membresia.VigenciaMeses + " meses";
        }

        row.addEventListener('click', () => {

            this.llenarInputs(membresia);
        });

    }

    llenarInputs(membresia) {

        const nombre = document.getElementById('txtNombre');
        const tipoMembresia = document.getElementById('txtTipo');
        const precio = document.getElementById('txtPrecio');
        const duracion = document.getElementById('txtDuracion');
        const feeServicio = document.getElementById('txtFeeServicio');
        const feeCancelar = document.getElementById('txtFeeCancelar');
        const feeReagendar = document.getElementById('txtFeeReagendar');

        nombre.value = membresia.NombreMembresia;
        tipoMembresia.value = membresia.TipoMembresia;
        precio.value = "$ " + membresia.Precio;
        feeServicio.value = membresia.FeeServicio + "%";
        feeCancelar.value = "$ " + membresia.FeeCancelar;
        feeReagendar.value = "$ " + membresia.FeeReagendar;
        

        if (membresia.VigenciaMeses === 1) {
            duracion.value = membresia.VigenciaMeses + " mes";
        } else {
            duracion.value = membresia.VigenciaMeses + " meses";
        }
        membresia.CedulaEmpresa = this.Cedula;
        console.log(membresia.CedulaEmpresa);
        this.MembresiaActual = membresia;

        this.cargarBoton(membresia.Precio);

    }

    disabledInputs() {
        $("#txtNombre").attr('disabled', 'disabled');
        $("#txtTipo").attr('disabled', 'disabled');
        $("#txtPrecio").attr('disabled', 'disabled');
        $("#txtDuracion").attr('disabled', 'disabled');
        $("#txtFeeServicio").attr('disabled', 'disabled');
        $("#txtFeeCancelar").attr('disabled', 'disabled');
        $("#txtFeeReagendar").attr('disabled', 'disabled');
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
                    $("#ready").modal();
                });
            }
        }, "#btn1");
    }


    cambiarEstadoMembresia() {
        const membresiaData = this.MembresiaActual;
        //const servicio = 'AdquirirMembresia?' + membresiaData;

        this.ctrlActions.PutPaymentApi('AdquirirMembresia', membresiaData, (response) => {
            console.log(response);
            this.redireccionar();
        });
    }

    redireccionar() {
        window.location.href = 'http://localhost:61102';
    }

    crearEventos() {
        const btn = document.getElementById('pago');
        btn.addEventListener('click', () => { this.cambiarEstadoMembresia() });
    }
}

document.addEventListener("DOMContentLoaded", function (event) {
    const controller = new vComprarMembresia();
    controller.crearEventos();
});