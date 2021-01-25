using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models.Controls
{
    public class CtrlInputCheckBoxModel : CtrlBaseModel
    {
                           
        public string Label { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string ColumnDataName { get; set; }


        public CtrlInputCheckBoxModel() {

            ViewName = "";
        }


    }
}