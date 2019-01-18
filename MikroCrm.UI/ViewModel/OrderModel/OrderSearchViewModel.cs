using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList.Mvc;
using PagedList;
using System.ComponentModel.DataAnnotations;

namespace MikroCrm.UI.ViewModel.OrderModel
{
    public class OrderSearchViewModel
    {
        public OrderSearchViewModel()
        {
            string sdate = DateTime.Now.Year + "-01-01";

            string edate = DateTime.Now.Year+"-12-31";
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
        public IPagedList<OrderListViewModel> OrderList { get; set; }
    }
}