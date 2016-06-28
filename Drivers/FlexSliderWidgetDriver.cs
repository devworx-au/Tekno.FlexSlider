using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Orchard.Core.Title.Models;
using Orchard.MediaLibrary.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Tekno.FlexSlider.Models;
using Tekno.FlexSlider.ViewModels;

namespace Tekno.FlexSlider.Drivers
{
    public class FlexSliderWidgetDriver : ContentPartDriver<FlexSliderWidgetPart>
    {
        private readonly IContentManager _contentManager;

        public FlexSliderWidgetDriver(IContentManager contentManager)
        {
            _contentManager = contentManager;
        }


        protected override DriverResult Display(FlexSliderWidgetPart part, string displayType, dynamic shapeHelper)
        {
            var items = _contentManager.Query<FlexSliderPart, FlexSliderPartRecord>("FlexSlider").Where(i => i.GroupId == part.GroupId).OrderBy(i => i.Sort).List().Select(i => new FlexSliderWidgetViewModel()
             {
                 ImagePath = ((MediaLibraryPickerField)i.Fields.Single(f => f.Name == "Picture")).MediaParts.FirstOrDefault() == null ? "" : ((MediaLibraryPickerField)i.Fields.Single(f => f.Name == "Picture")).MediaParts.First().MediaUrl,
                 Title = i.Get<TitlePart>().Title
             });

            return ContentShape("Parts_FlexSliderWidget",
                () => shapeHelper.Parts_FlexSliderWidget(SlideItems: items));
        }

        protected override DriverResult Editor(FlexSliderWidgetPart part, dynamic shapeHelper)
        {

            var model = new FlexSliderWidgetEditViewModel();

            var list = _contentManager.Query(VersionOptions.Latest, "FlexSliderGroup").List().Select(i => new { id = i.Id, value = i.Get<TitlePart>().Title });

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

            model.Count = part.Count;
            model.GroupId = part.GroupId;

            return ContentShape("Parts_FlexSliderWidget_Edit",
              () => shapeHelper.EditorTemplate(
                  TemplateName: "Parts/FlexSliderWidget",
                  Model: model,
                  Prefix: Prefix));

        }

        protected override DriverResult Editor(FlexSliderWidgetPart part, Orchard.ContentManagement.IUpdateModel updater, dynamic shapeHelper)
        {
            updater.TryUpdateModel(part, Prefix, null, null);
            return Editor(part, shapeHelper);
        }

        protected override void Importing(FlexSliderWidgetPart part, Orchard.ContentManagement.Handlers.ImportContentContext context)
        {
            string count = context.Attribute(part.PartDefinition.Name, "Count");
            byte countNumber;
            if (count != null && byte.TryParse(count, out countNumber))
            {
                part.Count = countNumber;
            }

            string groupId = context.Attribute(part.PartDefinition.Name, "GroupId");
            byte groupIdNumber;
            if (groupId != null && byte.TryParse(groupId, out groupIdNumber))
            {
                part.GroupId = groupIdNumber;
            }
        }

        protected override void Exporting(FlexSliderWidgetPart part, Orchard.ContentManagement.Handlers.ExportContentContext context)
        {
            context.Element(part.PartDefinition.Name).SetAttributeValue("Count", part.Count);
            context.Element(part.PartDefinition.Name).SetAttributeValue("GroupId", part.GroupId);
        }
    }
}