using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikroCrm.MikroEntity
{
   public class CARI_HESAP_YETKILILERI
    {
        public CARI_HESAP_YETKILILERI()
        {
            mye_SpecRECno = 0;
            mye_RECid_DBCno = 0;
            mye_RECid_RECno = 99999;
            mye_iptal = false;
            mye_fileid = 22;
            mye_hidden = false;
            mye_kilitli = false;
            mye_degisti = false;
            mye_checksum = 0;
            mye_create_user = 7;
            mye_create_date = DateTime.Now;
            mye_lastup_date = DateTime.Now;
            mye_lastup_user = 7;
            mye_lastup_date = DateTime.Now;
            mye_special3 = "SRK";
            mye_adres_no = 0;
            mye_unvan = 0;
            mye_hitap = 0;
            mye_hisse = 0;
            mye_mutabakat_yetkilisi_fl = false;
            mye_special1 = "";
            mye_special2 = "";
            mye_dogum_tarihi = DateTime.Now;
            mye_es_dogum_tarihi = DateTime.Now;
            mye_evlilik_tarihi = DateTime.Now;
            mye_es_isim = "";
            mye_tahsil = 0;
            mye_dahili_telno = "";

            mye_email_adres = "";
            mye_cep_telno = "";
            mye_tc_kimlikno = "";
            mye_vergi_dairesi = "";
            mye_vergi_kimlikno = "";
            mye_dogum_yeri = "";
            mye_ev_cadde = "";
            mye_ev_mahalle = "";
            mye_ev_sokak = "";
            mye_ev_Semt = "";
            mye_ev_Apt_No = "";
            mye_ev_Daire_No = "";
            mye_ev_posta_kodu = "";
            mye_ev_ilce = "";
            mye_ev_il = "";
            mye_ev_ulke = "";
            mye_ev_adres_kodu = "";
            mye_is_telno = "";
            mye_ev_telno = "";
            mye_KEP_adresi = "";
            


        }
        public int mye_RECno { get; set; }
        public short mye_RECid_DBCno { get; set; }
        public int mye_RECid_RECno { get; set; }
        public Nullable<int> mye_SpecRECno { get; set; }
        public Nullable<bool> mye_iptal { get; set; }
        public Nullable<short> mye_fileid { get; set; }
        public Nullable<bool> mye_hidden { get; set; }
        public Nullable<bool> mye_kilitli { get; set; }
        public Nullable<bool> mye_degisti { get; set; }
        public Nullable<int> mye_checksum { get; set; }
        public Nullable<short> mye_create_user { get; set; }
        public Nullable<System.DateTime> mye_create_date { get; set; }
        public Nullable<short> mye_lastup_user { get; set; }
        public Nullable<System.DateTime> mye_lastup_date { get; set; }
        public string mye_special1 { get; set; }
        public string mye_special2 { get; set; }
        public string mye_special3 { get; set; }
        public string mye_cari_kod { get; set; }
        public Nullable<int> mye_adres_no { get; set; }
        public string mye_isim { get; set; }
        public string mye_soyisim { get; set; }
        public Nullable<System.DateTime> mye_dogum_tarihi { get; set; }
        public Nullable<System.DateTime> mye_evlilik_tarihi { get; set; }
        public string mye_es_isim { get; set; }
        public Nullable<System.DateTime> mye_es_dogum_tarihi { get; set; }
        public Nullable<byte> mye_unvan { get; set; }
        public Nullable<byte> mye_hitap { get; set; }
        public Nullable<byte> mye_hisse { get; set; }
        public Nullable<byte> mye_tahsil { get; set; }
        public string mye_dahili_telno { get; set; }
        public string mye_email_adres { get; set; }
        public string mye_cep_telno { get; set; }
        public string mye_tc_kimlikno { get; set; }
        public string mye_vergi_dairesi { get; set; }
        public string mye_vergi_kimlikno { get; set; }
        public string mye_dogum_yeri { get; set; }
        public string mye_ev_cadde { get; set; }
        public string mye_ev_mahalle { get; set; }
        public string mye_ev_sokak { get; set; }
        public string mye_ev_Semt { get; set; }
        public string mye_ev_Apt_No { get; set; }
        public string mye_ev_Daire_No { get; set; }
        public string mye_ev_posta_kodu { get; set; }
        public string mye_ev_ilce { get; set; }
        public string mye_ev_il { get; set; }
        public string mye_ev_ulke { get; set; }
        public string mye_ev_adres_kodu { get; set; }
        public string mye_is_telno { get; set; }
        public string mye_ev_telno { get; set; }
        public string mye_KEP_adresi { get; set; }
        public Nullable<bool> mye_mutabakat_yetkilisi_fl { get; set; }
    }
}
