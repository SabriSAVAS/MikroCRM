using MikroCrm.Common.CryptoServices;
using MikroCrm.Data.Domain.Entities;
using MikroCrm.UI.ViewModel.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MikroCrm.UI.Controllers
{
    public class UserController : BaseController
    {
        // GET: User
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }
        public ActionResult List()
        {
            var model = new List<UserListViewModel>();
            var data = _userappservice.GetList();
            foreach (var item in data)
            {
                UserListViewModel user = new UserListViewModel();
                user.UserName = item.UserName.Trim();
                user.Id = item.Id;
                user.RoleId = item.RoleId;
                user.RoleName = item.Role.Name.Trim();
                user.IsActive = item.IsActive;
                user.CreateDate = item.CreateDate;
                user.DateOfEntry = item.DateOfEntry;
                user.Email = item.Email.Trim();
                model.Add(user);
            }

            return View(model);
        }
        public ActionResult AddUser()
        {
            var model = new UserViewModel();
            model.RoleList = GetRoleList();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddUser(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                UserApp user = new UserApp();
                user.UserName = model.UserName.Trim();
                user.Email = model.Email.Trim();
                user.Password = CryptoService.MD5Password(model.Password.Trim());
                user.RoleId = model.RoleId;
                user.IsActive = true;
                if (_userappservice.Insert(user) != null)
                {
                    SettingData data = new SettingData();
                    data.UserId = user.Id;
                    data.Password = model.SettingData.Password.Trim();
                    data.Server = model.SettingData.Server.Trim();
                    data.DataBase = model.SettingData.DataBase.Trim();
                    data.UserName = model.SettingData.UserName.Trim();
                    _settingdataservice.Insert(data);

                    GeneralSetting setting = new GeneralSetting();
                    setting.UserId = user.Id;
                    setting.DocSeri = "ES";
                    _generalsettingservice.Insert(setting);


                    Success("Kayıt işlemi başarılı");
                    return RedirectToAction("List");
                }
                else
                {
                    Warning("Kayıt işlemi başarısız");
                    return RedirectToAction("List");
                }

            }
            model.RoleList = GetRoleList();
            return View(model);
        }

        public ActionResult EditUser(int id)
        {
            var model = new UserViewModel();
            var data = _userappservice.GetById(id);
            if (data != null)
            {
                model.Id = data.Id;
                model.CreateDate = data.CreateDate;
                model.DateOfEntry = data.DateOfEntry;
                model.Email = data.Email;
                model.IsActive = data.IsActive;
                model.Password = CryptoService.MD5Password(data.Password);
                model.RoleId = data.RoleId;
                model.UserName = data.UserName;
            }

            var settingdata = _settingdataservice.Get(x => x.UserId == data.Id);
            if (settingdata != null)
            {
                model.SettingData.DataBase = settingdata.DataBase;
                model.SettingData.Password = settingdata.Password;
                model.SettingData.UserName = settingdata.UserName;
                model.SettingData.Server = settingdata.Server;
                model.SettingData.Id = settingdata.Id;
            }
            model.RoleList = GetRoleList();

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditUser(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                UserApp user = _userappservice.GetById(model.Id);
                user.Id = model.Id;
                user.UserName = model.UserName;
                user.Email = model.Email;
                //  user.Password = model.Password;
                user.RoleId = model.RoleId;
                if (_userappservice.Update(user))
                {
                    if (model.SettingData.Id > 0)
                    {
                        SettingData data = _settingdataservice.GetById(model.SettingData.Id);
                        data.UserId = user.Id;
                        data.Id = model.SettingData.Id;
                        data.Password = model.SettingData.Password;
                        data.Server = model.SettingData.Server;
                        data.DataBase = model.SettingData.DataBase;
                        data.UserName = model.SettingData.UserName;

                        _settingdataservice.Update(data);
                    }

                    Session["UserAccount"] = null;
                    Session["UserDataBase"] = null;
                    Session["SqlConnection"] = null;
                    Success("Guncelleme işlemi başarılı");

                    return RedirectToAction("List");
                }
                else
                {
                    Warning("Guncelleme işlemi başarısız");
                    return RedirectToAction("List");
                }

            }
            model.RoleList = GetRoleList();
            return View(model);
        }

        [HttpPost]
        public ActionResult DeleteUser(int id)
        {
            var result = _userappservice.Delete(id);
            if (result)
            {
                var setting = _settingdataservice.Get(x => x.UserId == id);
                if (setting != null)
                {
                    _settingdataservice.Delete(setting);
                }
                return Json("1");
            }
            else
            {
                return Json("-1");
            }
           
        }
        [HttpGet]
        public JsonResult DataBaseStatu(int id)
        {
            var data = _settingdataservice.Get(x => x.UserId == id);
            if (data == null) return Json("-1", JsonRequestBehavior.AllowGet);
            string sqlcon = "server=" + data.Server + ";DataBase=" + data.DataBase + ";User=" + data.UserName + ";Password=" + data.Password + "";
            SqlConnection con = new SqlConnection(sqlcon);
            try
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    return Json("1", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("-1", JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception)
            {

                return Json("-1", JsonRequestBehavior.AllowGet);
            }
            finally
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Close();
                }
            }
        }

        private List<SelectListItem> GetRoleList()
        {
            var data = _roleappservice.GetList().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
            return data.ToList();
        }

        [HttpPost]
        public ActionResult GeneralSettingAdd(string docseri, int userId)
        {
            GeneralSetting set = _generalsettingservice.Get(x => x.UserId == userId);
            if (set == null)
            {
                set = new GeneralSetting();
                set.DocSeri = docseri;
                set.UserId = userId;
                if (_generalsettingservice.Insert(set) != null)
                    return Json("1");
                return Json("-1");
            }
            set.DocSeri = docseri;
            set.UserId = userId;
            if (_generalsettingservice.Update(set))
                return Json("1");
            return Json("-1");

        }
        [HttpPost]
        public ActionResult GetGeneralSetting(int UserId)
        {
            GeneralSetting set = _generalsettingservice.Get(x => x.UserId == UserId);
            if (set != null)
            {
                return Json(set, JsonRequestBehavior.AllowGet);
            }
            else
            {
                set = new GeneralSetting();
                set.UserId = UserId;
                set.DocSeri = "";
                return Json(set, JsonRequestBehavior.AllowGet);
            }

        }
    }
}