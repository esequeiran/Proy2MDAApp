
class vModificarAdministrador {
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
        this.service = 'Administrador?identificacion=' + sessionStorage.getItem('IdUsuario');
        this.ctrlActions = new ControlActions();
        //metodos
        this.Admin;
        this.disabledInputs();
        this.getAdmin();
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

    //trae la informacion de un administrador
    getAdmin() {
        this.ctrlActions.GetToApi(this.service, (response) => {
            this.Admin = response;
            this.llenarInputs(this.Admin);
        });
    }

    // rellenar los inputs con la información correspondiente
    llenarInputs(admin) {
        //debugger
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

        //const date = ;
        //console.log(date);
        //const val = new Date(date);
        //const val = IPOfecha.setTime(Date.parse(date));
     
        //const dateBirth = val;
        //const dateBirth = val.toISOString().slice(0, 10);

        tipoId.value = admin.Data.TipoIdentificacion;
        id.value = admin.Data.Identificacion;
        nombre.value = admin.Data.Nombre;
        apellidoUno.value = admin.Data.ApellidoUno;
        apellidoDos.value = admin.Data.ApellidoDos;
        pais.value = admin.Data.PaisNacimiento;
        telefono.value = admin.Data.Telefono;
        correo.value = admin.Data.Correo;
        const date = new Date(admin.Data.FechaNacimiento);
        fechaNac.value = date.toISOString().slice(0, 10);


        this.sltGenero.value = this.obtenerGeneroId(admin.Data.Genero);
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

    //modificar administrador
    modificarAdministrador() {
        const administradorData = this.ctrlActions.GetDataForm('frmEditar');
        administradorData.Genero = this.obtenerGeneroNombre(parseInt(administradorData.Genero));
        this.ctrlActions.PutToAPI(this.service, administradorData);

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
        this.getAdmin();
    }
    //END

    crearEventos() {
        document.addEventListener('keyup', () => { this.validateForm() });
        this.btnModificar.addEventListener('click', () => { this.modificarAdministrador() });
        this.btnCancelar.addEventListener('click', () => { this.cancelarAccion() })

        this.sltGenero.addEventListener('change', () => { this.validateForm() });
    }

}

document.addEventListener("DOMContentLoaded", function (event) {
    const controller = new vModificarAdministrador();
    controller.crearEventos();
});