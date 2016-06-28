using System.Collections.Generic;
using System.Web.Mvc;

namespace Tekno.FlexSlider.ViewModels
{
    public class FlexSliderWidgetEditViewModel
    {
        public byte Count { get; set; }
        public IList<SelectListItem> Groups { get; set; }
        public int GroupId { get; set; }
    }
}