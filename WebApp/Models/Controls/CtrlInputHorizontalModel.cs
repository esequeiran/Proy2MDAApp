namespace WebApp.Models.Controls
{
    public class CtrlInputHorizontalModel : CtrlBaseModel
    {
        public string Type { get; set; }
        public string Label { get; set; }
        public string PlaceHolder { get; set; }
        public string ColumnDataName { get; set; }
        public string IsRequired { get; set; }
        public string Min { get; set; }
        public string Max { get; set; }
        public string Pattern { get; set; }
        public string IdFeedback { get; set; }
        public string Autofocus { get; set; }

        public CtrlInputHorizontalModel()
        {
            ViewName = "";
        }
    }
}