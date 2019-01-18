using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikroCrm.MikroEntity
{
    public class STOK_ALT_GRUPLARI
    {
        public int sta_RECno { get; set; }
        public short sta_RECid_DBCno { get; set; }
        public int sta_RECid_RECno { get; set; }
        public Nullable<int> sta_SpecRECno { get; set; }
        public Nullable<bool> sta_iptal { get; set; }
        public Nullable<short> sta_fileid { get; set; }
        public Nullable<bool> sta_hidden { get; set; }
        public Nullable<bool> sta_kilitli { get; set; }
        public Nullable<bool> sta_degisti { get; set; }
        public Nullable<int> sta_checksum { get; set; }
        public Nullable<short> sta_create_user { get; set; }
        public Nullable<System.DateTime> sta_create_date { get; set; }
        public Nullable<short> sta_lastup_user { get; set; }
        public Nullable<System.DateTime> sta_lastup_date { get; set; }
        public string sta_special1 { get; set; }
        public string sta_special2 { get; set; }
        public string sta_special3 { get; set; }
        public string sta_kod { get; set; }
        public string sta_isim { get; set; }
        public string sta_ana_grup_kod { get; set; }
    }
}
