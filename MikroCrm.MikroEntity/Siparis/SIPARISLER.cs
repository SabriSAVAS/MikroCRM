using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikroCrm.MikroEntity.Siparis
{
  public  class SIPARISLER
    {
        public int sip_RECno { get; set; }
        public short sip_RECid_DBCno { get; set; }
        public int sip_RECid_RECno { get; set; }
        public Nullable<int> sip_SpecRECno { get; set; }
        public Nullable<bool> sip_iptal { get; set; }
        public Nullable<short> sip_fileid { get; set; }
        public Nullable<bool> sip_hidden { get; set; }
        public Nullable<bool> sip_kilitli { get; set; }
        public Nullable<bool> sip_degisti { get; set; }
        public Nullable<int> sip_checksum { get; set; }
        public Nullable<short> sip_create_user { get; set; }
        public Nullable<System.DateTime> sip_create_date { get; set; }
        public Nullable<short> sip_lastup_user { get; set; }
        public Nullable<System.DateTime> sip_lastup_date { get; set; }
        public string sip_special1 { get; set; }
        public string sip_special2 { get; set; }
        public string sip_special3 { get; set; }
        public Nullable<int> sip_firmano { get; set; }
        public Nullable<int> sip_subeno { get; set; }
        public Nullable<System.DateTime> sip_tarih { get; set; }
        public Nullable<System.DateTime> sip_teslim_tarih { get; set; }
        public Nullable<byte> sip_tip { get; set; }
        public Nullable<byte> sip_cins { get; set; }
        public string sip_evrakno_seri { get; set; }
        public Nullable<int> sip_evrakno_sira { get; set; }
        public Nullable<int> sip_satirno { get; set; }
        public string sip_belgeno { get; set; }
        public Nullable<System.DateTime> sip_belge_tarih { get; set; }
        public string sip_satici_kod { get; set; }
        public string sip_musteri_kod { get; set; }
        public string sip_stok_kod { get; set; }
        public Nullable<double> sip_b_fiyat { get; set; }
        public Nullable<double> sip_miktar { get; set; }
        public Nullable<byte> sip_birim_pntr { get; set; }
        public Nullable<double> sip_teslim_miktar { get; set; }
        public Nullable<double> sip_tutar { get; set; }
        public Nullable<double> sip_iskonto_1 { get; set; }
        public Nullable<double> sip_iskonto_2 { get; set; }
        public Nullable<double> sip_iskonto_3 { get; set; }
        public Nullable<double> sip_iskonto_4 { get; set; }
        public Nullable<double> sip_iskonto_5 { get; set; }
        public Nullable<double> sip_iskonto_6 { get; set; }
        public Nullable<double> sip_masraf_1 { get; set; }
        public Nullable<double> sip_masraf_2 { get; set; }
        public Nullable<double> sip_masraf_3 { get; set; }
        public Nullable<double> sip_masraf_4 { get; set; }
        public Nullable<byte> sip_vergi_pntr { get; set; }
        public Nullable<double> sip_vergi { get; set; }
        public Nullable<byte> sip_masvergi_pntr { get; set; }
        public Nullable<double> sip_masvergi { get; set; }
        public Nullable<int> sip_opno { get; set; }
        public string sip_aciklama { get; set; }
        public string sip_aciklama2 { get; set; }
        public Nullable<int> sip_depono { get; set; }
        public Nullable<short> sip_OnaylayanKulNo { get; set; }
        public Nullable<bool> sip_vergisiz_fl { get; set; }
        public Nullable<bool> sip_kapat_fl { get; set; }
        public Nullable<bool> sip_promosyon_fl { get; set; }
        public string sip_cari_sormerk { get; set; }
        public string sip_stok_sormerk { get; set; }
        public Nullable<byte> sip_cari_grupno { get; set; }
        public Nullable<byte> sip_doviz_cinsi { get; set; }
        public Nullable<double> sip_doviz_kuru { get; set; }
        public Nullable<double> sip_alt_doviz_kuru { get; set; }
        public Nullable<int> sip_adresno { get; set; }
        public string sip_teslimturu { get; set; }
        public Nullable<bool> sip_cagrilabilir_fl { get; set; }
        public Nullable<short> sip_prosiprecDbId { get; set; }
        public Nullable<int> sip_prosiprecrecI { get; set; }
        public Nullable<byte> sip_iskonto1 { get; set; }
        public Nullable<byte> sip_iskonto2 { get; set; }
        public Nullable<byte> sip_iskonto3 { get; set; }
        public Nullable<byte> sip_iskonto4 { get; set; }
        public Nullable<byte> sip_iskonto5 { get; set; }
        public Nullable<byte> sip_iskonto6 { get; set; }
        public Nullable<byte> sip_masraf1 { get; set; }
        public Nullable<byte> sip_masraf2 { get; set; }
        public Nullable<byte> sip_masraf3 { get; set; }
        public Nullable<byte> sip_masraf4 { get; set; }
        public Nullable<bool> sip_isk1 { get; set; }
        public Nullable<bool> sip_isk2 { get; set; }
        public Nullable<bool> sip_isk3 { get; set; }
        public Nullable<bool> sip_isk4 { get; set; }
        public Nullable<bool> sip_isk5 { get; set; }
        public Nullable<bool> sip_isk6 { get; set; }
        public Nullable<bool> sip_mas1 { get; set; }
        public Nullable<bool> sip_mas2 { get; set; }
        public Nullable<bool> sip_mas3 { get; set; }
        public Nullable<bool> sip_mas4 { get; set; }
        public string sip_Exp_Imp_Kodu { get; set; }
        public Nullable<double> sip_kar_orani { get; set; }
        public Nullable<byte> sip_durumu { get; set; }
        public Nullable<short> sip_stalRecId_DBCno { get; set; }
        public Nullable<int> sip_stalRecId_RECno { get; set; }
        public Nullable<double> sip_planlananmiktar { get; set; }
        public Nullable<short> sip_teklifRecId_DBCno { get; set; }
        public Nullable<int> sip_teklifRecId_RECno { get; set; }
        public string sip_parti_kodu { get; set; }
        public Nullable<int> sip_lot_no { get; set; }
        public string sip_projekodu { get; set; }
        public Nullable<int> sip_fiyat_liste_no { get; set; }
        public Nullable<byte> sip_Otv_Pntr { get; set; }
        public Nullable<double> sip_Otv_Vergi { get; set; }
        public Nullable<double> sip_otvtutari { get; set; }
        public Nullable<byte> sip_OtvVergisiz_Fl { get; set; }
        public string sip_paket_kod { get; set; }
        public Nullable<short> sip_RezRecId_DBCno { get; set; }
        public Nullable<int> sip_RezRecId_RECno { get; set; }
        public Nullable<byte> sip_harekettipi { get; set; }
        public Nullable<short> sip_yetkili_recid_dbcno { get; set; }
        public Nullable<int> sip_yetkili_recid_recno { get; set; }
        public string sip_kapatmanedenkod { get; set; }
        public Nullable<System.DateTime> sip_gecerlilik_tarihi { get; set; }
        public Nullable<byte> sip_onodeme_evrak_tip { get; set; }
        public string sip_onodeme_evrak_seri { get; set; }
        public Nullable<int> sip_onodeme_evrak_sira { get; set; }
        public Nullable<double> sip_rezervasyon_miktari { get; set; }
        public Nullable<double> sip_rezerveden_teslim_edilen { get; set; }

        //public  string PrimaryColumn
        //{
        //    get { return "sip_RECno"; }
        //}
    }
}
