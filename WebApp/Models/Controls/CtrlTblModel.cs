using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models.Controls
{
    public class CtrlTblModel: CtrlBaseModel
    {
         public CtrlTblModel()
        {
            Columns = "";
        }

        public string Title { get; set; }
        public string Columns { get; set; }
        public string ColumnsDataName { get; set; }

        public int ColumnsCount => Columns.Split(',').Length;

        public string ColumnHeaders
        {
            get
            {
                var headers = "";
                foreach (var text in Columns.Split(','))
                {
                    headers += "<th>" + text + "</th>";
                }

                return headers;
            }
        }
    }
}