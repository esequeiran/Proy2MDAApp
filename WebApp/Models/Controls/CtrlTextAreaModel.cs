using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models.Controls
{
    public class CtrlTextAreaModel : CtrlBaseModel
    {
        public string Label { get; set; }
        public string PlaceHolder { get; set; }
        public string ColumnDataName { get; set; }
        public bool IsRequired { get; set; }
        public bool IsReadOnly { get; set; }
        public string AriaDescribedby { get; set; }
        public string IdSmall { get; set; }        
        public string Rows { get; set; }
        public string Cols { get; set; }
        public string Maxlength { get; set; }


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

        public CtrlTextAreaModel()
        { 
            ViewName = "";
        }
    }
}