using MikroCrm.Data.Domain.Entities;
using MikroCrm.MikroORM;
using MikroCrm.MikroORM.iliskiler;
using MikroCrm.MikroORM.myeData;
using MikroCrm.MikroORM.ProformaSiparis;
using MikroCrm.MikroORM.ProformaSiparis.View;
using MikroCrm.MikroORM.Report;
using MikroCrm.MikroORM.Report.BankView;
using MikroCrm.MikroORM.Report.CustomerView;
using MikroCrm.MikroORM.Siparis;
using MikroCrm.Service.CleanderServices;
using MikroCrm.Service.GeneralSettings;
using MikroCrm.Service.RoleServices;
using MikroCrm.Service.SettingDataServices;
using MikroCrm.Services.UserService;
using MikroCrm.UI.Attribute;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MikroCrm.UI.Controllers
{
    [LoginControl]
    public class BaseController : Controller
    {
        public CleanderService _cleanderservice;
        public UserAppService _userappservice;
        public RoleAppService _roleappservice;
        public SettingDataService _settingdataservice;
        public GeneralSettingService _generalsettingservice;
        public CariHesapYetkiliORM _carihesapYetkiliORM;
        public CariHesapAdresORM _carihesapadresleriORM;
        public StoklarORM _stoklarORM;
        public CariHesaplarORM _carihesaplarORM;
        public SiparisORM _siparisORM;
        public HizmetHesapORM _hizmethesaplarORM;
        public StokSatisFiyatlariORM _stoksatisFiyatORM;
        public EvrakAciklamaORM _evrakAciklamaORM;
        public viewProformaSiparisORM _viewproformaSiparisORM;
        public ProformaSiparisORM _proformaSiparisORM;
        public CariPersonelTanimlariORM _caripersonelTanimORM;
        public viewCustomerReportORM _viewCustomerReportORM;
        public iliskierORM _iliskiORM;
        public iliskilerViewORM _iliskilerViewORM;
        public myeTextDataOrm _myeTextDataOrm;
        public CariHesapYetkiliORM _carihesapyetkiliORM;
        public CustomerSearchORM _customersearchORM;
        public CustomerReportORM _customerreportORM;
        public BankaHesaplarOrm _bankahesaplarORM;
        public viewBankReportORM _viewBankReportORM;
        public BaseController()
        {
            
            _userappservice = new UserAppService();
            _roleappservice = new RoleAppService();
            _settingdataservice = new SettingDataService();
            _generalsettingservice = new GeneralSettingService();

            _carihesapyetkiliORM = new CariHesapYetkiliORM();
            _iliskiORM = new iliskierORM();
            _iliskilerViewORM = new iliskilerViewORM();
            _carihesapYetkiliORM = new CariHesapYetkiliORM();
            _carihesapadresleriORM = new CariHesapAdresORM();
            _carihesaplarORM = new CariHesaplarORM();
            _hizmethesaplarORM = new HizmetHesapORM();
            _stoklarORM = new StoklarORM();
            _carihesaplarORM = new CariHesaplarORM();
            _siparisORM = new SiparisORM();
            _stoksatisFiyatORM = new StokSatisFiyatlariORM();
            _evrakAciklamaORM = new EvrakAciklamaORM();
            _viewproformaSiparisORM = new viewProformaSiparisORM();
            _proformaSiparisORM = new ProformaSiparisORM();
            _caripersonelTanimORM = new CariPersonelTanimlariORM();
            _viewCustomerReportORM = new viewCustomerReportORM();
            _myeTextDataOrm = new myeTextDataOrm();
            _cleanderservice = new CleanderService();
            _customersearchORM = new CustomerSearchORM();
            _customerreportORM = new CustomerReportORM();
            _bankahesaplarORM = new BankaHesaplarOrm();
            _viewBankReportORM = new viewBankReportORM();
        }

       

        protected override void Dispose(bool disposing)
        {
            _userappservice.Dispose();
            _roleappservice.Dispose();
            _settingdataservice.Dispose();
        }
        public void Success(string message)
        {
            AddAlert(AlertStyles.Success, message);
        }

        public void Information(string message)
        {
            AddAlert(AlertStyles.Information, message);
        }

        public void Warning(string message, bool dismissable = false)
        {
            AddAlert(AlertStyles.Warning, message);
        }

        public void Danger(string message)
        {
            AddAlert(AlertStyles.Danger, message);
        }

        private void AddAlert(string alertStyle, string message)
        {
            TempData["Alert"] = alertStyle;
            TempData["Message"] = message;
        }
        public static class AlertStyles
        {
            public const string Success = "success";
            public const string Information = "info";
            public const string Warning = "warning";
            public const string Danger = "danger";
        }
    }
}