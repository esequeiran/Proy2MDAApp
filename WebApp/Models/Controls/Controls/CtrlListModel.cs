using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models.Controls
{
    public class CtrlListModel : CtrlBaseModel
    {
        public string Label { get; set; }
        public string ColumnDataName { get; set; }
        public string Pattern { get; set; }
        public string AriaDescribedby { get; set; }
        public string IdSmall { get; set; }
        public CtrlListModel()
        {
            ViewName = "";
        }
    }
}