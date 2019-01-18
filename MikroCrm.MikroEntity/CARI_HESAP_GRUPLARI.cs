using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikroCrm.MikroEntity
{
    public class CARI_HESAP_GRUPLARI
    {
        public int crg_RECno { get; set; }
        public short crg_RECid_DBCno { get; set; }
        public int crg_RECid_RECno { get; set; }
        public Nullable<int> crg_SpecRECNo { get; set; }
        public Nullable<bool> crg_iptal { get; set; }
        public Nullable<short> crg_fileid { get; set; }
        public Nullable<bool> crg_hidden { get; set; }
        public Nullable<bool> crg_kilitli { get; set; }
        public Nullable<bool> crg_degisti { get; set; }
        public Nullable<int> crg_CheckSum { get; set; }
        public Nullable<short> crg_create_user { get; set; }
        public Nullable<System.DateTime> crg_create_date { get; set; }
        public Nullable<short> crg_lastup_user { get; set; }
        public Nullable<System.DateTime> crg_lastup_date { get; set; }
        public string crg_special1 { get; set; }
        public string crg_special2 { get; set; }
        public string crg_special3 { get; set; }
        public string crg_kod { get; set; }
        public string crg_isim { get; set; }
        public string crg_muhasebe_kodu { get; set; }
    }
}
