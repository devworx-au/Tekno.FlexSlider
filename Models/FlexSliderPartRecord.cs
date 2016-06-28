using Orchard.ContentManagement.Records;

namespace Tekno.FlexSlider.Models
{
    public class FlexSliderPartRecord : ContentPartRecord
    {
        public virtual byte Sort { get; set; }
        public virtual int GroupId { get; set; }
    }
}