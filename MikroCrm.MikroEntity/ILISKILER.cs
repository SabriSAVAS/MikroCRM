using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikroCrm.MikroEntity
{
    public class ILISKILER
    {
        public int il_RECno { get; set; }
        public short il_RECid_DBCno { get; set; }
        public int il_RECid_RECno { get; set; }
        public Nullable<int> il_SpecRECno { get; set; }
        public Nullable<bool> il_iptal { get; set; }
        public Nullable<short> il_fileid { get; set; }
        public Nullable<bool> il_hidden { get; set; }
        public Nullable<bool> il_kilitli { get; set; }
        public Nullable<bool> il_degisti { get; set; }
        public Nullable<int> il_checksum { get; set; }
        public Nullable<short> il_create_user { get; set; }
        public Nullable<System.DateTime> il_create_date { get; set; }
        public Nullable<short> il_lastup_user { get; set; }
        public Nullable<System.DateTime> il_lastup_date { get; set; }
        public string il_special1 { get; set; }
        public string il_special2 { get; set; }
        public string il_special3 { get; set; }
        public Nullable<System.DateTime> il_baszaman { get; set; }
        public Nullable<System.DateTime> il_bitzaman { get; set; }
        public string il_sorumlu_personel { get; set; }
        public Nullable<byte> il_iliski_tipi { get; set; }
        public string il_carikodu { get; set; }
        public Nullable<int> il_adres_no { get; set; }
        public Nullable<short> il_yetkiliRecID_DBCno { get; set; }
        public Nullable<int> il_yetkiliRecID_RECno { get; set; }
        public string il_yetkiliadi { get; set; }
        public string il_yer { get; set; }
        public string il_konu { get; set; }
        public string il_refno { get; set; }
        public string il_projekodu { get; set; }
        public Nullable<byte> il_oncelik { get; set; }
        public Nullable<byte> il_cari_tipi { get; set; }
    }
}
