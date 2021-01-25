using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models.Controls
{
    public class CtrlRadioModel : CtrlBaseModel
    {
        public string Label { get; set; }
        public string ColumnDataName { get; set; }
        public string Value { get; set; }
        public bool IsChecked { get; set; }
        public string onchange { get; set; }


        public string CheckedParam { 
            get 
            {
                if (IsChecked == true)
                {
                    return "checked='checked'";
                } 
                return "";
            } 
        }

        public CtrlRadioModel()
        {
            ViewName = "";
        }

    }
}