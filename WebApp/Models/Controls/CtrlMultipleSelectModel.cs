using Entities_POJO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Web;

namespace WebApp.Models.Controls
{
    public class CtrlMultipleSelectModel: CtrlBaseModel
    {
        public string Label { get; set; }

        public string ListId { get; set; }
        //eve
        public string ColumnDataName { get; set; }
        public string AriaDescribedby { get; set; }
        public string IdSmall { get; set; }

        private string URL_API_LISTs = "http://localhost:61079/api/List/"; 

        public string ListOptions
        {
            get
            {
                var htmlOptions = "";
                var lst = GetOptionsFromAPI();
                htmlOptions += "<option value='" + "default0" + "'>" + "--Seleccione una o varias opciones--" + "</option>";
                foreach (var option in lst)
                {
                    htmlOptions += "<option value='" + option.Value + "'>" + option.Description + "</option>";
                }
                return htmlOptions;
            }
            set
            {

            }
        }


        private List<OptionList> GetOptionsFromAPI()
        {
            List<OptionList> options = new List<OptionList>();
            try
            {
                var client = new WebClient();
                client.Encoding = Encoding.UTF8;
                var response = client.DownloadString(URL_API_LISTs + ListId);
                options = JsonConvert.DeserializeObject<List<OptionList>>(response);     

            }
            catch (Exception)
            {
            }
            return options;
        }



        public CtrlMultipleSelectModel()
        {
            ViewName = "";
        }

    }
}