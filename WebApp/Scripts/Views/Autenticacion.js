function vAutenticacion() {

    this.Autenticar = function () {
        console.log(document.referrer);

        if (!sessionStorage.getItem('IdUsuario')) {
            window.location.pathname = "Home/vLogin";
        } 
    }    
}

//ON DOCUMENT READY
$(document).ready(function () {
    var aut = new vAutenticacion();
    aut.Autenticar();  

});

function LogOut() {
    console.log("ingresó al logout");
    sessionStorage.removeItem('IdUsuario');
    sessionStorage.removeItem('Nombre');
    sessionStorage.removeItem('Idroles');
    sessionStorage.removeItem('Nombreroles');   
}