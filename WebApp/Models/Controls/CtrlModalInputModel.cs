using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models.Controls
{
    public class CtrlModalInputModel: CtrlBaseModel
    {
        public string Title { get; set; }
        public string IdModal { get; set; }
        public string IdButton { get; set; } 
        public string LabelButton { get; set; } 

        public string Type { get; set; } 
        public string IdSmall { get; set; } 
        public string ColumnDataName { get; set; } 
        public string AriaDescribedby { get; set; } 
        public string LabelInput { get; set; }

        public CtrlModalInputModel() {
            ViewName = "";
        }
    }
}