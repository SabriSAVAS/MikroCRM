using MikroCrm.MikroEntity;
using MikroCrm.UI.ViewModel.CustomerCrmModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using MikroCrm.MikroEntity.myeData;

namespace MikroCrm.UI.Controllers
{
    public class CustomerCrmController : BaseController
    {
        // GET: CustomerCrm
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
            var model = new CrmCustomerSearchViewModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult List(CrmCustomerSearchViewModel model)
        {
            int pageindex = model.Page ?? 1;
            string sql = "Select msg_S_0088 as Id,msg_S_0200 as CariKod,msg_S_0390 as CariUnvan,msg_S_0602 as YetkiliAdSoyad,msg_S_0501 as PersonelKod,msg_S_0502 as PersonelAdSoyad,msg_S_0264 as BasTarih,msg_S_0476 as BasSaat,msg_S_0265 as BitTarih,msg_S_0477 as BitSaat,msg_S_0598 as Sure,msg_S_0595 as Tip,msg_S_0596 as Yer,msg_S_0597 as Konu,msg_S_1156 as Oncelik FROM dbo.fn_Cariiliskicarifoyu (N'" + model.CariKod + "','" + model.startDate + "','" + model.endDate + "',0)";
            var data = _iliskilerViewORM.GetList(sql);
            List<CrmCustomerMovListViewModel> list = new List<CrmCustomerMovListViewModel>();
            foreach (var item in data)
            {
                CrmCustomerMovListViewModel cus = new CrmCustomerMovListViewModel();
                cus.BasSaat = item.BasSaat;
                cus.BasTarih = item.BasTarih;
                cus.BitSaat = item.BitSaat;
                cus.BitTarih = item.BitTarih;
                cus.CariKod = item.CariKod;
                cus.CariUnvan = item.CariUnvan;
                cus.Id = item.Id;
                cus.Konu = item.Konu;
                cus.Oncelik = item.Oncelik;
                cus.PersonelAdSoyad = item.PersonelAdSoyad;
                cus.PersonelKod = item.PersonelKod;
                cus.Sure = item.Sure;
                cus.Tip = item.Tip;
                cus.Yer = item.Yer;
                cus.YetkiliAdSoyad = item.YetkiliAdSoyad;
                list.Add(cus);
            }
            model.CustomerMovList = list.ToPagedList(pageindex, 5);
            if (Request.IsAjaxRequest())
            {
                return PartialView("_customermovlist", model);
            }
            return View(model);
        }
        public ActionResult AddCrm()
        {
            var model = new CrmCustomerViewModel();
            model.il_sorumlu_personelList = GetsorumluPersonel();
            return View(model);
        }

