using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models.Controls
{
    public class CtrlInputMonedaNoRequeridoModel : CtrlBaseModel
    {
        public string Type { get; set; }
        public string Label { get; set; }
        public string PlaceHolder { get; set; }
        public string ColumnDataName { get; set; }
        public string Pattern { get; set; }    
        public string Min { get; set; }
        public string Max { get; set; }
        public string Name { get; set; }
        public string DataType { get; set; }


        public CtrlInputMonedaNoRequeridoModel()
        {
            ViewName = "";
        }
    }
}