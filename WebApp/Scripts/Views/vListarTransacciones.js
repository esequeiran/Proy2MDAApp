class vListarTransacciones {
	constructor() {
		this.tblUsuarioId = 'tblTransacciones';
		this.service = 'Transacciones?identificacion=109958746';
		this.ctrl = new ControlActions();
		this.columns = "Fecha,Monto,Concepto,TipoMovimiento";

		this.RetrieveAll();
		//$("table thead:nth-child(0n+2)").addClass("d-none");
	}
	

	RetrieveAll() {
		this.ctrl.FillTableJazmin(this.service, this.tblUsuarioId, false, false, true);
	}
}

document.addEventListener("DOMContentLoaded", function (event) {
	const controller = new vListarTransacciones();
});