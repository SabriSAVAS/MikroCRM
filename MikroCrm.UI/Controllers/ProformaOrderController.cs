using MikroCrm.UI.ViewModel.ProformaOrderModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using MikroCrm.UI.HelperBasket;
using MikroCrm.MikroEntity.ProformaSiparis;
using MikroCrm.MikroEntity;
using MikroCrm.UI.ViewModel.ProformaOrderModel.PrintModel;
using System.Globalization;
namespace MikroCrm.UI.Controllers
{
    public class ProformaOrderController : BaseController
    {
        // GET: ProformaOrder
        public ActionResult Index()
        {
            return RedirectToAction("List");
            //s.pro_kapat
        }
        public ActionResult List(ProformaOrderSearchViewModel model)
        {
            int pageIndex = model.Page ?? 1;
            model.DurumList.Add(new SelectListItem { Text = "Açık", Value = "Acık" });
            model.DurumList.Add(new SelectListItem { Text = "Kapalı", Value = "Kapalı" });

            string sql = "select MIN( s.pro_RECno) as Id ,MIN(s.pro_tarihi) as Tarih ,(s.pro_evrakno_seri +'-'+ CONVERT(nvarchar,s.pro_evrakno_sira)) as EvrakSeri , s.pro_saticikodu as SaticiKod ,cp.cari_per_adi  as SaticiAd ,s.pro_mustkodu as MusteriKod ,ch.cari_unvan1 as MusteriUnvan ,case s.pro_kapat  when '1' then 'Kapalı' else 'Acık'  end as Durum ,s.pro_aciklama as Aciklama ,s.pro_aciklama2 as Aciklama2 from PROFORMA_SIPARISLER s  left join CARI_HESAPLAR ch on s.pro_mustkodu=ch.cari_kod left join CARI_PERSONEL_TANIMLARI cp on s.pro_saticikodu=cp.cari_per_kod where (s.pro_special1='ES' or s.pro_special1='EM' or s.pro_special1='TS' or s.pro_special1='YS') and s.pro_mustkodu like '%" + model.CariKod + "%' and s.pro_saticikodu like '%" + model.TekniksyenAd + "%' and s.pro_tarihi  between '" + model.startDate + "' and '" + model.endDate + "' group by s.pro_evrakno_seri,s.pro_evrakno_sira,s.pro_saticikodu,cp.cari_per_adi,s.pro_mustkodu,ch.cari_unvan1,s.pro_kapat,s.pro_tarihi,s.pro_aciklama,s.pro_aciklama2  order by s.pro_tarihi desc";

            var profromaorders = _viewproformaSiparisORM.GetList(sql).Where(x => string.IsNullOrEmpty(model.Durum) || x.Durum.Trim().ToLower() == model.Durum.Trim().ToLower());
            model.TekniksyenAdList = GetTekniksyen();
            List<ProformaOrderListViewModel> list = new List<ProformaOrderListViewModel>();
            foreach (var item in profromaorders)
            {
                ProformaOrderListViewModel _pro = new ProformaOrderListViewModel();
                _pro.Aciklama = item.Aciklama.ToLower();
                _pro.Aciklama2 = item.Aciklama2.ToLower();
                _pro.EvrakSeri = item.EvrakSeri;
                _pro.Id = item.Id;
                _pro.MusteriKod = item.MusteriKod;
                _pro.MusteriUnvan = item.MusteriUnvan;
                _pro.SaticiAd = item.SaticiAd;
                _pro.SaticiKod = item.SaticiKod;
                _pro.Tarih = item.Tarih;
                _pro.Durum = item.Durum;
                list.Add(_pro);
            }

            model.OrderList = list.OrderByDescending(x => x.Tarih).ToPagedList(pageIndex, 10);
            if (Request.IsAjaxRequest())
            {
                return PartialView("_proformaorderList", model);
            }
            return View(model);
        }


