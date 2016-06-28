using Orchard.ContentManagement;
using System.ComponentModel.DataAnnotations;

namespace Tekno.FlexSlider.Models
{
    public class FlexSliderPart : ContentPart<FlexSliderPartRecord>
    {
        [Required]
        public byte Sort
        {
            get
            {
                if (Record.Sort == 0)
                    return 1;
                return Record.Sort;
            }
            set { Record.Sort = value; }
        }

        [Required]
        public int GroupId
        {
            get
            {
                return Record.GroupId;
            }
            set
            {
                Record.GroupId = value;
            }
        }
    }
}