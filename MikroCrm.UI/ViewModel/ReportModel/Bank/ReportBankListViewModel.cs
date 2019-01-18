using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MikroCrm.UI.ViewModel.ReportModel.Bank
{
    public class ReportBankListViewModel:ModelEntity
    {
        public DateTime Tarih { get; set; }
        public string EvrakSeri { get; set; }
        public int EvrakSira { get; set; }
        public string EvrakTip { get; set; }
        public string Cinsi { get; set; }
        public int Vade { get; set; }
        public string BorcAlacak { get; set; }
        public double Borc { get; set; }
        public double Alacak { get; set; }
        public double Tutar { get; set; }
        public string HesapIsmi { get; set; }
    }
}