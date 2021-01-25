using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models.Controls
{
    public class CtrlModalModel : CtrlBaseModel
    {
        //Parámetros específicos de modal
        public string Title { get; set; }
        public string IdModal { get; set; }
        public string IdParrafo { get; set;}
        public string ContenidoParrafo { get; set; }

        //Parámetros específicos del botón de acción del modal
        public string Label { get; set; }
        public string FunctionName { get; set; }
        public string ButtonType { get; set; }
        public string DataToggle { get; set; }
        public string DataTarget { get; set; }

        public CtrlModalModel()
        {
            ViewName = "";
        }
    }
}