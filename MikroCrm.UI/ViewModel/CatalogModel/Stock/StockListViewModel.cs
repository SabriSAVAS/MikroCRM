using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MikroCrm.UI.ViewModel.CatalogModel.Stock
{
    public class StockListViewModel:ModelEntity
    {
        public string StokKod { get; set; }
        public string StokAd { get; set; }
        public string Birim { get; set; }
        public double BirimFiyat { get; set; }
        public double Tutar { get; set; }
        public string Aciklama { get; set; }
    }
}