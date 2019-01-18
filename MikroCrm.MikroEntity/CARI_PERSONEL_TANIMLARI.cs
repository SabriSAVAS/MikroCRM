using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikroCrm.MikroEntity
{
   public class CARI_PERSONEL_TANIMLARI
    {
        public int cari_per_RECno { get; set; }
        public short cari_per_RECid_DBCno { get; set; }
        public int cari_per_RECid_RECno { get; set; }
        public Nullable<int> cari_per_SpecRECno { get; set; }
        public Nullable<bool> cari_per_iptal { get; set; }
        public Nullable<short> cari_per_fileid { get; set; }
        public Nullable<bool> cari_per_hidden { get; set; }
        public Nullable<bool> cari_per_kilitli { get; set; }
        public Nullable<bool> cari_per_degisti { get; set; }
        public Nullable<int> cari_per_checksum { get; set; }
        public Nullable<short> cari_per_create_user { get; set; }
        public Nullable<System.DateTime> cari_per_create_date { get; set; }
        public Nullable<short> cari_per_lastup_user { get; set; }
        public Nullable<System.DateTime> cari_per_lastup_date { get; set; }
        public string cari_per_special1 { get; set; }
        public string cari_per_special2 { get; set; }
        public string cari_per_special3 { get; set; }
        public string cari_per_kod { get; set; }
        public string cari_per_adi { get; set; }
        public string cari_per_soyadi { get; set; }
        public Nullable<byte> cari_per_tip { get; set; }
        public Nullable<byte> cari_per_doviz_cinsi { get; set; }
        public string cari_per_muhkod0 { get; set; }
        public string cari_per_muhkod1 { get; set; }
        public string cari_per_muhkod2 { get; set; }
        public string cari_per_muhkod3 { get; set; }
        public string cari_per_muhkod4 { get; set; }
        public string cari_per_banka_tcmb_kod { get; set; }
        public string cari_per_banka_tcmb_subekod { get; set; }
        public string cari_per_banka_tcmb_ilkod { get; set; }
        public string cari_per_banka_hesapno { get; set; }
        public string cari_per_banka_swiftkodu { get; set; }
        public Nullable<double> cari_per_prim_adet { get; set; }
        public Nullable<double> cari_per_prim_yuzde { get; set; }
        public Nullable<double> cari_per_prim_carpani { get; set; }
        public Nullable<double> cari_per_basmprimcirotav1 { get; set; }
        public Nullable<double> cari_per_basmprimyuz1 { get; set; }
        public Nullable<double> cari_per_basmprimcirotav2 { get; set; }
        public Nullable<double> cari_per_basmprimyuz2 { get; set; }
        public Nullable<double> cari_per_basmprimcirotav3 { get; set; }
        public Nullable<double> cari_per_basmprimyuz3 { get; set; }
        public Nullable<double> cari_per_basmprimcirotav4 { get; set; }
        public Nullable<double> cari_per_basmprimyuz4 { get; set; }
        public Nullable<double> cari_per_basmprimcirotav5 { get; set; }
        public Nullable<double> cari_per_basmprimyuz5 { get; set; }
        public string cari_per_kasiyerkodu { get; set; }
        public string cari_per_kasiyersifresi { get; set; }
        public string cari_per_kasiyerAmiri { get; set; }
        public Nullable<int> cari_per_userno { get; set; }
        public Nullable<int> cari_per_depono { get; set; }
        public string cari_per_cepno { get; set; }
        public string cari_per_mail { get; set; }
        public string cari_takvim_kodu { get; set; }
        public string cari_per_kasiyerfirmaid { get; set; }
        public string cari_per_KEP_adresi { get; set; }
    }
}
