using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikroCrm.MikroEntity
{
  public  class EVRAK_ACIKLAMALARI
    {
        public int egk_RECno { get; set; }
        public short egk_RECid_DBCno { get; set; }
        public int egk_RECid_RECno { get; set; }
        public Nullable<int> egk_SpecRECno { get; set; }
        public Nullable<bool> egk_iptal { get; set; }
        public Nullable<short> egk_fileid { get; set; }
        public Nullable<bool> egk_hidden { get; set; }
        public Nullable<bool> egk_kilitli { get; set; }
        public Nullable<bool> egk_degisti { get; set; }
        public Nullable<int> egk_checksum { get; set; }
        public Nullable<short> egk_create_user { get; set; }
        public Nullable<System.DateTime> egk_create_date { get; set; }
        public Nullable<short> egk_lastup_user { get; set; }
        public Nullable<System.DateTime> egk_lastup_date { get; set; }
        public string egk_special1 { get; set; }
        public string egk_special2 { get; set; }
        public string egk_special3 { get; set; }
        public Nullable<short> egk_dosyano { get; set; }
        public Nullable<byte> egk_hareket_tip { get; set; }
        public Nullable<byte> egk_evr_tip { get; set; }
        public string egk_evr_seri { get; set; }
        public Nullable<int> egk_evr_sira { get; set; }
        public string egk_evr_ustkod { get; set; }
        public Nullable<short> egk_evr_doksayisi { get; set; }
        public string egk_evracik1 { get; set; }
        public string egk_evracik2 { get; set; }
        public string egk_evracik3 { get; set; }
        public string egk_evracik4 { get; set; }
        public string egk_evracik5 { get; set; }
        public string egk_evracik6 { get; set; }
        public string egk_evracik7 { get; set; }
        public string egk_evracik8 { get; set; }
        public string egk_evracik9 { get; set; }
        public string egk_evracik10 { get; set; }
        public Nullable<double> egk_sipgenkarorani { get; set; }
        public string egk_kargokodu { get; set; }
        public string egk_kargono { get; set; }
        public Nullable<System.DateTime> egk_tesaltarihi { get; set; }
        public string egk_tesalkisi { get; set; }
        public Nullable<short> egk_prevwiewsayisi { get; set; }
        public Nullable<short> egk_emailsayisi { get; set; }
        public Nullable<bool> egk_Evrakopno_verildi_fl { get; set; }
    }
}
