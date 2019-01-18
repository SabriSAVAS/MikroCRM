using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList.Mvc;
using PagedList;

namespace MikroCrm.UI.ViewModel.CatalogModel.Customer
{
    public class CustomerSearchViewModel
    {
        public CustomerSearchViewModel()
        {
            CariKod = "";
            CariUnvan = "";
        }
        public string CariKod { get; set; }
        public string CariUnvan { get; set; }
        public int? Page { get; set; }
        public IPagedList<CustomerListViewModel>  CustomerList { get; set; }
    }
}