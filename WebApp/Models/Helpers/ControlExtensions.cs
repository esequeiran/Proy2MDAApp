using System.Web;
using System.Web.Mvc;
using WebApp.Models.Controls;

namespace WebApp.Models.Helpers
{
    public static class ControlExtensions
    {
        public static HtmlString CtrlTable(this HtmlHelper html, string viewName, string id, string title,
            string columnsTitle, string ColumnsDataName, string onSelectFunction, string colorHeader = "")
        {
            var ctrl = new CtrlTableModel
            {
                ViewName = viewName,
                Id = id,
                Title = title,
                Columns = columnsTitle,
                ColumnsDataName = ColumnsDataName,
                FunctionName = onSelectFunction
            };

            return new HtmlString(ctrl.GetHtml());
        }


        public static HtmlString CtrlChart(this HtmlHelper html, string viewName, string id, string title,
            string labels, string chartType, string onLoadFunction)
        {
            var ctrl = new CtrlChartModel
            {
                ViewName = viewName,
                Id = id,
                Title = title,
                Labels = labels,
                ChartType = chartType,
                OnLoadFunction = onLoadFunction
            };

            return new HtmlString(ctrl.GetHtml());
        }


        public static HtmlString CtrlInputOferente(this HtmlHelper html, string id, string type, string label, string placeHolder = "", string columnDataName = "", bool isRequired = false, bool isReadOnly = false)
        {
            var ctrl = new CtrlInputOferenteModel
            {
                Id = id,
                Type = type,
                Label = label,
                PlaceHolder = placeHolder,
                ColumnDataName = columnDataName,
                IsRequired = isRequired,
                IsReadOnly = isReadOnly

            };

            return new HtmlString(ctrl.GetHtml());
        }


        public static HtmlString CtrlInput(this HtmlHelper html, string id, string type, string label, string placeHolder = "", 
            string columnDataName = "", string IsRequired = "", string min="", string max = "", string pattern = "" )
        {
            var ctrl = new CtrlInputModel
            {
                Id = id,
                Type = type,
                Label = label,
                PlaceHolder = placeHolder,
                ColumnDataName = columnDataName,
                IsRequired = IsRequired,
                Min = min,
                Max = max,
                Pattern = pattern
            };
            
            return new HtmlString(ctrl.GetHtml());
        }

        public static HtmlString CtrlInputCheckBox(this HtmlHelper html, string id, string label, string value, string name = "",
         string columnDataName = "")
        {
            var ctrl = new CtrlInputCheckBoxModel
            {
                Id = id,
                Label = label,
                Name = name,
                Value = value,
                ColumnDataName = columnDataName,              
            };

            return new HtmlString(ctrl.GetHtml());
        }

        public static HtmlString CtrlTextArea(this HtmlHelper html, string id, string label, string ariaDescribedby, string idSmall, string maxlength, string placeHolder = "", 
            string columnDataName = "", bool isRequired = false, bool isReadOnly = false, string rows = "10", string cols ="50")
        {
            var ctrl = new CtrlTextAreaModel
            {
                Id = id,
                Label = label,
                PlaceHolder = placeHolder,
                ColumnDataName = columnDataName,
                IsRequired = isRequired,
                IsReadOnly = isReadOnly,
                AriaDescribedby = ariaDescribedby,
                IdSmall = idSmall,
                Rows = rows,
                Cols = cols,
                Maxlength = maxlength

            };

            return new HtmlString(ctrl.GetHtml());
        }

        public static HtmlString CtrlButton(this HtmlHelper html, string viewName, string id, string label, string onClickFunction = ""
            , string buttonType = "primary", string dataToggle = "", string dataTarget="", string customClass = "")
        {
            var ctrl = new CtrlButtonModel
            {
                ViewName = viewName,
                Id = id,
                Label = label,
                FunctionName = onClickFunction,
                ButtonType = buttonType,
                DataToggle = dataToggle,
                DataTarget = dataTarget,
                CustomClass = customClass
            };

            return new HtmlString(ctrl.GetHtml());
        }


