
using Orchard.ContentManagement.Records;
namespace Tekno.FlexSlider.Models
{
    public class FlexSliderWidgetPartRecord : ContentPartRecord
    {
        public virtual byte Count { get; set; }
        public virtual int GroupId { get; set; }
    }
}