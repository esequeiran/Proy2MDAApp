class vDashboardAdmin {
    constructor() {
        //servicios
        this.service = 'Ingresos?identificacion=109958746';
        this.ctrlActions = new ControlActions();
        //variables locales
        this.ingresos;
        this.getIngresos();
        this.oferentesTopTen;
        this.solicitudesRegistro;
        //tablas
        this.tablaIngresos = document.getElementById('tblOferentesIngresos');
        this.tablaSolicitudes = document.getElementById('tblSolicitudesRegistro');
        //métodos de la clase
        this.getOferentesMasIngresos();
        this.getSolicitudesRegistroNuevas();

        $("table thead:nth-child(0n+2)").addClass("d-none");
    }

    //Trae los ingresos del APP
    getIngresos() {
        this.ctrlActions.GetToApi(this.service, (response) => {
            const ingresos = response.Data;
            for (let i = 0; i < ingresos.length; i++) {
                const ingreso = ingresos[i];
                ingreso.Fecha = new Date(ingreso.Fecha);
                ingresos[i] = ingreso
            }
            this.ingresos = ingresos;
            this.llenarGrafico();
        });
    }

    //Trae los Oferentes con más ingresos
    getOferentesMasIngresos() {
        this.ctrlActions.GetToApi('TopTen', (response) => {
            this.oferentesTopTen = response.Data;
            this.llenarTablaOferentes();
        });
    }

    //trae las solicitudes recientes
    getSolicitudesRegistroNuevas() {
        this.ctrlActions.GetToApi('Oferente', (response) => {
            this.solicitudesRegistro = response.Data;
            console.log(this.solicitudesRegistro);
            this.llenarTablaSolicitudes();
        });
    }

    //Llena el gráfico
    llenarGrafico() {
        const ingresos = document.getElementById(`ingresos`).getContext(`2d`);
        let montos = [];
        let fechas = [];
        
        for (let i = 0; i < this.ingresos.length; i++) {
            montos.push(this.ingresos[i].Monto);
            fechas.push(this.ingresos[i].Fecha.toLocaleDateString());
        }
        const data = {
            type: `bar`,
            data: {
                labels: fechas,
                datasets: [{
                    data: montos,
                    borderColor: `rgba(243, 156, 18, 0.5)`,
                    backgroundColor: `rgba(241, 196, 15, 0.5)`,
                    label: `Ingresos`
                }]
            }
        }
        const test = new Chart(ingresos, data);
    }  

    cargarDataTableOferentes(seDescarga = false) {

        //Creamos una instancia de la clase, en el contexto actual:
        const selft = '#tblOferentesIngresos';

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

    //Llena tabla de los oferentes que más ingresos genera
    llenarTablaOferentes() {
        for (let i = 0; i < this.oferentesTopTen.length; i++) {
            const oferente = this.oferentesTopTen[i];
            this.crearColumnaTblOferentes(oferente, (i + 1));
        }
        this.cargarDataTableOferentes();
    }

    crearColumnaTblOferentes(oferente, index) {
        const tableRef = this.tablaIngresos.getElementsByTagName('tbody')[0];
        const row = tableRef.insertRow();
        const identificacion = row.insertCell(0);
        const nombreComercial = row.insertCell(1);
        const totalIngresos = row.insertCell(2);

        identificacion.innerHTML = oferente.Cedula
        nombreComercial.innerHTML = oferente.NombreComercial;
        totalIngresos.innerHTML ="$ " + oferente.TotalIngresosGenerados;

        row.addEventListener('click', () => {
            if (this.rowselected !== undefined) {
                this.rowselected.classList.remove("table-active");
            }
            this.rowselected = row;
            this.rowselected.classList.add("table-active");
            this.verificarRedireccionarPerfilOferente(oferente);
        });
    }

    verificarRedireccionarPerfilOferente(oferente) {
        //implementar el redireccionar cuando Daniel tenga el perfil listo****
        //console.log(oferente.Cedula);
    }

    //llena la tabla de las solicitudes
    cargarDataTableSolicitudes(seDescarga = false) {

        //Creamos una instancia de la clase, en el contexto actual:
        const selft = '#tblSolicitudesRegistro';

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


    llenarTablaSolicitudes() {
        for (let i = 0; i < this.solicitudesRegistro.length; i++) {
            const solicitud = this.solicitudesRegistro[i];
            this.crearColumnaSolicitud(solicitud, (i + 1));
        }
        this.cargarDataTableSolicitudes();
    }

    crearColumnaSolicitud(solicitud, index) {
        const tableRef = this.tablaSolicitudes.getElementsByTagName('tbody')[0];
        const row = tableRef.insertRow();

        const cedula = row.insertCell(0);
        const nombre = row.insertCell(1);
        const nombreComercial = row.insertCell(2);

        cedula.innerHTML = solicitud.Cedula;
        nombre.innerHTML = solicitud.Nombre;
        nombreComercial.innerHTML = solicitud.NombreComercial;

        row.addEventListener('click', () => {
            if (this.rowselected !== undefined) {
                this.rowselected.classList.remove("table-active");
            }
            this.rowselected = row;
            this.rowselected.classList.add("table-active");
            this.verificarRedireccionarVistaSolicitudes(solicitud);
        });
    }

    verificarRedireccionarVistaSolicitudes(oferente) {
        $("#solicitud").modal();
    }

    redireccionarSolicitudes() {
        window.location.href = 'http://localhost:61102/Home/vSolicitudRegistro';
    }

    crearEventos() {
        const btnSolicitudes = document.getElementById('verSolicitudes');
        btnSolicitudes.addEventListener('click', () => { this.redireccionarSolicitudes() });
        // redirecciona a la pagina del perfil que Daniel está haciendo const btnOferente = document.getElementById('verOferente');
    }
}

document.addEventListener("DOMContentLoaded", function (event) {
    const controller = new vDashboardAdmin();
    controller.crearEventos();
});