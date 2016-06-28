using Orchard.ContentManagement;
using System.ComponentModel.DataAnnotations;

namespace Tekno.FlexSlider.Models
{
    public class FlexSliderWidgetPart : ContentPart<FlexSliderWidgetPartRecord>
    {
        [Required]
        public byte Count
        {
            get
            {
                if (Record.Count == 0)
                {
                    return 3;
                }
                return Record.Count;
            }
            set { Record.Count = value; }
        }

        [Required]
        public int GroupId
        {
            get { return Record.GroupId; }
            set { Record.GroupId = value; }
        }
    }
}