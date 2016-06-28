using Orchard;
using Orchard.ContentManagement.Drivers;
using Orchard.Localization;
using Tekno.FlexSlider.Models;

namespace Tekno.FlexSlider.Drivers
{
    public class FlexSliderGroupDriver : ContentPartDriver<FlexSliderGroupPart>
    {
        public FlexSliderGroupDriver(IOrchardServices services)
        {
            Services = services;
        }

        public Localizer T { get; set; }

        public IOrchardServices Services { get; set; }

        protected override DriverResult Display(FlexSliderGroupPart part, string displayType, dynamic shapeHelper)
        {
            if (!Services.Authorizer.Authorize(Permissions.ViewSlider, T("Not allowed to view slide items")))
                return new DriverResult();

            return ContentShape("Parts_FlexSliderGroup",
                   () => shapeHelper.Parts_FlexSliderGroup(ContentPart: part, ContentItem: part.ContentItem));
        }

        protected override DriverResult Editor(FlexSliderGroupPart part, dynamic shapeHelper)
        {
            return ContentShape("Parts_FlexSliderGroup_Edit",
              () => shapeHelper.EditorTemplate(
                  TemplateName: "Parts/FlexSliderGroup",
                  Model: part,
                  Prefix: Prefix));

        }

        protected override DriverResult Editor(FlexSliderGroupPart part, Orchard.ContentManagement.IUpdateModel updater, dynamic shapeHelper)
        {
            updater.TryUpdateModel(part, Prefix, null, null);
            return Editor(part, shapeHelper);
        }
    }
}