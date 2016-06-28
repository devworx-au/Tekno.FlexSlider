using Orchard.ContentManagement.Handlers;
using Orchard.Data;
using Tekno.FlexSlider.Models;

namespace Tekno.FlexSlider.Handlers
{
    public class FlexSliderWidgetHandler : ContentHandler
    {
        public FlexSliderWidgetHandler(IRepository<FlexSliderWidgetPartRecord> repository)
        {
            Filters.Add(StorageFilter.For(repository));
        }
    }
}