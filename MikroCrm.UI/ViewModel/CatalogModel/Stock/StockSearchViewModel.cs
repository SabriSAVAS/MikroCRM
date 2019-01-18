using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList.Mvc;
using PagedList;

namespace MikroCrm.UI.ViewModel.CatalogModel.Stock
{
    public class StockSearchViewModel
    {
        public StockSearchViewModel()
        {
            StokKod = "";
            StokAd = "";
        }
        public string StokKod { get; set; }
        public string StokAd { get; set; }
        public int? Page { get; set; }
        public IPagedList<StockListViewModel> StockList { get; set; }

    }
}