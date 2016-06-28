using Orchard.UI.Resources;

namespace Tekno.FlexSlider
{
    public class ResourceManifest : IResourceManifestProvider
    {
        public void BuildManifests(ResourceManifestBuilder builder)
        {
            builder.Add().DefineStyle("FlexSlider")
                .SetUrl("flexslider.min.css", "flexslider.css")
                .SetVersion("2.6.1")
                .SetCdn("//cdnjs.cloudflare.com/ajax/libs/flexslider/2.6.1/flexslider.min.css", "//cdnjs.cloudflare.com/ajax/libs/flexslider/2.6.1/flexslider.css", true);

            builder.Add().DefineScript("FlexSlider")
                .SetUrl("jquery.flexslider.min.js", "jquery.flexslider.js")
                .SetDependencies("jQuery")
                .SetVersion("2.6.1")
                .SetCdn("//cdnjs.cloudflare.com/ajax/libs/flexslider/2.6.1/jquery.flexslider.min.js", "//cdnjs.cloudflare.com/ajax/libs/flexslider/2.6.1/jquery.flexslider.js", true);
        }
    }
}