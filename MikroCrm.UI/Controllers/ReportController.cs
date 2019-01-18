using MikroCrm.UI.ViewModel.ReportModel.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using System.Data;
using ClosedXML.Excel;
using System.IO;
using MikroCrm.Common.MailServices;
using System.Text.RegularExpressions;
using MikroCrm.UI.ViewModel.ReportModel;
using MikroCrm.UI.ViewModel.ReportModel.Bank;

namespace MikroCrm.UI.Controllers
{
    public class ReportController : BaseController
    {
        public ActionResult Customer()
        {
            var model = new ReportCustomerSearchViewModel();


            List<ReportCustomerListViewModel> list = new List<ReportCustomerListViewModel>();

            model.ReportCustomerList = list.ToPagedList(model.Page ?? 1, 20);

            return View(model);

        }
        [HttpPost]
        public ActionResult Customer(ReportCustomerSearchViewModel model)
        {
            if (ModelState.IsValid)
            {
                string sql = "select msg_S_0088 as Id,#msg_S_0158 as EvrakCinsId,msg_S_0089 as Tarih,msg_S_0090 as EvrakSeri,msg_S_0091 as EvrakSira,msg_S_0094 as EvrakTip,msg_S_0003 as EvrakCinsi,msg_S_0098 as VadeTarih,#msg_S_0165 as Miktar,msg_S_0100 as BA,[msg_S_0101\\T] as Borc,[msg_S_0102\\T] as Alacak,msg_S_0115 as KarsiHesapIsmi from  dbo.fn_CariFoy (N'0',0,'" + model.CariKod + "',NULL,'" + model.DevirDate + "','" + model.startDate + "','" + model.endDate + "',0,N'')";
                int pageIndex = model.Page ?? 1;

                var data = _viewCustomerReportORM.GetList(sql);
                List<ReportCustomerListViewModel> list = new List<ReportCustomerListViewModel>();
                if (data.Count > 0)
                {

                    foreach (var item in data)
                    {
                        ReportCustomerListViewModel cus = new ReportCustomerListViewModel();
                        cus.Alacak = item.Alacak;
                        cus.Borc = item.Borc;
                        cus.BA = item.BA;
                        cus.EvrakCinsi = item.EvrakCinsi;
                        cus.EvrakCinsId = item.EvrakCinsId;
                        cus.EvrakSeri = item.EvrakSeri;
                        cus.EvrakSira = item.EvrakSira;
                        cus.EvrakTip = item.EvrakTip;
                        cus.Id = item.Id;
                        cus.KarsiHesapIsmi = item.KarsiHesapIsmi;
                        cus.Miktar = item.Miktar;
                        cus.Tarih = item.Tarih;
                        cus.VadeTarih = item.VadeTarih;
                        list.Add(cus);
                    }

                }
                model.ReportCustomerList = list.ToPagedList(pageIndex, 10);
                if (Request.IsAjaxRequest())
                {
                    return PartialView("_reportcustomerlist", model);
                }

                return View(model);
            }


            return View(model);
        }


