class vListarSolicitudesPendientesHoras {
    constructor() {
        //servicios
        this.service = 'SolicitudHora?idEmpresa=' + sessionStorage.getItem('IdUsuario');
        this.ctrlActions = new ControlActions();

        //Tabla
        this.tabla = document.getElementById('tblSolicitudesph');
        //variables
        this.tiposTrabajo;
        this.actualSolicitud;

        //métodos
        this.getSolicitudesPendientesH();  
    }

    getSolicitudesPendientesH() {
        
        this.ctrlActions.GetToApi(this.service, (response) => {
            this.llenarTabla(response.Data);
        });
       
    }

    llenarTabla(response) {
        this.solicitudesph = response;
        this.tabla.getElementsByTagName('tbody').innerHTML = '';
        for (let i = 0; i < this.solicitudesph.length; i++) {
            const solicitud = this.solicitudesph[i];
            this.crearColumna(solicitud, (i + 1));
        }
        this.cargarDataTable();
    }

    crearColumna(solicitud, index) {
        const tableRef = this.tabla.getElementsByTagName('tbody')[0];
        const row = tableRef.insertRow();

        const fecha = row.insertCell(0);
        const nombreCompleto = row.insertCell(1);
        const descripcionNecesidad = row.insertCell(2);
        const agregarHoras = row.insertCell(3);

        let date = new Date(solicitud.FechaEvento);

        fecha.innerHTML = date.toLocaleDateString();
        nombreCompleto.innerHTML = solicitud.NombreCompletoCliente;
        descripcionNecesidad.innerHTML = solicitud.DescripcionNecesidad;

        const span = document.createElement('span');
        span.classList.add('text-muted');
        span.innerHTML = 'Agregar horas';

        const i = document.createElement('i');
        i.classList.add('fas', 'fa-plus-circle', 'pl-2', 'text-primary');
        i.style.fontSize = '20px';

        agregarHoras.appendChild(span);
        agregarHoras.appendChild(i);
        agregarHoras.addEventListener('click', () => {
            sessionStorage.setItem('idSolicitud', solicitud.IdSolicitud);
            location.href = "http://localhost:61102/Home/vRegistrarHorasTrabajadas";
        });
    }

    cargarDataTable(seDescarga = false) {

        //Creamos una instancia de la clase, en el contexto actual:
        const selft = '#tblSolicitudesph';

        let numeroColumna = 0;
        $(selft + ' tr#trbusqueda th').each(function () {
            const classID = 'busquedaCelda' + selft.replace('#', '');
            let title = $(this).text() || '';
            if (numeroColumna !== 3 && $(this).hasClass("descartar-celda") === false) {
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
    const controller = new vListarSolicitudesPendientesHoras();
    //controller.crearEventos();
});