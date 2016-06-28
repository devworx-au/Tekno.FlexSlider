using Orchard.UI.Resources;

namespace Tekno.FlexSlider
{
    public class ResourceManifest : IResourceManifestProvider
    {
        public void BuildManifests(ResourceManifestBuilder builder) {
            builder.Add().DefineStyle("FlexSlider").SetUrl("flexslider.min.css", "flexslider.css").SetVersion("2.6.1");

            builder.Add().DefineScript("FlexSlider").SetUrl("jquery.flexslider.min.js", "jquery.flexslider.js").SetDependencies("jQuery").SetVersion("2.6.1");
        }
    }
}