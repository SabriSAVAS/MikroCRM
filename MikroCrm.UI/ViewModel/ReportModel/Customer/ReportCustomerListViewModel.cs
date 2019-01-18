using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MikroCrm.UI.ViewModel.ReportModel.Customer
{
    public class ReportCustomerListViewModel:ModelEntity
    {
        public int EvrakCinsId { get; set; }
        public DateTime Tarih { get; set; }
        public string EvrakSeri { get; set; }
        public int EvrakSira { get; set; }
        public string EvrakTip { get; set; }
        public string EvrakCinsi { get; set; }
        public DateTime VadeTarih { get; set; }
        public double Miktar { get; set; }
        public string BA { get; set; }
        public double Borc { get; set; }
        public double Alacak { get; set; }
        public string KarsiHesapIsmi { get; set; }
    }
}