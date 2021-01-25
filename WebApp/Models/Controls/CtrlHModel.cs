using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models.Controls
{
    public class CtrlHModel:CtrlBaseModel
    {
        public string Tittle { get; set; }

        public CtrlHModel() {
            ViewName = "";
        }
    }
}