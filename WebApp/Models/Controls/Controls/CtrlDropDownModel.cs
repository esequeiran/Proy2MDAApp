using Entities_POJO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace WebApp.Models.Controls
{
    public class CtrlDropDownModel : CtrlBaseModel
    {
        public string Label { get; set; }
        public string ListId { get; set; }

        //eve
        public string ColumnDataName { get; set; }



        private string URL_API_LISTs = "http://localhost:61079/api/List/";

        public string ListOptions
        {
            get
            {
                var htmlOptions = "";
                var lst = GetOptionsFromAPI();

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
                var response = client.DownloadString(URL_API_LISTs + ListId);
                options = JsonConvert.DeserializeObject<List<OptionList>>(response);
            }


            catch (Exception)
            {

            }

            return options;
        }



        public CtrlDropDownModel()
        {
            ViewName = "";
        }
    }
}