using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models.Controls
{
    public class CtrlInputCptchaModelCtrl : CtrlBaseModel
    {
        public string Type { get; set; }
        public string Label { get; set; }
        public string ColumnDataName { get; set; }
        public string AriaDescribedby { get; set; }
        public string IdSmall { get; set; }
        public string  TextSmall { get; set; }
        public string TextSpan { get; set; }

        public CtrlInputCptchaModelCtrl()
        {
            ViewName = "";
        }
    }
}