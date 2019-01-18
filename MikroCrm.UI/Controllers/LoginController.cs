using MikroCrm.Common.CryptoServices;
using MikroCrm.Service.SettingDataServices;
using MikroCrm.Services.UserService;
using MikroCrm.UI.ViewModel.LoginModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security;
using System.Web.Security;

namespace MikroCrm.UI.Controllers
{
    public class LoginController : Controller
    {
        private UserAppService _userservice;
        private SettingDataService _settingDataBase;
        public LoginController()
        {
            _userservice = new UserAppService();
            _settingDataBase = new SettingDataService();
        }
        // GET: Login
        public ActionResult Index()
        {
            var model = new LoginViewModel();
            model.Ip = getIp();
            return View(model);
        }

        private string getIp()
        {
          string  ipaddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (ipaddress == "" || ipaddress == null)
                return ipaddress = Request.ServerVariables["REMOTE_ADDR"];
            else
                return "";
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _userservice.ValidetUser(model.Email, CryptoService.MD5Password(model.Password));
                if (user != null)
                {
                    user.DateOfEntry = DateTime.Now;
                    _userservice.Update(user);

                    FormsAuthentication.SetAuthCookie(user.Email, false);
                    Session["UserAccount"] = user;
                    var database = _settingDataBase.Get(x => x.UserId==user.Id);
                    if (database!=null)
                    {
                        Session["UserDataBase"] = database;

                    }
                    return RedirectToAction("Index", "Home");
                }
               
                ModelState.AddModelError("", "Böyle bir kullanici bulunamadi");
            }
            return View(model);
        }
        public ActionResult SingOut()
        {
            Session["UserAccount"] = null;
            Session["UserDataBase"] = null;
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            _settingDataBase.Dispose();
            _userservice.Dispose();
        }
    }
}