        public ActionResult AddOrder()
        {
            var model = new ProformaOrderViewModel();
            List<ProformaOrderBasketListViewModel> list = new List<ProformaOrderBasketListViewModel>();
            foreach (var item in HizmetOrderBasket.ActiveOrder.items)
            {
                ProformaOrderBasketListViewModel bas = new ProformaOrderBasketListViewModel();
                bas.HizmetAd = item.HizmetAd;
                bas.HizmetTip = item.HizmetTip;
                bas.Special = item.Special;
                bas.HizmetKod = item.HizmetKod;

                list.Add(bas);
            }


            if (getIp().ToString().Equals("85.97.119.161"))
            {
                model.EvrakSeri = "TS";
            }
        
            else
            {
                model.EvrakSeri = "YS";//""this.GeneralSettingData().DocSeri;

            }
           
            model.EvrakSira = GetEvrakNo(model.EvrakSeri).Value;
            model.TekniksyenList = GetTekniksyen();
            model.ProformaOrderList = list;
            return View(model);
        }
        private string getIp()
        {
            string ipaddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (ipaddress == "" || ipaddress == null)
                return ipaddress = Request.ServerVariables["REMOTE_ADDR"];
            else
                return "";
        }
        private List<SelectListItem> GetTekniksyen()
        {
            var data = _caripersonelTanimORM.GetList().Select(x => new SelectListItem { Text = x.cari_per_adi, Value = x.cari_per_kod });
            return data.ToList();
        }

