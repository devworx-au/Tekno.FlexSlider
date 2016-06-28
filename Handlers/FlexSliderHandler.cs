using Orchard.ContentManagement.Handlers;
using Orchard.Data;
using Tekno.FlexSlider.Models;

namespace Tekno.FlexSlider.Handlers
{
    public class FlexSliderHandler : ContentHandler
    {
        public FlexSliderHandler(IRepository<FlexSliderPartRecord> repository)
        {
            Filters.Add(StorageFilter.For(repository));
        }
    }
}