        public static HtmlString CtrlModalModel(this HtmlHelper html, string idModal, string title, string idParrafo, 
            string viewName , string id, string label, string contenidoParrafo = "" , string onClickFunction = "", 
            string buttonType = "primary", string dataToggle = "", string dataTarget = "")
        {
            var ctrl = new CtrlModalModel
            {
                IdModal = idModal,
                Title = title,
                IdParrafo = idParrafo,
                ContenidoParrafo = contenidoParrafo,
                ViewName = viewName,
                Id = id,
                Label = label,
                FunctionName = onClickFunction,
                ButtonType = buttonType,
                DataToggle = dataToggle,
                DataTarget = dataTarget
            };

            return new HtmlString(ctrl.GetHtml());
        }


        public static HtmlString CtrlAModel(this HtmlHelper html, string viewName, string id, string label, string href="", string onClickFunction = "")
        {
            var ctrl = new CtrlAModel
            {
                ViewName = viewName,
                Id = id,
                Label = label,
                FunctionName = onClickFunction,
                Href = href
            };

            return new HtmlString(ctrl.GetHtml());
        }     
        public static HtmlString CtrlADocModel(this HtmlHelper html, string viewName, string id, string label, string href="", string onClickFunction = "")
        {
            var ctrl = new CtrlADocModel
            {
                ViewName = viewName,
                Id = id,
                Label = label,
                FunctionName = onClickFunction,
                Href = href
            };

            return new HtmlString(ctrl.GetHtml());
        }

        public static HtmlString CtrlDropDown(this HtmlHelper html, string id, string label, string listId,string columnDataName)
        {
            var ctrl = new CtrlDropDownModel
            {

                Id = id,
                Label = label,
                ListId = listId,
                ColumnDataName = columnDataName
            };

            return new HtmlString(ctrl.GetHtml());
        }

        public static HtmlString CtrlMultipleSelect(this HtmlHelper html, string id, string label, string listId, string columnDataName,string ariaDescribeby, string idSmall)
        {
            var ctrl = new CtrlMultipleSelectModel
            {
                Id = id,
                Label = label,
                ListId = listId,
                ColumnDataName = columnDataName,
                AriaDescribedby = ariaDescribeby,
                IdSmall = idSmall,
            };

            return new HtmlString(ctrl.GetHtml());
        }

        public static HtmlString CtrlDropDownWithList(this HtmlHelper html, string id, string label, string listOpt, string columnDataName)
        {
            var ctrl = new CtrlDropDownWithListModel
            {
                Id = id,
                Label = label,
                ColumnDataName = columnDataName,
                ListOpt = listOpt
            };
            return new HtmlString(ctrl.GetHtml());
        }


        public static HtmlString CtrlRadio(this HtmlHelper html, string id, string label,
         string columnDataName = "", string value = "", bool isChecked = false, string onchange = "")
        {
            var ctrl = new CtrlRadioModel
            {
                Id = id,
                Label = label,
                Value = value,
                ColumnDataName = columnDataName,
                IsChecked = isChecked,
                onchange = onchange
            };

            return new HtmlString(ctrl.GetHtml());
        }

        public static HtmlString CtrlListModel(this HtmlHelper html, string id, string label, string columnDataName, string ariaDescribeby, string idSmall, string pattern = "")
        {
            var ctrl = new CtrlListModel
            {
                Id = id,
                Label = label,
                ColumnDataName = columnDataName,
                AriaDescribedby = ariaDescribeby,
                IdSmall = idSmall,
                Pattern = pattern
            };

            return new HtmlString(ctrl.GetHtml());
        }

        public static HtmlString CtrlInputRequeridedModel(this HtmlHelper html, string id, string type, string label, string columnDataName,
         string ariaDescribedby, string idSmall, string placeholder = "", string pattern = "", string min = "", string max = "")
        {
            var ctrl = new CtrlInputRequeridedModel
            {
                Id = id,
                Type = type,
                Label = label,
                PlaceHolder = placeholder,
                ColumnDataName = columnDataName,
                Pattern = pattern,
                AriaDescribedby = ariaDescribedby,
                IdSmall = idSmall,
                Min = min,
                Max = max
            };
            return new HtmlString(ctrl.GetHtml());
        }

        public static HtmlString CtrlInputHorizontal(this HtmlHelper html, string id, string type, string label, string placeHolder = "",
            string columnDataName = "", string IsRequired = "", string min = "", string max = "", string pattern = "", string idFeedback = "", bool autofocus = false)
        {

            if (string.IsNullOrEmpty(idFeedback)) idFeedback = id + "Feedback";

            var ctrl = new CtrlInputHorizontalModel
            {
                Id = id,
                Type = type,
                Label = label,
                PlaceHolder = placeHolder,
                ColumnDataName = columnDataName,
                IsRequired = IsRequired,
                Min = min,
                Max = max,
                Pattern = pattern,
                IdFeedback = idFeedback,
                Autofocus = (autofocus) ? "autofocus=\"autofocus\"" : ""
            };

            return new HtmlString(ctrl.GetHtml());
        }