        [HttpPost]
        public ActionResult AddOrder(ProformaOrderViewModel model)
        {

            if (ModelState.IsValid)
            {
                if (HizmetOrderBasket.ActiveOrder.items.Count > 0)
                {

                    bool durum = false;
                    int count = 0;
                    foreach (var item in HizmetOrderBasket.ActiveOrder.items)
                    {
                        PROFORMA_SIPARISLER p = new PROFORMA_SIPARISLER();
                        p.pro_RECid_DBCno = 0;
                        p.pro_RECid_RECno = 0;
                        p.pro_SpecRecNo = 0;
                        p.pro_iptal = false;
                        p.pro_fileid = 22;
                        p.pro_hidden = false;
                        p.pro_kilitli = false;
                        p.pro_degisti = false;
                        p.pro_checksum = 0;
                        p.pro_create_user = 7;
                        p.pro_create_date = DateTime.Now;
                        p.pro_lastup_date = DateTime.Now;
                        p.pro_lastup_user = 7;
                        p.pro_firmano = 0;
                        p.pro_subeno = 0;
                        p.pro_tarihi = model.Tarih;
                        p.pro_testarihi = model.Tarih;
                        p.pro_tipi = 0;
                        p.pro_cinsi = 2;
                        p.pro_evrakno_seri = model.EvrakSeri;
                        p.pro_evrakno_sira = model.EvrakSira;
                        p.pro_satirno = count;
                        p.pro_belge_tarihi = model.Tarih;
                        p.pro_saticikodu = model.TekniksyenKod;
                        p.pro_mustkodu = model.CariKod;
                        p.pro_stokkodu = item.HizmetKod;
                        if (item.HizmetTip == "Hizmet")
                        {
                            string Aciklama1 = model.Aciklama1;
                            if (!string.IsNullOrEmpty(Aciklama1))
                            {
                                if (Aciklama1.Length >= 50)
                                {
                                    string subAciklama = Aciklama1.Substring(0, 49);
                                    Aciklama1 = subAciklama;
                                }

                            }
                            else
                            {
                                Aciklama1 = "";
                            }
                            p.pro_aciklama = Aciklama1;
                        }
                        else
                        {
                            p.pro_aciklama = "";
                        }
                        if (item.HizmetTip == "Hizmet")
                        {
                            p.pro_aciklama2 = GetAciklama(model) + " = " + GetSaat(model);
                        }
                        else
                        {
                            p.pro_aciklama2 = "";
                        }
                        p.pro_depono = 1;
                        if (item.HizmetTip == "Hizmet")
                        {
                            p.pro_harekettipi = 1;
                        }
                        else
                        {
                            p.pro_harekettipi = 0;
                        }

                        if (item.HizmetTip == "Hizmet")
                        {
                            p.pro_special1 = item.Special;
                        }
                        else
                        {
                            p.pro_special1 = "";
                        }
                        p.pro_special2 = "";
                        p.pro_special3 = "";
                        p.pro_belge_no = "";
                        p.pro_iskonto1 = 0;
                        p.pro_iskonto2 = 0;
                        p.pro_iskonto3 = 0;
                        p.pro_iskonto4 = 0;
                        p.pro_iskonto5 = 0;
                        p.pro_iskonto6 = 0;
                        p.pro_masraf1 = 0;
                        p.pro_masraf2 = 0;
                        p.pro_masraf3 = 0;
                        p.pro_masraf4 = 0;
                        p.pro_vergipntr = 1;
                        p.pro_vergi = 0;
                        p.pro_masrafvergi = 0;
                        p.pro_masrafvergipntr = 0;
                        p.pro_opno = 0;
                        p.pro_onaylayanKul_no = 0;
                        p.pro_vergisiz = false;
                        p.pro_kapat = false;
                        p.pro_promosyon_fl = false;
                        p.pro_cari_grupno = 0;
                        p.pro_dovizcinsi = 0;
                        p.pro_dovizkuru = 1;
                        p.pro_altdovizkuru = 0;
                        p.pro_adresno = 1;
                        p.pro_teslimturu = "";
                        p.pro_cagrilabilir_fl = true;
                        p.pro_sipDbID = 0;
                        p.pro_sipRecID = 0;
                        p.pro_isk_mas_1 = 0;
                        p.pro_isk_mas_2 = 1;
                        p.pro_isk_mas_3 = 1;
                        p.pro_isk_mas_4 = 1;
                        p.pro_isk_mas_5 = 1;
                        p.pro_isk_mas_6 = 1;
                        p.pro_isk_mas_7 = 1;
                        p.pro_isk_mas_8 = 1;
                        p.pro_isk_mas_9 = 1;
                        p.pro_isk_mas_10 = 1;
                        p.pro_sat_isk_mas1 = false;
                        p.pro_sat_isk_mas2 = false;
                        p.pro_sat_isk_mas3 = false;
                        p.pro_sat_isk_mas4 = false;
                        p.pro_sat_isk_mas5 = false;
                        p.pro_sat_isk_mas6 = false;
                        p.pro_sat_isk_mas7 = false;
                        p.pro_sat_isk_mas8 = false;
                        p.pro_sat_isk_mas9 = false;
                        p.pro_sat_isk_mas10 = false;
                        p.pro_Exp_Imp_Kodu = "";
                        p.pro_karoani = 0;
                        p.pro_durumu = 0;
                        p.pro_stalRecId_DBCno = 0;
                        p.pro_stalRecId_RECno = 0;
                        p.pro_planlananmiktar = 0;
                        p.pro_teklifRecId_DBCno = 0;
                        p.pro_teklifRecId_RECno = 0;
                        p.pro_parti_kodu = "";
                        p.pro_lot_no = 0;
                        p.pro_fiyat_liste_no = 0;
                        p.pro_Otv_Pntr = 0;
                        p.pro_Otv_Vergi = 0;
                        p.pro_otvtutari = 0;
                        p.pro_OtvVergisiz_Fl = 0;
                        p.pro_paket_kod = "";
                        p.pro_RezRecId_DBCno = 0;
                        p.pro_RezRecId_RECno = 0;
                        p.pro_yetkili_recid_dbcno = 0;
                        p.pro_yetkili_recid_recno = 0;
                        p.pro_kapatmanedenkod = "";
                        p.pro_gecerlilik_tarihi = DateTime.Now;
                        p.pro_onodeme_evrak_seri = "";
                        p.pro_onodeme_evrak_sira = 0;
                        p.pro_onodeme_evrak_tip = 0;
                        p.pro_rezervasyon_miktari = 0;
                        p.pro_rezerveden_teslim_edilen = 0;

                        if (item.HizmetTip == "Hizmet")
                        {
                            p.pro_miktar = GetMiktar(model);
                        }
                        else
                        {

                            p.pro_miktar = 1;

                        }
                        p.pro_birim_pntr = 0;
                        p.pro_tesmiktari = 0;
                        p.pro_bfiyati = 0;
                        p.pro_tutari = 0;
                        p.pro_cari_sormerk = "";
                        p.pro_projekodu = "";
                        p.pro_stok_sormerk = "";
                        durum = _proformaSiparisORM.Insert(p);
                        count++;
                    }
                    Session["EvrakSeri"] = null;
                    Session["ProformaOrder"] = null;
                    if (durum)
                    {
                        PROFORMA_SIPARISLER pro = _proformaSiparisORM.GetList("select top 1 * from PROFORMA_SIPARISLER order by pro_RECno desc").FirstOrDefault();
                        if (pro != null)
                        {
                            insertEvrakAciklamsi(pro.pro_evrakno_seri, pro.pro_evrakno_sira, model.Aciklama1, model.Aciklama2, model.Aciklama3, model.Aciklama4, model.Aciklama5);
                        }
                        Success("Kayit işlemi başarılı");
                        return Json("1");
                    }
                    else
                    {
                        Warning("Kayit işlemi başarısız");
                        return Json("1");
                    }
                }
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult DeleteOrder(int id)
        {
            bool result = false;
            PROFORMA_SIPARISLER pro = _proformaSiparisORM.GetList("select * from PROFORMA_SIPARISLER where pro_RECno='" + id + "'").FirstOrDefault();
            if (pro != null)
            {


                result = _proformaSiparisORM.Delete("Delete from PROFORMA_SIPARISLER where pro_evrakno_seri='" + pro.pro_evrakno_seri + "' and pro_evrakno_sira='" + pro.pro_evrakno_sira + "'");

                _evrakAciklamaORM.Delete("Delete from EVRAK_ACIKLAMALARI where egk_evr_seri='" + pro.pro_evrakno_seri + "' and egk_evr_sira='" + pro.pro_evrakno_sira + "'");

                if (result)
                {
                    return Json("1");
                }
                else { return Json("-1"); }
            }
            else
            {
                return Json("");
            }
        }

        private void insertEvrakAciklamsi(string EvrakSeri, int? EvrakSira, string aciklama = "", string aciklama1 = "", string aciklama2 = "", string aciklama3 = "", string aciklama4 = "")
        {

            EVRAK_ACIKLAMALARI _ac = new EVRAK_ACIKLAMALARI();
            _ac.egk_RECid_DBCno = 0;
            _ac.egk_RECid_RECno = 999999;
            _ac.egk_SpecRECno = 0;
            _ac.egk_iptal = false;
            _ac.egk_fileid = 66;
            _ac.egk_hidden = false;
            _ac.egk_kilitli = false;
            _ac.egk_degisti = false;
            _ac.egk_checksum = 0;
            _ac.egk_create_user = 10;
            _ac.egk_create_date = DateTime.Now;
            _ac.egk_lastup_user = 10;
            _ac.egk_lastup_date = DateTime.Now;
            _ac.egk_special1 = "SRK";
            _ac.egk_special2 = "";
            _ac.egk_special3 = "";
            _ac.egk_dosyano = 22;
            _ac.egk_hareket_tip = 0;
            _ac.egk_evr_tip = 2;
            _ac.egk_evr_seri = EvrakSeri;
            _ac.egk_evr_sira = EvrakSira;
            _ac.egk_evr_ustkod = "";
            _ac.egk_evr_doksayisi = 0;
            _ac.egk_evracik1 = aciklama;
            _ac.egk_evracik2 = aciklama1;
            _ac.egk_evracik3 = aciklama2;
            _ac.egk_evracik4 = aciklama3;
            _ac.egk_evracik5 = aciklama4;
            _ac.egk_evracik6 = "";
            _ac.egk_evracik7 = "";
            _ac.egk_evracik8 = "";
            _ac.egk_evracik9 = "";
            _ac.egk_evracik10 = "";
            _ac.egk_sipgenkarorani = 0;
            _ac.egk_kargokodu = "";
            _ac.egk_kargono = "";
            _ac.egk_tesaltarihi = Convert.ToDateTime("1899-12-30 00:00:00.000");
            _ac.egk_tesalkisi = "";
            _ac.egk_prevwiewsayisi = 0;
            _ac.egk_emailsayisi = 0;
            _ac.egk_Evrakopno_verildi_fl = false;
            _evrakAciklamaORM.Insert(_ac);

        }

        private string GetAciklama(ProformaOrderViewModel model)
        {
            DateTime bas = Convert.ToDateTime(model.BasSaati);
            DateTime bit = Convert.ToDateTime(model.BitSaati);
            TimeSpan fark = Convert.ToDateTime(bit) - Convert.ToDateTime(bas);
            string breandcup = Convert.ToString(fark.Hours + " saat " + fark.Minutes + " dk");

            return breandcup;
        }
        private string GetSaat(ProformaOrderViewModel model)
        {
            DateTime bas = Convert.ToDateTime(model.BasSaati);
            DateTime bit = Convert.ToDateTime(model.BitSaati);

            string breandcup = bas.ToShortTimeString() + " - " + bit.ToShortTimeString();

            return breandcup;
        }

        private double? GetMiktar(ProformaOrderViewModel model)
        {
            DateTime bas = Convert.ToDateTime(model.BasSaati);
            DateTime bit = Convert.ToDateTime(model.BitSaati);
            TimeSpan fark = Convert.ToDateTime(bit) - Convert.ToDateTime(bas);
            string breandcup = Convert.ToString(fark.TotalHours);
            double miktar = Convert.ToDouble(breandcup);
            return Convert.ToDouble(miktar);
        }

        private int? GetEvrakNo(string evraknoseri)
        {
            int? sira = 1;

            //var data = _proformaSiparisORM.GetList("select top 1 pro_evrakno_sira from PROFORMA_SIPARISLER where pro_evrakno_seri='" + this.GeneralSettingData().DocSeri + "' order by pro_evrakno_sira desc").FirstOrDefault();

            var data = _proformaSiparisORM.GetList("select top 1 pro_evrakno_sira from PROFORMA_SIPARISLER where pro_evrakno_seri='" + evraknoseri + "' order by pro_evrakno_sira desc").FirstOrDefault();

            if (data == null)
            {

                return sira;
            }
            else
            {
                sira = data.pro_evrakno_sira + 1;

                return sira;
            }



            //int? sira = 1;
            //var data = _proformaSiparisORM.GetList("select top 1 pro_evrakno_sira from PROFORMA_SIPARISLER where pro_evrakno_seri='" + this.GeneralSettingData().DocSeri + "' order by pro_evrakno_sira desc").FirstOrDefault();


            //if (Session["EvrakSeri"] == null)
            //{
            //    if (data == null)
            //    {
            //        Session["EvrakSeri"] = "EvrakSeri";
            //        return sira;
            //    }
            //    else
            //    {
            //        sira = data.pro_evrakno_sira + 1;
            //        Session["EvrakSeri"] = "EvrakSeri";
            //        return sira;
            //    }

            //}
            //else
            //{
            //    return data.pro_evrakno_sira++;
            //}
        }
        [HttpPost]
        public JsonResult GetEvrakSiraNo(string evrakseri)
        {
            int? sira = 1;
            var data = _proformaSiparisORM.GetList("select top 1 pro_evrakno_sira from PROFORMA_SIPARISLER where pro_evrakno_seri='" + evrakseri + "' order by pro_evrakno_sira desc").FirstOrDefault();
            if (data == null)
            {
                return Json(sira, JsonRequestBehavior.AllowGet);
            }
            else
            {
                sira = data.pro_evrakno_sira + 1;
                return Json(sira, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult AddBasketOrder(string special, string hizmettip, string hizmetkod, string hizmetad)
        {
            HizmetItem item = new HizmetItem();
            item.Special = special;
            item.HizmetTip = hizmettip;
            item.HizmetKod = hizmetkod;
            item.HizmetAd = hizmetad;
            HizmetOrderBasket.ActiveOrder.OrderAdd(item);
            //  var data = HizmetOrderBasket.ActiveOrder.items;
            return Json("1");
        }
        [HttpPost]
        public PartialViewResult GetOrderBasketList()
        {
            var model = new ProformaOrderViewModel();
            List<ProformaOrderBasketListViewModel> list = new List<ProformaOrderBasketListViewModel>();
            foreach (var item in HizmetOrderBasket.ActiveOrder.items)
            {
                ProformaOrderBasketListViewModel bas = new ProformaOrderBasketListViewModel();
                bas.HizmetAd = item.HizmetAd;
                bas.HizmetTip = item.HizmetTip;
                bas.Special = item.Special;
                bas.HizmetKod = item.HizmetKod;
                bas.Id++;
                list.Add(bas);
            }
            model.ProformaOrderList = list;
            return PartialView("_basketproformaorderlist", model);
        }

        [HttpPost]
        public ActionResult OrderDeleteRow(string stokkod)
        {

            HizmetItem item = new HizmetItem();
            item.HizmetKod = stokkod;
            HizmetOrderBasket.ActiveOrder.OrderRemove(item);
            var data = HizmetOrderBasket.ActiveOrder.items;
            return Json("1");
        }


        public ActionResult PrintService(int? id)
        {
            if (id == null || id == 0) { return RedirectToAction("List"); }
            var model = new PrintListViewModel();
            var prosip = _proformaSiparisORM.GetList("select * from PROFORMA_SIPARISLER where pro_RECno='" + id + "'").FirstOrDefault();
            if (prosip != null)
            {

                model.MusteriAd = _carihesaplarORM.GetList("select * from CARI_HESAPLAR where cari_kod='" + prosip.pro_mustkodu + "'").FirstOrDefault().cari_unvan1;
                model.MusteriKod = prosip.pro_mustkodu;
                var adres = _carihesapadresleriORM.GetList("select * from CARI_HESAP_ADRESLERI where adr_cari_kod='" + prosip.pro_mustkodu + "'").FirstOrDefault();
                if (adres != null)
                {
                    model.Adres = adres.adr_cadde;
                    model.il = adres.adr_il;
                    model.ilce = adres.adr_ilce;
                }
                string[] parcali = prosip.pro_aciklama2.Split('=');

                if (parcali.Length == 2)
                {
                    model.Saat = parcali[0].ToString();//prosip.pro_aciklama2;
                    model.BasBitSaat = parcali[1].ToString();
                }
                else
                {
                    model.Saat = parcali[0].ToString();
                }



                model.Tarih = prosip.pro_tarihi;
                model.EvrakNo = prosip.pro_evrakno_seri + " " + prosip.pro_evrakno_sira.ToString();
                List<PrintList> list = new List<PrintList>();

                var siparisler = _proformaSiparisORM.GetList("select * from PROFORMA_SIPARISLER where pro_evrakno_seri='" + prosip.pro_evrakno_seri + "' and pro_evrakno_sira='" + prosip.pro_evrakno_sira + "'");
                var aciklama = _evrakAciklamaORM.GetList("select top 1 * from EVRAK_ACIKLAMALARI where egk_evr_seri='" + prosip.pro_evrakno_seri + "' and egk_evr_sira='" + prosip.pro_evrakno_sira + "'").FirstOrDefault();
                if (siparisler.Count > 0)
                {
                    foreach (var item in siparisler)
                    {
                        PrintList print = new PrintList();

                        if (item.pro_harekettipi == 0)
                        {
                            print.HizmetAd = ToTitleCase(_stoklarORM.GetList("select * from STOKLAR where sto_kod='" + item.pro_stokkodu + "'").FirstOrDefault().sto_isim.ToLower());
                            print.HizmetTip = "Stok";
                        }
                        else
                        {
                            print.HizmetAd = ToTitleCase(_hizmethesaplarORM.GetList("select * from HIZMET_HESAPLARI where hiz_kod='" + item.pro_stokkodu + "'").FirstOrDefault().hiz_isim.ToLower().Trim());
                            print.HizmetKod = item.pro_stokkodu;
                            if (aciklama != null)
                            {
                                print.Aciklama = ToTitleCase(Convert.ToString(aciklama.egk_evracik1 + " " + aciklama.egk_evracik2 + " " + aciklama.egk_evracik3 + " " + aciklama.egk_evracik4 + " " + aciklama.egk_evracik5).Trim().ToLower());
                            }
                            print.HizmetTip = "Hizmet";

                        }
                        list.Add(print);
                    }
                }
                model.PrintList = list;
            }
            else
            {
                return RedirectToAction("List");
            }

            return View(model);
        }

        public static string ToTitleCase(string value)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value);
        }
    }
}