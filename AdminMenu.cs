using Orchard.ContentManagement;
using Orchard.Localization;
using Orchard.UI.Navigation;
using Tekno.FlexSlider.Models;

namespace Tekno.FlexSlider
{
    public class AdminMenu : INavigationProvider
    {
        private readonly IContentManager _contentManager;

        public Localizer T { get; set; }

        public string MenuName { get { return "admin"; } }

        public AdminMenu(IContentManager contentManager)
        {
            _contentManager = contentManager;
        }

        public void GetNavigation(NavigationBuilder builder)
        {
            builder.Add(T("Slider"), "1.5", BuildMenu);
        }

        private void BuildMenu(NavigationItemBuilder menu)
        {
            menu.Add(T("New Slider Group"), "1",
                       item =>
                       item.Action("Create", "Admin", new { area = "Contents", id = "FlexSliderGroup" }).Permission(Permissions.CreateSlider));

            menu.Add(T("New Slider Group"), "1",
                       item =>
                       item.Action("Create", "Admin", new { area = "Contents", id = "FlexSliderGroup" }).Permission(Permissions.CreateSlider));

            if (SliderGroupItemExists())
            {
                menu.Add(T("Manage Slider Groups"), "1.1",
                         item =>
                         item.Action("Groups", "Admin", new { area = "Tekno.FlexSlider" }));

                menu.Add(T("New Slider Item"), "1.2",
                         item =>
                         item.Action("Create", "Admin", new { area = "Contents", id = "FlexSlider" }));
            }

            if (SliderGroupItemExists() && SliderItemExists())
            {
                menu.Add(T("Manage Slider Items"), "1.1",
                         item =>
                         item.Action("Items", "Admin", new { area = "Tekno.FlexSlider" }).Permission(Permissions.ManageSlider));
            }

        }

        private bool SliderItemExists()
        {
            return _contentManager.Query<FlexSliderPart, FlexSliderPartRecord>("FlexSlider").Count() > 0;
        }

        private bool SliderGroupItemExists()
        {
            return _contentManager.Query("FlexSliderGroup").Count() > 0;
        }
    }
}