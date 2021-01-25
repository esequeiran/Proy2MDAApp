class vConfigurarIVA {
    constructor() {
        this.btnModificar = document.getElementById('btnModificar');
        this.btnCancelar = document.getElementById('btnCancelar');
        //servicios
        this.service = 'Iva';
        this.ctrlActions = new ControlActions();
        //metodos
        this.getIVA();
    }

    getIVA() {
        this.ctrlActions.GetToApi(this.service, (response) => {
            const iva = response;
            this.llenarInput(iva);
        });
    }

    cancelarAccion() {
        this.getIVA();
    }

    llenarInput(piva) {
        const iva = document.getElementById('txtIva');
        iva.value = piva.Data.PorcentajeIVA;
    }

    //validar campos
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
    //END



    //modificar IVA
    modificar() {
        const IvaData = this.ctrlActions.GetDataForm('frmEditar');
        this.ctrlActions.PutToAPI('Iva', IvaData);
    }

    crearEventos() {
        this.btnModificar.addEventListener('click', () => { this.validateForm() });
        this.btnModificar.addEventListener('click', () => { this.modificar() });
        this.btnCancelar.addEventListener('click', () => { this.cancelarAccion() });
    }
}

document.addEventListener("DOMContentLoaded", function (event) {
    const controller = new vConfigurarIVA();
    controller.crearEventos();
});