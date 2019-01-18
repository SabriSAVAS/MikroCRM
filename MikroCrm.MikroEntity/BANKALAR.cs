﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikroCrm.MikroEntity
{
 public   class BANKALAR
    {
        public int ban_RECno { get; set; }
        public short ban_RECid_DBCno { get; set; }
        public int ban_RECid_RECno { get; set; }
        public Nullable<int> ban_SpecRECNo { get; set; }
        public Nullable<bool> ban_iptal { get; set; }
        public Nullable<short> ban_fileid { get; set; }
        public Nullable<bool> ban_hidden { get; set; }
        public Nullable<bool> ban_kilitli { get; set; }
        public Nullable<bool> ban_degisti { get; set; }
        public Nullable<int> ban_CheckSum { get; set; }
        public Nullable<short> ban_create_user { get; set; }
        public Nullable<System.DateTime> ban_create_date { get; set; }
        public Nullable<short> ban_lastup_user { get; set; }
        public Nullable<System.DateTime> ban_lastup_date { get; set; }
        public string ban_special1 { get; set; }
        public string ban_special2 { get; set; }
        public string ban_special3 { get; set; }
        public string ban_kod { get; set; }
        public string ban_ismi { get; set; }
        public string ban_sube { get; set; }
        public string ban_SwiftKodu { get; set; }
        public string ban_IBANKodu { get; set; }
        public string ban_hesapno { get; set; }
        public Nullable<int> ban_firma_no { get; set; }
        public Nullable<byte> ban_hesap_tip { get; set; }
        public Nullable<byte> ban_mevduat_tip { get; set; }
        public Nullable<byte> ban_kredi_tip { get; set; }
        public string ban_muh_kod { get; set; }
        public string ban_ver_cek_muh_kod { get; set; }
        public string ban_tah_cek_muh_kod { get; set; }
        public string ban_tah_sen_muh_kod { get; set; }
        public string ban_tem_cek_muh_kod { get; set; }
        public string ban_tem_sen_muh_kod { get; set; }
        public string ban_mus_krdrkart_muh_kod { get; set; }
        public string ban_frm_krdrkart_muh_kod { get; set; }
        public string ban_must_havale_sozu_muh_kodu { get; set; }
        public string ban_firma_havale_emri_muh_kodu { get; set; }
        public string ban_tem_muh_kod { get; set; }
        public Nullable<byte> ban_doviz_cinsi { get; set; }
        public Nullable<double> ban_vade_fark_yuzde { get; set; }
        public Nullable<double> ban_kredi_tavan { get; set; }
        public Nullable<double> ban_risk_tavan { get; set; }
        public Nullable<bool> ban_nakakincelenmesi { get; set; }
        public string ban_TCMB_Kodu { get; set; }
        public string ban_TCMB_Sube_Kodu { get; set; }
        public string ban_TCMB_Il_kodu { get; set; }
        public string ban_musteri_no { get; set; }
        public Nullable<byte> ban_Ayni_banka_tahsil_suresi { get; set; }
        public Nullable<byte> ban_baska_banka_tahsil_suresi { get; set; }
        public Nullable<byte> ban_odul_katkisi_hesap_cinsi { get; set; }
        public string ban_odul_katkisi_hesabi { get; set; }
        public Nullable<byte> ban_servis_komisyon_hesap_cinsi { get; set; }
        public string ban_servis_komisyon_hesabi { get; set; }
        public Nullable<byte> ban_erken_odm_faiz_hesap_cinsi { get; set; }
        public string ban_erken_odm_faiz_hesabi { get; set; }
        public string ban_pos_tahsilat_cari_hesabi { get; set; }
        public string ban_adr_cadde { get; set; }
        public string ban_adr_mahalle { get; set; }
        public string ban_adr_sokak { get; set; }
        public string ban_adr_Semt { get; set; }
        public string ban_adr_Apt_No { get; set; }
        public string ban_adr_Daire_No { get; set; }
        public string ban_adr_posta_kodu { get; set; }
        public string ban_adr_ilce { get; set; }
        public string ban_adr_il { get; set; }
        public string ban_adr_ulke { get; set; }
        public string ban_adr_adres_kodu { get; set; }
        public string ban_tel_ulke_kodu { get; set; }
        public string ban_tel_bolge_kodu { get; set; }
        public string ban_tel_no1 { get; set; }
        public string ban_tel_no2 { get; set; }
        public string ban_tel_faxno { get; set; }
        public string ban_tel_modem { get; set; }
        public string ban_temsilci { get; set; }
        public string ban_temsilci_email { get; set; }
        public string ban_ufrs_muh_kod { get; set; }
        public string ban_ufrs_ver_cek_muh_kod { get; set; }
        public string ban_ufrs_tah_cek_muh_kod { get; set; }
        public string ban_ufrs_tah_sen_muh_kod { get; set; }
        public string ban_ufrs_tem_cek_muh_kod { get; set; }
        public string ban_ufrs_tem_sen_muh_kod { get; set; }
        public string ban_ufrs_mus_krdrkart_muh_kod { get; set; }
        public string ban_ufrs_frm_krdrkart_muh_kod { get; set; }
        public string ban_ufrs_must_havale_sozu_muh_kodu { get; set; }
        public string ban_ufrs_firma_havale_emri_muh_kodu { get; set; }
        public string ban_ufrs_ver_cek_sinif_muh_kod { get; set; }
        public string ban_ufrs_frm_hav_emri_sinif_muh_kodu { get; set; }
        public string ban_ufrs_tem_muh_kod { get; set; }
    }
}
