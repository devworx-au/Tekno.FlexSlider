using System.Collections.Generic;
using System.Web.Mvc;

namespace Tekno.FlexSlider.ViewModels
{
    public class FlexSliderEditViewModel
    {
        public byte Sort{ get; set; }
        public IList<SelectListItem> Groups { get; set; }
        public int GroupId { get; set; }
    }
}