class vRegistrarTrabajadores {
    constructor() {
        this.generos = [
            { idGenero: 0, nombre: "-Seleccione una opción-" },
            { idGenero: 1, nombre: "Masculino" },
            { idGenero: 2, nombre: "Femenino" },
            { idGenero: 3, nombre: "Otro" },
            { idGenero: 4, nombre: "Prefiero no específicar" },
        ];

       
        this.sltGenero = document.getElementById('selectGenero');

        this.btnRegistrar = document.getElementById('btnCrearTrabajador');
        this.ctrlActions = new ControlActions();
        this.fillsltGenero();

        this.desactivarBtn();
    }
    get formInputs() {
        const inputs = Array.from(document.querySelectorAll(".required"), (input) => {
            const inputData = {
                isValid: input.validity.valid,
                element: input,
                small: input.nextElementSibling
            }
            return inputData;
        });
        return inputs;
    }



    obtenerGeneroId = function (id) {
        let genero;
        var generosId = new vRegistrarTrabajadores;

        for (const genre of generosId.generos) {
            if (genre.idGenero == id) {
                genero = genre.nombre;
            }
        }
        return genero;
    }


 

    fillsltGenero() {
        for (const genero of this.generos) {
            this.sltGenero.options.add(new Option(genero.nombre, genero.idGenero));
        }
    }




    fillslts() {
        this.fillsltGenero();

    }


    desactivarBtn() {
        this.btnRegistrar.classList.add('disabled');
        this.btnRegistrar.disabled = true;
    }

    activarBtn() {
        this.btnRegistrar.classList.remove('disabled');
        this.btnRegistrar.removeAttribute('disabled');
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



    clearForm() {
        const inputs = Array.from(document.querySelectorAll('.form-control'), (input) => {
            input.value = '';
            input.classList.remove('is-valid');
            return input;
        });
        this.fillslts();
    }



    crearEventos() {
        document.addEventListener('keyup', () => { this.validateForm() });
        this.sltGenero.addEventListener('change', () => { this.validateForm() });
    
    }

}
function vRegistroTrabajador() {

    //CAPTCHA
    // create the frontend captcha instance in the DOM.ready event-handler;
    // and set the captchaEndpoint property to point to 
    // the captcha endpoint path on your app's backend
    var captcha = $('#botdetect-captcha').captcha({
        captchaEndpoint: 'http://localhost:61079/simple-captcha-endpoint.ashx'
    });
    //CAPTCHA

    this.service = 'Trabajador';
    this.ctrlActions = new ControlActions();

    this.CrearTrabajador = function () {
        var fec = (new Date).getFullYear();
        var fecNacimiento = $('#txtFecNacimiento')[0].value.split('-');
        var edad = ( fec[0] - fecNacimiento[0]);
        if (edad < 18) {
            this.ctrlActions = new ControlActions();
            this.ctrlActions.ShowMessage('E', "Debe ser mayor a 18 años para poder registrarse en la aplicación.");
            return false;
        }

        var nombreListas = new vRegistrarTrabajadores;
        var trabajadorData = {};
        trabajadorData = this.ctrlActions.GetDataForm('frmTrabajador');

        trabajadorData.Genero = nombreListas.obtenerGeneroId(trabajadorData.Genero);

        //CAPTCHA		
        var userEnteredCaptchaCode = captcha.getUserEnteredCaptchaCode();
        var captchaId = captcha.getCaptchaId();
        //CAPTCHA
        trabajadorData.userEnteredCaptchaCode = userEnteredCaptchaCode;
        trabajadorData.captchaId = captchaId;
        //Cambiar cuando este el perfil
        trabajadorData.IdEmpresa = sessionStorage.getItem('IdEmpresa');



        //Hace el post al create
        this.ctrlActions.PostToAPI(this.service, trabajadorData, function (success) {
            if (success) {

                $('#txtNombre').val("");
                $('#txtApellido1').val("");
                $('#txtApellido2').val("");
                $('#txtCedula').val("");
                $("#selectGenero option[value='0']").prop('selected', true);
                $('#txtCorreo').val("");
                $('#txtFecNacimiento').val("");
                $('#userCaptchaInput').val("");

                

            } else {

                //captcha
                captcha.reloadImage();
                //$('#modalRegistrarOferente').modal('show')
                //$('#errorRegistro').text('Ha ocurrido un error')
                //this.ctrlActions = new ControlActions();
                this.ctrlActions.ShowMessage('E', "Ha ocurrido un error.");

            }
        });

    }
}
//ON DOCUMENT READY
$(document).ready(function () {

    var vregistroTrabajador = new vRegistroTrabajador();
});

document.addEventListener("DOMContentLoaded", function (event) {
    const controller = new vRegistrarTrabajadores();
    controller.crearEventos();
});