        [HttpPost]
        public ActionResult SendMail(string email, string carikod, DateTime ilktarih, DateTime sontarih)
        {
            var resultcari = _carihesaplarORM.GetList("select * from CARI_HESAPLAR where cari_kod='" + carikod + "'").FirstOrDefault();
            if (resultcari == null)
            {
                return Json("Böyle bir cari bulunmuyor.");
            }
            if (emailIsValid(email) == false)
            {
                return Json("Mail adresi uygun bir mail adresi değil");
            }
            DateTime DevirDate = Convert.ToDateTime((DateTime.Now.Year - 1) + ".12.31");
            string _ilktarih = ilktarih.Date.Year + "." + ilktarih.Date.Month + "." + ilktarih.Date.Day;
            string _sontarih = sontarih.Date.Year + "." + sontarih.Date.Month + "." + sontarih.Date.Day;

            string sql = "select msg_S_0088 as Id,#msg_S_0158 as EvrakCinsId,msg_S_0089 as Tarih,msg_S_0090 as EvrakSeri,msg_S_0091 as EvrakSira,msg_S_0094 as EvrakTip,msg_S_0003 as EvrakCinsi,msg_S_0098 as VadeTarih,#msg_S_0165 as Miktar,msg_S_0100 as BA,[msg_S_0101\\T] as Borc,[msg_S_0102\\T] as Alacak,msg_S_0115 as KarsiHesapIsmi from  dbo.fn_CariFoy (N'0',0,'" + carikod + "',NULL,'" + DevirDate + "','" + _ilktarih + "','" + _sontarih + "',0,N'')";

            var data = _viewCustomerReportORM.GetList(sql);

            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[10] { new DataColumn("KAYIT NO"),
                 new DataColumn("TARİH"),
                  new DataColumn("VADE TARİH"),
                   new DataColumn("SERİ"),
                    new DataColumn("SIRA"),
                     new DataColumn("MIKTAR"),
                      new DataColumn("EVRAK TİPİ"),
                       new DataColumn("BORÇ"),
                        new DataColumn("ALACAK"),
                         new DataColumn("AÇIKLAMA")

            });

            if (data.Count == 0) return Json("Carinizde hareket bulunmamaktadır.");
            foreach (var item in data)
            {
                dt.Rows.Add(item.Id, item.Tarih, item.VadeTarih, item.EvrakSeri, item.EvrakSira, item.Miktar, item.EvrakTip, item.Borc, item.Alacak, item.KarsiHesapIsmi);
            }


