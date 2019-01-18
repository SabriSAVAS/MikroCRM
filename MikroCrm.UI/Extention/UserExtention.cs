using MikroCrm.Data.Domain.Entities;
using MikroCrm.Service.GeneralSettings;
using MikroCrm.Service.SettingDataServices;
using MikroCrm.Services.UserService;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Mvc;
using System.Security;
using System.Web.Security;

public static class UserExtention
{
    public static UserApp GetUserApp(this HtmlHelper h)
    {
        var userapp = (UserApp)HttpContext.Current.Session["UserAccount"];
        return userapp;
    }
    public static UserApp GetUserApp(this Controller h)
    {
        var userapp = (UserApp)HttpContext.Current.Session["UserAccount"];
        return userapp;
    }

    public static SettingData GetSettingData(this HtmlHelper h)
    {
        var userdatabase = (SettingData)HttpContext.Current.Session["UserDataBase"];
        return userdatabase;
    }
    public static SettingData GetSettingData(this Controller h)
    {
        var userdatabase = (SettingData)HttpContext.Current.Session["UserDataBase"];
        return userdatabase;
    }
    public static GeneralSetting GeneralSettingData(this Controller h)
    {
        var userapp = (UserApp)HttpContext.Current.Session["UserAccount"];
        GeneralSettingService _generalservice = new GeneralSettingService();
        GeneralSetting set = _generalservice.Get(x => x.UserId == userapp.Id);
        if (set!=null)
        {
            return set;
        }
        else
        {
            set = new GeneralSetting();

          
            set.DocSeri = "YS";
            return set;
        }
        
    }
    public static bool GetConnection(this HtmlHelper h)
    {
        var email = HttpContext.Current.User.Identity.Name;
        UserAppService _userservice = new UserAppService();
        SettingDataService _settingdataservice = new SettingDataService();
        var user = _userservice.Get(x => x.Email.Trim() == email);
        var data = _settingdataservice.Get(x => x.UserId == user.Id);
        string sqlcon = "server=" + data.Server + ";DataBase=" + data.DataBase + ";User=" + data.UserName + ";Password=" +data.Password + "";
        SqlConnection con = new SqlConnection(sqlcon);
        try
        {
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception)
        {

            return false;
        }
        finally
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Close();
            }
        }
        
    }
}
