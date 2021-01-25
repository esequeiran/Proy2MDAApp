class vPerfilCliente {
    constructor() {
        //servicios
        this.service = 'Cliente?identificacion=116570734';//+ sessionStorage.getItem('IdUsuario');
        this.ctrlActions = new ControlActions();

        this.disabledInputs();
        this.getCliente();
    }

    getCliente() {
        this.ctrlActions.GetToApi(this.service, (response) => {
            this.cliente = response;
            this.llenarInputs(this.cliente);
        });
    }

    disabledInputs() {
        $("#selectTipoId").attr('disabled', 'disabled');
        $("#txtId").attr('disabled', 'disabled');
        $("#txtNombre").attr('disabled', 'disabled');
        $("#txtApellidoUno").attr('disabled', 'disabled');
        $("#txtApellidoDos").attr('disabled', 'disabled');
        $("#txtFechaNacimiento").attr('disabled', 'disabled');
        $("#selectPais").attr('disabled', 'disabled');
        $("#selectGenero").attr('disabled', 'disabled');
        $("#txtTelefono").attr('disabled', 'disabled');
        $("#txtCorreo").attr('disabled', 'disabled');
    }

    llenarInputs(cliente) {
        const tipoId = document.getElementById('selectTipoId');
        const id = document.getElementById('txtId');
        const nombre = document.getElementById('txtNombre');
        const apellidoUno = document.getElementById('txtApellidoUno');
        const apellidoDos = document.getElementById('txtApellidoDos');
        const fechaNac = document.getElementById('txtFechaNacimiento');
        const pais = document.getElementById('selectPais');
        const genero = document.getElementById('selectGenero');
        const telefono = document.getElementById('txtTelefono');
        const correo = document.getElementById('txtCorreo');

        tipoId.value = cliente.Data.TipoIdentificacion;
        id.value = cliente.Data.Identificacion;
        nombre.value = cliente.Data.Nombre;
        apellidoUno.value = cliente.Data.ApellidoUno;
        apellidoDos.value = cliente.Data.ApellidoDos;
        pais.value = cliente.Data.PaisNacimiento;
        telefono.value = cliente.Data.Telefono;
        correo.value = cliente.Data.Correo;
        genero.value = cliente.Data.Genero;
        const date = new Date(cliente.Data.FechaNacimiento);
        fechaNac.value = date.toISOString().slice(0, 10);
    }
}
document.addEventListener("DOMContentLoaded", function (event) {
    const controller = new vPerfilCliente();
    controller.crearEventos();
});