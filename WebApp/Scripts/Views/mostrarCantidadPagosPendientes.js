class pagosPendientes {
    constructor() {
        this.service = 'Notificacion?IdCliente=' + sessionStorage.getItem('IdUsuario');
        this.ctrlActions = new ControlActions();
        this.span = document.getElementById('cantidadPendiente');

        this.getTotalPagosPendientes();
    }

    getTotalPagosPendientes() {
        this.ctrlActions.GetToApi(this.service, (response) => {
            this.cantidad = response.Data.CantNotificaciones || 0;
            this.mostrarNotificacion();
        });
    }

    mostrarNotificacion() {
        if (this.cantidad > 0) {
            this.span.classList.remove('d-none');
            this.span.classList.add('d-inline');
            this.span.innerHTML = this.cantidad;
        }
    }
}

document.addEventListener("DOMContentLoaded", function (event) {
    const controller = new pagosPendientes();
    //controller.crearEventos();
});