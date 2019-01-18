using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MikroCrm.UI.ViewModel.ProformaOrderModel
{
    public class ProformaOrderListViewModel
    {
       
        public int Id { get; set; }
        public DateTime Tarih { get; set; }
        public string EvrakSeri { get; set; }
        public string SaticiKod { get; set; }
        public string SaticiAd { get; set; }
        public string MusteriKod { get; set; }
        public string MusteriUnvan { get; set; }
        public string Durum { get; set; }
        public string Aciklama { get; set; }
        public string Aciklama2 { get; set; }

       
       
    }
}