        public static HtmlString CtrlInputMonedaModel(this HtmlHelper html, string id, string type, string label, string columnDataName,
         string ariaDescribedby = "", string idSmall = "", string placeholder = "", string pattern = "", string min = "", string max = "", string name = "",
         string dataType = "")
        {
            var ctrl = new CtrlInputMonedaModel
            {
                Id = id,
                Type = type,
                Label = label,
                PlaceHolder = placeholder,
                ColumnDataName = columnDataName,
                Pattern = pattern,
                AriaDescribedby = ariaDescribedby,
                IdSmall = idSmall,
                Min = min,
                Max = max,
                Name = name,
                DataType = dataType

            };
            return new HtmlString(ctrl.GetHtml());
        }

        public static HtmlString CtrlInputMonedaNoRequeridoModel(this HtmlHelper html, string id, string type, string label, string columnDataName,
    string placeholder = "", string pattern = "", string min = "", string max = "", string name = "", string dataType = "")
        {
            var ctrl = new CtrlInputMonedaNoRequeridoModel
            {
                Id = id,
                Type = type,
                Label = label,
                PlaceHolder = placeholder,
                ColumnDataName = columnDataName,
                Pattern = pattern,          
                Min = min,
                Max = max,
                Name = name,
                DataType = dataType

            };
            return new HtmlString(ctrl.GetHtml());
        }

        public static HtmlString CtrlTableIIModel(this HtmlHelper html , string viewName , string id , string title ,
           string columnsTitle , string ColumnsDataName , string onSelectFunction , string colorHeader) {
            var ctrl = new CtrlTableModel {
                ViewName = viewName ,
                Id = id ,
                Title = title ,
                Columns = columnsTitle ,
                ColumnsDataName = ColumnsDataName ,
                FunctionName = onSelectFunction
            };

            return new HtmlString(ctrl.GetHtml());
        }

        public static HtmlString CtrlTblModel(this HtmlHelper html , string viewName , string id , string title ,
            string columnsTitle , string ColumnsDataName, string colorHeader = "") {
            var ctrl = new CtrlTblModel {
                ViewName = viewName ,
                Id = id ,
                Title = title ,
                Columns = columnsTitle ,
                ColumnsDataName = ColumnsDataName
            };

            return new HtmlString(ctrl.GetHtml());
        }

        public static HtmlString CtrlInputCptchaModelCtrl(this HtmlHelper html , string id , string type , string label , string columnDataName ,
         string ariaDescribedby , string idSmall , string textSmall, string textSpan) {
            var ctrl = new CtrlInputCptchaModelCtrl {
                Id = id ,
                Type = type ,
                Label = label ,
                ColumnDataName = columnDataName,
                AriaDescribedby = ariaDescribedby ,
                IdSmall = idSmall,
                TextSmall = textSmall,
                TextSpan = textSpan
            };
            return new HtmlString(ctrl.GetHtml());
        }

        public static HtmlString CtrlDropDownTipoTrabajo(this HtmlHelper html, string id, string label, string listId, string columnDataName)
        {
            var ctrl = new CtrlDropDownModelTipoTrabajo
            {

                Id = id,
                Label = label,
                ListId = listId,
                ColumnDataName = columnDataName
            };

            return new HtmlString(ctrl.GetHtml());
        }

        public static HtmlString CtrlModalInputModel(this HtmlHelper html , string id , 
            string type , string labelInput , string columnDataName ,string idSmall,string title , 
            string idModal, string labelBtn, string buttonType, string ariadescribed, 
            string idInput, string idButton,string placeholder = "") {
            var ctrl = new CtrlModalInputModel {
                Title = title ,
                IdModal = idModal ,
                IdButton = idButton ,
                LabelButton = labelBtn ,
                Type = type ,
                IdSmall = idSmall ,
                ColumnDataName = columnDataName ,
                AriaDescribedby = ariadescribed ,
                LabelInput = labelInput ,
                Id = id
            };
            return new HtmlString(ctrl.GetHtml());
        }
    }
}