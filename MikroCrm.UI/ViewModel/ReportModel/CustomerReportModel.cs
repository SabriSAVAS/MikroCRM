using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MikroCrm.UI.ViewModel.ReportModel
{
    public class CustomerReportModel
    {
        public string CariKod { get; set; }
        public string CariUnvan { get; set; }
        public string VergiDairesiNo { get; set; }
        public bool BilBakımveDestek { get; set; }
        public string MikroUzakBagTelDes { get; set; }
        public string MikroEgDes { get; set; }
        public string YedeklemeSistemi { get; set; }
        public DateTime SözBas { get; set; }
        public DateTime SözBit { get; set; }
        public string Yorum1 { get; set; }
        public string Yorum2 { get; set; }
        public string AsistanBasTar { get; set; }
        public string AsistanIsmi { get; set; }
        public DateTime KonturBasTar { get; set; }
        public string Kep { get; set; }
        public string eImza { get; set; }
        public string GrupAdı { get; set; }
    }
}