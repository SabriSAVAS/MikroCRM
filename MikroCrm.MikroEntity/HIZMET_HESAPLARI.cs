using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikroCrm.MikroEntity
{
    public class HIZMET_HESAPLARI
    {
        public int hiz_RECno { get; set; }
        public short hiz_RECid_DBCno { get; set; }
        public int hiz_RECid_RECno { get; set; }
        public Nullable<int> hiz_SpecRecno { get; set; }
        public Nullable<bool> hiz_iptal { get; set; }
        public Nullable<short> hiz_fileid { get; set; }
        public Nullable<bool> hiz_hidden { get; set; }
        public Nullable<bool> hiz_kilitli { get; set; }
        public Nullable<bool> hiz_degisti { get; set; }
        public Nullable<int> hiz_checksum { get; set; }
        public Nullable<short> hiz_create_user { get; set; }
        public Nullable<System.DateTime> hiz_create_date { get; set; }
        public Nullable<short> hiz_lastup_user { get; set; }
        public Nullable<System.DateTime> hiz_lastup_date { get; set; }
        public string hiz_special1 { get; set; }
        public string hiz_special2 { get; set; }
        public string hiz_special3 { get; set; }
        public Nullable<byte> hiz_tip { get; set; }
        public string hiz_kod { get; set; }
        public string hiz_isim { get; set; }
        public string hiz_yabanci_isim { get; set; }
        public string hiz_tipkod { get; set; }
        public string hiz_sinifkod { get; set; }
        public string hiz_grupkod { get; set; }
        public string hiz_sat_muh_kod { get; set; }
        public string hiz_sat_iade_muh_kod { get; set; }
        public string hiz_mal_muh_kod { get; set; }
        public string hiz_sat_mal_muh_kod { get; set; }
        public string hiz_mal_yan_muh_kod { get; set; }
        public Nullable<double> hiz_fiyat { get; set; }
        public Nullable<byte> hiz_doviz_cinsi { get; set; }
        public string hiz_isk_grup { get; set; }
        public Nullable<byte> hiz_KDV { get; set; }
        public string hiz_muh_sat_isk_kod { get; set; }
        public string hiz_muh_aIiskmuhkod { get; set; }
        public string hiz_ilavemasmuhkod { get; set; }
        public Nullable<int> hiz_operasyon_suresi { get; set; }
        public Nullable<byte> hiz_oivuygulama { get; set; }
        public Nullable<double> hiz_oivtutar { get; set; }
        public Nullable<byte> hiz_oivturu { get; set; }
        public string hiz_sat_ufrs_fark_muh_kod { get; set; }
        public string hiz_sat_iade_ufrs_fark_muh_kod { get; set; }
        public string hiz_mal_ufrs_fark_muh_kod { get; set; }
        public string hiz_sat_mal_ufrs_fark_muh_kod { get; set; }
        public string hiz_mal_yan_ufrs_fark_muh_kod { get; set; }
        public string hiz_muh_sat_ufrs_fark_isk_kod { get; set; }
        public string hiz_muh_aIiskufrs_fark_muhkod { get; set; }
        public string hiz_ilavemasufrs_fark_muhkod { get; set; }
        public string hiz_birim_ad { get; set; }
    }
}
