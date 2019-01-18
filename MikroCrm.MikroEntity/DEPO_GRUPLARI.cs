using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikroCrm.MikroEntity
{
    public class DEPO_GRUPLARI
    {
        public int dgr_RECno { get; set; }
        public short dgr_RECid_DBCno { get; set; }
        public int dgr_RECid_RECno { get; set; }
        public Nullable<int> dgr_SpecRECno { get; set; }
        public Nullable<bool> dgr_iptal { get; set; }
        public Nullable<short> dgr_fileid { get; set; }
        public Nullable<bool> dgr_hidden { get; set; }
        public Nullable<bool> dgr_kilitli { get; set; }
        public Nullable<bool> dgr_degisti { get; set; }
        public Nullable<int> dgr_checksum { get; set; }
        public Nullable<short> dgr_create_user { get; set; }
        public Nullable<System.DateTime> dgr_create_date { get; set; }
        public Nullable<short> dgr_lastup_user { get; set; }
        public Nullable<System.DateTime> dgr_lastup_date { get; set; }
        public string dgr_special1 { get; set; }
        public string dgr_special2 { get; set; }
        public string dgr_special3 { get; set; }
        public string dgr_kod { get; set; }
        public string dgr_ismi { get; set; }
    }
}
