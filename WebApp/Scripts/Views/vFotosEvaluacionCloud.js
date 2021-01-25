var CLOUDINARY_URL = 'https://api.cloudinary.com/v1_1/dc8lacq7g/upload';
var CLOUDINARY_UPLOAD_PRESET = 'u86aylh2';

var archivoF1 = document.getElementById('F1');
var archivoF2 = document.getElementById('F2');
var archivoF3 = document.getElementById('F3');

var datosArchivoF1 = {};
var datosArchivoF2 = {};
var datosArchivoF3 = {};

if (archivoF1) {
    archivoF1.addEventListener('change', function (event) {
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
                datosArchivoF1 = res;
                $("#foto1").text(res.original_filename);
            }
        })
    })
}


if (archivoF2) {
    archivoF2.addEventListener('change', function (event) {
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
                datosArchivoF2 = res;
                $("#foto2").text(res.original_filename);
            }
        })
    })
}


if (archivoF3) {
    archivoF3.addEventListener('change', function (event) {
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
                datosArchivoF3 = res;
                $("#foto3").text(res.original_filename);
            }
        })
    })
}