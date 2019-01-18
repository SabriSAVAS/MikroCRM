using MikroCrm.Common.CryptoServices;
using MikroCrm.Data.Domain.Entities;
using MikroCrm.Service.RoleServices;
using MikroCrm.Services.UserService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MikroCrm.UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            UserAppService _userService = new UserAppService();
            RoleAppService _roleService = new RoleAppService();
            if (!_roleService.Any(x=>x.Name=="Admin"))
            {
                RoleApp role1 = new RoleApp();
                role1.Name = "Admin";
                _roleService.Insert(role1);
                
            }
            if (!_roleService.Any(x => x.Name == "User"))
            {
                RoleApp role2 = new RoleApp();
                role2.Name = "User";
                _roleService.Insert(role2);
            }
            if (!_userService.Any(x=>x.Email== "admin@admin.com"))
            {
                UserApp user = new UserApp();
                user.Email = "admin@admin.com";
                user.Password = CryptoService.MD5Password("123");
                user.UserName = "Admin";
                user.CreateDate = DateTime.Now;
                user.DateOfEntry = DateTime.Now;
                user.IsActive = true;
                user.RoleId = 1;
                _userService.Insert(user);
            }
            _userService.Dispose();
            _userService.Dispose();
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
