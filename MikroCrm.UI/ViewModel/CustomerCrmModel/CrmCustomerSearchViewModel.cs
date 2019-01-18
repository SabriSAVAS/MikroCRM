using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MikroCrm.UI.ViewModel.CustomerCrmModel
{
    public class CrmCustomerSearchViewModel
    {
        public CrmCustomerSearchViewModel()
        {
            string sdate = DateTime.Now.Year + "-01-01";

            string edate = DateTime.Now.Year + "-12-31";
            startDate = sdate;
            endDate = edate;
            CariKod = "";
        }

        public string CariKod { get; set; }
        public string CariUnvan { get; set; }
        [Required]
        public string startDate { get; set; }
        [Required]
        public string endDate { get; set; }
        public int? Page { get; set; }
     public IPagedList<CrmCustomerMovListViewModel> CustomerMovList { get; set; }
    }
}