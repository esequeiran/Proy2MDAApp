

var CLOUDINARY_URL = 'https://api.cloudinary.com/v1_1/dc8lacq7g/upload';
var CLOUDINARY_UPLOAD_PRESET = 'u86aylh2';


var archivoC = document.getElementById('curriculum');
var archivoH = document.getElementById('hojaDelincuencia');

var datosArchivo1 = {};
var datosArchivo2 = {};


if (archivoC) {
    archivoC.addEventListener('change', function (event) {
        var file = event.target.files[0];
        var formData = new FormData();
        formData.append('file', file);
        formData.append('upload_preset', CLOUDINARY_UPLOAD_PRESET);
        console.log(file);


        $.ajax({
            url: CLOUDINARY_URL,
            type: 'POST',
            data: formData,
            contentType: false,
            processData: false,
            success: function (res) {
                console.log(res);
                datosArchivo1 = res;
                $('#curri').text(res.original_filename);

            }
        })

    });
}
if (archivoH) {
    archivoH.addEventListener('change', function (event) {
        var file = event.target.files[0];
        var formData = new FormData();
        formData.append('file', file);
        formData.append('upload_preset', CLOUDINARY_UPLOAD_PRESET);    
        $.ajax({
            url: CLOUDINARY_URL,
            type: 'POST',
            data: formData,
            contentType: false,
            processData: false,
            success: function (res) {
                console.log(res);
                datosArchivo2 = res;
                $('#hojaD').text(res.original_filename)

            }
        })

    });
}


function vCloud() {
    var ctrlActions = new ControlActions();
    var camposValidos = true;
    $('#frmDocumentos input[required]').each(function () {
        if (this.value === "") {
            camposValidos = false;
        }
    })

    if (camposValidos === false) {
        ctrlActions.ShowMessage('E', "Los campos que tiene este simbolo:(*) deben ser llenados.");
        return false;
    }

    this.CrearDocumento = function () {

        var ctrlActions = new ControlActions();

        var doc1 = {
            IdDocumento: datosArchivo1.url,
            NombreDocumento: datosArchivo1.original_filename,
            Extension: datosArchivo1.format,
            IdUsuario: sessionStorage.getItem('CedulaRegistro'),
            //IdUsuario: $('#txtCedulaJuridica')[0].value,
            TipoDocumento: "Curriculum"

        }

        var doc2 = {
            IdDocumento: datosArchivo2.url,
            NombreDocumento: datosArchivo2.original_filename,
            Extension: datosArchivo2.format,
            IdUsuario: sessionStorage.getItem('CedulaRegistro'),
            TipoDocumento: "Hoja de delincuencia"

        }
       
        ctrlActions.PostToAPI('Documento', doc1, function (success) {
            if (success) {   
                ctrlActions.PostToAPI('Documento', doc2, function (success1) {
                    if (success1) {
                        $('#RegistroDocumento').css('display', 'none');
                        window.location.href = "vRegistrarLocalizacion";
                        

                        //Revisar esta parte
                        //$('#MensajeFinal').css('display', 'block');
                        //$('#correoUsuario').append($('#txtCorreo')[0].value);
                        //$('#modalRegistrarOfe').modal('show')
                        //$('#buenRegistro').text('Sus datos han sidos registrados!')

                    } else {
                        //$('#modalRegistrarOferente').modal('show')
                        //$('#errorRegistro').text('Ha ocurrido un error')
                        this.ctrlActions.ShowMessage('E', "Ha ocurrido un error.");
                      
                    }
                });

            } else {
                this.ctrlActions.ShowMessage('E', "Ha ocurrido un error.");
            }
        });
      
    }

}
