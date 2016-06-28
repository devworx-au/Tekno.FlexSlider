using Orchard.Environment.Extensions.Models;
using Orchard.Security.Permissions;
using System.Collections.Generic;

namespace Tekno.FlexSlider
{
    public class Permissions : IPermissionProvider
    {
        public static readonly Permission CreateSlider = new Permission { Description = "Create slider", Name = "CreateSlider" };
        public static readonly Permission ManageSlider = new Permission { Description = "Manage slider", Name = "ManageSlider" };
        public static readonly Permission ViewSlider = new Permission { Description = "View slider", Name = "ViewSlider" };

        public virtual Feature Feature { get; set; }

        public IEnumerable<Permission> GetPermissions()
        {
            return new[] {
                CreateSlider,
                ManageSlider,
                ViewSlider,
            };
        }

        public IEnumerable<PermissionStereotype> GetDefaultStereotypes()
        {
            return new[] {
                new PermissionStereotype {
                    Name = "Administrator",
                    Permissions = new[] {ManageSlider, CreateSlider,ViewSlider}
                },
                new PermissionStereotype {
                    Name = "Anonymous",
                    Permissions = new[] {ViewSlider}
                },
                new PermissionStereotype {
                    Name = "Authenticated",
                    Permissions = new[] {ViewSlider}
                },
                new PermissionStereotype {
                    Name = "Editor",
                    Permissions = new[] {CreateSlider,ViewSlider}
                },
                new PermissionStereotype {
                    Name = "Moderator",
                    Permissions = new[] {ManageSlider, CreateSlider,ViewSlider}
                },
                new PermissionStereotype {
                    Name = "Author",
                    Permissions = new[] {CreateSlider,ViewSlider}
                },
                new PermissionStereotype {
                    Name = "Contributor",
                    Permissions = new[] {CreateSlider,ViewSlider}
                },
            };
        }
    }
}