using Orchard;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Orchard.Core.Title.Models;
using Orchard.Localization;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Tekno.FlexSlider.Models;
using Tekno.FlexSlider.ViewModels;

namespace Tekno.FlexSlider.Drivers
{
    public class FlexSliderDriver : ContentPartDriver<FlexSliderPart>
    {
        private readonly IContentManager _contentManager;

        public FlexSliderDriver(IOrchardServices services, IContentManager contentManager)
        {
            Services = services;
            _contentManager = contentManager;
        }

        public Localizer T { get; set; }

        public IOrchardServices Services { get; set; }

        protected override DriverResult Display(FlexSliderPart part, string displayType, dynamic shapeHelper)
        {
            if (!Services.Authorizer.Authorize(Permissions.ViewSlider, T("Not allowed to view slide items")))
                return new DriverResult();

            var group = _contentManager.Get(part.GroupId);

            FlexSliderViewModel model = new FlexSliderViewModel();

            if (group != null)
                model.Group = group.Get<TitlePart>().Title;


            model.Sort = part.Sort;


            return ContentShape("Parts_FlexSlider",
                () => shapeHelper.Parts_FlexSlider(Item: model));
        }

        protected override DriverResult Editor(FlexSliderPart part, dynamic shapeHelper)
        {
            var model = new FlexSliderEditViewModel();

            var list = _contentManager.Query("FlexSliderGroup").List().Select(i => new { id = i.Id, value = i.Get<TitlePart>().Title });

            model.Groups = new List<SelectListItem>();

            foreach (var item in list)
            {
                if (item.id == part.GroupId)
                {
                    model.Groups.Add(new SelectListItem() { Selected = true, Text = item.value, Value = item.id.ToString() });
                }
                else
                {
                    model.Groups.Add(new SelectListItem() { Selected = false, Text = item.value, Value = item.id.ToString() });
                }
            }

            model.Sort = part.Sort;
            model.GroupId = part.GroupId;


            return ContentShape("Parts_FlexSlider_Edit",
              () => shapeHelper.EditorTemplate(
                  TemplateName: "Parts/FlexSlider",
                  Model: model,
                  Prefix: Prefix));

        }

        protected override DriverResult Editor(FlexSliderPart part, Orchard.ContentManagement.IUpdateModel updater, dynamic shapeHelper)
        {
            updater.TryUpdateModel(part, Prefix, null, null);
            return Editor(part, shapeHelper);
        }

        protected override void Importing(FlexSliderPart part, Orchard.ContentManagement.Handlers.ImportContentContext context)
        {
            string sort = context.Attribute(part.PartDefinition.Name, "Sort");
            byte sortNumber;
            if (sort != null && byte.TryParse(sort, out sortNumber))
            {
                part.Sort = sortNumber;
            }
            string groupId = context.Attribute(part.PartDefinition.Name, "GroupId");
            byte groupIdNumber;
            if (groupId != null && byte.TryParse(groupId, out groupIdNumber))
            {
                part.GroupId = groupIdNumber;
            }
        }

        protected override void Exporting(FlexSliderPart part, Orchard.ContentManagement.Handlers.ExportContentContext context)
        {
            context.Element(part.PartDefinition.Name).SetAttributeValue("Sort", part.Sort);
            context.Element(part.PartDefinition.Name).SetAttributeValue("GroupId", part.GroupId);
        }


    }
}