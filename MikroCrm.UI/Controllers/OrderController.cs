using MikroCrm.MikroORM;
using MikroCrm.MikroORM.Siparis.View;
using MikroCrm.UI.ViewModel.OrderModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using MikroCrm.UI.HelperBasket;
using MikroCrm.MikroEntity.Siparis;

namespace MikroCrm.UI.Controllers
{
    public class OrderController : BaseController
    {
        // GET: Order
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }
        public ActionResult List(OrderSearchViewModel model)
        {
            if (ModelState.IsValid)
            {
                int pageIndex = model.Page ?? 1;

                string sql = "SELECT TOP 100  MIN(sip_RECno) AS KayitNo /* İLK KAYIT NO */ , sip_evrakno_seri AS EvrakSeri /* SERİ */ , sip_evrakno_sira AS EvrakNo /* SIRA NO */ , sip_tarih AS SiparisTarihi /* SİPARİŞ TARİHİ */ , MIN(sip_teslim_tarih) AS TeslimTarihi /* TESLİM TARİHİ */ , dbo.fn_TalepTemin(sip_tip) AS Tipi /* TİPİ */ , dbo.fn_SiparisCins(sip_cins) AS SiparisCinsi /* SİPARİŞ CİNSİ */ , sip_musteri_kod AS CariKodu /* CARİ KODU */ , dbo.fn_CarininIsminiBul(0,sip_musteri_kod) AS CariIsmi /* CARİ İSMİ */ , SUM(sip_miktar) AS Miktar /* MİKTAR */, SUM( dbo.fn_SiparisNetTutar ( sip_tutar, sip_iskonto_1, sip_iskonto_2, sip_iskonto_3, sip_iskonto_4, sip_iskonto_5, sip_iskonto_6, sip_masraf_1, sip_masraf_2, sip_masraf_3, sip_masraf_4, sip_vergi, sip_masvergi, sip_Otv_Vergi, sip_otvtutari, sip_vergisiz_fl, 2,sip_doviz_kuru,sip_alt_doviz_kuru)) AS Tutar, COUNT(sip_satirno) AS SatirSayisi /* SATIR SAYISI */  FROM dbo.SIPARISLER WITH (NOLOCK)  Where sip_musteri_kod like '%" + model.CariKod + "%' and sip_tarih BETWEEN '" + model.startDate + "' and '" + model.endDate + "' GROUP BY sip_tip, sip_cins, sip_evrakno_seri, sip_evrakno_sira, sip_tarih, sip_musteri_kod ORDER BY  sip_tarih";
                viewSiparisORM sip = new viewSiparisORM();

                var data = sip.GetList(sql).OrderByDescending(x => x.EvrakNo).OrderByDescending(x => x.SiparisTarihi).ToList();
                List<OrderListViewModel> orderlist = new List<OrderListViewModel>();
                foreach (var item in data)
                {
                    OrderListViewModel order = new OrderListViewModel();
                    order.CariIsmi = item.CariIsmi;
                    order.CariKodu = item.CariKodu;
                    order.EvrakNo = item.EvrakNo;
                    order.EvrakSeri = item.EvrakSeri;
                    order.KalanMiktar = item.KalanMiktar;
                    order.KayitNo = item.KayitNo;
                    order.Miktar = item.Miktar;
                    order.SatirSayisi = item.SatirSayisi;
                    order.SiparisCinsi = item.SiparisCinsi;
                    order.SiparisTarihi = item.SiparisTarihi;
                    order.TeslimTarihi = item.TeslimTarihi;
                    order.Tipi = item.Tipi;
                    order.Tutar = item.Tutar;
                    orderlist.Add(order);
                }

                model.OrderList = orderlist.ToPagedList(pageIndex, 10);
                if (Request.IsAjaxRequest())
                {
                    return PartialView("_orderlist", model);
                }
                return View(model);
            }

            return View(model);
        }
        public ActionResult AddOrder()
        {
            var model = new OrderViewModel();
            List<OrderBasketListViewModel> list = new List<OrderBasketListViewModel>();
            foreach (var item in OrderBasket.ActiveOrder._Items)
            {
                OrderBasketListViewModel bas = new OrderBasketListViewModel();
                bas.Aciklama = "";
                bas.Birim = item.stoklar.sto_birim1_ad;
                bas.BirimFiyat = 10;
                bas.Miktar = item.Quantity;
                bas.Id = item.stoklar.sto_RECno;
                bas.StokAd = item.stoklar.sto_isim;
                bas.StokKod = item.stoklar.sto_kod;
                bas.Tutar = item.Quantity * bas.BirimFiyat;

                list.Add(bas);
            }
            model.OrderBasketList = list;
            return View(model);
        }

