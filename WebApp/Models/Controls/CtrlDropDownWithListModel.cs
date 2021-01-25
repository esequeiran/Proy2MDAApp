using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models.Controls
{
    public class CtrlDropDownWithListModel : CtrlBaseModel
    {
        public string Label { get; set; }
        public string ColumnDataName { get; set; }
        public string ListOpt { get; set; }           

        public string ListOptions
        {
            get
            {
                var lst = ListOpt.Split(',');
                var htmlOptions = "";                

                foreach (var option in lst)
                {
                    htmlOptions += "<option value='" + option + "'>" + option + "</option>";
                }
                return htmlOptions;
            }
            set
            {

            }
        }
                  


        public CtrlDropDownWithListModel()
        {
            ViewName = "";
        }
    }
}