            using (XLWorkbook wb = new XLWorkbook())
            {



                wb.Worksheets.Add(dt);

                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    byte[] file = stream.ToArray();
                    var result = MailService.sendmail(email, "Cari hareket föyü", resultcari.cari_unvan1 + " cari hesap ekstersi", file.ToArray(), "CariEkste.xlsx");
                    if (result)
                    {
                        return Json("Mailiniz Gönderildi");
                    }
                    else
                    {
                        return Json("Mailiniz Gönderilmedi");
                    }

                }
            }

        }

        public static bool emailIsValid(string email)
        {
            string expresion;
            expresion = @"^(((\([\w!#$%&'*+\/=?^_`{|}~-]*\))?[^<>()[\]\\.,;:\s@\""]+(\.[^<>()[\]\\.,;:\s@\""]+)*)|(\"".+\""))(\([\w!#$%&'*+\/=?^_`{|}~-]*\))?@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, string.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }


        public ActionResult CustomerSearch()
        {
            CustomerModel cus = new CustomerModel();
            return View(cus);
        }

        public ActionResult AutoComplete(string term)
        {
            //  var data =       
            var customer = (from cus in _carihesaplarORM.GetList()
                            where cus.cari_unvan1.Contains(term.Trim().ToUpper())
                            select new
                            {
                                value = cus.cari_unvan1,
                                id = cus.cari_kod
                            }).Take(10).ToList();
            return Json(customer, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult GetCustomer(string kod)
        {
            var data = _customersearchORM.GetList("exec prc_CariArama '" + kod + "'").FirstOrDefault();
            CustomerModel cus = new CustomerModel();
            cus.Adres1 = data.Adres1;
            cus.Adres2 = data.Adres2;
            cus.Bakiye = data.Bakiye;
            cus.BolgeKod = data.BolgeKod;
            cus.CariKod = data.CariKod;
            cus.CariUnvan = data.CariUnvan;
            cus.eFaturaBaslangicTarihi = data.eFaturaBaslangicTarihi;
            cus.eFaturaDurum = data.eFaturaDurum;
            cus.Email = data.Email;
            cus.Fax = data.Fax;
            cus.Id = data.Id;
            cus.Ilce = data.Ilce;
            cus.Il = data.Il;
            cus.PostaKodu = data.PostaKodu;
            cus.Tel1 = data.Tel1;
            cus.Tel2 = data.Tel2;
            cus.VergiDairesi = data.VergiDairesi;
            cus.VergiNumarası = data.VergiNumarası;
            cus.WebAdresi = data.WebAdresi;
            return PartialView("_customersearch", cus);

        }
        public ActionResult CustomerReport()
        {
            var data = _customerreportORM.GetList("exec prc_CariTakipRaporu").ToList();
            List<CustomerReportModel> list = new List<CustomerReportModel>();
            foreach (var item in data)
            {
                CustomerReportModel model = new CustomerReportModel();
                model.AsistanBasTar = item.AsistanBasTar;
                model.AsistanIsmi = item.AsistanIsmi;
                model.BilBakımveDestek = item.BilBakımveDestek;
                model.CariKod = item.CariKod;
                model.CariUnvan = item.CariUnvan;
                model.eImza = item.eImza;
                model.GrupAdı = item.GrupAdı;
                model.Kep = item.Kep;
                model.KonturBasTar = item.KonturBasTar;
                model.MikroEgDes = item.MikroEgDes;
                model.MikroUzakBagTelDes = item.MikroUzakBagTelDes;
                model.SözBas = item.SözBas;
                model.SözBit = item.SözBit;
                model.VergiDairesiNo = item.VergiDairesiNo;
                model.YedeklemeSistemi = item.YedeklemeSistemi;
                model.Yorum1 = item.Yorum1;
                model.Yorum2 = item.Yorum2;
                list.Add(model);
            }
            return View(list);
        }



        //Banka Hareketleri
        public ActionResult BankList()
        {
            var model = new ReportBankSearchViewModel();


            List<ReportBankListViewModel> list = new List<ReportBankListViewModel>();

            model.ReportBankList = list.ToPagedList(model.Page ?? 1, 20);

            return View(model);
        }
        [HttpPost]
        public ActionResult BankList(ReportBankSearchViewModel model)
        {
            if (ModelState.IsValid)
            {
                string sql = "Select msg_S_0088 as Id,msg_S_0089 as Tarih,msg_S_0090 as EvrakSeri,msg_S_0091 as EvrakSira,msg_S_0094 as EvrakTip,msg_S_0003 as Cinsi,#msg_S_0158 as Vade,msg_S_0100 as BorcAlacak,[msg_S_0101\\T] as Borc,[msg_S_0102\\T] as Alacak,[#msg_S_0103\\T] as Tutar,[msg_S_0114] as Hesapismi from dbo.fn_CariFoy (N'0',2,N'" + model.BankaKod + "',1,'" + model.DevirDate + "','" + model.startDate + "','" + model.endDate + "',0,N'')";
                int pageIndex = model.Page ?? 1;
                var data = _viewBankReportORM.GetList(sql);
                List<ReportBankListViewModel> list = new List<ReportBankListViewModel>();
                if (data.Count > 0)
                {

                    foreach (var item in data)
                    {
                        ReportBankListViewModel cus = new ReportBankListViewModel();
                        cus.Alacak = item.Alacak;
                        cus.Borc = item.Borc;
                        cus. BorcAlacak= item.BorcAlacak;
                        cus.EvrakSeri = item.EvrakSeri;
                        cus.EvrakSira = item.EvrakSira;
                        cus.EvrakTip = item.EvrakTip;
                        
                        cus.HesapIsmi = item.HesapIsmi;
                        
                        cus.Tarih = item.Tarih;
                        cus.Vade = item.Vade;
                        list.Add(cus);
                    }

                }
                model.ReportBankList = list.ToPagedList(pageIndex, 10);
                if (Request.IsAjaxRequest())
                {
                    return PartialView("_reportbanklist", model);
                }

                return View(model);
            }


            return View(model);
        }
    }

}