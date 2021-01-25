(function ($) {
    jQuery.fn.extend({
        html5_qrcode: function (qrcodeSuccess, qrcodeError, videoError) {
            return this.each(function () {
                var currentElem = $(this);

                var height = currentElem.height();
                var width = currentElem.width();

                if (height == null) {
                    height = 250;
                }

                if (width == null) {
                    width = 300;
                }

                var vidElem = $('<video id="idVideoCodigo" width="' + width + 'px" height="' + height + 'px"></video>').appendTo(currentElem);
                var canvasElem = $('<canvas id="qr-canvas" width="' + (width - 2) + 'px" height="' + (height - 2) + 'px" style="display:none;"></canvas>').appendTo(currentElem);

                var video = vidElem[0];
                var canvas = canvasElem[0];
                var context = canvas.getContext('2d');
                var localMediaStream;

                var scan = function () {
                    if (localMediaStream && $('#idVideoCodigo').length > 0) {
                        context.drawImage(video, 0, 0, 307, 250);

                        try {
                            qrcode.decode();
                        } catch (e) {
                            qrcodeError(e, localMediaStream);
                        }

                        $.data(currentElem[0], "timeout", setTimeout(scan, 500));

                    } else {
                        //$.data(currentElem[0], "timeout", setTimeout(scan, 500));
                    }
                };//end snapshot function

                window.URL = window.URL || window.webkitURL || window.mozURL || window.msURL;
                navigator.getUserMedia = navigator.getUserMedia || navigator.webkitGetUserMedia || navigator.mozGetUserMedia || navigator.msGetUserMedia;

                var successCallback = function (stream) {
                    video.srcObject = stream;

                    localMediaStream = stream;
                    $.data(currentElem[0], "stream", stream);

                    video.play();
                    $.data(currentElem[0], "timeout", setTimeout(scan, 1000));
                };

                // Call the getUserMedia method with our callback functions
                if (navigator.getUserMedia) {
                    navigator.getUserMedia({ video: true }, successCallback, function (error) {
                        videoError(error, localMediaStream);
                    });
                } else {
                    console.log('Native web camera streaming (getUserMedia) not supported in this browser.');
                    // Display a friendly "sorry" message to the user
                }

                qrcode.callback = function (result) {
                    qrcodeSuccess(result, localMediaStream);
                };
            }); // end of html5_qrcode
        },

        html5_qrcode_stop: function () {
            return this.each(function () {
                //stop the stream and cancel timeouts
                $(this).data('stream').getVideoTracks().forEach(function (videoTrack) {
                    videoTrack.stop();
                });

                clearTimeout($(this).data('timeout'));
            });
        }
    });
})(jQuery);


function vEscanearCodigoQR() {
  
    //this.service = "EscanearCodigoSolicitud";
    //this.ctrlActions = new ControlActions();

    this.Escanear = function () {    
        var service = "EscanearCodigoSolicitud";
        var ctrlActions = new ControlActions();
        var solicitudData = {};
        var cedulaCliente = sessionStorage.getItem('IdUsuario');

        $('#reader').removeClass('divLogoCodigoQR');

        $('#reader').html5_qrcode(function (data) {

            $('#reader').html5_qrcode_stop();

            $('#idVideoCodigo').remove();
            $('#qr-canvas').remove();
            $('#reader').addClass('divLogoCodigoQR');
          
            solicitudData['CedulaCliente'] = cedulaCliente;
            solicitudData['CodigoQR'] = data;

            ctrlActions.PostToAPI(service, solicitudData);   
          
        },
            function (error) {
                //console.log(error);
            }, function (videoError) {
                //console.log(videoError);
            }
        );

    }
}


$(document).ready(function () {
    var vEscanear = new vEscanearCodigoQR();
   
});