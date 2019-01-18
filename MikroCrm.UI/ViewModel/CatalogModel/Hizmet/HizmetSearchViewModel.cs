using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
namespace MikroCrm.UI.ViewModel.CatalogModel.Hizmet
{
    public class HizmetSearchViewModel
    {
        public HizmetSearchViewModel()
        {
            HizmetKod = "";
            HizmetAd = "";
        }
        public string HizmetKod { get; set; }
        public string HizmetAd { get; set; }
        public int? Page { get; set; }
        public IPagedList<HizmetListViewModel> HizmetList { get; set; }
    }
}