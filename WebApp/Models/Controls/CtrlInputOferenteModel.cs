using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models.Controls
{
    public class CtrlInputOferenteModel : CtrlBaseModel
    {
        public string Type { get; set; }
        public string Label { get; set; }
        public string PlaceHolder { get; set; }
        public string ColumnDataName { get; set; }
        public bool IsRequired { get; set; }
        public bool IsReadOnly { get; set; }
        public string RequiredParam
        {
            get
            {
                if (IsRequired == true)
                {
                    return "required";
                }
                return "";
            }
        }
        public string ReadOnlyParam
        {
            get
            {
                if (IsReadOnly == true)
                {
                    return "readonly";
                }
                return "";
            }
        }

        public CtrlInputOferenteModel()
        {
            ViewName = "";
        }
    }
}