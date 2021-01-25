using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models.Controls
{
    public class CtrlADocModel : CtrlBaseModel
    {
        public string Label { get; set; }
        public string FunctionName { get; set; }
        public string Href { get; set; }

        public CtrlADocModel()
        {
            ViewName = "";
        }
    }
 
}