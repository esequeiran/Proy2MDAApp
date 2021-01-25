class vRegistrarCliente {
    constructor() {
        this.captcha = $('#botdetect-captcha').captcha({
            captchaEndpoint: 'http://localhost:61079/simple-captcha-endpoint.ashx'
        });
        this.generos = [
            { idGenero: 0, nombre: "-Seleccione una opción-" },
            { idGenero: 1, nombre: "Masculino" },
            { idGenero: 2, nombre: "Femenino" },
            { idGenero: 3, nombre: "Otro" },
            { idGenero: 4, nombre: "Prefiero no específicar" },
        ];
        this.tiposId = [
            { id: 0, nombre: "-Seleccione una opción-" },
            { id: 1, nombre: "Física" },
            { id: 2, nombre: "NITE" },
            { id: 3, nombre: "DIMEX" }
        ]
        this.paises = [
            { idPais: 0, nombre: "-Seleccione una opción-" },
            { idPais: 1, nombre: "Afganistan" },
            { idPais: 2, nombre: "Albania" },
            { idPais: 3, nombre: "Alemania" },
            { idPais: 5, nombre: "Andorra" },
            { idPais: 6, nombre: "Angola" },
            { idPais: 7, nombre: "Antartida" },
            { idPais: 8, nombre: "Antigua y Barbuda" },
            { idPais: 9, nombre: "Arabia Saudi" },
            { idPais: 10, nombre: "Argelia" },
            { idPais: 11, nombre: "Argentina" },
            { idPais: 12, nombre: "Armenia" },
            { idPais: 13, nombre: "Australia" },
            { idPais: 14, nombre: "Austria" },
            { idPais: 15, nombre: "Azerbaiyan" },
            { idPais: 16, nombre: "Bahamas" },
            { idPais: 17, nombre: "Bahrain" },
            { idPais: 18, nombre: "Bangladesh" },
            { idPais: 19, nombre: "Barbados" },
            { idPais: 20, nombre: "Belgica" },
            { idPais: 21, nombre: "Belice" },
            { idPais: 22, nombre: "Benin" },
            { idPais: 23, nombre: "Bermudas" },
            { idPais: 24, nombre: "Bielorrusia" },
            { idPais: 25, nombre: "Birmania Myanmar" },
            { idPais: 26, nombre: "Bolivia" },
            { idPais: 27, nombre: "Bosnia y Herzegovina" },
            { idPais: 28, nombre: "Botswana" },
            { idPais: 29, nombre: "Brasil" },
            { idPais: 30, nombre: "Brunei" },
            { idPais: 31, nombre: "Bulgaria" },
            { idPais: 32, nombre: "Burkina Faso" },
            { idPais: 33, nombre: "Burundi" },
            { idPais: 34, nombre: "Butan" },
            { idPais: 35, nombre: "Cabo Verde" },
            { idPais: 36, nombre: "Camboya" },
            { idPais: 37, nombre: "Camerun" },
            { idPais: 38, nombre: "Canadá" },
            { idPais: 39, nombre: "Chad" },
            { idPais: 40, nombre: "Chile" },
            { idPais: 41, nombre: "China" },
            { idPais: 42, nombre: "Chipre" },
            { idPais: 43, nombre: "Colombia" },
            { idPais: 44, nombre: "Comores" },
            { idPais: 45, nombre: "Congo" },
            { idPais: 46, nombre: "Corea del Norte" },
            { idPais: 47, nombre: "Corea del Sur" },
            { idPais: 48, nombre: "Costa de Marfil" },
            { idPais: 49, nombre: "Costa Rica" },
            { idPais: 50, nombre: "Croacia" },
            { idPais: 51, nombre: "Cuba" },
            { idPais: 52, nombre: "Dinamarca" },
            { idPais: 53, nombre: "Dominica" },
            { idPais: 54, nombre: "Ecuador" },
            { idPais: 55, nombre: "Egipto" },
            { idPais: 56, nombre: "El Salvador" },
            { idPais: 57, nombre: "El Vaticano" },
            { idPais: 58, nombre: "Emiratos arabes Unidos" },
            { idPais: 59, nombre: "Eritrea" },
            { idPais: 60, nombre: "Eslovaquia" },
            { idPais: 61, nombre: "Eslovenia" },
            { idPais: 62, nombre: "España" },
            { idPais: 63, nombre: "Estados Unidos" },
            { idPais: 64, nombre: "Estonia" },
            { idPais: 65, nombre: "Etiopia" },
            { idPais: 66, nombre: "Filipinas" },
            { idPais: 67, nombre: "Finlandia" },
            { idPais: 68, nombre: "Fiji" },
            { idPais: 69, nombre: "Francia" },
            { idPais: 70, nombre: "Gabon" },
            { idPais: 71, nombre: "Gambia" },
            { idPais: 72, nombre: "Georgia" },
            { idPais: 73, nombre: "Ghana" },
            { idPais: 74, nombre: "Gibraltar" },
            { idPais: 75, nombre: "Granada" },
            { idPais: 76, nombre: "Grecia" },
            { idPais: 77, nombre: "Guam" },
            { idPais: 78, nombre: "Guatemala" },
            { idPais: 79, nombre: "Guinea" },
            { idPais: 80, nombre: "Guinea Ecuatorial" },
            { idPais: 81, nombre: "Guinea Bissau" },
            { idPais: 82, nombre: "Guyana" },
            { idPais: 83, nombre: "Haití" },
            { idPais: 84, nombre: "Honduras" },
            { idPais: 85, nombre: "Hungría" },
            { idPais: 86, nombre: "India" },
            { idPais: 87, nombre: "Indian Ocean" },
            { idPais: 88, nombre: "Indonesia" },
            { idPais: 89, nombre: "Iran" },
            { idPais: 90, nombre: "Iraq" },
            { idPais: 91, nombre: "Irlanda" },
            { idPais: 92, nombre: "Islandia" },
            { idPais: 93, nombre: "Israel" },
            { idPais: 94, nombre: "Italia" },
            { idPais: 95, nombre: "Jamaica" },
            { idPais: 96, nombre: "Japon" },
            { idPais: 97, nombre: "Jersey" },
            { idPais: 98, nombre: "Jordania" },
            { idPais: 99, nombre: "Kazajstan" },
            { idPais: 100, nombre: "Kenia" },
            { idPais: 101, nombre: "Kirguistan" },
            { idPais: 103, nombre: "Kiribati" },
            { idPais: 104, nombre: "Kuwait" },
            { idPais: 105, nombre: "Laos" },
            { idPais: 106, nombre: "Lesoto" },
            { idPais: 107, nombre: "Letonia" },
            { idPais: 108, nombre: "Libano" },
            { idPais: 109, nombre: "Libia" },
            { idPais: 110, nombre: "Liechtenstein" },
            { idPais: 111, nombre: "Lituania" },
            { idPais: 112, nombre: "Luxemburgo" },
            { idPais: 113, nombre: "Macedonia" },
            { idPais: 114, nombre: "Madagascar" },
            { idPais: 115, nombre: "Malasia" },
            { idPais: 116, nombre: "Malawi" },
            { idPais: 117, nombre: "Maldivas" },
            { idPais: 118, nombre: "Mali" },
            { idPais: 119, nombre: "Malta" },
            { idPais: 120, nombre: "Mauricio" },
            { idPais: 121, nombre: "Mauritania" },
            { idPais: 122, nombre: "México" },
            { idPais: 123, nombre: "Micronesia" },
            { idPais: 124, nombre: "Moldavia" },
            { idPais: 125, nombre: "Mónaco" },
            { idPais: 126, nombre: "Mongolia" },
            { idPais: 127, nombre: "Montserrat" },
            { idPais: 128, nombre: "Mozambique" },
            { idPais: 129, nombre: "Namibia" },
            { idPais: 130, nombre: "Nauru" },
            { idPais: 131, nombre: "Nepal" },
            { idPais: 132, nombre: "Nicaragua" },
            { idPais: 133, nombre: "Niger" },
            { idPais: 134, nombre: "Nigeria" },
            { idPais: 135, nombre: "Noruega" },
            { idPais: 136, nombre: "Nueva Zelanda" },
            { idPais: 137, nombre: "Oman" },
            { idPais: 138, nombre: "Paises Bajos" },
            { idPais: 140, nombre: "Pakistan" },
            { idPais: 141, nombre: "Palau" },
            { idPais: 142, nombre: "Panamá" },
            { idPais: 143, nombre: "Papua Nueva Guinea" },
            { idPais: 144, nombre: "Paraguay" },
            { idPais: 145, nombre: "Perú" },
            { idPais: 146, nombre: "Polonia" },
            { idPais: 147, nombre: "Portugal" },
            { idPais: 148, nombre: "Puerto Rico" },
            { idPais: 149, nombre: "Qatar" },
            { idPais: 150, nombre: "Reino Unido" },
            { idPais: 151, nombre: "Republica Centroafricana" },
            { idPais: 152, nombre: "Republica Checa" },
            { idPais: 153, nombre: "Republica Democratica del Congo" },
            { idPais: 154, nombre: "Republica Dominicana" },
            { idPais: 155, nombre: "Ruanda" },
            { idPais: 156, nombre: "Rumania" },
            { idPais: 157, nombre: "Rusia" },
            { idPais: 158, nombre: "Sahara Occidental" },
            { idPais: 159, nombre: "Samoa" },
            { idPais: 160, nombre: "San Cristobal y Nevis" },
            { idPais: 161, nombre: "San Marino" },
            { idPais: 162, nombre: "San Vicente y las Granadinas" },
            { idPais: 163, nombre: "Santa Lucía" },
            { idPais: 164, nombre: "Santo Tome y Princípe" },
            { idPais: 165, nombre: "Senegal" },
            { idPais: 166, nombre: "Seychelles" },
            { idPais: 167, nombre: "Singapur" },
            { idPais: 168, nombre: "Somalia" },
            { idPais: 169, nombre: "Southern Ocean" },
            { idPais: 170, nombre: "Sri Lanka" },
            { idPais: 171, nombre: "Swazilandia" },
            { idPais: 172, nombre: "Sudafrica" },
            { idPais: 173, nombre: "Sudan" },
            { idPais: 174, nombre: "Suecia" },
            { idPais: 175, nombre: "Suiza" },
            { idPais: 176, nombre: "Surinam" },
            { idPais: 177, nombre: "Tailandia" },
            { idPais: 178, nombre: "Taiwan" },
            { idPais: 179, nombre: "Tanzania" },
            { idPais: 180, nombre: "Tayikistan" },
            { idPais: 181, nombre: "Togo" },
            { idPais: 182, nombre: "Tokelau" },
            { idPais: 183, nombre: "Tonga" },
            { idPais: 184, nombre: "Trinidad y Tobago" },
            { idPais: 185, nombre: "Tunez" },
            { idPais: 186, nombre: "Turkmekistan" },
            { idPais: 187, nombre: "Turquía" },
            { idPais: 188, nombre: "Tuvalu" },
            { idPais: 189, nombre: "Ucrania" },
            { idPais: 190, nombre: "Uganda" },
            { idPais: 191, nombre: "Uruguay" },
            { idPais: 192, nombre: "Uzbekistan" },
            { idPais: 193, nombre: "Vanuatu" },
            { idPais: 194, nombre: "Venezuela" },
            { idPais: 195, nombre: "Vietnam" },
            { idPais: 196, nombre: "Yemen" },
            { idPais: 197, nombre: "Djibouti" },
            { idPais: 198, nombre: "Zambia" },
            { idPais: 199, nombre: "Zimbabue" }
        ];

        this.sltGenero = document.getElementById('selectGenero');
        this.sltId = document.getElementById('selectTipoId');
        this.sltPaises = document.getElementById('selectPais');

        this.btnRegistrar = document.getElementById('btnCrear');

        this.ctrlActions = new ControlActions();
        this.fillsltGenero();
        this.fillsltPaises();
        this.fillsltTiposId();
        this.desactivarBtn();
        console.log(this.captcha);
    }

    
    get captchaId() {
        return this.captcha.getCaptchaId();
    }

    get userEnteredCaptchaCode() {
        return this.captcha.getUserEnteredCaptchaCode();
    }

    //retorna e valor de los campos requeridos   
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

    //llenar los selects
    fillsltGenero() {
        for (const genero of this.generos) {
            this.sltGenero.options.add(new Option(genero.nombre, genero.idGenero));
        }
    }

    fillsltPaises() {
        for (const pais of this.paises) {
            this.sltPaises.options.add(new Option(pais.nombre, pais.idPais));
        }
    }

    fillsltTiposId() {
        for (const id of this.tiposId) {
            this.sltId.options.add(new Option(id.nombre, id.id));
        }
    }

    fillslts() {
        this.fillsltGenero();
        this.fillsltTiposId();
        this.fillsltPaises();
    }
    // END llenar los selects

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

    //Obtener el valor de los selects
    obtenerTipoId(id) {
        let tipo;
        for (const tipoId of this.tiposId) {
            if (tipoId.id === id) {
                tipo = tipoId.nombre;
            }
        }
        return tipo;
    }

    obtenerGeneroId(id) {
        let genero;
        for (const genre of this.generos) {
            if (genre.idGenero === id) {
                genero = genre.nombre;
            }
        }
       return genero;
    }


    obtenerPais(id) {
        let pais;
        for (const p of this.paises) {
            if (p.idPais === id) {
                pais = p.nombre;
            }
        }
        return pais;
    }
    //END

    //Obtener valores de los inputs
    getValuesForm() {
        const clienteData = this.ctrlActions.GetDataForm('frmCreate');
        clienteData.TipoIdentificacion = this.obtenerTipoId(parseInt(clienteData.TipoIdentificacion));
        clienteData.Genero = this.obtenerGeneroId(parseInt(clienteData.Genero));
        clienteData.PaisNacimiento = this.obtenerPais(parseInt(clienteData.PaisNacimiento));
        clienteData.userEnteredCaptchaCode = this.userEnteredCaptchaCode;
        clienteData.captchaId = this.captchaId;

        debugger

        this.ctrlActions.PostToAPI('Cliente', clienteData, res => {
            if (res === true) {
                this.redireccionar();
            } else {
                this.showErrorCaptcha();
            }
        });
        
    }
    //END

    redireccionar() {
        sessionStorage.setItem('CedulaRegistro', $('#txtId').val());
        sessionStorage.setItem('TipoRegistro', 'Cliente');
        this.clearForm();
        window.location.href = 'vRegistrarLocalizacion';
        
    }

    showErrorCaptcha() {
        const captchaInput = document.getElementById('userCaptchaInput');
        captchaInput.nextElementSibling.classList.remove('d-none');
        captchaInput.nextElementSibling.classList.remove('text-muted');
        captchaInput.classList.add('is-invalid');
        captchaInput.nextElementSibling.classList.add('invalid-feedback');
        captchaInput.focus();

        this.captcha.reloadImage();
        this.ctrlActions.ShowMessage('E', "Código captcha inválido. Intente de nuevo");
    }

    clearForm() {
        const inputs = Array.from(document.querySelectorAll('.form-control'), (input) => {
            input.value = '';
            input.classList.remove('is-valid');
            return input;
        });

        this.sltId.innerHTML = "";
        this.sltPaises.innerHTML = "";
        this.btnRegistrar.innerHTML = "";
        this.fillslts();
    } 

    crearEventos() {
        document.addEventListener('keyup', () => { this.validateForm() });
        this.sltGenero.addEventListener('change', () => { this.validateForm() });
        this.sltId.addEventListener('change', () => { this.validateForm() });
        this.sltPaises.addEventListener('change', () => { this.validateForm() });
        this.btnRegistrar.addEventListener('click', () => { this.getValuesForm() });
    }

}
document.addEventListener("DOMContentLoaded", function (event) {
    const controller = new vRegistrarCliente();
    controller.crearEventos();
});
