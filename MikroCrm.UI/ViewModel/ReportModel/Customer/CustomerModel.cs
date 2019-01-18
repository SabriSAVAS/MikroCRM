using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MikroCrm.UI.ViewModel.ReportModel.Customer
{
    public class CustomerModel
    {
        public int Id { get; set; }
        public string CariKod { get; set; }
        public string CariUnvan { get; set; }
        public string VergiDairesi { get; set; }
        public string VergiNumarası { get; set; }
        public string Email { get; set; }
        public string WebAdresi { get; set; }
        public DateTime eFaturaBaslangicTarihi { get; set; }
        public bool eFaturaDurum { get; set; }
        public double Bakiye { get; set; }
        public string Adres1 { get; set; }
        public string Adres2 { get; set; }
        public string PostaKodu { get; set; }
        public string Il { get; set; }
        public string Ilce { get; set; }
        public string BolgeKod { get; set; }
        public string Tel1 { get; set; }
        public string Tel2 { get; set; }
        public string Fax { get; set; }
    }
}