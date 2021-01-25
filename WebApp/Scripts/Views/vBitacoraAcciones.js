function vBitacoraAcciones() {

    this.tblBitacoraId = 'tblBitacoraAcciones';
    this.service = 'Bitacora';
    this.ctrlActions = new ControlActions();
    this.columns = "IdBitacora,Nombre,DescripcionAccion,Fecha";

    this.RetrieveAll = function () {
        this.ctrlActions.FillTableCambiosEvelyn(this.service, this.tblBitacoraId, false);        
    }

    this.ocultar = function () {
        $('thead tr th:first-child').hide();
        $('tbody tr td:first-child').hide();
    }
    
    this.ReloadTable = function () {
        this.ctrlActions.FillTableCambiosEvelyn(this.service, this.tblBitacoraId, true);
      
    }

    this.Create = function () {
        var membresiasData = {};
        membresiasData = this.ctrlActions.GetDataForm('frmCreate');
        //Hace el post al create
        this.ctrlActions.PostToAPI(this.service, membresiasData);
        //Refresca la tabla
        this.ReloadTable();
    }
    

    this.BindFields = function (data) {
        this.ctrlActions.BindFields('frmEdicion', data);
    }
}

//ON DOCUMENT READY
$(document).ready(function () {

    var vBit = new vBitacoraAcciones();
    vBit.RetrieveAll();   
 

});