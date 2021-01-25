class vModificarCliente {
    constructor() {
        //elementos HTML
        this.generos = [
            { idGenero: 0, nombre: "-Seleccione una opción-" },
            { idGenero: 1, nombre: "Masculino" },
            { idGenero: 2, nombre: "Femenino" },
            { idGenero: 3, nombre: "Otro" },
            { idGenero: 4, nombre: "Prefiero no específicar" },
        ]
        this.sltGenero = document.querySelector('#selectGenero');
        this.btnModificar = document.getElementById('btnEdit');
        this.btnCancelar = document.getElementById('btnCancel');
        // servicios
        this.service = 'Cliente?identificacion=' + sessionStorage.getItem('IdUsuario');//+ sessionStorage.getItem('IdUsuario');
        this.ctrlActions = new ControlActions();
        //metodos
        this.cliente;
        this.disabledInputs();
        this.getCliente();
        this.fillsltGenero();
    }

    //Desactiva campos no editables
    disabledInputs() {
        $("#selectTipoId").attr('disabled', 'disabled');
        $("#txtId").attr('disabled', 'disabled');
        $("#txtFechaNacimiento").attr('disabled', 'disabled');
        $("#selectPais").attr('disabled', 'disabled');
        $("#txtCorreo").attr('disabled', 'disabled');
    }

    fillsltGenero() {
        for (const genero of this.generos) {
            this.sltGenero.options.add(new Option(genero.nombre, genero.idGenero));
        }
    }

    //trae la informacion de un Cliente
    getCliente() {
        this.ctrlActions.GetToApi(this.service, (response) => {
            this.cliente = response;
            this.llenarInputs(this.cliente);
        });
    }

    // rellenar los inputs con la información correspondiente
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

        const date = new Date(cliente.Data.FechaNacimiento);
        fechaNac.value = date.toISOString().slice(0, 10);


        this.sltGenero.value = this.obtenerGeneroId(cliente.Data.Genero);
    }

    obtenerGeneroId(nombreGenero) {
        let genero;
        for (const genre of this.generos) {
            if (genre.nombre === nombreGenero) {
                genero = genre.idGenero;
            }
        }
        return genero;
    }
    //END LlenarInputs

    //validar campos
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
        this.btnModificar.classList.add('disabled');
        this.btnModificar.disabled = true;
    }

    activarBtn() {
        this.btnModificar.classList.remove('disabled');
        this.btnModificar.removeAttribute('disabled');
    }

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
    //END validar


    //modificar Cliente
    modificarCliente() {
        const clienteData = this.ctrlActions.GetDataForm('frmEditar');
        clienteData.Genero = this.obtenerGeneroNombre(parseInt(clienteData.Genero));
        this.ctrlActions.PutToAPI(this.service, clienteData);

    }

    obtenerGeneroNombre(id) {
        let nombreGenero;
        for (const genero of this.generos) {
            if (genero.idGenero === id) {
                nombreGenero = genero.nombre;
            }
        }
        return nombreGenero;
    }
    //END

    //cancelar
    cancelarAccion() {
        this.getCliente();
    }
    //END

    crearEventos() {
        document.addEventListener('keyup', () => { this.validateForm() });
        this.btnModificar.addEventListener('click', () => { this.modificarCliente(), this.getCliente() });
        this.btnCancelar.addEventListener('click', () => { this.cancelarAccion() })

        this.sltGenero.addEventListener('change', () => { this.validateForm() });
    }
}
document.addEventListener("DOMContentLoaded", function (event) {
    const controller = new vModificarCliente();
    controller.crearEventos();
});