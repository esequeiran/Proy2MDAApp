function vDashOferente() {
    this.tblTrabajos = 'tblTrabajosRealizados';
    this.tblTrabajadores = 'tblTrabajadoresIngresos';
    this.service = 'IngresosOferente?cedula=' + sessionStorage.getItem('IdUsuario');
    this.serviceTrabajos = 'TrabajosRealizados?idEmpresa=' + sessionStorage.getItem('IdEmpresa');
    this.serviceTrabajador = 'TrabajadoresOferente?idEmpresa=' + sessionStorage.getItem('IdEmpresa');
    this.ctrlActions = new ControlActions();
    this.columnsTrabajo = "IdSolicitud,IdEstado,FechaEvento";
    this.columnsTrabajador = "Nombre,Cedula";

    $("table thead:nth-child(0n+2)").addClass("d-none");


    // Trae los ingresos del APP
    this.getIngresos = function () {
        this.ctrlActions.GetToApi(this.service, (response) => {
            const ingresos = response.Data;
            for (let i = 0; i < ingresos.length; i++) {
                const ingreso = ingresos[i];
                //ingreso.Fecha = new Date(ingreso.Fecha);
                //ingresos[i] = ingreso
            }
            this.ingresos = ingresos;
            this.llenarGrafico();
        });
    }


    this.llenarGrafico = function () {
        const ctx = document.getElementById(`ingresos`).getContext(`2d`);
        let montos = [];
        let fechas = [];

        for (let i = 0; i < this.ingresos.length; i++) {
            montos.push(this.ingresos[i].Monto);
            fechas.push(this.ingresos[i].Fecha);
        }
        const data = {
            type: `bar`,
            data: {
                labels: fechas,
                datasets: [{
                    data: montos,
                    borderColor: `rgba(243, 156, 18, 0.5)`,
                    backgroundColor: `rgba(241, 196, 15, 0.5)`,
                    label: `Ingresos`
                }]
            },
            options: {
                scales: {
                    yAxes: [{
                        ticks: {
                            beginAtZero: true
                        }
                    }]
                }
            }
        }
        const test = new Chart(ctx, data);
    }

    this.GetIdEmpresa = async function () {
        var result = await this.GetDataByCedula(sessionStorage.getItem('IdUsuario'));
        sessionStorage.setItem("IdEmpresa", result.Data.Oferente.CedulaJuridica)
    }

    this.GetDataByCedula = function (cedula) {
        return $.ajax({
            url: 'http://localhost:61079/api/Oferente?idUsuario=' + cedula,
            type: 'GET',
            contentType: 'application/json'
        });
    }

    this.RetrieveAllTrabajos = function () {
        this.ctrlActions.FillTable(this.serviceTrabajos, this.tblTrabajos, false);
    }
    this.RetrieveAllTrabajadores = function () {
        this.ctrlActions.FillTable(this.serviceTrabajador, this.tblTrabajadores, false);
    }

}
//ON DOCUMENT READY
$(document).ready(function () {

    var vdashOferente = new vDashOferente;
    vdashOferente.getIngresos();
    vdashOferente.GetIdEmpresa();
    vdashOferente.RetrieveAllTrabajos();
    vdashOferente.RetrieveAllTrabajadores();


});