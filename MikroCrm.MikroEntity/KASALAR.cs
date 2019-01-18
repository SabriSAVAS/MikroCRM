using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikroCrm.MikroEntity
{
    public class KASALAR
    {
        public int kas_RECno { get; set; }
        public short kas_RECid_DBCno { get; set; }
        public int kas_RECid_RECno { get; set; }
        public Nullable<int> kas_SpecRecno { get; set; }
        public Nullable<bool> kas_iptal { get; set; }
        public Nullable<short> kas_fileid { get; set; }
        public Nullable<bool> kas_hidden { get; set; }
        public Nullable<bool> kas_kilitli { get; set; }
        public Nullable<bool> kas_degisti { get; set; }
        public Nullable<int> kas_checksum { get; set; }
        public Nullable<short> kas_create_user { get; set; }
        public Nullable<System.DateTime> kas_create_date { get; set; }
        public Nullable<short> kas_lastup_user { get; set; }
        public Nullable<System.DateTime> kas_lastup_date { get; set; }
        public string kas_special1 { get; set; }
        public string kas_special2 { get; set; }
        public string kas_special3 { get; set; }
        public Nullable<byte> kas_tip { get; set; }
        public Nullable<int> kas_firma_no { get; set; }
        public string kas_kod { get; set; }
        public string kas_isim { get; set; }
        public string kas_muh_kod { get; set; }
        public Nullable<byte> kas_doviz_cinsi { get; set; }
        public string kas_bankakodu { get; set; }
        public Nullable<bool> kas_nakakincelenmesi { get; set; }
        public string kas_ufrs_muh_kod { get; set; }
    }
}
