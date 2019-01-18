using MikroCrm.Data.Domain.Entities;
using MikroCrm.Service.SettingDataServices;
using MikroCrm.Services.UserService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebService.MikroORM;

namespace MikroCrm.UI.Attribute
{
    public class LoginControl: ActionFilterAttribute
    {
       
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                //if (!HttpContext.Current.Response.IsRequestBeingRedirected)
                //    filterContext.HttpContext.Response.Redirect("/Login/Index");
            }
            else
            {
                var database = (SettingData)filterContext.HttpContext.Session["UserDataBase"];
                if (database == null)
                {
                   var email= HttpContext.Current.User.Identity.Name;
                    UserAppService _userservice = new UserAppService();
                    SettingDataService _settingdataservice = new SettingDataService();
                    var user=_userservice.Get(x => x.Email.Trim() == email);
                    var data = _settingdataservice.Get(x => x.UserId == user.Id);
                    filterContext.HttpContext.Session["UserDataBase"] = data;
                    filterContext.HttpContext.Session["UserAccount"] = user;
                    _userservice.Dispose();
                    _settingdataservice.Dispose();
                }
            }
        }
      
    }
   
}