using MikroCrm.MikroORM;
using MikroCrm.UI.ViewModel.CatalogModel.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using MikroCrm.UI.ViewModel.CatalogModel.Stock;
using MikroCrm.UI.ViewModel.CatalogModel.Hizmet;
using MikroCrm.UI.ViewModel.CatalogModel.Bank;

namespace MikroCrm.UI.Controllers
{
    public class CatalogController : BaseController
    {
    
   
      
        // GET: Catalog
        public PartialViewResult CustomerList(CustomerSearchViewModel model)
        {
            int pageIndex = model.Page ?? 1;
            string sql = "Select top 100 * From CARI_HESAPLAR where cari_kod like '%" + model.CariKod + "%' and cari_unvan1 like '%" + model.CariUnvan + "%'  order by cari_RECno desc";
            var customers = _carihesaplarORM.GetList(sql);

            List<CustomerListViewModel> list = new List<CustomerListViewModel>();
            foreach (var item in customers)
            {
                CustomerListViewModel cus = new CustomerListViewModel();
                cus.Id = item.cari_RECno;
                cus.CariKod = item.cari_kod;
                cus.CariUnvan = item.cari_unvan1;
                list.Add(cus);
            }
            model.CustomerList = list.ToPagedList(pageIndex, 5);
            if (Request.IsAjaxRequest())
            {
                return PartialView("_customerList", model);

            }
            return PartialView("_customerPopup", model);
        }

        public PartialViewResult StockList(StockSearchViewModel model)
        {
            int pageIndex = model.Page ?? 1;
            string sql = "Select top 100 * From STOKLAR where sto_kod like '%" + model.StokKod + "%' and sto_isim like '%" + model.StokAd + "%'  order by sto_RECno desc";
            var stocks = _stoklarORM.GetList(sql);

            List<StockListViewModel> list = new List<StockListViewModel>();
            foreach (var item in stocks)
            {
                StockListViewModel cus = new StockListViewModel();
                cus.Id = item.sto_RECno;
                cus.StokKod = item.sto_kod;
                cus.StokAd = item.sto_isim;
                list.Add(cus);
            }
            model.StockList = list.ToPagedList(pageIndex, 5);
            if (Request.IsAjaxRequest())
            {
                return PartialView("_stockList", model);

            }
            return PartialView("_stockPopup", model);
        }
        public ActionResult HizmetList(HizmetSearchViewModel model)
        {
            int pageIndex = model.Page ?? 1;
            string sql = "Select top 100 * From HIZMET_HESAPLARI where hiz_kod like '%" + model.HizmetKod + "%' and hiz_isim like '%" + model.HizmetAd + "%'  order by hiz_RECno desc";
            var stocks = _hizmethesaplarORM.GetList(sql);

            List<HizmetListViewModel> list = new List<HizmetListViewModel>();
            foreach (var item in stocks)
            {
                HizmetListViewModel cus = new HizmetListViewModel();
                cus.Id = item.hiz_RECno;
                cus.HizmetKod = item.hiz_kod;
                cus.HizmetAd = item.hiz_isim;
                list.Add(cus);
            }
            model.HizmetList = list.ToPagedList(pageIndex, 5);
            if (Request.IsAjaxRequest())
            {
                return PartialView("_hizmetList", model);

            }
            return PartialView("_hizmetPopup", model);
        }


        public PartialViewResult BankList(BankSearchViewModel model)
        {
            int pageIndex = model.Page ?? 1;
            string sql = "select * from BANKALAR where ban_kod like '%" + model.BankaKod + "%' and ban_ismi like '%" + model.Bankaismi + "%'  order by ban_RECno desc";
            var banks = _bankahesaplarORM.GetList(sql);

            List<BankListViewModel> list = new List<BankListViewModel>();
            foreach (var item in banks)
            {
                BankListViewModel ban = new BankListViewModel();
                ban.Id = item.ban_RECno;
                ban.BankaKod = item.ban_kod;
                ban.BankaIsmi = item.ban_ismi;
                list.Add(ban);
            }
            model.BankList = list.ToPagedList(pageIndex, 5);
            if (Request.IsAjaxRequest())
            {
                return PartialView("_bankList", model);

            }
            return PartialView("_bankPopup", model);
        }
    }
}