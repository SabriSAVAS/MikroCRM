using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MikroCrm.UI.ViewModel.ProformaOrderModel
{
    public class ProformaOrderSearchViewModel
    {
        public ProformaOrderSearchViewModel()
        {
            string sdate = DateTime.Now.Year + "-01-01";

            string edate = DateTime.Now.Year + "-12-31";
            startDate = sdate;
            endDate = edate;
            CariKod = "";
            TekniksyenAd = "";
            DurumList = new List<SelectListItem>();
           
            TekniksyenAdList = new List<SelectListItem>();
        }
        
        public string CariKod { get; set; }
        public string CariUnvan { get; set; }
        public string TekniksyenAd { get; set; }

        [Required]
        public string startDate { get; set; }
        [Required]
        public string endDate { get; set; }
        public string Durum { get; set; }
        public int? Page { get; set; }

        public List<SelectListItem> DurumList { get; set; }
        public List<SelectListItem> TekniksyenAdList { get; set; }
        public IPagedList<ProformaOrderListViewModel> OrderList { get; set; }
    }
}