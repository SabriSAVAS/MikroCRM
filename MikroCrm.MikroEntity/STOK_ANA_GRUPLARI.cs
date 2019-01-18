using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikroCrm.MikroEntity
{
    public class STOK_ANA_GRUPLARI
    {
        public int san_RECno { get; set; }
        public short san_RECid_DBCno { get; set; }
        public int san_RECid_RECno { get; set; }
        public Nullable<int> san_SpecRECno { get; set; }
        public Nullable<bool> san_iptal { get; set; }
        public Nullable<short> san_fileid { get; set; }
        public Nullable<bool> san_hidden { get; set; }
        public Nullable<bool> san_kilitli { get; set; }
        public Nullable<bool> san_degisti { get; set; }
        public Nullable<int> san_checksum { get; set; }
        public Nullable<short> san_create_user { get; set; }
        public Nullable<System.DateTime> san_create_date { get; set; }
        public Nullable<short> san_lastup_user { get; set; }
        public Nullable<System.DateTime> san_lastup_date { get; set; }
        public string san_special1 { get; set; }
        public string san_special2 { get; set; }
        public string san_special3 { get; set; }
        public string san_kod { get; set; }
        public string san_isim { get; set; }
    }
}