        [HttpPost]
        public ActionResult AddOrder(OrderViewModel model)
        {
           
            if (ModelState.IsValid)
            {
                if (OrderBasket.ActiveOrder._Items.Count > 0)
                {
                    int count = 0;
                    bool durum = false;
                  //  int evraknosira = GetEvrakNoSira();
                    foreach (var item in OrderBasket.ActiveOrder._Items)
                    {
                        SIPARISLER sip = new SIPARISLER();
                        sip.sip_stok_kod = item.stoklar.sto_kod;
                        sip.sip_RECid_DBCno = 0;
                        sip.sip_RECid_RECno = 0;
                        sip.sip_SpecRECno = 0;
                        sip.sip_iptal = false;
                        sip.sip_fileid = 21;
                        sip.sip_hidden = false;
                        sip.sip_kilitli = false;
                        sip.sip_iptal = false;
                        sip.sip_degisti = false;
                        sip.sip_checksum = 0;
                        sip.sip_create_user = 1;/* (short)this.Customer().cari_RECno;*/
                        sip.sip_create_date = DateTime.Now;
                        sip.sip_lastup_user = 1;
                        sip.sip_lastup_date = DateTime.Now;
                        sip.sip_special1 = "";
                        sip.sip_special2 = "ES";
                        sip.sip_special3 = "";
                        sip.sip_firmano = 0;
                        sip.sip_subeno = 0;
                        sip.sip_tarih = Convert.ToDateTime(model.Tarih);
                        sip.sip_teslim_tarih = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                        sip.sip_tip = 0;
                        sip.sip_cins = 0;
                        sip.sip_evrakno_seri = this.GeneralSettingData().DocSeri;
                        sip.sip_evrakno_sira = GetEvrakNoSira();
                        sip.sip_satirno = count;
                        sip.sip_belgeno = "";
                        sip.sip_belge_tarih = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                        sip.sip_satici_kod = "";
                        sip.sip_musteri_kod = model.CariKod;
                        sip.sip_stok_kod = item.stoklar.sto_kod;

                        sip.sip_b_fiyat = item.BirimFiyat;

                        sip.sip_miktar = item.Quantity;
                        sip.sip_birim_pntr = 1;
                        sip.sip_teslim_miktar = 0;
                        sip.sip_tutar = item.Quantity * item.BirimFiyat;
                        sip.sip_iskonto1 = 0;
                        sip.sip_iskonto2 = 0;
                        sip.sip_iskonto3 = 0;
                        sip.sip_iskonto4 = 0;
                        sip.sip_iskonto5 = 0;
                        sip.sip_iskonto6 = 0;
                        sip.sip_iskonto_1 = 0;
                        sip.sip_iskonto_2 = 0;
                        sip.sip_iskonto_3 = 0;
                        sip.sip_iskonto_4 = 0;
                        sip.sip_iskonto_5 = 0;
                        sip.sip_iskonto_6 = 0;
                        sip.sip_masraf_1 = 0;
                        sip.sip_masraf_2 = 0;
                        sip.sip_masraf_3 = 0;
                        sip.sip_masraf_4 = 0;
                        sip.sip_vergi_pntr = 4;
                        sip.sip_vergi = 0;
                        sip.sip_masvergi = 0;
                        sip.sip_masvergi_pntr = 0;
                        sip.sip_masvergi = 0;
                        sip.sip_opno = 0;
                        sip.sip_aciklama = "";
                        sip.sip_aciklama2 = "";
                        sip.sip_depono = 1;
                        sip.sip_OnaylayanKulNo = 0;
                        sip.sip_vergisiz_fl = false;
                        sip.sip_kapat_fl = false;
                        sip.sip_promosyon_fl = false;
                        sip.sip_cari_sormerk = "";
                        sip.sip_stok_sormerk = "";
                        sip.sip_cari_grupno = 0;
                        sip.sip_doviz_cinsi = 0;
                        sip.sip_doviz_kuru = 1;
                        sip.sip_alt_doviz_kuru = 1;
                        sip.sip_adresno = 1;
                        sip.sip_teslimturu = "";
                        sip.sip_cagrilabilir_fl = true;
                        sip.sip_prosiprecDbId = 0;
                        sip.sip_prosiprecrecI = 0;
                        sip.sip_iskonto1 = 0;
                        sip.sip_iskonto2 = 1;
                        sip.sip_iskonto3 = 1;
                        sip.sip_iskonto4 = 1;
                        sip.sip_iskonto5 = 1;
                        sip.sip_iskonto6 = 1;
                        sip.sip_masraf1 = 1;
                        sip.sip_masraf2 = 1;
                        sip.sip_masraf3 = 1;
                        sip.sip_masraf4 = 1;
                        sip.sip_isk1 = false;
                        sip.sip_isk2 = false;
                        sip.sip_isk3 = false;
                        sip.sip_isk4 = false;
                        sip.sip_isk5 = false;
                        sip.sip_isk6 = false;
                        sip.sip_mas1 = false;
                        sip.sip_mas2 = false;
                        sip.sip_mas3 = false;
                        sip.sip_mas4 = false;
                        sip.sip_Exp_Imp_Kodu = "";
                        sip.sip_kar_orani = 0;
                        sip.sip_durumu = 0;
                        sip.sip_stalRecId_DBCno = 0;
                        sip.sip_stalRecId_RECno = 0;
                        sip.sip_planlananmiktar = 0;
                        sip.sip_teklifRecId_DBCno = 0;
                        sip.sip_teklifRecId_RECno = 0;
                        sip.sip_parti_kodu = "";
                        sip.sip_lot_no = 0;
                        sip.sip_projekodu = "";
                        sip.sip_fiyat_liste_no = 0;
                        sip.sip_Otv_Pntr = 0;
                        sip.sip_Otv_Vergi = 0;
                        sip.sip_otvtutari = 0;
                        sip.sip_OtvVergisiz_Fl = 0;
                        sip.sip_paket_kod = "";
                        sip.sip_RezRecId_DBCno = 0;
                        sip.sip_RezRecId_RECno = 0;
                        sip.sip_harekettipi = 0;
                        sip.sip_yetkili_recid_dbcno = 0;

                        sip.sip_yetkili_recid_recno = 0;
                        sip.sip_kapatmanedenkod = "";
                        sip.sip_gecerlilik_tarihi = Convert.ToDateTime("1899-12-30 00:00:00.000");
                        sip.sip_onodeme_evrak_tip = 0;
                        sip.sip_onodeme_evrak_seri = "";
                        sip.sip_onodeme_evrak_sira = 0;
                        sip.sip_rezervasyon_miktari = 0;
                        sip.sip_rezerveden_teslim_edilen = 0;
                        count++;
                        durum = _siparisORM.Insert(sip);

                    }
                    Session["EvrakSeri"] = null;
                    Session["ActiveOrder"] = null;
                    if (durum)
                    {
                        Success("Kayıt işlemi başarılı");
                        return Json("1", JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        Warning("Kayıt işlemi başarısız");
                        return Json("1", JsonRequestBehavior.AllowGet);
                    }
                }

            }
            return View(model);
        }

        [HttpPost]
        public ActionResult DeleteOrder(int Id)
        {
            
            bool result=_siparisORM.Delete("DELETE FROM SIPARISLER where sip_RECno="+Id);
            if (result)
            {
                return Json("1");
            }
            else
            {
                return Json("-1");
            }
           
        }
        private int? GetEvrakNoSira()
        {

            int? sira = 1;
            var data = _siparisORM.GetList("select top 1 sip_evrakno_sira from SIPARISLER where sip_evrakno_seri='" + this.GeneralSettingData().DocSeri + "' order by sip_evrakno_sira desc").FirstOrDefault();


            if (Session["EvrakSeri"] == null)
            {
                if (data == null)
                {
                    Session["EvrakSeri"] = "EvrakSeri";
                    return sira;
                }
                else
                {
                    sira = data.sip_evrakno_sira + 1;
                    Session["EvrakSeri"] = "EvrakSeri";
                    return sira;
                }

            }
            else
            {
                return data.sip_evrakno_sira++;
            }
        }

        [HttpPost]
        public ActionResult AddBasketOrder(string stokkod,int miktar)
        {
            var stok = _stoklarORM.GetList("select * from STOKLAR where sto_kod='" + stokkod + "'").FirstOrDefault();
            StockItem item = new StockItem();
            var fiyat = _stoksatisFiyatORM.GetList().FirstOrDefault(x => x.sfiyat_stokkod == stok.sto_kod);
            if (fiyat != null)
            {
                item.BirimFiyat = fiyat.sfiyat_fiyati ?? 0;
            }
            else
            {
                item.BirimFiyat = 0;
            }
            item.Quantity = miktar;
            item.stoklar = stok;
            OrderBasket.ActiveOrder.OrderAdd(item);
            var data = OrderBasket.ActiveOrder._Items;
            return Json("1");
        }
        [HttpPost]
        public PartialViewResult GetOrderBasketList()
        {
            var model = new OrderViewModel();
            List<OrderBasketListViewModel> list = new List<OrderBasketListViewModel>();
            foreach (var item in OrderBasket.ActiveOrder._Items)
            {
                OrderBasketListViewModel bas = new OrderBasketListViewModel();
                bas.Aciklama = "";
                bas.Birim = item.stoklar.sto_birim1_ad;
                bas.BirimFiyat = item.BirimFiyat;
                bas.Miktar = item.Quantity;
                bas.Id = item.stoklar.sto_RECno;
                bas.StokAd = item.stoklar.sto_isim;
                bas.StokKod = item.stoklar.sto_kod;
                bas.Tutar = item.Quantity * bas.BirimFiyat;
                list.Add(bas);
            }
            model.OrderBasketList = list;
            return PartialView("_basketorderlist", model);
        }

        [HttpPost]
        public ActionResult OrderDeleteRow(string stokkod)
        {
            var stok = _stoklarORM.GetList("select * from STOKLAR where sto_kod='" + stokkod + "'").FirstOrDefault();
            StockItem item = new StockItem();
            item.stoklar = stok;
            OrderBasket.ActiveOrder.OrderRemove(item);
            var data = OrderBasket.ActiveOrder._Items;
            return Json("1");
        }
    }
}