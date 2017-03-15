using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asm.Aplicacion.Modulos.Seguridad.AppUsers.Impl;
using Asm.Dominio.Modulos.Seguridad.Agregados.AppUsers;
using Asm.Infra;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Practices.Unity;

namespace Asm.Aplicacion.Helpers
{
    public class TestDataConfiguration
    {

        public static void Initialize()
        {
            ConfiguracionAdmin();

        }

        private static void ConfiguracionAdmin()
        {
            var context = new UnitOfWork();

            if (context == null)
                throw new ArgumentNullException(nameof(context));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<AppUser>(new UserStore<AppUser>(context));

            #region Creacion Roles           

            if (!roleManager.RoleExists("admin"))
            {
                var role = new IdentityRole { Name = "admin" };
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists("public"))
            {
                var role = new IdentityRole { Name = "public" };
                roleManager.Create(role);
            }

            #endregion

            #region Creacion Usuario y Asignacion Roles

            var userAdmin = context.Users.FirstOrDefault(ele => ele.UserName == "admin");
            if (userAdmin == null)
            {
                var user = new AppUser
                {
                    UserName = "admin",
                    Email = "admin@uibasoft.com",
                };
                var password = "*admin*";
                var result = userManager.Create(user, password);
                if (result.Succeeded)
                    userAdmin = user;
            }
            if (userAdmin != null)
            {
                var roladmin = context.Roles.FirstOrDefault(ele => ele.Name == "admin");
                if (roladmin != null)
                {
                    if (userAdmin.Roles.All(ele => ele.RoleId != roladmin.Id))
                    {
                        var asignRole = userManager.AddToRole(userAdmin.Id, "admin");
                    }
                }

            }

            var userPublic = context.Users.FirstOrDefault(ele => ele.UserName == "public");
            if (userPublic == null)
            {
                var user = new AppUser
                {
                    UserName = "public",
                    Email = "public@uibasoft.com",
                };
                var password = "*public*";
                var result = userManager.Create(user, password);
                if (result.Succeeded)
                    userPublic = user;
            }
            if (userPublic != null)
            {
                var rolPublic = context.Roles.FirstOrDefault(ele => ele.Name == "public");
                if (rolPublic != null)
                {
                    if (userPublic.Roles.All(ele => ele.RoleId != rolPublic.Id))
                    {
                        var asignRole = userManager.AddToRole(userPublic.Id, "public");
                    }
                }
            }

            #endregion

        }
    }
}
