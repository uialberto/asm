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

            if (!roleManager.Roles.Any(ele => ele.Id == "admin"))
            {
                var role = new IdentityRole { Id = "admin", Name = "Administrador" };
                roleManager.Create(role);
            }
            if (!roleManager.Roles.Any(ele => ele.Id == "public"))
            {
                var role = new IdentityRole { Id = "public", Name = "Publico" };
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
                    Email = "info@uibasoft.com",
                };
                var password = "*admin*";
                var result = userManager.Create(user, password);
                if (result.Succeeded)
                    userAdmin = user;
            }
            if (userAdmin != null)
            {
                var roladmin = context.Roles.FirstOrDefault(ele => ele.Id == "admin");
                if (roladmin != null)
                {
                    if (userAdmin.Roles.All(ele => ele.RoleId != roladmin.Id))
                    {
                        var asignRole = userManager.AddToRole(userAdmin.Id, roladmin.Name);
                    }
                }

            }

            var userPublic = context.Users.FirstOrDefault(ele => ele.UserName == "uialberto");
            if (userPublic == null)
            {
                var user = new AppUser
                {
                    UserName = "uialberto",
                    Email = "uialberto@gmail.com",
                };
                var password = "Passw0rd";
                var result = userManager.Create(user, password);
                if (result.Succeeded)
                    userPublic = user;
            }
            if (userPublic != null)
            {
                var rolPublic = context.Roles.FirstOrDefault(ele => ele.Id == "public");
                if (rolPublic != null)
                {
                    if (userPublic.Roles.All(ele => ele.RoleId != rolPublic.Id))
                    {
                        var asignRole = userManager.AddToRole(userPublic.Id, rolPublic.Name);
                    }
                }
            }

            #endregion


        }
    }
}
