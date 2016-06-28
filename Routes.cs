using Orchard.Mvc.Routes;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;

namespace Tekno.FlexSlider
{
    public class Routes : IRouteProvider
    {
        public void GetRoutes(ICollection<RouteDescriptor> routes)
        {
            foreach (var routeDescriptor in GetRoutes())
                routes.Add(routeDescriptor);
        }


        public IEnumerable<RouteDescriptor> GetRoutes()
        {
            return new[] {
                 new RouteDescriptor {
                    Route = new Route(
                        "Admin/Slider",
                        new RouteValueDictionary {
                            {"area", "Tekno.FlexSlider"},
                            {"controller", "Admin"},
                            {"action", "Items"}
                        },
                        new RouteValueDictionary(),
                        new RouteValueDictionary {
                            {"area", "Tekno.FlexSlider"}
                        },
                        new MvcRouteHandler())
                }, new RouteDescriptor {
                    Route = new Route(
                        "Admin/Group",
                        new RouteValueDictionary {
                            {"area", "Tekno.FlexSlider"},
                            {"controller", "Admin"},
                            {"action", "Groups"}
                        },
                        new RouteValueDictionary(),
                        new RouteValueDictionary {
                            {"area", "Tekno.FlexSlider"}
                        },
                        new MvcRouteHandler())
                }
            };
        }
    }
}