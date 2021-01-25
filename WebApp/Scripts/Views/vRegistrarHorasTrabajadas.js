class vRegistrarHorasTrabajadas {
    constructor() {
        //servicios
        this.service = 'HorasTrabajadas';
        this.ctrlActions = new ControlActions();
        //botones
        this.btnRegistrar = document.getElementById('btnGuardar');
        //Tabla
        this.tabla = document.getElementById('tblTiposTrabajo');
        //variables
        this.tiposTrabajo;
        this.actualTrabajo;
        
        //métodos
        this.getTiposTrabajoSolicitud();  
    }

    //trae la localizaciones de un usuario
    getTiposTrabajoSolicitud() {
        this.ctrlActions.GetToApi(this.service + '?idtipo=' + sessionStorage.getItem('idSolicitud'), (response) => {
            this.llenarTabla(response.Data);
        });
    }

    cargarDataTable(seDescarga = false) {

        //Creamos una instancia de la clase, en el contexto actual:
        const selft = '#tblTiposTrabajo';

        let numeroColumna = 0;
        $(selft + ' tr#trbusqueda th').each(function () {
            const classID = 'busquedaCelda' + selft.replace('#', '');
            let title = $(this).text() || '';
            if ($(this).hasClass("descartar-celda") === false) {
                $(this).html('<input type="text" id="' + numeroColumna + '" class="' + classID + ' form-control text-center mx-0 my-0 pt-0 py-1" style="min-width: 80px; font: inherit; font-size: 13px; font-family: \'Font Awesome 5 Free\'; position: inherit; left: 0; bottom: 0;" placeholder="&#xf002; ' + title.trim() + '" />');
                
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

    llenarTabla(response) {
        this.tiposTrabajo = response;
        this.tabla.getElementsByTagName('tbody').innerHTML = '';
        for (let i = 0; i < this.tiposTrabajo.length; i++) {
            const trabajo = this.tiposTrabajo[i];
            this.crearColumna(trabajo, (i + 1));
        }

        this.cargarDataTable();
    }

    crearColumna(trabajo, index) {
        const tableRef = this.tabla.getElementsByTagName('tbody')[0];
        const row = tableRef.insertRow();
        
        const nombre = row.insertCell(0);
        const cantHoras = row.insertCell(1);
        nombre.innerHTML = trabajo.Nombre_TipoTrabajo;

        const hrs = trabajo.HorasTrabajadas;

        if (hrs === 0 || hrs === -1) {
            const span = document.createElement('span');
            span.classList.add('text-muted');
            span.innerHTML = 'Horas no registradas';
            span.id = 'cant' + index;
            const i = document.createElement('i');
            i.classList.add('fas', 'fa-plus-circle', 'pl-2');
            i.style.fontSize = '20px';

            cantHoras.appendChild(span);
            cantHoras.appendChild(i);
            cantHoras.addEventListener('click', () => {
                this.trabajoActual = trabajo;
                this.mostrarModal();
            });
        } else {
            cantHoras.innerHTML = trabajo.HorasTrabajadas + " horas";
        }
    }

    //Mostrar modal
    mostrarModal() {
        $("#save").modal();
        
    }

    getValuesForm() {
        const input = document.getElementById('txtHoras');
        const hrs = input.value;
        this.trabajoActual.HorasTrabajadas = hrs;
        this.createObj();
    }

    createObj() {
        const SolicitudDeTrabajo = {
            "IdSolicitud": sessionStorage.getItem('idSolicitud'), //agarrar del session Storage
            "TipoTrabajo": this.trabajoActual.Id_TipoTrabajo,
            "HorasTrabajadas": this.trabajoActual.HorasTrabajadas,
            "Descripcion": this.trabajoActual.Nombre_TipoTrabajo
        }
        this.postApi(SolicitudDeTrabajo);
    }

    postApi(SolicitudData) {
        this.ctrlActions.PostToAPI(this.service, SolicitudData, () => {
            
            this.getTiposTrabajoSolicitud();
            this.clearForm();
            this.tabla.innerHTML = "";
            this.getTiposTrabajoSolicitud();  
            location.reload(true);
        });
        

        
    }

    clearForm() {
        const inputs = Array.from(document.querySelectorAll('.required'), (input) => {
            input.value = '';
            input.classList.remove('is-valid');
            return input;
        });
    }

    Notificar() {
        this.crearNotificacion();
    }

    crearNotificacion() {
        const notificacion = {
            "IdSolicitud": sessionStorage.getItem('idSolicitud'), //TRAER DE SESSION STORAGE
            "Mensaje": "Hay un pago pendiente a realizar."

        };
        

        this.ctrlActions.PostToAPI('NotificacionCreate', notificacion, () => {
            this.redireccionar();
        });

        
        
    }

    redireccionar() {
       window.location.href = 'http://localhost:61102/Home/vIndexInterno';
    }
    //Validar Campo
    get formInputs() {
        const inputs = Array.from(document.querySelectorAll('.required'), (input) => {
            const inputData = {
                isValid: input.validity.valid,
                element: input,
                small: input.nextElementSibling
            }
            return inputData;
        });
        return inputs;
    }

    desactivarBtn() {
        this.btnRegistrar.classList.add('disabled');
        this.btnRegistrar.disabled = true;
    }

    activarBtn() {
        this.btnRegistrar.classList.remove('disabled');
        this.btnRegistrar.removeAttribute('disabled');
    }

    //Validar campos del form
    validateForm() {
        let valido = true;
        for (const dataKey in this.formInputs) {
            if (this.formInputs.hasOwnProperty(dataKey)) {
                const currentData = this.formInputs[dataKey];
                if (currentData.isValid === false) {
                    valido = false;
                    currentData.element.classList.add('is-invalid');
                    currentData.small.classList.remove('text-muted');
                    currentData.small.classList.add('invalid-feedback');
                } else {
                    if (currentData.element.value === '0') {
                        valido = false;
                        currentData.element.classList.add('is-invalid');
                        currentData.small.classList.remove('text-muted');
                        currentData.small.classList.remove('d-none');
                        currentData.small.classList.add('invalid-feedback');
                    } else {
                        currentData.element.classList.remove('is-invalid');
                        currentData.element.classList.add('is-valid');
                        currentData.small.classList.remove('text-muted');
                        currentData.small.classList.remove('invalid-feedback');
                        currentData.small.classList.add('d-none');
                    }
                }
            }
        }
        if (valido === true) {
            this.activarBtn();
        } else {
            this.desactivarBtn();
        }
    }
    //END

    crearEventos() {
        document.addEventListener('keyup', () => { this.validateForm() });
        this.btnRegistrar.addEventListener('click', () => {
            this.getValuesForm();
            this.validateForm();
        });

        const btnNotificar = document.getElementById('notificar');
        btnNotificar.addEventListener('click', () => { this.Notificar() });

        const btnCancelar = document.getElementById('btnCerrar');
        btnCancelar.addEventListener('click', () => { this.clearForm() });
    }
}

document.addEventListener("DOMContentLoaded", function (event) {
    const controller = new vRegistrarHorasTrabajadas();
    controller.crearEventos();
});