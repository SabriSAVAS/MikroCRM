﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikroCrm.MikroEntity.ProformaSiparis
{
   public class PROFORMA_SIPARISLER
    {
        public int pro_RECno { get; set; }
        public short pro_RECid_DBCno { get; set; }
        public int pro_RECid_RECno { get; set; }
        public Nullable<int> pro_SpecRecNo { get; set; }
        public Nullable<bool> pro_iptal { get; set; }
        public Nullable<short> pro_fileid { get; set; }
        public Nullable<bool> pro_hidden { get; set; }
        public Nullable<bool> pro_kilitli { get; set; }
        public Nullable<bool> pro_degisti { get; set; }
        public Nullable<int> pro_checksum { get; set; }
        public Nullable<short> pro_create_user { get; set; }
        public Nullable<System.DateTime> pro_create_date { get; set; }
        public Nullable<short> pro_lastup_user { get; set; }
        public Nullable<System.DateTime> pro_lastup_date { get; set; }
        public string pro_special1 { get; set; }
        public string pro_special2 { get; set; }
        public string pro_special3 { get; set; }
        public Nullable<int> pro_firmano { get; set; }
        public Nullable<int> pro_subeno { get; set; }
        public Nullable<System.DateTime> pro_tarihi { get; set; }
        public Nullable<System.DateTime> pro_testarihi { get; set; }
        public Nullable<byte> pro_tipi { get; set; }
        public Nullable<byte> pro_cinsi { get; set; }
        public string pro_evrakno_seri { get; set; }
        public Nullable<int> pro_evrakno_sira { get; set; }
        public Nullable<int> pro_satirno { get; set; }
        public string pro_belge_no { get; set; }
        public Nullable<System.DateTime> pro_belge_tarihi { get; set; }
        public string pro_saticikodu { get; set; }
        public string pro_mustkodu { get; set; }
        public string pro_stokkodu { get; set; }
        public Nullable<double> pro_bfiyati { get; set; }
        public Nullable<double> pro_miktar { get; set; }
        public Nullable<byte> pro_birim_pntr { get; set; }
        public Nullable<double> pro_tesmiktari { get; set; }
        public Nullable<double> pro_tutari { get; set; }
        public Nullable<double> pro_iskonto1 { get; set; }
        public Nullable<double> pro_iskonto2 { get; set; }
        public Nullable<double> pro_iskonto3 { get; set; }
        public Nullable<double> pro_iskonto4 { get; set; }
        public Nullable<double> pro_iskonto5 { get; set; }
        public Nullable<double> pro_iskonto6 { get; set; }
        public Nullable<double> pro_masraf1 { get; set; }
        public Nullable<double> pro_masraf2 { get; set; }
        public Nullable<double> pro_masraf3 { get; set; }
        public Nullable<double> pro_masraf4 { get; set; }
        public Nullable<byte> pro_vergipntr { get; set; }
        public Nullable<double> pro_vergi { get; set; }
        public Nullable<byte> pro_masrafvergipntr { get; set; }
        public Nullable<double> pro_masrafvergi { get; set; }
        public Nullable<int> pro_opno { get; set; }
        public string pro_aciklama { get; set; }
        public string pro_aciklama2 { get; set; }
        public Nullable<int> pro_depono { get; set; }
        public Nullable<short> pro_onaylayanKul_no { get; set; }
        public Nullable<bool> pro_vergisiz { get; set; }
        public Nullable<bool> pro_kapat { get; set; }
        public Nullable<bool> pro_promosyon_fl { get; set; }
        public string pro_cari_sormerk { get; set; }
        public string pro_stok_sormerk { get; set; }
        public Nullable<byte> pro_cari_grupno { get; set; }
        public Nullable<byte> pro_dovizcinsi { get; set; }
        public Nullable<double> pro_dovizkuru { get; set; }
        public Nullable<double> pro_altdovizkuru { get; set; }
        public Nullable<int> pro_adresno { get; set; }
        public string pro_teslimturu { get; set; }
        public Nullable<bool> pro_cagrilabilir_fl { get; set; }
        public Nullable<short> pro_sipDbID { get; set; }
        public Nullable<int> pro_sipRecID { get; set; }
        public Nullable<byte> pro_isk_mas_1 { get; set; }
        public Nullable<byte> pro_isk_mas_2 { get; set; }
        public Nullable<byte> pro_isk_mas_3 { get; set; }
        public Nullable<byte> pro_isk_mas_4 { get; set; }
        public Nullable<byte> pro_isk_mas_5 { get; set; }
        public Nullable<byte> pro_isk_mas_6 { get; set; }
        public Nullable<byte> pro_isk_mas_7 { get; set; }
        public Nullable<byte> pro_isk_mas_8 { get; set; }
        public Nullable<byte> pro_isk_mas_9 { get; set; }
        public Nullable<byte> pro_isk_mas_10 { get; set; }
        public Nullable<bool> pro_sat_isk_mas1 { get; set; }
        public Nullable<bool> pro_sat_isk_mas2 { get; set; }
        public Nullable<bool> pro_sat_isk_mas3 { get; set; }
        public Nullable<bool> pro_sat_isk_mas4 { get; set; }
        public Nullable<bool> pro_sat_isk_mas5 { get; set; }
        public Nullable<bool> pro_sat_isk_mas6 { get; set; }
        public Nullable<bool> pro_sat_isk_mas7 { get; set; }
        public Nullable<bool> pro_sat_isk_mas8 { get; set; }
        public Nullable<bool> pro_sat_isk_mas9 { get; set; }
        public Nullable<bool> pro_sat_isk_mas10 { get; set; }
        public string pro_Exp_Imp_Kodu { get; set; }
        public Nullable<double> pro_karoani { get; set; }
        public Nullable<byte> pro_durumu { get; set; }
        public Nullable<short> pro_stalRecId_DBCno { get; set; }
        public Nullable<int> pro_stalRecId_RECno { get; set; }
        public Nullable<double> pro_planlananmiktar { get; set; }
        public Nullable<short> pro_teklifRecId_DBCno { get; set; }
        public Nullable<int> pro_teklifRecId_RECno { get; set; }
        public string pro_parti_kodu { get; set; }
        public Nullable<int> pro_lot_no { get; set; }
        public string pro_projekodu { get; set; }
        public Nullable<int> pro_fiyat_liste_no { get; set; }
        public Nullable<byte> pro_Otv_Pntr { get; set; }
        public Nullable<double> pro_Otv_Vergi { get; set; }
        public Nullable<double> pro_otvtutari { get; set; }
        public Nullable<byte> pro_OtvVergisiz_Fl { get; set; }
        public string pro_paket_kod { get; set; }
        public Nullable<short> pro_RezRecId_DBCno { get; set; }
        public Nullable<int> pro_RezRecId_RECno { get; set; }
        public Nullable<byte> pro_harekettipi { get; set; }
        public Nullable<short> pro_yetkili_recid_dbcno { get; set; }
        public Nullable<int> pro_yetkili_recid_recno { get; set; }
        public string pro_kapatmanedenkod { get; set; }
        public Nullable<System.DateTime> pro_gecerlilik_tarihi { get; set; }
        public Nullable<byte> pro_onodeme_evrak_tip { get; set; }
        public string pro_onodeme_evrak_seri { get; set; }
        public Nullable<int> pro_onodeme_evrak_sira { get; set; }
        public Nullable<double> pro_rezervasyon_miktari { get; set; }
        public Nullable<double> pro_rezerveden_teslim_edilen { get; set; }
    }
}