        private List<SelectListItem> GetsorumluPersonel()
        {
            var data = _caripersonelTanimORM.GetList().Select(x => new SelectListItem { Text = x.cari_per_adi, Value = x.cari_per_kod }).ToList();
            return data;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCrm(CrmCustomerViewModel model)
        {
            if (ModelState.IsValid)
            {

                if (_carihesaplarORM.carihesapvarmı(model.il_carikodu))
                {
                    return Json("Böyle bir cari hesap bulunmadı");
                }
                else
                {
                    ILISKILER il = new ILISKILER();

                    il.il_RECid_DBCno = model.il_RECid_DBCno;
                    il.il_RECid_RECno = model.il_RECid_DBCno;
                    il.il_SpecRECno = model.il_RECid_DBCno;
                    il.il_iptal = model.il_iptal;
                    il.il_fileid = model.il_fileid;
                    il.il_hidden = model.il_hidden;
                    il.il_kilitli = model.il_kilitli;
                    il.il_degisti = model.il_degisti;
                    il.il_checksum = model.il_checksum;
                    il.il_create_user = model.il_create_user;
                    il.il_create_date = model.il_create_date;
                    il.il_lastup_user = model.il_RECid_DBCno;
                    il.il_lastup_date = model.il_lastup_date;
                    il.il_special1 = model.il_special1;
                    il.il_special2 = model.il_special2;
                    il.il_special3 = model.il_special3;
                    il.il_baszaman = Convert.ToDateTime(model.il_baszaman + " " + model.il_bassaati);
                    il.il_bitzaman = Convert.ToDateTime(model.il_bitzaman + " " + model.il_bitsaati);
                    il.il_sorumlu_personel = model.il_sorumlu_personel;
                    il.il_iliski_tipi = model.il_iliski_tipi;
                    il.il_carikodu = model.il_carikodu;
                    il.il_adres_no = model.il_adres_no;
                    il.il_yetkiliRecID_DBCno = model.il_yetkiliRecID_DBCno;
                    il.il_yetkiliRecID_RECno = model.il_yetkiliRecID_RECno;
                    il.il_yetkiliadi = model.il_yetkiliadi;
                    il.il_yer = model.il_yer;
                    il.il_konu = model.il_konu;
                    il.il_refno = model.il_refno;
                    il.il_projekodu = model.il_projekodu;
                    il.il_oncelik = model.il_oncelik;
                    il.il_cari_tipi = model.il_cari_tipi;
                    if (_iliskiORM.Insert(il))
                    {
                        Success("Kayit işlemi başarılı.");
                        var getLastId = _iliskiORM.GetList("Select * From ILISKILER where il_carikodu='" + model.il_carikodu + "'  order by il_RECno desc ").FirstOrDefault();
                        if (getLastId != null)
                        {
                            mye_TextData dt = new mye_TextData();
                            dt.TableID = 154;
                            dt.RecID_DBCno = 0;
                            dt.RecID_RECno = getLastId.il_RECno;
                            dt.Data = model.Aciklama;
                            _myeTextDataOrm.Insert(dt);
                        }

                        return Json("1");
                    }
                    else
                    {

                        Danger("Kayit işlemi başarısiz.");
                        return Json("1");
                    }
                }
            }
            model.il_sorumlu_personelList = GetsorumluPersonel();
            return View(model);
        }
        public ActionResult CustomerAutList(string carikod)
        {

            var data = _carihesapYetkiliORM.GetList("Select * from CARI_HESAP_YETKILILERI where mye_cari_kod like '%" + carikod + "%'").ToList();
            List<CustomerAutListViewModel> list = new List<CustomerAutListViewModel>();
            foreach (var item in data)
            {
                CustomerAutListViewModel cus = new CustomerAutListViewModel();
                cus.Id = item.mye_RECno;
                cus.YetkiliAd = item.mye_isim;
                cus.YetkiliSoyad = item.mye_soyisim;
                list.Add(cus);
            }
            if (Request.IsAjaxRequest())
            {
                return PartialView("_autList", list);
            }
            return PartialView("_CustomerAutList", list);
        }
        [HttpPost]
        public ActionResult DeleteCrm(int Id)
        {

            var result = _iliskiORM.Delete("Delete from ILISKILER where il_RECno='" + Id + "'");
            if (result)
            {
                return Json("1");
            }
            else
            {
                return Json("-1");
            }

        }

        public PartialViewResult AddAutCrm()
        {
            var model = new CustomerAutAddViewModel();

            return PartialView("_CustomerAutAdd", model);
        }
        [HttpPost]
        public ActionResult AddAutCrm(CustomerAutAddViewModel model)
        {


            if (_carihesaplarORM.carihesapvarmı(model.mye_cari_kod))
            {
                return Json("Böyle bir cari hesap bulunmadı");
            }
            else
            {
                var customeraut = new CARI_HESAP_YETKILILERI();
                customeraut.mye_isim = model.mye_isim;
                customeraut.mye_soyisim = model.mye_soyisim;
                customeraut.mye_adres_no = 1;
                customeraut.mye_cari_kod = model.mye_cari_kod;


                if (_carihesapYetkiliORM.Insert(customeraut))
                    return Json("1");
                else
                    return Json("-1");
            }
        }




      
    }
}