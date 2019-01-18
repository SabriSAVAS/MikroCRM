using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MikroCrm.UI.ViewModel.CustomerCrmModel
{
    public class CrmCustomerViewModel
    {
        public CrmCustomerViewModel()
        {
            this.il_iliski_tipiList = new List<SelectListItem>();

            il_iliski_tipiList.Add(new SelectListItem() { Text = "Telefon", Value = "0" });
            il_iliski_tipiList.Add(new SelectListItem { Text = "Elektronik Posta", Value = "1" });
            il_iliski_tipiList.Add(new SelectListItem { Text = "Fax", Value = "2" });
            il_iliski_tipiList.Add(new SelectListItem { Text = "Mektup", Value = "3" });
            il_iliski_tipiList.Add(new SelectListItem { Text = "Ziyaret", Value = "4" });
            il_iliski_tipiList.Add(new SelectListItem { Text = "Toplantı", Value = "5" });
            il_iliski_tipiList.Add(new SelectListItem { Text = "Seminer", Value = "6" });
            il_iliski_tipiList.Add(new SelectListItem { Text = "Karşılama", Value = "7" });
            il_iliski_tipiList.Add(new SelectListItem { Text = "Fuar", Value = "8" });
            il_iliski_tipiList.Add(new SelectListItem { Text = "Tebrik Kartı", Value = "9" });
            il_iliski_tipiList.Add(new SelectListItem { Text = "SMS Mesaj", Value = "10" });
            il_iliski_tipiList.Add(new SelectListItem { Text = "Diğer", Value = "11" });

            this.il_cari_tipiList = new List<SelectListItem>();
            il_cari_tipiList.Add(new SelectListItem { Text = "Cari ", Value = "0" });
            il_cari_tipiList.Add(new SelectListItem { Text = "Aday Cari ", Value = "1" });


            this.il_oncelikList = new List<SelectListItem>();
            il_oncelikList.Add(new SelectListItem { Text = "Cok Düşük ", Value = "0" });
            il_oncelikList.Add(new SelectListItem { Text = "Düşük ", Value = "1" });
            il_oncelikList.Add(new SelectListItem { Text = "Normal ", Value = "2" });
            il_oncelikList.Add(new SelectListItem { Text = "Yuksek ", Value = "3" });
            il_oncelikList.Add(new SelectListItem { Text = "Çok Yuksek ", Value = "4" });

            il_sorumlu_personelList = new List<SelectListItem>();

            il_baszaman = Convert.ToString(DateTime.Now.ToShortDateString());
            il_bitzaman = Convert.ToString(DateTime.Now.ToShortDateString());
            il_oncelik = 2;
            il_yetkiliRecID_DBCno = 0;
            //

            il_RECid_DBCno = 0;
            il_RECid_RECno = 200000;
            il_SpecRECno = 0;
            il_iptal = false;
            il_fileid = 154;
            il_hidden = false;
            il_kilitli = false;
            il_degisti = false;
            il_checksum = 0;
            il_create_user = 7;
            il_create_date = DateTime.Now;
            il_lastup_user = 7;
            il_lastup_date = DateTime.Now;
            il_special1 = "SRK";
            il_special2 = "";
            il_special3 = "";
            il_adres_no = 1;
            il_projekodu = "";
            il_yer = "";
            il_konu = "";
            il_refno = "";

            il_bassaatiList = GetSaat();
            il_bitsaatiList = GetSaat();

        }

        private List<SelectListItem> GetSaat()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem { Text = "09:00", Value = "09:00" });
            list.Add(new SelectListItem { Text = "09:15", Value = "09:15" });
            list.Add(new SelectListItem { Text = "09:30", Value = "09:30" });
            list.Add(new SelectListItem { Text = "09:45", Value = "09:45" });
            list.Add(new SelectListItem { Text = "10:00", Value = "10:00" });
            list.Add(new SelectListItem { Text = "10:15", Value = "10:15" });
            list.Add(new SelectListItem { Text = "10:30", Value = "10:30" });
            list.Add(new SelectListItem { Text = "10:45", Value = "10:45" });
            list.Add(new SelectListItem { Text = "11:00", Value = "11:00" });
            list.Add(new SelectListItem { Text = "11:15", Value = "11:15" });
            list.Add(new SelectListItem { Text = "11:30", Value = "11:30" });
            list.Add(new SelectListItem { Text = "11:45", Value = "11:45" });
            list.Add(new SelectListItem { Text = "12:00", Value = "12:00" });
            list.Add(new SelectListItem { Text = "12:15", Value = "12:15" });
            list.Add(new SelectListItem { Text = "12:30", Value = "12:30" });
            list.Add(new SelectListItem { Text = "12:45", Value = "12:45" });
            list.Add(new SelectListItem { Text = "13:00", Value = "13:30" });
            list.Add(new SelectListItem { Text = "13:15", Value = "13:15" });
            list.Add(new SelectListItem { Text = "13:30", Value = "13:30" });
            list.Add(new SelectListItem { Text = "13:45", Value = "13:45" });
            list.Add(new SelectListItem { Text = "14:00", Value = "14:00" });
            list.Add(new SelectListItem { Text = "14:15", Value = "14:15" });
            list.Add(new SelectListItem { Text = "14:30", Value = "14:30" });
            list.Add(new SelectListItem { Text = "14:45", Value = "14:45" });
            list.Add(new SelectListItem { Text = "15:00", Value = "15:00" });
            list.Add(new SelectListItem { Text = "15:15", Value = "15:15" });
            list.Add(new SelectListItem { Text = "15:30", Value = "15:30" });
            list.Add(new SelectListItem { Text = "15:45", Value = "15:45" });
            list.Add(new SelectListItem { Text = "16:00", Value = "16:00" });
            list.Add(new SelectListItem { Text = "16:15", Value = "16:15" });
            list.Add(new SelectListItem { Text = "16:30", Value = "16:30" });
            list.Add(new SelectListItem { Text = "16:45", Value = "16:45" });
            list.Add(new SelectListItem { Text = "17:00", Value = "17:00" });
            list.Add(new SelectListItem { Text = "17:15", Value = "17:15" });
            list.Add(new SelectListItem { Text = "17:30", Value = "17:30" });
            list.Add(new SelectListItem { Text = "17:45", Value = "17:45" });
            list.Add(new SelectListItem { Text = "18:00", Value = "18:00" });
            list.Add(new SelectListItem { Text = "18:15", Value = "18:15" });
            list.Add(new SelectListItem { Text = "18:45", Value = "18:45" });
            list.Add(new SelectListItem { Text = "19:00", Value = "19:00" });

            return list;
        }
        public int il_RECno { get; set; }
        public short il_RECid_DBCno { get; set; }
        public int il_RECid_RECno { get; set; }
        public Nullable<int> il_SpecRECno { get; set; }
        public Nullable<bool> il_iptal { get; set; }
        public Nullable<short> il_fileid { get; set; }
        public Nullable<bool> il_hidden { get; set; }
        public Nullable<bool> il_kilitli { get; set; }
        public Nullable<bool> il_degisti { get; set; }
        public Nullable<int> il_checksum { get; set; }
        public Nullable<short> il_create_user { get; set; }
        public Nullable<System.DateTime> il_create_date { get; set; }
        public Nullable<short> il_lastup_user { get; set; }
        public Nullable<System.DateTime> il_lastup_date { get; set; }
        public string il_special1 { get; set; }
        public string il_special2 { get; set; }
        public string il_special3 { get; set; }

        public string il_baszaman { get; set; }
        public string il_bitzaman { get; set; }
        public List<SelectListItem> il_bassaatiList { get; set; }
        [Required(ErrorMessage = "Saat Girişi Yapınız...")]
        public string il_bassaati { get; set; }
        public List<SelectListItem> il_bitsaatiList { get; set; }
        [Required(ErrorMessage = "Saat Girişi Yapınız...")]
        public string il_bitsaati { get; set; }
        public List<SelectListItem> il_sorumlu_personelList { get; set; }
        [Required(ErrorMessage = "Sorumlu personel seçiniz yapınız...")]
        public string il_sorumlu_personel { get; set; }
        public List<SelectListItem> il_iliski_tipiList { get; set; }
        public Nullable<byte> il_iliski_tipi { get; set; }
        [Required(ErrorMessage = "Cari kod girişi yapınız...")]
        public string il_carikodu { get; set; }
        public string il_cariunvani { get; set; }

        public Nullable<int> il_adres_no { get; set; }

        public Nullable<short> il_yetkiliRecID_DBCno { get; set; }
        [Required(ErrorMessage = "Yetkili kod girişi yapınız...")]
        public Nullable<int> il_yetkiliRecID_RECno { get; set; }
        [Required(ErrorMessage = "Yetkili adı girişi yapınız...")]
        public string il_yetkiliadi { get; set; }
        public string il_yer { get; set; }
        public string il_konu { get; set; }
        public string il_refno { get; set; }
        public string il_projekodu { get; set; }
        public List<SelectListItem> il_oncelikList { get; set; }
        public Nullable<byte> il_oncelik { get; set; }
        public List<SelectListItem> il_cari_tipiList { get; set; }
        public Nullable<byte> il_cari_tipi { get; set; }



        public string Aciklama { get; set; }
    }
}